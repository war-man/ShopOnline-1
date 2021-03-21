using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopOnline.Application.Page;
using ShopOnline.Model.CartModel;
using ShopOnline.Model.ProductModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductConnectAPI _productConnectAPI;
        public CartController(IProductConnectAPI productConnectAPI)
        {
            _productConnectAPI = productConnectAPI;
        }
        public IActionResult Index(string keyword,int pageIndex=1,int pageSize=5)
        {
            var getall = HttpContext.Session.GetString("CartRequest");
            if (getall == null)
            {
                return RedirectToAction("DonFindCart", "Cart");
                
            }
            var listcart = JsonConvert.DeserializeObject<List<CartItem>>(getall);
            var request = new PageRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            };
            var product = from p in listcart
                          select new { p };
            
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                product= product.Where(x => x.p.ProductViewModel.Name.Contains(request.Keyword));
            }
            var total = product.Count();
            var vt = product.Skip((request.PageIndex - 1) * (request.PageSize)).Take(request.PageSize)
                .Select(x => new CartItem() {
                    ProductViewModel = x.p.ProductViewModel,
                    ColorId = x.p.ColorId,
                    SizeId = x.p.SizeId,
                    Quantity = x.p.Quantity
                }).ToList();
            var page = new PagedResult<CartItem>()
            {
                Items=vt,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = total,
            };
            return View(page);
        }
        public async Task<IActionResult> AddCart(int productId,int colorId,int sizeId,int quantity)
        {
            var productViewModel = await _productConnectAPI.FindProductById(productId);
            var getall = HttpContext.Session.GetString("CartRequest");
            if (getall != null)
            {
                var listCartItemAdd = JsonConvert.DeserializeObject<List<CartItem>>(getall);
                if (listCartItemAdd.Exists(x => x.ProductViewModel.Id == productId))
                {
                    foreach(var cartadd in listCartItemAdd)
                    {
                        if (cartadd.ProductViewModel.Id == productId)
                        {
                            if (cartadd.ColorId == colorId && cartadd.SizeId == sizeId)
                            {
                                cartadd.Quantity = cartadd.Quantity + 1;
                            }
                            else
                            {
                                var cartItem1 = new CartItem()
                                {
                                    ProductViewModel = productViewModel,
                                    ColorId = colorId,
                                    Quantity = quantity,
                                    SizeId = sizeId
                                };
                                listCartItemAdd.Add(cartItem1);
                               
                            }
                        }
                       
                        
                    }
                }
                else
                {
                    var cartItem2 = new CartItem()
                    {
                        ProductViewModel = productViewModel,
                        ColorId = colorId,
                        Quantity = quantity,
                        SizeId = sizeId
                    };
                    listCartItemAdd.Add(cartItem2);

                }
                HttpContext.Session.SetString("CartRequest", JsonConvert.SerializeObject(listCartItemAdd));

            }
            else
            {
                var listcartItem = new List<CartItem>();
                var cartitem = new CartItem()
                {
                    ProductViewModel = productViewModel,
                    ColorId = colorId,
                    SizeId = sizeId,
                    Quantity = quantity
                };
                listcartItem.Add(cartitem);
                HttpContext.Session.SetString("CartRequest", JsonConvert.SerializeObject(listcartItem));
            }
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult DonFindCart()
        {
            return View();
        }
    }
}
