using ShopOnline.Model.FunctionModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface IFunctionSerVice
    {
        Task<List<FunctionViewModel>> GetAllFunction();
        Task<List<FunctionViewModel>> GetListFunctionParentId();
    }
}
