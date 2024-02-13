using Students.Courses.Entity.Models;

namespace Students.Courses.Api.Interfaces;

public interface IStudentService
{
    public Task<IEnumerable<Student>> GetStudents();
    
    public Task<Student> GetStudent(Guid id);
}