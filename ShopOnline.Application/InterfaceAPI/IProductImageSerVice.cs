using ShopOnline.Model.ProductImageModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface IProductImageSerVice
    {
        Task<List<ProductImageViewModel>> GetAllProductImage();
        Task<int> CreatProductImage (int productId, string[] images);
        Task<List<ProductImageViewModel>> GetListProductImageByProductId(int Id);
        Task<int> DeleteProductImage(int Id);

    }
}
