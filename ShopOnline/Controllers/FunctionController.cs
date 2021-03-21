using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.InterfaceAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionSerVice _functionSerVice;
        public FunctionController(IFunctionSerVice functionSerVice)
        {
            _functionSerVice = functionSerVice;
        }    
        [HttpGet("GetAllFunction")]
        public async Task<IActionResult> GetAllFunction()
        {
            var listfunction = await _functionSerVice.GetAllFunction();
            return Ok(listfunction);
        }
        [HttpGet("GetListFunctionParentId")]
        public async Task<IActionResult> GetListFunctionParentId()
        {
            var listfunction = await _functionSerVice.GetListFunctionParentId();
            return Ok(listfunction);
        }
    }
}
