using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PPM.Administration.Infrastucture;
using PPM.Api;
using PPM.Api.Middleware;
using PPM.Api.Middleware.Exceptions;
using PPM.Locations.Infrastructure;

namespace ProcessProductionManagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
     
        public void ConfigureServices(IServiceCollection services)
        {
 
            services.AddControllers();
            services.AddScoped<IExceptionHandler, ExceptionHandler>();
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddCors(cfg =>
            {
                cfg.AddPolicy("CoreClient",
                policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

        }

        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            var databaseSettings = new DatabaseSetttings();
            
            Configuration.GetSection("Database").Bind(databaseSettings);
            builder.UseAdministationModule(databaseSettings.ConnectionString, databaseSettings.DbNameAdministration);
            builder.UseLocationsModule(databaseSettings.ConnectionString, databaseSettings.DbNameLocations);
        }
   
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseExceptionMiddleware();

            app.UseSwagger();

            app.UseCors("CoreClient");

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
