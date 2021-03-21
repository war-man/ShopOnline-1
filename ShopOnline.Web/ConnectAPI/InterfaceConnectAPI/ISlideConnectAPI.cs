using ShopOnline.Model.SlideModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.InterfaceConnectAPI
{
    public interface ISlideConnectAPI
    {
        Task<List<SlideViewModel>> GetAllSlide();
        Task<bool> CreatSlide(CreatSlide request);
    }
}
