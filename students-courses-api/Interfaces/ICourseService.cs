using Students.Courses.Entity.Models;

namespace Students.Courses.Api.Interfaces;

public interface ICourseService
{
    public Task<IEnumerable<Course>> GetCourses();
    
    public Task<Course> GetCourse(Guid id);
}