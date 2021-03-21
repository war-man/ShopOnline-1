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
    public class ProductColorSerVice : IProductColorSerVice
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ProductColorSerVice(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ProductColorViewModel> FindColorById(int Id)
        {
            var color = await _context.ProductColors.FindAsync(Id);
            var productColorViewModel = _mapper.Map<ProductColor, ProductColorViewModel>(color);
            return productColorViewModel;
            
        }
        public async Task<List<ProductColorViewModel>> GetAllColor()
        { 
            var listcolor = await _context.ProductColors.ToListAsync();
            var listColorViewModel = _mapper.Map<List<ProductColor>, List<ProductColorViewModel>>(listcolor);
            return listColorViewModel;
        }
    }
}
