using Students.Courses.Entity.Models;
using Students.Courses.Repository.Context;

namespace Students.Courses.Repository.Seeds;

public class Seed
{
    public static async Task SeedAll(DataContext context)
    {
        if (context.Students.Any() || context.Courses.Any()) return;
        
        // students
        var students = new List<Student>
        {
            new Student
            {
                Name = "Vasiliy",
                Surname = "Konov",
                Email = "vaskon@gmail.com",
                Courses = new List<Course>(),
            },
            new Student
            {
                Name = "Mikhail",
                Surname = "Tall",
                Email = "mih@gmail.com",
                Courses = new List<Course>(),

            },
            new Student
            {
                Name = "Andrey",
                Surname = "Ivanov",
                Email = "aniv@gmail.com",
                Courses = new List<Course>(),

            },
        };
        
        // courses
        var courses = new List<Course>()
        {
            new Course()
            {
                Title = "Frontend",
                Description = "Learn styling and create responsive user interfaces, " +
                              "powerful frameworks for web programming",
                StartDate = DateTime.UtcNow.AddMonths(-1),
                EndDate = DateTime.UtcNow.AddMonths(1),
                Students = new List<Student>()
                {
                    students[0],
                    students[1]
                }
            },
            new Course()
            {
                Title = "Backend",
                Description = "Learn how to design modern systems and services, refresh your knowledge of today's architectures, " +
                              "and explore principles of application design",
                StartDate = DateTime.UtcNow.AddMonths(-2),
                EndDate = DateTime.UtcNow.AddMonths(2),
                Students = new List<Student>()
                {
                    students[2]
                }
            },
        };

        await context.Students.AddRangeAsync(students);
        await context.Courses.AddRangeAsync(courses);
        await context.SaveChangesAsync();
    }
}