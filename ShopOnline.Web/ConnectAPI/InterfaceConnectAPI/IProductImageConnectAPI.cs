using ShopOnline.Model.ProductImageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.InterfaceConnectAPI
{
    public interface IProductImageConnectAPI
    {
        Task<List<ProductImageViewModel>> GetAllProductImage();
        Task<bool> CreatProductImage(CreatProductImage request);
        Task<List<ProductImageViewModel>> GetListProductImageByProductId(int Id);
        Task<bool> DeleteProductImage(int Id);
    }
}
