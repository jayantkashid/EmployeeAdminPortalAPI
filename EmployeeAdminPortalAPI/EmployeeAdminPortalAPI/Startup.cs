using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAdminPortalAPI.DataConnection;
using EmployeeAdminPortalAPI.DataMapperRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeAdminPortalAPI
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
            //Adding CORS in app for angular app requests
            services.AddCors((options)=> {
                options.AddPolicy("angularAppRequest", (builder) => {
                    builder.WithOrigins("http://localhost:4200").AllowAnyHeader().WithMethods("GET","POST","PUT","DELETE").WithExposedHeaders();
                });
            });
            services.AddControllers();
            services.AddDbContext<EmployeeAdminContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EmployeeAdminPortalDb")));

            // Dependecy Injection in .net core for api - Inversed injection to api controller
            services.AddScoped<IEmployeeRepository, SqlEmployeeRepository>();
            services.AddAutoMapper(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //adding CORS in application
            app.UseCors("angularAppRequest");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
