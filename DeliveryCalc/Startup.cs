using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using DeliveryCalc.Provider;
using System.Text;
using DeliveryCalc.Provider;
using DeliveryCalc.Services;
using System.Collections.Generic;
using DeliveryCalc.Models;

namespace DeliveryCalc
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
            services.AddCors();
            services.AddScoped<IProvider<InputElement>, BirdProvider>();
            services.AddScoped<IProvider<InputElement>, TurtleProvider>();
            services.AddScoped<IDeliveryCalcService<InputElement>, DeliveryCalcService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();     
        }
    }
}