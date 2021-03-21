using ShopOnline.Application.Page;
using ShopOnline.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface IProductSerVice
    {
        Task<int> CreatProduct(CreatProduct request);
        Task<PagedResult<ProductViewModel>> GetAllProductPaging(PageRequest request);
        Task<List<ProductViewModel>> GetAllProduct();
        Task<ProductViewModel> FindProductById(int Id);
        Task<int> DeleteProduct(int Id);
        Task<List<ProductQuantityViewModel>> GetAllProductQuantityByProductId(int Id);
        Task<int> CreatProductQuantity(CreatProductQuantityViewModel request);
        Task<List<WholePriceViewModel>> GetAllWholePriceByProductId(int Id);
        Task<int> CreatWholePrice(CreatWholePriceViewModel request);
        Task<int> DeleteWholePrice(int Id);
        void ImportExcel(string filePath,int categoryId);
        Task<ProductViewModel> ProductDetail(int Id);
        Task<List<ProductViewModel>> GetAllProductSeo(int Id);
    }
}
