using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Model.ProductCategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategorySerVice _productCategorySerVice;
        public ProductCategoryController(IProductCategorySerVice productCategorySerVice)
        {
            _productCategorySerVice = productCategorySerVice;
        }
        [HttpPost("CreatProductCategory")]
        public async Task<IActionResult> CreatProductCategory(CreatProductCategory request)
        {
            var creat = await  _productCategorySerVice.CreatProductCategoryViewModel(request);
            return Ok();
        }
        [HttpGet("GetAllProductCategory")]
        public async Task<IActionResult> GetAllProductCategory()
        {
            var listproductcategory = await _productCategorySerVice.GetAllProductCategoryViewModel();
            return Ok(listproductcategory);
        }
        [HttpPost("DeleteProductCategory")]
        public async Task<IActionResult> DeleteProductCategory(int Id)
        {
            var delete = await _productCategorySerVice.DeleteProductCategoryViewModel(Id);
            return Ok();
        }    
        [HttpPost("ReOrder")]
        public async Task<IActionResult> ReOrder([FromBody]ProductCategoryUpdateSortOrder request)
        {
            var find = await _productCategorySerVice.ReOrder(request);
            return Ok();
        }    
        [HttpPost("UpdateParentId")]
        public async Task<IActionResult> UpdateParentId([FromBody]ProductCategoryUpdateParentId request)
        {
            var find = await _productCategorySerVice.UpdateParentId(request);
            return Ok(); 
        }
        [HttpPost("FindProductCategory")]
        public async Task<IActionResult> FindProductById([FromBody]int Id)
        {

            var productcategory = await _productCategorySerVice.FindProductById(Id);
            return Ok(productcategory);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var listproductcategoryViewModel = await _productCategorySerVice.GetAll();
            return Ok(listproductcategoryViewModel);
        }
    }
}
