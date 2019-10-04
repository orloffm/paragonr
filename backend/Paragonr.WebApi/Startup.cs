using System;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Paragonr.Application.Common.Mapping;
using Paragonr.Application.Services;
using Paragonr.Domain;
using Paragonr.Persistence;
using Paragonr.Tools.Mapping.Dto;
using Paragonr.WebApi.Common;
using Paragonr.WebApi.Common.Middleware;
using Paragonr.WebApi.Infrastructure;

namespace Paragonr.WebApi
{
    public class Startup
    {
        private const string ParagonrDatabaseConfigurationKey = "ParagonrDatabase";
        private const string AppSettingsConfigurationKey = "AppSettings";

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //     app.UseDatabaseErrorPage();
            }

            app.UseAppExceptionHandler();

            // app.UseOpenApi();
            //
            // app.UseSwaggerUi3(settings =>
            // {
            //     settings.Path = "/api";
            //     //    settings.DocumentPath = "/api/specification.json";   Enable when NSwag.MSBuild is upgraded to .NET Core 3.0
            // });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //  app.UseCors(x => x
            //     .AllowAnyOrigin()
            //     .AllowAnyMethod()
            //     .AllowAnyHeader());

            //  app.UseHttpsRedirection();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // services.AddCors();

            services.AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                });

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection(AppSettingsConfigurationKey);
            services.Configure<AppSettings>(appSettingsSection);

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddMediatR(typeof(EntityBaseDto).Assembly);
            services.AddHttpContextAccessor();

            // Database.
            var connectionString = Configuration.GetConnectionString(ParagonrDatabaseConfigurationKey);
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<BudgetDbContext>(
                options => options
                    .UseNpgsql(connectionString)
                    .EnableSensitiveDataLogging()
                );
            services.AddScoped<IBudgetDbContext>(provider => provider.GetService<BudgetDbContext>());

            // Auth.
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterAssemblyTypes(typeof(RateProvider).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(EntityBaseDto).Assembly).AsImplementedInterfaces();
            IContainer container = builder.Build();

            var provider = new AutofacServiceProvider(container);
            return provider;
        }
    }
}
