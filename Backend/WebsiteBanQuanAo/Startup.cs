using NXHOANG.ApplicationCore.Interface.Repository;
using NXHOANG.ApplicationCore.Interface.Service;
using NXHOANG.ApplicationCore.Service;
using NXHOANG.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NXHOANG.DoAnTotNghiep
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
            services.AddControllersWithViews();

            services.AddCors();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(60);//You can set Time   
            });

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ISlideRepository, SlideRepository>();
            services.AddScoped<ISlideService, SlideService>();

            services.AddScoped<IMenuHeaderRepository, MenuHeaderRepository>();
            services.AddScoped<IMenuHeaderService, MenuHeaderService>();

            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();

            services.AddScoped<IFooterProductRepository, FooterProductRepository>();
            services.AddScoped<IFooterProductService, FooterProductService>();

            services.AddScoped<IProductOrderRepository, ProductOrderRepository>();
            services.AddScoped<IProductOrderService, ProductOrderService>();

            services.AddScoped<IProductOrderDetailRepository, ProductOrderDetailRepository>();
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
            app.UseStaticFiles();

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });


            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("shoppingCart", "gio-hang.html", new { controller = "ShoppingCart", action = "Index" });

                endpoints.MapControllerRoute("contact", "lien-he.html", new { controller = "Contact", action = "Index" });

                endpoints.MapControllerRoute("search", "tim-kiem.html", new { controller = "Home", action = "Search" });

                endpoints.MapControllerRoute("category", "danh-muc-{ProductCategoryLink}/{ProductCategoryId}", new { controller = "ProductCategory", action = "Index" });

                endpoints.MapControllerRoute("product", "san-pham-chi-tiet/{ProductId}.html", new { controller = "Product", action = "Detail" });

                endpoints.MapControllerRoute("login", "dang-nhap.html", new { controller = "Home", action = "Login" });

                endpoints.MapControllerRoute("register", "dang-ky.html", new { controller = "Home", action = "Register" });
                    
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
