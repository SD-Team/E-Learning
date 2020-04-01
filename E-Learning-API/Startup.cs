using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using E_Learning_API.Application.AutoMapper;
using E_Learning_API.Application.Implementation;
using E_Learning_API.Application.Interfaces;
using E_Learning_API.Data.Interfaces;
using E_Learning_API.Data.Repository;
using E_Learning_API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace E_Learning_API
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
            //Add cors
            services.AddCors();
            services.AddDbContext<DBContextVideo>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("VideoConnection"))
            );
            services.AddDbContext<DBContextUser>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("UserConnection"))
            );

            services.AddControllers();

            // config Mapper
            services.AddSingleton(AutoMapperConfig.RegisterMappings());
            services.AddScoped<IMapper>(sp =>
            {
                return new Mapper(AutoMapperConfig.RegisterMappings());
            });
            //repository genarate
            services.AddTransient(typeof(IRepositoryVideo<,>), typeof(RepositoryVideo<,>));
            services.AddTransient(typeof(IRepositoryUser<,>), typeof(RepositoryUser<,>));
            //service
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<ISystemManagementService, SystemManagementService>();
            services.AddTransient<IReportManagementService, ReportManagementService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Add allow any header
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            // Publish
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "spa-fallback",
                    pattern: "{controller=FallBack}/{action=Index}/{id?}"
                );

                endpoints.MapFallbackToController("Index", "FallBack");
            });
        }
    }
}
