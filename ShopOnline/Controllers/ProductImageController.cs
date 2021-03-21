using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Model.ProductImageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageSerVice _productImageSerVice;
        public ProductImageController(IProductImageSerVice productImageSerVice)
        {
            _productImageSerVice = productImageSerVice;
        }    
        [HttpPost("CreatProductImage")]
        public async Task<IActionResult> CreatProductImage([FromBody]CreatProductImage request)
        {
            var creat = await _productImageSerVice.CreatProductImage(request.ProductId, request.Images);
            return Ok();
        }    
        [HttpGet("GetAllProductImage")]
        public async Task<IActionResult> GetAllProductImage()
        {
            var listproductimageSerVice = await _productImageSerVice.GetAllProductImage();
            return Ok(listproductimageSerVice);
        }
        [HttpPost("GetListProductImageByProductId")]
        public async Task<IActionResult> GetListProductImageByProductId([FromBody]int Id)
        {
            var listproductImage = await _productImageSerVice.GetListProductImageByProductId(Id);
            return Ok(listproductImage);
        }
        [HttpPost("DeleteProductImage")]
        public async Task<IActionResult> DeleteProductImage([FromBody]int Id)
        {
            var productimage = await _productImageSerVice.DeleteProductImage(Id);
            return Ok(productimage);
        }
    }
}
