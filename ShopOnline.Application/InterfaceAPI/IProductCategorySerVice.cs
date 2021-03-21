using ShopOnline.Model.ProductCategoryModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface IProductCategorySerVice
    {
        Task<List<ProductCategoryViewModel>> GetAllProductCategoryViewModel();
        Task<int> CreatProductCategoryViewModel(CreatProductCategory request);
        Task<int> DeleteProductCategoryViewModel(int Id);
        Task<int> ReOrder(ProductCategoryUpdateSortOrder request);
        Task<int> UpdateParentId(ProductCategoryUpdateParentId request);
        Task<ProductCategoryViewModel> FindProductById(int Id);
        Task<List<ProductCategoryViewModel>> GetAll();

    }
}
