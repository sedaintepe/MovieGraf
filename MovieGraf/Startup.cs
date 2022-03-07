using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieGraf.Data;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases;
using UseCases.DataClassPluginInterfaces;

namespace MovieGraf
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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            services.AddDbContext<Graf>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "admin"));
               options.AddPolicy("LoginOnly", p => p.RequireClaim("Position", "Login"));
            });

            //dependicy injection for ýnmemory
            //services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>(); //her istek için 
            //services.AddScoped<IMovieRepository, MovieInMemoryRepository>(); //her istek için
                     //EFCORE                                                        //
            services.AddScoped<ICategoryRepository,CategoryRepository>(); //her istek için 
            services.AddScoped<IMovieRepository, MovieRepository>(); //her istek için 

            //dependicy injection for usecases
            services.AddTransient<IViewCategoriesUseCases, ViewCategoriesUseCases>();
            services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
            services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
            services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
            services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
            services.AddTransient<IViewMovieUseCase, ViewMovieUseCase>();
            services.AddTransient<IAddMovieUseCase, AddMovieUseCase>();
            services.AddTransient<IEditMovieUseCase, EditMovieUseCase>();
            services.AddTransient<IGetMovieByIdUseCase, GetMovieByIdUseCase>();
            services.AddTransient<IDeleteMovieUseCase, DeleteMovieUseCase>();
            services.AddTransient<IViewMoviesByCategoryId, ViewMoviesByCategoryId>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
       

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
