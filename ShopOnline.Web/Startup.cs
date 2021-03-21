using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ShopOnline.Data;
using ShopOnline.Web.Authorization;
using ShopOnline.Web.ConnectAPI.ImplementationConnectAPI;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using ShopOnline.Web.Hubs;
using ShopOnline.Web.LocalizationResources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSignalR();
          
            services.AddRazorPages()
                  .AddRazorRuntimeCompilation();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/Admin/Login/Login";
                   options.AccessDeniedPath = "/User/Forbidden/";
               });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(30);
            });
            services.AddTransient<IReViewProductConnectAPI, ReViewProductConnectAPI>();
            services.AddTransient<ISlideConnectAPI, SlideConnectAPI>();
            services.AddTransient<IUserConnectAPI, UserConnectAPI>();
            services.AddTransient<IPermissionConnectAPI,PermissionConnectAPI>();
            services.AddTransient<IRoleConnectAPI, RoleConnectAPI>();
            services.AddTransient<IProductImageConnectAPI, ProductImageConnectAPI>();
            services.AddTransient<IProductConnectAPI, ProductConnectAPI>();
            services.AddTransient<IFunctionConnectAPI, FunctionConnectAPI>();
            services.AddTransient<IProductCategoryConnectAPI, ProductCategoryConnectAPI>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();
            var cultures = new[]
             {

                new CultureInfo("vi"),
                new CultureInfo("en")
            };
            services.AddControllersWithViews().AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(ops =>
            {
                // When using all the culture providers, the localization process will
                // check all available culture providers in order to detect the request culture.
                // If the request culture is found it will stop checking and do localization accordingly.
                // If the request culture is not found it will check the next provider by order.
                // If no culture is detected the default culture will be used.

                // Checking order for request culture:
                // 1) RouteSegmentCultureProvider
                //      e.g. http://localhost:1234/tr
                // 2) QueryStringCultureProvider
                //      e.g. http://localhost:1234/?culture=tr
                // 3) CookieCultureProvider
                //      Determines the culture information for a request via the value of a cookie.
                // 4) AcceptedLanguageHeaderRequestCultureProvider
                //      Determines the culture information for a request via the value of the Accept-Language header.
                //      See the browsers language settings

                // Uncomment and set to true to use only route culture provider
                ops.UseAllCultureProviders = false;
                ops.ResourcesPath = "LocalizationResources";
                ops.RequestLocalizationOptions = o =>
                {
                    o.SupportedCultures = cultures;
                    o.SupportedUICultures = cultures;
                    o.DefaultRequestCulture = new RequestCulture("vi");
                };
            }); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseRequestLocalization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapControllerRoute(
                      name: "MyArea",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
               name: "default",
               pattern: "{culture=vi}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
