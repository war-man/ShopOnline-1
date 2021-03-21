using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class ProductSizeSerVice : IProductSizeSerVice
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ProductSizeSerVice(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ProductSizeViewModel> FindProductSizeById(int Id)
        {
            var productsize = await _context.ProductSizes.FindAsync(Id);
            var productSizeViewModel = _mapper.Map<ProductSize, ProductSizeViewModel>(productsize);
            return productSizeViewModel;
        }

        public async Task<List<ProductSizeViewModel>> GetAllSize()
        {
            var listproductsize = await _context.ProductSizes.ToListAsync();
            var listproductSizeViewModel = _mapper.Map<List<ProductSize>, List<ProductSizeViewModel>>(listproductsize);
            return listproductSizeViewModel;
        }
    }
}
