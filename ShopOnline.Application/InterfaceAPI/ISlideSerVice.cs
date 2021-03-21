using ShopOnline.Model.SlideModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface ISlideSerVice
    {
        Task<List<SlideViewModel>> GetAllSlide();
        Task<int> CreatSlide(CreatSlide request);
    }
}
