using Microsoft.EntityFrameworkCore;
using ProductAPI.DAL;
using ProductAPI.DAL.Interfaces;
using ProductAPI.DAL.Repository;
using ProductAPI.Service.Helpers;
using ProductAPI.Service.Implementations;
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
            services.AddScoped<IImageAccessorService, ImageAccessorService>();
            services.AddScoped<ICloudinaryActions, CloudinaryActions>();

            services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));

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

            services.AddEndpointsApiExplorer();

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
