using Microsoft.AspNetCore.Mvc;
using ShopOnline.Model.ReViewProductModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Controllers
{
    public class ReViewProductController : Controller
    {
        private readonly IUserConnectAPI _userConnectAPI;
        private readonly IReViewProductConnectAPI _reViewProductConnectAPI;
        public ReViewProductController(IReViewProductConnectAPI reViewProductConnectAPI, IUserConnectAPI userConnectAPI)
        {
            _userConnectAPI = userConnectAPI;
            _reViewProductConnectAPI = reViewProductConnectAPI;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreatReViewProduct(string review,string phone,string email,int productId,int quantity)
        {
            var user = User.Identity.Name;
            var username = await _userConnectAPI.FindUserByName(user);

            var request = new CreatReViewProduct()
            {
                UserName = user,
                PhoneNumberUser = username.PhoneNumber,
                EmailUser = username.Email,
                ProductId = productId,
                Quantity = quantity,
                DateCreated = DateTime.Now,
                Review = review
            };
            var creat = await _reViewProductConnectAPI.CreatReView(request);
            return RedirectToAction("Product","ProductDetail",new {Id=productId});
        }
       
    }
}
