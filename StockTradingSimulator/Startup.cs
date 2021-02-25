using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using StockTradingSimulator.Models;

namespace StockTradingSimulator
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //TODO "This setup leaves the API wide open for access. In production applications you might need to add more restrictions. Please check Microsoft’s documentation on enabling cross origin requests for more details."
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddDbContext<CompanyContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CompanyContext")));

            services.AddDbContext<StockCandlesticksContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("StockCandlesticksContext")));

            services.AddDbContext<OrdersContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("OrdersContext")));

            services.AddDbContext<StocksContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("StocksContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");  //TODO "This setup leaves the API wide open for access. In production applications you might need to add more restrictions. Please check Microsoft’s documentation on enabling cross origin requests for more details."
            app.UseMvc();
        }
    }
}
