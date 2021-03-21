using Microsoft.AspNetCore.Mvc;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.ViewComponents
{
    public class SileBarViewComponent:ViewComponent
    {
        private readonly IFunctionConnectAPI _functionConnectAPI;
        public SileBarViewComponent(IFunctionConnectAPI functionConnectAPI)
        {
            _functionConnectAPI = functionConnectAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listfunction = await _functionConnectAPI.GetListFunctionParentId();
            return View(listfunction);
        }
    }
}
