using ShopOnline.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface IProductColorSerVice
    {
        Task<List<ProductColorViewModel>> GetAllColor();
        Task<ProductColorViewModel> FindColorById(int Id);
    }
}
