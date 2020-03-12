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
using TopkaE.FPLDataDownloader.DBContext;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using TopkaE.FPLDataDownloader.AutoMapper;
using TopkaE.FPLDataDownloader.Repository;

namespace TopkaE.FPLDataDownloader
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
            string connectionString = Configuration["MariaDBConnection"];
            services.AddDbContext<TopkaEContext>(options => options.
                UseMySql(connectionString)
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OutputModelsProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            //services.AddScoped<IPlayerRepository, EFPlayerRepository>();
            services.AddScoped<IPlayerRepository, MariaDBPlayerRepository>();
            services.AddHttpClient();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());

            //app.UseAuthentication();
            app.UseMvc();
        }
    }
}
