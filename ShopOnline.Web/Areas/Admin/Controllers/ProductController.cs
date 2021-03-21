using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using ShopOnline.Application.Page;
using ShopOnline.Data.Entity;
using ShopOnline.Model.ProductModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IProductConnectAPI _productConnectAPI;
        public ProductController(IProductConnectAPI productConnectAPI, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _productConnectAPI = productConnectAPI;
        }    
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreatProduct(CreatProduct request)
        {
            var creat = await _productConnectAPI.CreatProduct(request);
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> GetAllWholePriceByProductId(int Id)
        {
            var list = await _productConnectAPI.GetAllWholePriceByProductId(Id);
            return Json(new
            {
                status = true,
                data = list
            });
        }
        public async Task<IActionResult> CreatWholePrice(string Value,int productId)
        {
            var list = JsonConvert.DeserializeObject<List<CreatWholePrice>>(Value);
            var request = new CreatWholePriceViewModel()
            {
                ProductId = productId,
                ListCreat = list
            };
            var creat =  await _productConnectAPI.CreatWholePrice(request);
            return Json(new
            {
                status = true,
            });
        }
        public async Task<IActionResult> GetAllProductPaging(string keyword,int pageIndex,int pageSize)
        {
            var request = new PageRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            };
            var listproductpaging = await _productConnectAPI.GetAllProductPaging(request);
            return new OkObjectResult(listproductpaging);
        }
        public async Task<IActionResult> GetListProductColor()
        {
            var listcolor = await _productConnectAPI.GetAllColor();
            return Json(new
            {
                status = true,
                data = listcolor
            });
        }
        public async Task<IActionResult> GetListProductSize()
        {
            var listsize = await _productConnectAPI.GetAllSize();
            return Json(new
            {
                status = true,
                data = listsize
            });
        }
        public async Task<IActionResult> GetListProductQuantityByProductId(int Id)
        {
            var list = await _productConnectAPI.GetAllProductQuantityByProductId(Id);
            return Json(new
            {
                status = true,
                data = list
            });
        }
        public async Task<IActionResult> CreatProductQuantity(string Value,int productId)
        {
            var listCreat = JsonConvert.DeserializeObject<List<CreatProductQuantity>>(Value);
            var request = new CreatProductQuantityViewModel()
            {
                CreatList = listCreat,
                ProductId = productId,
            };
            var creat = await _productConnectAPI.CreatProductQuantity(request);
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> DeleteWholePrice(int Id)
        {
            var delete =  await _productConnectAPI.DeleteWholePrice(Id);
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var product = await _productConnectAPI.DeleteProduct(Id);
            return Json(new
            {
                status = true
            });
        }
        public IActionResult ImportExcel(IList<IFormFile> files,int categoryId)
        {
            
            if (files != null && files.Count > 0)
            {
                var file = files[0];
                var filename = ContentDispositionHeaderValue
                                   .Parse(file.ContentDisposition)
                                   .FileName
                                   .Trim('"');

                string folder = _hostingEnvironment.WebRootPath + $@"\uploaded\excels";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string filePath = Path.Combine(folder, filename);

                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                var request = new CreatExel()
                {
                    FilePath = filePath,
                    CategoryId = categoryId
                };
                _productConnectAPI.ImportExcel(request);
                return new OkObjectResult(filePath);
            }
            return new NoContentResult();
        }
        
        public async Task<IActionResult> ExportExcel()
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string directory = Path.Combine(sWebRootFolder, "export-files");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string sFileName = $"Product_{DateTime.Now:yyyyMMddhhmmss}.xlsx";
            string fileUrl = $"{Request.Scheme}://{Request.Host}/export-files/{sFileName}";
            FileInfo file = new FileInfo(Path.Combine(directory, sFileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            }
            var listproduct = await _productConnectAPI.GetAllProduct();
            using (ExcelPackage package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Products");
                worksheet.Cells["A1"].LoadFromCollection(listproduct, true, TableStyles.Light1);
                worksheet.Cells.AutoFitColumns();
                package.Save(); //Save the workbook.
            }
            var test = fileUrl;
            return Json(new
            {
                status = true,
                data = test
            });
        }

    }
}
