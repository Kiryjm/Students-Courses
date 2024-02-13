using Microsoft.EntityFrameworkCore;
using Students.Courses.Api.Interfaces;
using Students.Courses.Entity.Models;
using Students.Courses.Repository.Context;

namespace Students.Courses.Api.Services;

public class CourseService : ICourseService
{
    
    private readonly DataContext _context;

    public CourseService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetCourses()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<Course> GetCourse(Guid id)
    {
        return await _context.Courses.FindAsync(id);
    }
}