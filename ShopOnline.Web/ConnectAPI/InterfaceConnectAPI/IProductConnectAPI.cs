using ShopOnline.Application.Page;
using ShopOnline.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.InterfaceConnectAPI
{
    public interface IProductConnectAPI
    {
        Task<List<ProductQuantityViewModel>> GetAllProductQuantityByProductId(int Id);
        Task<bool> CreatProductQuantity(CreatProductQuantityViewModel request);
        Task<List<ProductColorViewModel>> GetAllColor();
        Task<ProductColorViewModel> FindColorById(int Id);
        Task<List<ProductSizeViewModel>> GetAllSize();
        Task<ProductSizeViewModel> FindProductSizeById(int Id);
        Task<bool> CreatProduct(CreatProduct request);
        Task<PagedResult<ProductViewModel>> GetAllProductPaging(PageRequest request);
        Task<List<ProductViewModel>> GetAllProduct();
        Task<ProductViewModel> FindProductById(int Id);

        Task<bool> DeleteProduct(int Id);
        Task<List<WholePriceViewModel>> GetAllWholePriceByProductId(int Id);
        Task<bool> CreatWholePrice(CreatWholePriceViewModel request);
        Task<bool> DeleteWholePrice(int Id);
        void ImportExcel(CreatExel request);
        Task<ProductViewModel> ProductDetail(int Id);
        Task<List<ProductViewModel>> ProductSeo(int Id);
    }
}
