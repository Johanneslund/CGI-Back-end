using CGICodeTest.Data;
using CGICodeTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGICodeTest
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

            //Behövde lägga till detta då CORS inte lät frontend att koppla upp annars
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                   .AllowAnyMethod()
                                                                    .AllowAnyHeader()));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowCredentials();
                });
            });
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddDbContext<CardContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("CardDb")
                )
            );

            services.AddTransient<ICardRepository, CardRepository>();

            services.AddTransient<ICardService, CardService>();



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CGICodeTest", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CGICodeTest v1"));
            }


            //Behövde lägga till detta då CORS inte lät frontend att koppla upp annars
            app.UseCors("AllowAll");
            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseCors(builder => builder.AllowAnyMethod());
            app.UseCors(builder => builder.AllowAnyHeader());
            app.UseCors(builder => builder.AllowCredentials());

            app.UseMvc();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
