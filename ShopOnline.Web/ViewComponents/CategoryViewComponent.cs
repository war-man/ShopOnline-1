using Microsoft.AspNetCore.Mvc;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly IProductCategoryConnectAPI _productCategoryConnectAPI;
        public CategoryViewComponent(IProductCategoryConnectAPI productCategoryConnectAPI)
        {
            _productCategoryConnectAPI = productCategoryConnectAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listproductcategory = await _productCategoryConnectAPI.GetAllProductCategory();
            return View(listproductcategory);
        }
    }
}
