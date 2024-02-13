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

        try
        {
            _context.Database.BeginTransaction();
            var students = await _context.Students.ToListAsync();
            
            
            _context.Database.CommitTransaction();
            return students;
        }
        catch (Exception e)
        {
            _context.Database.RollbackTransaction();
            throw;
        }
    }

    public async Task<Student> GetStudent(Guid id)
    {
        return await _context.Students.FindAsync(id);
    }
}