using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuanLyKho.Core.Repository;
using QuanLyKho.Core.Service;
using QuanLyKho.Core.UnitOfWorks;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;
using QuanLyKho.Service.Category;
using QuanLyKho.Service.Product;
using QuanLyKho.Service.Store;
using QuanLyKho.Service.StoreStock;
using QuanLyKho.Service.Transaction;
using QuanLyKho.Service.UnitOfMeasure;
using QuanLyKho.Service.User;
using QuanLyKho.Service.NhaCungCap;

namespace QuanLyKho.Web
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
            services.AddDbContext<WarehouseDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConStr"), o =>
                {
                    o.MigrationsAssembly("QuanLyKho.Data");
                });
            });
            services.AddAutoMapper(c => c.AddProfile<QuanLyKho.Mapper.MapProfile>(), typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<INhaCungCapService, NhaCungCapService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfMeasureService, UnitOfMeasureService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStoreStockService, StoreStockService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUnitOfWorks, QuanLyKho.UnitOfWork.UnitOfWork>();
            services.AddControllersWithViews().
                    AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    }).AddRazorRuntimeCompilation();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                     {
                         options.LoginPath = new PathString("/auth/login");
                         options.Cookie.HttpOnly = true;
                         options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                         options.SlidingExpiration = true;
                     });
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
                .RequireAuthorization();
            });
        }
    }
}
