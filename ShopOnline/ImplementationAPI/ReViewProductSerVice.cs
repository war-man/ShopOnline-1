using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Application.Page;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.ReViewProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class ReViewProductSerVice : IReViewProductSerVice
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ReViewProductSerVice(ApplicationDbContext context , IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<int> CreatReView(CreatReViewProduct request)
        {
            var creat = new ReviewProduct()
            {

                UserName = request.UserName,
                PhoneNumberUser = request.PhoneNumberUser,
                EmailUser = request.EmailUser,
                DateCreated = DateTime.Now,
                Review = request.Review,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
            };
            _context.ReviewProducts.Add(creat);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ReViewProductViewModel>> GetAllReView(PageRequest request)
        {
            var listReview = await _context.ReviewProducts.ToListAsync();
            var product = from p in listReview
                          select new { p };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                product = product.Where(x => x.p.UserName.Contains(request.Keyword));
            }
            var total = product.Count();
            var vt = product.Skip((request.PageIndex - 1) * (request.PageSize)).Take(request.PageSize)
                .Select(x => new ReViewProductViewModel()
                {
                     Id=x.p.Id,
                     UserName=x.p.UserName,
                     PhoneNumberUser=x.p.PhoneNumberUser,
                     EmailUser=x.p.EmailUser,
                     DateCreated= x.p.DateCreated,
                     Review=x.p.Review,
                     ProductId=x.p.ProductId,
                     Quantity=x.p.Quantity
                }).ToList();
            var page = new PagedResult<ReViewProductViewModel>()
            {
                Items = vt,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = total
            };
            return page;
        }
        public async Task<List<ReViewProductViewModel>> GetReViewOfProductById(int Id)
        {
            var listReview = await _context.ReviewProducts.Where(x => x.ProductId == Id).ToListAsync();
            var listReViewProductViewModel = _mapper.Map<List<ReviewProduct>, List<ReViewProductViewModel>>(listReview);
            return listReViewProductViewModel;
        }
    }
}
