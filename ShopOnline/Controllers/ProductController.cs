using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Application.Page;
using ShopOnline.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductSizeSerVice _productSizeSerVice;
        private readonly IProductColorSerVice _productColorSerVice;
        private readonly IProductSerVice _productSerVice;
        public ProductController(IProductSerVice productSerVice, IProductColorSerVice productColorSerVice, IProductSizeSerVice productSizeSerVice)
        {
            _productSizeSerVice = productSizeSerVice;
            _productColorSerVice = productColorSerVice;
            _productSerVice = productSerVice;
        }    
        [HttpPost("GetAllProductPaging")]
        public async Task<IActionResult> GetAllProductPaging(PageRequest request)
        {
            var listproduct = await _productSerVice.GetAllProductPaging(request);
            return Ok(listproduct);
        } 
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var listproduct = await _productSerVice.GetAllProduct();
            return Ok(listproduct);
        }
        [HttpPost("CreatProduct")]
        public async Task<IActionResult> CreatProduct(CreatProduct request)
        {
            var creat = await _productSerVice.CreatProduct(request);
            return Ok();
        }
        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody]int Id)
        {
            var delete = await _productSerVice.DeleteProduct(Id);
            return Ok();
        }
        [HttpPost("FindProductById")]
        public async Task<IActionResult> FindProductById(int Id)
        {
            var product = await _productSerVice.FindProductById(Id);
            return Ok(product);
        }
        [HttpPost("FindColorById")]
        public async Task<IActionResult> FindColorById([FromBody]int Id)
        {
            var color = await _productColorSerVice.FindColorById(Id);
            return Ok(color);
        }
        [HttpGet("GetAllColor")]
        public async Task<IActionResult> GetAllColor()
        {
            var listcolor = await _productColorSerVice.GetAllColor();
            return Ok(listcolor);
        }
        [HttpGet("GetAllSize")]
        public async Task<IActionResult> GetAllSize()
        {
            var listsize = await _productSizeSerVice.GetAllSize();
            return Ok(listsize);
        }
        [HttpPost("FindSizeById")]
        public async Task<IActionResult> FindSizeById([FromBody]int Id)
        {
            var size = await _productSizeSerVice.FindProductSizeById(Id);
            return Ok(size);
        }
        [HttpPost("GetAllProductQuantityByProductId")]
        public async Task<IActionResult> GetAllProductQuantityByProductId([FromBody]int Id)
        {
            var list = await _productSerVice.GetAllProductQuantityByProductId(Id);
            return Ok(list);
        }
        [HttpPost("CreatProductQuantity")]
        public async Task<IActionResult> CreatProductQuantity([FromBody]CreatProductQuantityViewModel request)
        {
            var creat = await _productSerVice.CreatProductQuantity(request);
            return Ok();
        }
        [HttpPost("GetAllWholePriceByProductId")]
        public async Task<IActionResult> GetAllWholePriceByProductId([FromBody]int Id)
        {
            var listwholePriceViewModel = await _productSerVice.GetAllWholePriceByProductId(Id);
            return Ok(listwholePriceViewModel);
        }
        [HttpPost("CreatWholePrice")]
        public async Task<IActionResult> CreatWholePrice([FromBody]CreatWholePriceViewModel request)
        {
            var creat = await _productSerVice.CreatWholePrice(request);
            return Ok();
        }
        [HttpPost("DeleteWholePrice")]
        public async Task<IActionResult> DeleteWholePrice([FromBody]int Id)
        {
            var delete = await _productSerVice.DeleteWholePrice(Id);
            return Ok();
        }
        [HttpPost("ImportEx")]
        public IActionResult ImportExcel([FromBody]CreatExel request)
        {
             _productSerVice.ImportExcel(request.FilePath,request.CategoryId);
            return Ok();
        }
        [HttpPost("ProductDetail")]
        public async Task<IActionResult> ProductDetail([FromBody]int Id)
        {
            var product = await _productSerVice.ProductDetail(Id);
            return Ok(product);
        }
        [HttpPost("ProductSeo")]
        public async Task<IActionResult> GetAllProductSeo([FromBody]int Id)
        {
            var listproductseo = await _productSerVice.GetAllProductSeo(Id);
            return Ok(listproductseo);
        }
    }
}
