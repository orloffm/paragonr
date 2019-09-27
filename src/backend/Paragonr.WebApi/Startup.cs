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
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Paragonr.Application.Infrastructure;
using Paragonr.Application.Interfaces;
using Paragonr.Application.Services;
using Paragonr.Persistence;
using Paragonr.WebApi.Infrastructure;

namespace Paragonr.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //  app.UseCors(x => x
            //     .AllowAnyOrigin()
            //     .AllowAnyMethod()
            //     .AllowAnyHeader());

            //  app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // services.AddCors();

            services.AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
                });

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddMediatR(typeof(EntityBaseDto).Assembly);

            services.AddDbContext<IBudgetDbContext, BudgetDbContext>(
                options => options.UseSqlServer(
                    @"data source=.;initial catalog=Paragonr;integrated security=True;MultipleActiveResultSets=True;",
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()
                )
            );

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

            // To support EF migrations.
            services.TryAdd(new ServiceDescriptor(typeof(BudgetDbContext), typeof(BudgetDbContext), ServiceLifetime.Scoped));

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
