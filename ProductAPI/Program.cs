using Microsoft.EntityFrameworkCore;
using ProductAPI.Extensions;
using ProductAPI.Middleware.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddApplicationDocumentation();

builder.Logging.AddWatchDogLogger();

builder.AddAppAuthetication();
builder.Services.AddAuthorization();

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

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseCors("cors");
app.MapControllers();

app.UseWatchDogExceptionLogger();

app.Run();