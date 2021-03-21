using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.FunctionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class FunctionSerVice : IFunctionSerVice
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public FunctionSerVice(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<FunctionViewModel>> GetAllFunction()
        {
            var listfunction = await _context.Functions.ToListAsync();
            var listfunctionVM = _mapper.Map<List<Function>, List<FunctionViewModel>>(listfunction);
            return listfunctionVM;
        }

        public async Task<List<FunctionViewModel>> GetListFunctionParentId()
        {
            var listfunction = await _context.Functions.OrderBy(x => x.ParentId).ToListAsync();
            var listfunctionVM = _mapper.Map<List<Function>, List<FunctionViewModel>>(listfunction);
            return listfunctionVM;
        }
    }
}
