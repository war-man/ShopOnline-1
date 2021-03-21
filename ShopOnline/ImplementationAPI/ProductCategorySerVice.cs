using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.ProductCategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class ProductCategorySerVice : IProductCategorySerVice
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ProductCategorySerVice(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<int> CreatProductCategoryViewModel(CreatProductCategory request)
        {
             
            
            if(request.Id>=0)
            {
                
                var productcategoryUpdate = await _context.ProductCategories.FindAsync(request.Id);
                
                productcategoryUpdate.Name = request.Name;
                productcategoryUpdate.Decripstion = request.Decripstion;
                if (request.ParentId == 0)
                {
                    productcategoryUpdate.ParentId = null;
                }
                else
                {
                    productcategoryUpdate.ParentId = request.ParentId;
                }
               
                productcategoryUpdate.PathImage = request.PathImage;
                productcategoryUpdate.SortOrder = request.SortOrder;
                productcategoryUpdate.SeoAlias = request.SeoAlias;
                productcategoryUpdate.SeoDescription = request.SeoDescription;
                productcategoryUpdate.SeoKeywords = request.SeoKeywords;
                productcategoryUpdate.SeoPageTitle = request.SeoPageTitle;
                
                
                _context.ProductCategories.Update(productcategoryUpdate);

            }
            else
            {
                var productcategory = new ProductCategory()
                {
                    Name = request.Name,
                    Decripstion = request.Decripstion,
                    ParentId = request.ParentId,
                    PathImage = request.PathImage,
                    SortOrder = request.SortOrder,
                    SeoAlias = request.SeoAlias,
                    SeoDescription = request.SeoDescription,
                    SeoKeywords = request.SeoKeywords,
                    SeoPageTitle = request.SeoPageTitle
                };
                _context.ProductCategories.Add(productcategory);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProductCategoryViewModel(int Id)
        {
            var productcategoryDelete = await _context.ProductCategories.FindAsync(Id);
            _context.ProductCategories.Remove(productcategoryDelete);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductCategoryViewModel> FindProductById(int Id)
        {
            var product = await _context.ProductCategories.FindAsync(Id);
            var productViewModel = _mapper.Map<ProductCategory, ProductCategoryViewModel>(product);
            return productViewModel;
        }

        public async Task<List<ProductCategoryViewModel>> GetAll()
        {
            var listproductcategory = await _context.ProductCategories.ToListAsync();
            var listproductCategoryViewmodel = _mapper.Map<List<ProductCategory>, List<ProductCategoryViewModel>>(listproductcategory);
            return listproductCategoryViewmodel;
        }

        public async Task<List<ProductCategoryViewModel>> GetAllProductCategoryViewModel()
        {
            var listproductcategory = await _context.ProductCategories.OrderBy(x => x.ParentId).ToListAsync();
            var listproductcategoryViewModel = _mapper.Map<List<ProductCategory>, List<ProductCategoryViewModel>>(listproductcategory);
            return listproductcategoryViewModel;
        }

        public async Task<int> ReOrder(ProductCategoryUpdateSortOrder request)
        {
            var source = await _context.ProductCategories.FindAsync(request.SourceId);
            var target = await _context.ProductCategories.FindAsync(request.TargetId);
            int tempOrder = source.SortOrder;
            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _context.ProductCategories.Update(source);
            _context.ProductCategories.Update(target);
            return  await _context.SaveChangesAsync();
              
        }

        public async Task<int> UpdateParentId(ProductCategoryUpdateParentId request)
        {
            var sourceCategory = await _context.ProductCategories.FindAsync(request.SourceId);
            sourceCategory.ParentId = request.TargetId;
            _context.ProductCategories.Update(sourceCategory);

            //Get all sibling
            var key = request.Items.Select(n => n.Key).FirstOrDefault();

            var sibling = _context.ProductCategories.Where(x => x.Id == key).ToList();
            foreach (var child in sibling)
            {
                child.SortOrder = request.Items[child.Id];
                _context.ProductCategories.Update(child);
            }
           return  await _context.SaveChangesAsync(); 
        }
    }
}
