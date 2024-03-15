using Students.Courses.Api.Configuration;
using Students.Courses.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(config);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

var serviceBasePath = config["ServiceBasePath"];
// *** Configuring the path that the service runs
app.UsePathBase(serviceBasePath);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.UseSwaggerUI(c =>
    // {
    //     c.SwaggerEndpoint(
    //         $"{config["ServiceBasePath"]}/swagger.json",
    //         "App Store API v1"
    //     );
    // });
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.InitializeDatabase();

app.Run();
