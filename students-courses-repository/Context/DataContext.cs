using Microsoft.EntityFrameworkCore;
using Students.Courses.Entity.Models;

namespace Students.Courses.Repository.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    
    public DbSet<Course> Courses { get; set; }
}