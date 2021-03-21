using ShopOnline.Model.ProductCategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.InterfaceConnectAPI
{
    public interface IProductCategoryConnectAPI
    {
        Task<List<ProductCategoryViewModel>> GetAllProductCategory();
        Task<bool> CreatProductCategory(CreatProductCategory request);
        Task<bool> DeleteProductCategory(int Id);
        Task<bool> ReOrder(ProductCategoryUpdateSortOrder request);
        Task<bool> UpdateParentId(ProductCategoryUpdateParentId request);
        Task<ProductCategoryViewModel> FindProductById(int Id);
        Task<List<ProductCategoryViewModel>> GetAll();

    }
}
