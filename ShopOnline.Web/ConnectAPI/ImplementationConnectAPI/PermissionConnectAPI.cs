using Newtonsoft.Json;
using ShopOnline.Model.PermissionModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.ImplementationConnectAPI
{
    public class PermissionConnectAPI : IPermissionConnectAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PermissionConnectAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreatPermission(CreatPermissionViewModel request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/Permission/CreatPermission", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<List<PermissionViewModel>> GetAllPermission()
        {
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.GetAsync("api/Permission/GetAllPermission");
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<PermissionViewModel>>(readpost);
            return product;
        }

        public async Task<List<PermissionViewModel>> GetListPermissionFromRole(string RoleName)
        {
            var json = JsonConvert.SerializeObject(RoleName);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/Permission/GetPermissionFromRole",jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<PermissionViewModel>>(readpost);
            return product;
        }
    }
}
