
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Application.Page;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class PageSerVice : IPageSerVice
    {
        private readonly ApplicationDbContext _context;
        public PageSerVice(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreatPage(CreatPage request)
        {
            if (request.Id > 0)
            {
                var pageupdate = await _context.Pages.FindAsync(request.Id);
                pageupdate.Alias = request.Alias;
                pageupdate.Decripstion = request.Decripstion;
                _context.Pages.Update(pageupdate);
            }
            var page = new Page()
            {
                Alias = request.Alias,
                Decripstion = request.Decripstion
            };
            _context.Pages.Add(page);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<PageViewModel>> GetAllPagePaging(PageRequest request)
        {
            var listproduct = await _context.Pages.ToListAsync();

            var product = from p in listproduct
                          select new { p };
           
            var total = product.Count();
            var vt = product.Skip((request.PageIndex - 1) * (request.PageSize)).Take(request.PageSize)
                .Select(x => new PageViewModel()
                {
                     Id=x.p.Id,
                     Alias=x.p.Alias,
                     Decripstion=x.p.Decripstion

                }).ToList();
            var page = new PagedResult<PageViewModel>()
            {
                Items = vt,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = total
            };
            return page;
        }
    }
}
