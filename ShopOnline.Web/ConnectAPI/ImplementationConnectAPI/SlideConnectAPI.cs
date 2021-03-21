using Newtonsoft.Json;
using ShopOnline.Model.SlideModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.ImplementationConnectAPI
{
    public class SlideConnectAPI : ISlideConnectAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SlideConnectAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> CreatSlide(CreatSlide request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.PostAsync("api/Slide/CreatSlide", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<List<SlideViewModel>> GetAllSlide()
        {
           
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri("https://localhost:44318");
            var post = await creat.GetAsync("api/Slide/GetAllSlide");
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<SlideViewModel>>(readpost);
            return product;
        }
    }
}
