using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace BT.Infrastructure.Config
{
    public static class ConfigureSwagger
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Bachelor's thesis",
                    Description = "Positioning and tracking of the object based on data from the GPS module",
                    TermsOfService = new Uri("https://aleksanderszatko.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Aleksader Szatko",
                        Email = "szatko.corp@gmail.com",
                        Url = new Uri("https://aleksanderszatko.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Undef",
                        Url = new Uri("https://aleksanderszatko.com"),
                    }
                });
                x.OperationFilter<RemoveVersionFromParameter>();
                x.DocumentFilter<ReplaceVersionWithExactValueInPath>();
            });
        }

        public static void ConfigSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(x =>
            {
                x.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(x =>
            {
                x.DocumentTitle = "API DOC - Bachelor's thesis";
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Bachelor's thesis");
                x.DefaultModelExpandDepth(2);
                x.DefaultModelRendering(ModelRendering.Model);
                x.DefaultModelsExpandDepth(-1);
                x.DisplayOperationId();
                x.DisplayRequestDuration();
                x.DocExpansion(DocExpansion.None);
                x.EnableDeepLinking();
                x.EnableFilter();
                x.ShowExtensions();
                x.ShowCommonExtensions();
                x.EnableValidator();
                x.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Head);
            });
        }
    }

    #region SWAGGER HELPERS
    public class RemoveVersionFromParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters.Single(p => p.Name == "version");
            operation.Parameters.Remove(versionParameter);
        }
    }

    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = new OpenApiPaths();
            foreach (var path in swaggerDoc.Paths)
            {
                paths.Add(path.Key.Replace("v{version}", swaggerDoc.Info.Version), path.Value);
            }
            swaggerDoc.Paths = paths;
        }
    }
    #endregion
}