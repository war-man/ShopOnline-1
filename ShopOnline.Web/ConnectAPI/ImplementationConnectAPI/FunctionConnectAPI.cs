using Newtonsoft.Json;
using ShopOnline.Model.FunctionModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.ImplementationConnectAPI
{
    public class FunctionConnectAPI : IFunctionConnectAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FunctionConnectAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<FunctionViewModel>> GetAllFunction()
        {
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.GetAsync("api/Function/GetAllFunction");
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<FunctionViewModel>>(readpost);
            return product;
        }

        public async Task<List<FunctionViewModel>> GetListFunctionParentId()
        {
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.GetAsync("api/Function/GetListFunctionParentId");
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<FunctionViewModel>>(readpost);
            return product;
        }
    }
}
