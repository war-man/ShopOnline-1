using Newtonsoft.Json;
using ShopOnline.Application.Page;
using ShopOnline.Model.ReViewProductModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.ImplementationConnectAPI
{
    public class ReViewProductConnectAPI : IReViewProductConnectAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReViewProductConnectAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> CreatReView(CreatReViewProduct request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/ReViewProduct/CreatReViewProductPaging", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<PagedResult<ReViewProductViewModel>> GetAllReView(PageRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/ReViewProduct/GetAllReViewProductPaging", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<PagedResult<ReViewProductViewModel>>(readpost);
            return product;
        }

        public async Task<List<ReViewProductViewModel>> GetReViewOfProductById(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/ReViewProduct/GetReViewOfProductById", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<ReViewProductViewModel>>(readpost);
            return product;
        }
    }
}
