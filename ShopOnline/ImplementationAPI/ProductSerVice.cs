using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Application.Page;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class ProductSerVice : IProductSerVice
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ProductSerVice(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> CreatProduct(CreatProduct request)
        {
            if(request.Id>0)
            {
                var productUpdate = await _context.Products.FindAsync(request.Id);
                productUpdate.Name = request.Name;
                productUpdate.Price = request.Price;
                productUpdate.LastPrice = request.LastPrice;
                productUpdate.PathImage = request.PathImage;
                productUpdate.ProductCategoryId = request.ProductCategoryId;
                productUpdate.SeoAlias = request.SeoAlias;
                productUpdate.Decripstion = request.Decripstion;
                productUpdate.SeoDescription = request.SeoDescription;
                productUpdate.SeoKeywords = request.SeoKeywords;
                productUpdate.SeoPageTitle = request.SeoPageTitle;
                _context.Products.Update(productUpdate);
                 
            }
            else
            {
                var product = new Product()
                {
                    Name = request.Name,
                    Price = request.Price,
                    LastPrice = request.LastPrice,
                    PathImage = request.PathImage,
                    Decripstion = request.Decripstion,
                    ProductCategoryId = request.ProductCategoryId,
                    SeoAlias = request.SeoAlias,
                    SeoDescription = request.SeoDescription,
                    SeoKeywords = request.SeoKeywords,
                    SeoPageTitle = request.SeoPageTitle,

                };
                _context.Products.Add(product);
                
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreatProductQuantity(CreatProductQuantityViewModel request)
        {
            var listproductquantityRemove = await _context.ProductQuantities.Where(x => x.ProductId == request.ProductId).ToListAsync();
            foreach(var remove in listproductquantityRemove)
            {
                _context.ProductQuantities.Remove(remove);
            }    
            foreach(var product in request.CreatList)
            {
                var productquantity = new ProductQuantity()
                {
                    ProductId = request.ProductId,
                    ProductColorId = product.ProductColorId,
                    ProductSizeId = product.ProductSizeId,
                    Quantity=product.Quantity
                };
                _context.ProductQuantities.Add(productquantity);
               
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreatWholePrice(CreatWholePriceViewModel request)
        {
            var listwholePrice = await _context.WholePrices.Where(x => x.ProductId == request.ProductId).ToListAsync();
            foreach(var remove in listwholePrice)
            {
                _context.WholePrices.Remove(remove);
            }
            
            foreach (var product in request.ListCreat)
            {
                var wolePrice = new WholePrice()
                {
                    ProductId = request.ProductId,
                    FromQuantity = product.FromQuantity,
                    ToQuantity = product.ToQuantity,
                    Price = product.Price
                };
                _context.WholePrices.Add(wolePrice);
                
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProduct(int Id)
        {
            var listproductImage = await _context.ProductImages.Where(x => x.ProductId == Id).ToListAsync();
            foreach(var image in listproductImage)
            {
                _context.ProductImages.Remove(image);
            }    
            var product = await _context.Products.FindAsync(Id);
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteWholePrice(int Id)
        {
            var wholePrice = await _context.WholePrices.FindAsync(Id);
            _context.WholePrices.Remove(wholePrice);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductViewModel> FindProductById(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            var productVM = _mapper.Map<Product, ProductViewModel>(product);
            return productVM;
        }

        public async Task<List<ProductViewModel>> GetAllProduct()
        {
            var listproduct = await _context.Products.ToListAsync();
            var listproductVm = _mapper.Map<List<Product>, List<ProductViewModel>>(listproduct);
            return listproductVm;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllProductPaging(PageRequest request)
        { 
            var listproduct = await _context.Products.ToListAsync();

            var product = from p in listproduct
                          select new { p };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                product = product.Where(x => x.p.Name.Contains(request.Keyword));
            }
            var total = product.Count();
            var vt = product.Skip((request.PageIndex - 1) * (request.PageSize)).Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                      Id=x.p.Id,
                      Name=x.p.Name,
                      Price=x.p.Price,
                      LastPrice=x.p.LastPrice,
                      PathImage=x.p.PathImage,
                      Decripstion=x.p.Decripstion,
                      SeoAlias=x.p.SeoAlias,
                      SeoDescription=x.p.SeoDescription,
                      SeoKeywords=x.p.SeoKeywords,
                      SeoPageTitle=x.p.SeoPageTitle,
                      ProductCategoryId=x.p.ProductCategoryId
                  
                }).ToList();
            var page = new PagedResult<ProductViewModel>()
            {
                Items = vt,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = total
            };
            return page;
        }
        public async Task<List<ProductQuantityViewModel>> GetAllProductQuantityByProductId(int Id)
        {
            var list = await _context.ProductQuantities.Where(x => x.ProductId == Id).ToListAsync();
            var listquantity = _mapper.Map<List<ProductQuantity>, List<ProductQuantityViewModel>>(list);
            return listquantity;
        }

        public async Task<List<ProductViewModel>> GetAllProductSeo(int Id)
        {
            var listproductSeo = await _context.Products.Where(x => x.ProductCategoryId == Id).ToListAsync();
            var listproductSeoViewModel = _mapper.Map<List<Product>, List<ProductViewModel>>(listproductSeo);
            return listproductSeoViewModel;
        }

        public async Task<List<WholePriceViewModel>> GetAllWholePriceByProductId(int Id)
        {
            var listwholePrice = await _context.WholePrices.Where(x => x.ProductId == Id).ToListAsync();
            var listwholePriceViewModel = _mapper.Map<List<WholePrice>, List<WholePriceViewModel>>(listwholePrice);
            return listwholePriceViewModel;
        }

        public void ImportExcel(string filePath,int categoryId)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                Product product;
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    product = new Product();

                    product.Name = workSheet.Cells[i, 1].Value.ToString();
                    decimal.TryParse(workSheet.Cells[i, 2].Value.ToString(), out var price);
                    product.Price = price;

                    decimal.TryParse(workSheet.Cells[i, 3].Value.ToString(), out var lastPrice);
                    product.LastPrice = lastPrice;
                    product.PathImage = workSheet.Cells[i, 4].Value.ToString();
                    product.ProductCategoryId = categoryId;
                    _context.Products.Add(product);
                }
            }
            _context.SaveChanges();
        }

        public async Task<ProductViewModel> ProductDetail(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            var productModel = _mapper.Map<Product, ProductViewModel>(product);
            return productModel;
        }
    }
}
