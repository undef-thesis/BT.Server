using System;
using BT.Application.Common;
using BT.Infrastructure.Config;
using BT.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using BT.Application.Services.Auth;
using BT.Api.Middlewares;
using FluentValidation.AspNetCore;
using BT.Application.Validators;
using BT.Application.Options;
using BT.Application.Features.Behaviours;

namespace BT.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfiguration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfiguration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthTokenService, AuthTokenService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IAuthTokenCache, AuthTokenCache>();
            services.AddScoped<IDataContext, DataContext>();

            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("BT_DB"));

            services.AddMediatR(AppDomain.CurrentDomain.Load("BT.Application"));

            services.AddSingleton(AutoMapperConfig.Initialize());

            services.Configure<IdentityOptions>(Configuration.GetSection("IdentityOptions"));
            services.AddJwt(Configuration["IdentityOptions:SecretKey"]);
            services.AddSwagger();
            services.AddVersioning();

            services.AddMemoryCache();

            services.AddCors(options => options.AddPolicy("CorsPolicy", option =>
            {
                option
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:4200");
            }));

            services.SetupValidators();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            services.AddControllers()
                .AddFluentValidation()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.ConfigSwagger();

            app.UseMiddleware<AuthMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
