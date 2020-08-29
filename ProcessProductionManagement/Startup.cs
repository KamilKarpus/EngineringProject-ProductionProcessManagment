using Autofac;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Validation;
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
using PPM.Api.Modules.Users;
using PPM.Locations.Infrastructure;
using PPM.UserAccess.Application.IndentityServer;
using PPM.UserAccess.Infrastructure;
using System.Collections.Generic;
using PPM.Orders.Infrastructure;
using PPM.Api.Configuration.Authorization;
using Microsoft.AspNetCore.Authorization;
using PPM.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

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

            ConfigureIdentityServer(services);
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();


            services.AddSingleton<IExceptionHandler, ExceptionHandler>();
            services.AddScoped<IAuthorizationHandler, HasPermissionAuthorizationHandler>();

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

            });
            services.AddCors(cfg =>
            {
                cfg.AddPolicy("CoreClient",
                policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(HasPermissionAttribute.HasPermissionPolicyName, policyBuilder =>
                {
                    policyBuilder.Requirements.Add(new HasPermissionAuthorizationRequirement());
                    policyBuilder.AddAuthenticationSchemes(IdentityServerAuthenticationDefaults.AuthenticationScheme);
                });
            });

   


        }
        private void ConfigureIdentityServer(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfig.GetApis())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                .AddInMemoryPersistedGrants()
                .AddProfileService<ProfileService>()
                .AddDeveloperSigningCredential();

            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, x =>
                {
                    x.Authority = Configuration["Authority"];
                    x.ApiName = "ppmAPI";
                    x.RequireHttpsMetadata = false;
                });
        }
        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            var databaseSettings = new DatabaseSetttings();

            Configuration.GetSection("Database").Bind(databaseSettings);
            builder.UseAdministationModule(databaseSettings.ConnectionString, databaseSettings.DbNameAdministration);
            builder.UseLocationsModule(databaseSettings.ConnectionString, databaseSettings.DbNameLocations);
            builder.UseAUserModule(databaseSettings.ConnectionString, databaseSettings.DbNameUsers);
            builder.UseOrdersModule(databaseSettings.ConnectionString, databaseSettings.DbNameOrders);
        }
   
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CoreClient");
            app.UseIdentityServer();

            app.UseExceptionMiddleware();

            app.UseSwagger();


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); 

            app.UseAuthorization();

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
