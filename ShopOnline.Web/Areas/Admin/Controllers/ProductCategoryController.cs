using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Data;
using ShopOnline.Model.ProductCategoryModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductCategoryConnectAPI _productCategoryConnectAPI;
        public ProductCategoryController(IProductCategoryConnectAPI productCategoryConnectAPI, ApplicationDbContext context)
        {
            _context = context;
            _productCategoryConnectAPI = productCategoryConnectAPI;
        }    
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            var list = await _productCategoryConnectAPI.GetAll();
            return Json(new
            {
                status = true,
                data = list
            });
        }
        public async Task<IActionResult> GetAllProductCategory()
        {
            var listproductcategory = await _productCategoryConnectAPI.GetAllProductCategory();
            return Json(new
            {
                status = true,
                data = listproductcategory
            });
        }
        public async Task<IActionResult> FindProductCategory(int Id)
        {
            var product = await _productCategoryConnectAPI.FindProductById(Id);
            return Json(new
            {
                status = true,
                data = product
            });
        }    
        public  async Task<IActionResult> CreatProductCategory(CreatProductCategory request)
        {
            var creat = await _productCategoryConnectAPI.CreatProductCategory(request);
            return Json(new
            {
                status = true
            });
        }    
        public async Task<IActionResult> ReOrder(int sourceId, int targetId)
        {
            var request = new ProductCategoryUpdateSortOrder()
            {
                SourceId = sourceId,
                TargetId = targetId
            };
           var find = await _productCategoryConnectAPI.ReOrder(request);
            return Json(new
            {
                status = true
            });
           
        }
        public async Task<IActionResult> UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            var sourceCategory = await _context.ProductCategories.FindAsync(sourceId);
            sourceCategory.ParentId = targetId;
            _context.ProductCategories.Update(sourceCategory);

            //Get all sibling
            var key = items.Select(n => n.Key).FirstOrDefault();

            var sibling = await _context.ProductCategories.Where(x => x.Id == key).ToListAsync();
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _context.ProductCategories.Update(child);
            }
           await _context.SaveChangesAsync();
            return Json(new
            {
                status = true
            });
        }


    }
}
