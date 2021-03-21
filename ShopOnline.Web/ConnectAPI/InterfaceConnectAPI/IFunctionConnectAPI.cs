using ShopOnline.Model.FunctionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.InterfaceConnectAPI
{
    public interface IFunctionConnectAPI
    {
        Task<List<FunctionViewModel>> GetAllFunction();
        Task<List<FunctionViewModel>> GetListFunctionParentId();
    }
}
