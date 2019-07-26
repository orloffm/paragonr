using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Paragonr.Application.Infrastructure;
using Paragonr.Business.Interfaces;
using Paragonr.Business.Services;
using Paragonr.Persistence;

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

            //app.UseHttpsRedirection();
            app.UseMvc();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
                });

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddMediatR(typeof(EntityBaseDto).Assembly);

            services.AddDbContext<IBudgetDbContext, BudgetDbContext>(
                options => options.UseSqlServer(
                    @"data source=.;initial catalog=Paragonr;integrated security=True;MultipleActiveResultSets=True;",
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()
                )
            );

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