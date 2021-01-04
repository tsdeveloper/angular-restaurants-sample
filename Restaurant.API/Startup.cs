using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Restaurant.Core.AutoMapper;
using Restaurant.Core.Specification;
using Restaurant.Core.Specification.Interfaces;
using Restaurant.Infra.Data;
using Restaurant.Infra.Repository;
using Restaurant.Infra.Services;

namespace Restaurant.API
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
            var dbConn = Configuration.GetConnectionString("MySqlConn");

            services.AddDbContext<AppStoreContext>(o => o.UseMySql(dbConn));
            
        
            
            services.AddControllers().AddFluentValidation();
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAngularDev", p =>
                {
                    p.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });
            

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IRestaurantRatingService, RestaurantRatingService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(MappingProfiles));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();
            

            app.UseCors("AllowAngularDev");
            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}