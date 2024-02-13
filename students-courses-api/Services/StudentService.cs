using Microsoft.EntityFrameworkCore;
using Students.Courses.Api.Interfaces;
using Students.Courses.Entity.Models;
using Students.Courses.Repository.Context;

namespace Students.Courses.Api.Services;

public class StudentService : IStudentService
{
    
    private readonly DataContext _context;

    public StudentService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetStudents()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student> GetStudent(Guid id)
    {
        return await _context.Students.FindAsync(id);
    }
}