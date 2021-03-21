using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Application.Page;
using ShopOnline.Model.ReViewProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReViewProductController : ControllerBase
    {
        private readonly IReViewProductSerVice _reViewProductSerVice;
        public ReViewProductController(IReViewProductSerVice reViewProductSerVice)
        {
            _reViewProductSerVice = reViewProductSerVice;
        }
        [HttpPost("GetAllReViewProductPaging")]
        public async Task<IActionResult> GetAllProductPaging([FromBody]PageRequest request)
        {
            var list = await _reViewProductSerVice.GetAllReView(request);
            return Ok(list);
        }
        [HttpPost("CreatReViewProductPaging")]
        public async Task<IActionResult> CreatReViewProduct([FromBody]CreatReViewProduct request)
        {
            var creat = await _reViewProductSerVice.CreatReView(request);
            return Ok();
        } 
        [HttpPost("GetReViewOfProductById")]
        public async Task<IActionResult> GetReViewOfProductById([FromBody]int Id)
        {
            var list = await _reViewProductSerVice.GetReViewOfProductById(Id);
            return Ok(list);
        }
    }
}
