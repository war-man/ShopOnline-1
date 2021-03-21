using Newtonsoft.Json;
using ShopOnline.Application.Page;
using ShopOnline.Model.UserModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.ImplementationConnectAPI
{
    public class UserConnectAPI : IUserConnectAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserConnectAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> Authentication(AuthenticationRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/User/Authentication", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
          
            return readpost;
        }

        public  async Task<bool> DeleteUser(string UserId)
        {
            var json = JsonConvert.SerializeObject(UserId);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/User/DeleteUser", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserByUserName(string UserName)
        {
            var json = JsonConvert.SerializeObject(UserName);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/User/DeleteUserByUserName", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<UserViewModel> FindUserById(string UserId)
        {
            var json = JsonConvert.SerializeObject(UserId);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/User/FindUserById", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<UserViewModel>(readpost);
            return product;
        }

        public async Task<UserViewModel> FindUserByName(string UserName)
        {
            var json = JsonConvert.SerializeObject(UserName);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/User/FindUserByName", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<UserViewModel>(readpost);
            return product;
        }

        public async Task<List<UserViewModel>> GetAllUser()
        {
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.GetAsync("api/User/GetAllUser");
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<UserViewModel>>(readpost);
            return product;
        }

        public async Task<PagedResult<UserViewModel>> GetAllUserPaging(PageRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/User/GetAllUserPaging", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<PagedResult<UserViewModel>>(readpost);
            return product;
        }

        public async Task<IList<string>> GetListRoleOfUserByUserName(string UserName)
        {
            var json = JsonConvert.SerializeObject(UserName);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/User/GetListRoleOfUserByUserName", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<IList<string>>(readpost);
            return product;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/User/Register", jsonstring);

            return post.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateUser(UpdateUser request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/User/UpdateUser", jsonstring);
            return post.IsSuccessStatusCode;
        }
    }
}
