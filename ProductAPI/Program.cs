using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductAPI;
using ProductAPI.DAL;
using ProductAPI.DAL.Interfaces;
using ProductAPI.DAL.Repository;
using ProductAPI.Middleware.Extensions;
using ProductAPI.Service.Implementations;
using System.Reflection;
using WatchDog.src.Enums;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(connectionString));

builder.Services.AddResponseCaching();
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddApiVersioning(option =>
{
    option.AssumeDefaultVersionWhenUnspecified = true;
    option.DefaultApiVersion = new ApiVersion(1, 0);
    option.ReportApiVersions = true;// ? ????????? ?????? ???????????? ??? ????????? ?????? 
});
builder.Services.AddVersionedApiExplorer(option =>
{
    option.GroupNameFormat = "'v'VVV";
    option.SubstituteApiVersionInUrl = true;// ???? ??????????? ?????? ? ???????
});

builder.Services.AddControllers(option =>
{
    option.CacheProfiles.Add("Default30",
        new CacheProfile()
        {
            Duration = 30// ???????? ?? 30 ???
        });
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "ProductAPI V1 (Product)",
        Description = "Web API 2022",
        TermsOfService = new Uri("https://vk.com/id306326375"),
        Contact = new OpenApiContact
        {
            Name = "?????? ??????",
            Email = "avgorlov899@gmail.com",
            Url = new Uri("https://github.com/Andrej-Gorlov")
        },
        License = new OpenApiLicense
        {
            Name = "????????...",
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
            Name = "?????? ??????",
            Email = "avgorlov899@gmail.com",
            Url = new Uri("https://github.com/Andrej-Gorlov")
        },
        License = new OpenApiLicense
        {
            Name = "????????...",
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
            Name = "?????? ??????",
            Email = "avgorlov899@gmail.com",
            Url = new Uri("https://github.com/Andrej-Gorlov")
        },
        License = new OpenApiLicense
        {
            Name = "????????...",
            Url = new Uri("https://vk.com/id306326375")
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddWatchDogServices(opt =>
{
    opt.IsAutoClear = false;
    //opt.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Quarterly;
    opt.SetExternalDbConnString = connectionString;
    opt.DbDriverOption = WatchDogDbDriverEnum.PostgreSql;
});

builder.Logging.AddWatchDogLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductAPI V1 (Product)");
        option.SwaggerEndpoint("/swagger/v2/swagger.json", "ProductAPI V2 (Category)");
        option.SwaggerEndpoint("/swagger/v3/swagger.json", "ProductAPI V3 (Image)");
    });
}

app.UseErrorHandlerMiddleware();

app.UseHttpsRedirection();

app.UseWatchDog(opt =>
{
    opt.WatchPageUsername = builder.Configuration.GetConnectionString("LoginWatchDog");
    opt.WatchPagePassword = builder.Configuration.GetConnectionString("PasswordWatchDog");
});

app.UseAuthorization();

app.MapControllers();

app.UseWatchDogExceptionLogger();

app.Run();