using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Application.Page;
using ShopOnline.Model.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IPageSerVice _pageSerVice;
        public PageController(IPageSerVice pageSerVice)
        {
            _pageSerVice = pageSerVice;
        }
        [HttpPost("GetAllPagePaging")]
        public async Task<IActionResult> GetAllPagePaging(PageRequest request)
        {
            var list = await _pageSerVice.GetAllPagePaging(request);
            return Ok(list);
        }
        [HttpPost("CreatPage")]
        public async Task<IActionResult> CreatPage(CreatPage request)
        {
            var creat = await _pageSerVice.CreatPage(request);
            return Ok();
        }
    }
}
