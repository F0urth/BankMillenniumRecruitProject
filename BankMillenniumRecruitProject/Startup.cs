using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankMillenniumRecruitProject.Data;
using BankMillenniumRecruitProject.Services;
using BankMillenniumRecruitProject.Services.Factories;
using BankMillenniumRecruitProject.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BankMillenniumRecruitProject
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

            services.AddControllers().AddXmlDataContractSerializerFormatters();

            services.AddDbContext<MillenniumDbContext>(opt => opt.UseInMemoryDatabase("ExerciseDatabase"));

            services.AddScoped<ISampleItemRepository, SampleItemRepository>();
            services.AddScoped<ISampleItemService, SampleItemService>();
            services.AddScoped<SampleItemFactory>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BankMillenniumRecruitProject", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BankMillenniumRecruitProject v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
