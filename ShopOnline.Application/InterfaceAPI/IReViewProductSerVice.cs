using ShopOnline.Application.Page;
using ShopOnline.Model.ReViewProductModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface IReViewProductSerVice
    {
        Task<PagedResult<ReViewProductViewModel>> GetAllReView(PageRequest request);
        Task<int> CreatReView(CreatReViewProduct request);
        Task<List<ReViewProductViewModel>> GetReViewOfProductById(int Id);
    }
}
