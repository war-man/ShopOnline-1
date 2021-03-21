using ShopOnline.Application.Page;
using ShopOnline.Model.ReViewProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.InterfaceConnectAPI
{
    public interface IReViewProductConnectAPI
    {
        Task<PagedResult<ReViewProductViewModel>> GetAllReView(PageRequest request);
        Task<bool> CreatReView(CreatReViewProduct request);
        Task<List<ReViewProductViewModel>> GetReViewOfProductById(int Id);
    }
}
