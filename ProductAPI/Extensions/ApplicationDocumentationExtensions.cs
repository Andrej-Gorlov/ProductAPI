using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ProductAPI.Extensions
{
    public static class ApplicationDocumentationExtensions
    {
        public static IServiceCollection AddApplicationDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "ProductAPI V1 (Product)",
                    Description = "Web API 2022",
                    TermsOfService = new Uri("https://vk.com/id306326375"),
                    Contact = new OpenApiContact
                    {
                        Name = "Горлов Андрей",
                        Email = "avgorlov899@gmail.com",
                        Url = new Uri("https://github.com/Andrej-Gorlov")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Лицензия...",
                        Url = new Uri("https://vk.com/id306326375")
                    }
                });
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2.0",
                    Title = "ProductAPI V2 (Category)",
                    Description = "Web API.",
                    TermsOfService = new Uri("https://vk.com/id306326375"),
                    Contact = new OpenApiContact
                    {
                        Name = "Горлов Андрей",
                        Email = "avgorlov899@gmail.com",
                        Url = new Uri("https://github.com/Andrej-Gorlov")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Лицензия...",
                        Url = new Uri("https://vk.com/id306326375")
                    }
                });
                options.SwaggerDoc("v3", new OpenApiInfo
                {
                    Version = "v3.0",
                    Title = "ProductAPI V3 (Image)",
                    Description = "Web API.",
                    TermsOfService = new Uri("https://vk.com/id306326375"),
                    Contact = new OpenApiContact
                    {
                        Name = "Горлов Андрей",
                        Email = "avgorlov899@gmail.com",
                        Url = new Uri("https://github.com/Andrej-Gorlov")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Лицензия...",
                        Url = new Uri("https://vk.com/id306326375")
                    }
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        new string[]{}
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
