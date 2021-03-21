using Microsoft.AspNetCore.Mvc;
using ShopOnline.Model.SlideModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlideController : Controller
    {
        private readonly ISlideConnectAPI _slideConnectAPI;
        public SlideController(ISlideConnectAPI slideConnectAPI)
        {
            _slideConnectAPI = slideConnectAPI;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllSlide()
        {
            var list = await _slideConnectAPI.GetAllSlide();
            return Json(new
            {
                status = true,
                data = list
            });
        }
        public async Task<IActionResult> CreatSlide(CreatSlide request)
        {
            var creat = await _slideConnectAPI.CreatSlide(request);
            return Json(new
            {
                status = true
            });
        }
    }
}
