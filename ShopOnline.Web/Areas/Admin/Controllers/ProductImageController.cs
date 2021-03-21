using Microsoft.AspNetCore.Mvc;
using ShopOnline.Model.ProductImageModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageConnectAPI _productImageConnectAPI;
        public ProductImageController(IProductImageConnectAPI productImageConnectAPI)
        {
            _productImageConnectAPI = productImageConnectAPI;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllProductImage()
        {
            var listproductImage = await _productImageConnectAPI.GetAllProductImage();
            return Json(new
            {
                status = true,
                data=listproductImage
            });
        }
        public async Task<IActionResult> CreatProductImage(CreatProductImage request)
        {
            var creat = await _productImageConnectAPI.CreatProductImage(request);
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> GetListProductImageByProductId(int Id)
        {
            var listImage = await _productImageConnectAPI.GetListProductImageByProductId(Id);
            return Json(new
            {
                status = true,
                data = listImage
            });
        }
        public async Task<IActionResult> DeleteProductImage(int Id)
        {
            var delete = await _productImageConnectAPI.DeleteProductImage(Id);
            return Json(new
            {
                status = true
            });
        }
    }
}
