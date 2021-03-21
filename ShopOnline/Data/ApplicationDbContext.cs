using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Configuration;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfiguration(new LogoConfiguration());
            builder.ApplyConfiguration(new ReviewProductConfiguration());
            builder.ApplyConfiguration(new SortConfiguration());
            builder.ApplyConfiguration(new SlideConfiguration());
            builder.ApplyConfiguration(new BlogConfiguration());
            builder.ApplyConfiguration(new WholePriceConfiguration());
            builder.ApplyConfiguration(new ProductQuantityConfiguration());
            builder.ApplyConfiguration(new PageConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new FooterConfiguration());
            builder.ApplyConfiguration(new FunctionConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
            builder.ApplyConfiguration(new PaymentConfiguration());
            builder.ApplyConfiguration(new PermissionConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new ProductColorConfiguration());
            builder.ApplyConfiguration(new ProductImageConfiguration());
            builder.ApplyConfiguration(new ProductSizeConfiguration());
            builder.Entity<ProductCategory>().HasData(
            new ProductCategory()
            {
                Id = 1,
                Name = "Men shirt",
                SeoAlias = "men-shirt",
                ParentId = null,
                SortOrder = 1
            },
            new ProductCategory()
            {
                Id = 2,
                Name = "Women shirt",
                SeoAlias = "women-shirt",
                ParentId = null,

                SortOrder = 2
            },
            new ProductCategory()
            {
                Id = 3,
                Name = "Men shoes",
                SeoAlias = "men-shoes",
                ParentId = null,

                SortOrder = 3
            },
            new ProductCategory()
            {
                Id = 4,
                Name = "Woment shoes",
                SeoAlias = "women-shoes",
                ParentId = null,
                SortOrder = 4
            });
            builder.Entity<IdentityRole>().HasData(
               new IdentityRole()
               {
                   Name = "Admin",
                   NormalizedName = "Admin",
               },
                new IdentityRole()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",

                },
                new IdentityRole()
                {
                    Name = "Customer",
                    NormalizedName = "Customer",

                });
            builder.Entity<Function>().HasData(
             new Function()
             {
                 Id = "SYSTEM",
                 Name = "System",
                 ParentId = null,
                 SortOrder = 1,
                 URL = "/",
                 IconCss = "fa-desktop",
             },
             new Function()
             {
                 Id = "ROLE",
                 Name = "Role",
                 ParentId = "SYSTEM",
                 SortOrder = 1,
                 URL = "/admin/role/index",
                 IconCss = "fa-home",

             },
             new Function()
             {
                 Id = "FUNCTION",
                 Name = "Function",
                 ParentId = "SYSTEM",
                 SortOrder = 2,
                 URL = "/admin/function/index",
                 IconCss = "fa-home"

             },
             new Function()
             {
                 Id = "USER",
                 Name = "User",
                 ParentId = "SYSTEM",
                 SortOrder = 3,
                 URL = "/admin/user/index",
                 IconCss = "fa-home"

             },
             new Function()
             {
                 Id = "ACTIVITY",
                 Name = "Activity",
                 ParentId = "SYSTEM",
                 SortOrder = 4,
                 URL = "/admin/activity/index",
                 IconCss = "fa-home"

             },
             new Function()
             {
                 Id = "ERROR",
                 Name = "Error",
                 ParentId = "SYSTEM",
                 SortOrder = 5,
                 URL = "/admin/error/index",
                 IconCss = "fa-home"

             },
             new Function()
             {
                 Id = "SETTING",
                 Name = "Configuration",
                 ParentId = "SYSTEM",
                 SortOrder = 6,
                 URL = "/admin/setting/index",
                 IconCss = "fa-home"

             },
             new Function()
             {
                 Id = "PRODUCT",
                 Name = "Product Management",
                 ParentId = null,
                 SortOrder = 2,
                 URL = "/",
                 IconCss = "fa-chevron-down"

             },
             new Function()
             {
                 Id = "PRODUCT_CATEGORY",
                 Name = "Category",
                 ParentId = "PRODUCT",
                 SortOrder = 1,
                 URL = "/admin/productcategory/index",
                 IconCss = "fa-chevron-down"

             },
             new Function()
             {
                 Id = "PRODUCT_LIST",
                 Name = "Product",
                 ParentId = "PRODUCT",
                 SortOrder = 2,
                 URL = "/admin/product/index",
                 IconCss = "fa-chevron-down"

             },
             new Function()
             {
                 Id = "BILL",
                 Name = "Bill",
                 ParentId = "PRODUCT",
                 SortOrder = 3,
                 URL = "/admin/bill/index",
                 IconCss = "fa-chevron-down"

             },
             new Function()
             {
                 Id = "CONTENT",
                 Name = "Content",
                 ParentId = null,
                 SortOrder = 3,
                 URL = "/",
                 IconCss = "fa-table"

             },
             new Function()
             {
                 Id = "BLOG",
                 Name = "Blog",
                 ParentId = "CONTENT",
                 SortOrder = 1,
                 URL = "/admin/blog/index",
                 IconCss = "fa-table"

             },
             new Function()
             {
                 Id = "UTILITY",
                 Name = "Utilities",
                 ParentId = null,
                 SortOrder = 4,
                 URL = "/",
                 IconCss = "fa-clone"

             },
             new Function()
             {
                 Id = "FOOTER",
                 Name = "Footer",
                 ParentId = "UTILITY",
                 SortOrder = 1,
                 URL = "/admin/footer/index",
                 IconCss = "fa-clone"

             },
             new Function()
             {
                 Id = "FEEDBACK",
                 Name = "Feedback",
                 ParentId = "UTILITY",
                 SortOrder = 2,
                 URL = "/admin/feedback/index",
                 IconCss = "fa-clone"

             },
             new Function()
             {
                 Id = "ANNOUNCEMENT",
                 Name = "Announcement",
                 ParentId = "UTILITY",
                 SortOrder = 3,
                 URL = "/admin/announcement/index",
                 IconCss = "fa-clone"

             },
             new Function()
             {
                 Id = "CONTACT",
                 Name = "Contact",
                 ParentId = "UTILITY",
                 SortOrder = 4,
                 URL = "/admin/contact/index",
                 IconCss = "fa-clone"

             },
             new Function()
             {
                 Id = "SLIDE",
                 Name = "Slide",
                 ParentId = "UTILITY",
                 SortOrder = 5,
                 URL = "/admin/slide/index",
                 IconCss = "fa-clone"

             },
             new Function()
             {
                 Id = "ADVERTISMENT",
                 Name = "Advertisment",
                 ParentId = "UTILITY",
                 SortOrder = 6,
                 URL = "/admin/advertistment/index",
                 IconCss = "fa-clone"

             },
             new Function()
             {
                 Id = "REPORT",
                 Name = "Report",
                 ParentId = null,
                 SortOrder = 5,
                 URL = "/",
                 IconCss = "fa-bar-chart-o"

             },
             new Function()
             {
                 Id = "REVENUES",
                 Name = "Revenue report",
                 ParentId = "REPORT",
                 SortOrder = 1,
                 URL = "/admin/report/revenues",
                 IconCss = "fa-bar-chart-o"

             },
             new Function()
             {
                 Id = "ACCESS",
                 Name = "Visitor Report",
                 ParentId = "REPORT",
                 SortOrder = 2,
                 URL = "/admin/report/visitor",
                 IconCss = "fa-bar-chart-o"

             },
             new Function()
             {
                 Id = "READER",
                 Name = "Reader Report",
                 ParentId = "REPORT",
                 SortOrder = 3,
                 URL = "/admin/report/reader",
                 IconCss = "fa-bar-chart-o"

             });
            base.OnModelCreating(builder);
        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<ReviewProduct> ReviewProducts { get; set; }
        public DbSet<Sort> Sorts { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<WholePrice> WholePrices { get; set; }
        public DbSet<ProductQuantity> ProductQuantities { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
    }
}
