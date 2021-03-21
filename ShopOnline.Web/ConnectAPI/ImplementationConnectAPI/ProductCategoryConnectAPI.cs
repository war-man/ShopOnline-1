using Newtonsoft.Json;
using ShopOnline.Model.ProductCategoryModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.ImplementationConnectAPI
{
    public class ProductCategoryConnectAPI : IProductCategoryConnectAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductCategoryConnectAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }    
        public async Task<bool> CreatProductCategory(CreatProductCategory request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/ProductCategory/CreatProductCategory", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductCategory(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/ProductCategory/DeleteProductCategory", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<ProductCategoryViewModel> FindProductById(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/ProductCategory/FindProductCategory", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductCategoryViewModel>(readpost);
            return product;
        }

        public async Task<List<ProductCategoryViewModel>> GetAll()
        {
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.GetAsync("api/ProductCategory/GetAll");
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<ProductCategoryViewModel>>(readpost);
            return product;
        }

        public async Task<List<ProductCategoryViewModel>> GetAllProductCategory()
        {
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.GetAsync("api/ProductCategory/GetAllProductCategory");
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<ProductCategoryViewModel>>(readpost);
            return product;
        }

        public  async Task<bool> ReOrder(ProductCategoryUpdateSortOrder request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/ProductCategory/ReOrder", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateParentId(ProductCategoryUpdateParentId request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/ProductCategory/UpdateParentId", jsonstring);
            return post.IsSuccessStatusCode;
        }
    }
}
