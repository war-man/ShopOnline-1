using Microsoft.AspNetCore.Mvc;
using ShopOnline.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Controllers
{
    public class ChatRealTimeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ChatRealTimeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
