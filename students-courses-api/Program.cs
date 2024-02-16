using Microsoft.EntityFrameworkCore;
using Students.Courses.Api.Configuration;
using Students.Courses.Api.Interfaces;
using Students.Courses.Api.Services;
using Students.Courses.Repository.Context;
using Students.Courses.Repository.Seeds;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
    });
});

builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ICourseService, CourseService>();

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
