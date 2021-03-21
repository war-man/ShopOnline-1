using ShopOnline.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface IProductSizeSerVice
    {
        Task<List<ProductSizeViewModel>> GetAllSize();
        Task<ProductSizeViewModel> FindProductSizeById(int Id);
    }
}
