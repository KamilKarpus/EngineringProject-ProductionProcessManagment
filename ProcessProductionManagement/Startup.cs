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
using PPM.Printing.Infrastructure;
using PPM.Api.Modules.Printing;
using PPM.Api.Configuration.SignalR;
using System;
using Autofac.Extensions.DependencyInjection;
using PPM.Administration.Infrastucture.Configuration;
using PPM.Locations.Infrastructure.Configuration;
using PPM.UserAccess.Infrastructure.Configuration;
using PPM.Orders.Infrastructure.Configuration;
using PPM.Printing.Infrastructure.Configuration;
using IdentityModel.AspNetCore.OAuth2Introspection;

namespace ProcessProductionManagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
     
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddCors(cfg =>
            {
                cfg.AddPolicy("CoreClient",
                policy =>
                {
                    policy.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });

            services.AddControllers();

            ConfigureIdentityServer(services);
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();
            services.AddScoped<IHubClient, PrintingHubClient>();

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
 
            services.AddAuthorization(options =>
            {
                options.AddPolicy(HasPermissionAttribute.HasPermissionPolicyName, policyBuilder =>
                {
                    policyBuilder.Requirements.Add(new HasPermissionAuthorizationRequirement());
                    policyBuilder.AddAuthenticationSchemes(IdentityServerAuthenticationDefaults.AuthenticationScheme);
                });
            });
            services.AddSignalR();

            return CreateAutofacServiceProvider(services);
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
                    x.TokenRetriever = new Func<HttpRequest, string>(req =>
                    {
                        var fromHeader = TokenRetrieval.FromAuthorizationHeader();
                        var fromQuery = TokenRetrieval.FromQueryString();
                        return fromHeader(req) ?? fromQuery(req);
                    });
                });
        }
        public IServiceProvider CreateAutofacServiceProvider(IServiceCollection services)
        {

            var builder = new ContainerBuilder();

            builder.Populate(services);
            var databaseSettings = new DatabaseSetttings();

            Configuration.GetSection("Database").Bind(databaseSettings);
            
            builder.RegisterAdministationModule();
            builder.RegisterLocationsModule();
            builder.RegisterUserModule();
            builder.RegisterOrdersModule();
            builder.RegisterPrintingModule();

            var container = builder.Build();

            var hubClient = container.Resolve<IHubClient>();

            AdministrationStartup.Intialize(databaseSettings.ConnectionString, databaseSettings.DbNameAdministration);
            LocationsStartup.Intialize(databaseSettings.ConnectionString, databaseSettings.DbNameLocations);
            UserAccessStartup.Intialize(databaseSettings.ConnectionString, databaseSettings.DbNameUsers);
            OrdersStartup.Intialize(databaseSettings.ConnectionString, databaseSettings.DbNameOrders);
            PrintingStartup.Intialize(databaseSettings.ConnectionString,
                databaseSettings.DbNamePrinting,
                Configuration["BlobStorage:ConnectionString"],
                Configuration["BlobStorage:QrCodeContainer"],
                hubClient);
            return new AutofacServiceProvider(container);
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
                endpoints.MapHub<PrintingHub>("/printinghub");
            });
        }
    }
}
