using MCake.Areas.Identity;
using MCake.Data;
using MCake.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Blazored.LocalStorage;
using MCake.Service;
using MCake.service;
using Hanssens.Net;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace MCake
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                 //options.UseSqlServer(Configuration.GetConnectionString("Sql"))
                 ///options.UseSqlite("Filename=mcake.db")
                 options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddDbContext<CartDbContext>(options =>
                 //options.UseSqlServer(Configuration.GetConnectionString("Sql"))
                 ///options.UseSqlite("Filename=mcake.db")
                 options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddDbContext<CollectionDbContext>(options =>
                 //options.UseSqlServer(Configuration.GetConnectionString("Sql"))
                 ///options.UseSqlite("Filename=mcake.db")
                 options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddDbContext<NavCollectionDbContext>(options =>
                 //options.UseSqlServer(Configuration.GetConnectionString("Sql"))
                 ///options.UseSqlite("Filename=mcake.db")
                 options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddIdentity<IdentityUser, Role>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<Role>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddEntityFrameworkNpgsql();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddBlazoredLocalStorage();
            services.AddScoped<ProtectedLocalStorage>()
            ; services.AddCors(policy =>
              {
                  policy.AddPolicy("CorsPolicy", opt => opt
                  .AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .WithExposedHeaders("X-Pagination"));
              });
            services.AddHttpContextAccessor();
            services.AddScoped<MainService>();
            services.AddTransient<ProductsController>();
            services.AddTransient<ProductCollectionsController>();
            services.AddTransient<CartsController>();
            services.AddTransient<ImagesController>();
            services.AddTransient<CategoriesController>();
            services.AddTransient<BlogsController>();
            services.AddTransient<OrdersController>();
            services.AddTransient<PaysController>();
            services.AddTransient<ContactsController>();
            services.AddTransient<ReviewsController>();
            services.AddTransient<WishlistsController>();
            services.AddTransient<WishCollectionsController>();
            services.AddTransient<NavCollectionsController>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,

            });

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
