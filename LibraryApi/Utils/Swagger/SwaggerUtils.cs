using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApi.Utils.Swagger
{
    public class SwaggerUtils
    {
        public string Title { get; set; }
        public string Scope { get; set; }
        public void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{Title} API",
                    Version = "v1",
                    Description = $"ASP.NET Core {Title} API"
                });

                /*c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Scheme = "oauth2",
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(configuration["Authority"] + "/connect/authorize"),
                            TokenUrl = new Uri(configuration["Authority"] + "/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                { "edpFacilita", "Acesso API Facilita" },
                                { "edpSmart", "Acesso API Facilita" },
                                { "edpSso", "Acesso API SSO" }
                            }
                        }
                    }
                });*/

                /*c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                        },
                        new[] { "edpFacilita", "edpSmart" }
                    }
                });*/
            });
        }

        public void ConfigureSwaggerUI(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Title} API");
                c.RoutePrefix = "swagger";
                c.OAuthClientId(Scope);
                c.OAuthAppName($"{Scope} - Swagger");
            });
        }
    }
}
