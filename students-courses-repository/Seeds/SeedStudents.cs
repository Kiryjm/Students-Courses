using System.Diagnostics;
using Students.Courses.Entity.Models;
using Students.Courses.Repository.Context;

namespace Students.Courses.Repository.Seeds;

public class Seed
{
    public static async Task SeedStudents(DataContext context)
        {
            if (context.Students.Any()) return;
            
            var students = new List<Student>
            {
                new Student
                {
                    Name = "Vasiliy",
                    Surname = "Konov",
                    Email = "vaskon@gmail.com",
                    // Courses = new List<Course>()
                    // {
                    //     new Course()
                    //     {
                    //         Title = "Frontend",
                    //         Description = "Learn styling and create responsive user interfaces, " +
                    //                       "powerful frameworks for web programming",
                    //         StartDate = DateTime.Today,
                    //         EndDate = DateTime.UtcNow.AddMonths(3)
                    //     }
                    // }
                },
                new Student
                {
                    Name = "Mikhail",
                    Surname = "Tall",
                    Email = "mih@gmail.com",
                },
                new Student
                {
                    Name = "Andrey",
                    Surname = "Ivanov",
                    Email = "aniv@gmail.com",
                },
            };

            await context.Students.AddRangeAsync(students);
            await context.SaveChangesAsync();
        }
}