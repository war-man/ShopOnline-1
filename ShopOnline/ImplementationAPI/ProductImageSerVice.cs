using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.ProductImageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class ProductImageSerVice : IProductImageSerVice
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ProductImageSerVice(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public  async Task<int> CreatProductImage(int productId,string[] images)
        {
            var listproductImage  = await _context.ProductImages.Where(x => x.ProductId == productId).ToListAsync();
            foreach (var image in listproductImage)
            {
                _context.ProductImages.Remove(image);
            }

            foreach (var image in images)
            {
                _context.ProductImages.Add(new ProductImage()
                {
                    Name = "Image",
                    PathImage = image,
                    ProductId = productId,
                });
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProductImage(int Id)
        {
            var productimage = await _context.ProductImages.FindAsync(Id);
            _context.ProductImages.Remove(productimage);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductImageViewModel>> GetAllProductImage()
        {
            var listprodutImage = await _context.ProductImages.ToListAsync();
            var listproductImageViewModel = _mapper.Map<List<ProductImage>, List<ProductImageViewModel>>(listprodutImage);
            return listproductImageViewModel;
        }

        public async Task<List<ProductImageViewModel>> GetListProductImageByProductId(int Id)
        {
            var productImage = await _context.ProductImages.Where(x => x.ProductId == Id).ToListAsync();
            var listproductImageViewModel = _mapper.Map<List<ProductImage>, List<ProductImageViewModel>>(productImage);
            return listproductImageViewModel;
        }
    }
}
