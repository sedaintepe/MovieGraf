using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieGraf.Data;
using Plugins.DataStore.InMemory;
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

            //dependicy injection for �nmemory
            services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>(); //her istek i�in 
            services.AddScoped<IMovieRepository, MovieInMemoryRepository>(); //her istek i�in 

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
