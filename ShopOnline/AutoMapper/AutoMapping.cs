using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ShopOnline.Data.Entity;
using ShopOnline.Model.FunctionModel;
using ShopOnline.Model.PermissionModel;
using ShopOnline.Model.ProductCategoryModel;
using ShopOnline.Model.ProductImageModel;
using ShopOnline.Model.ProductModel;
using ShopOnline.Model.ReViewProductModel;
using ShopOnline.Model.RoleModel;
using ShopOnline.Model.SlideModel;
using ShopOnline.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.AutoMapper
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<IdentityUser, UserViewModel>();
            CreateMap<UserViewModel, IdentityUser>();

            CreateMap<IdentityRole, RoleViewModel>();
            CreateMap<RoleViewModel, IdentityRole>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            CreateMap<Function, FunctionViewModel>();
            CreateMap<FunctionViewModel, Function>();

            CreateMap<Permission, PermissionViewModel>();
            CreateMap<PermissionViewModel, Permission>();

            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryViewModel, ProductCategory>();

            CreateMap<ProductColor, ProductColorViewModel>();
            CreateMap<ProductColorViewModel, ProductColor>();

            CreateMap<ProductImage, ProductImageViewModel>();
            CreateMap<ProductImageViewModel, ProductColor>();

            CreateMap<ProductSize, ProductSizeViewModel>();
            CreateMap<ProductSizeViewModel, ProductSize>();

            CreateMap<ProductQuantity, ProductQuantityViewModel>();
            CreateMap<ProductQuantityViewModel, ProductQuantity>();

            CreateMap<WholePrice, WholePriceViewModel>();
            CreateMap<WholePriceViewModel, WholePrice>();


            CreateMap<Permission, PermissionViewModel>();
            CreateMap<PermissionViewModel, Permission>();

            CreateMap<Slide, SlideViewModel>();
            CreateMap<SlideViewModel, Slide>();

            CreateMap<ReviewProduct, ReViewProductViewModel>();
            CreateMap<ReViewProductViewModel, ReviewProduct>();

        }
    }
}
