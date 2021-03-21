using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Model.SlideModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        private readonly ISlideSerVice _slideSerVice;
        public SlideController(ISlideSerVice slideSerVice)
        {
            _slideSerVice = slideSerVice;
        }
        [HttpGet("GetAllSlide")]
        public async Task<IActionResult> GetAllSlide()
        {
            var listslide = await _slideSerVice.GetAllSlide();
            return Ok(listslide);
        }
        [HttpPost("CreatSlide")]
        public  async Task<IActionResult> CreatSlide(CreatSlide request)
        {
            var create = await _slideSerVice.CreatSlide(request);
            return Ok();
        }
    }
}
