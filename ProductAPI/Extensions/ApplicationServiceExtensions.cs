using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductAPI.DAL;
using ProductAPI.DAL.Interfaces;
using ProductAPI.DAL.Repository;
using ProductAPI.Service.Implementations;
using System.Reflection;
using WatchDog.src.Enums;

namespace ProductAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            // Add services to the container.
            services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(connectionString));

            services.AddResponseCaching();
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddApiVersioning(option =>
            {
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.ReportApiVersions = true;// в заголовке ответа отображаются все доступные версии 
            });
            services.AddVersionedApiExplorer(option =>
            {
                option.GroupNameFormat = "'v'VVV";
                option.SubstituteApiVersionInUrl = true;// авто подстановка версии в маршрут
            });

            services.AddControllers(option =>
            {
                option.CacheProfiles.Add("Default30",
                    new CacheProfile()
                    {
                        Duration = 30// кешируем на 30 сек
                    });
            }).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

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
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            services.AddWatchDogServices(opt =>
            {
                opt.IsAutoClear = false;
                //opt.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Quarterly;
                opt.SetExternalDbConnString = connectionString;
                opt.DbDriverOption = WatchDogDbDriverEnum.PostgreSql;
            });

            return services;
        }
    }
}
