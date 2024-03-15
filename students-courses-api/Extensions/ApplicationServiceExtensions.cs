using Microsoft.EntityFrameworkCore;
using Students.Courses.Api.Interfaces;
using Students.Courses.Api.Services;
using Students.Courses.Repository.Context;
using Students.Courses.Services.Core;
using Students.Courses.Services.Students;

namespace Students.Courses.Api.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod().WithOrigins("http://localhost:3000");
            });
        });

        services.AddTransient<IStudentService, StudentService>();
        services.AddTransient<ICourseService, CourseService>();
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(StudentsList.Handler).Assembly));
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);

        return services;
    }
}