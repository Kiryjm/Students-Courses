using Microsoft.EntityFrameworkCore;
using Students.Courses.Repository.Context;
using Students.Courses.Repository.Seeds;

namespace Students.Courses.Api.Configuration;

public static class DatabaseInitialization
{
    public static async void Initialize(this IApplicationBuilder app, IConfiguration configuration)
    {
        // using var scope = app.Services.CreateScope();
        using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<DataContext>();
            await context.Database.MigrateAsync();
            await Seed.SeedStudents(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occured during migration");
        }
    }
}