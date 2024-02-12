using Students.Courses.Entity.Models.Base;

namespace Students.Courses.Entity.Models;

public class Student : Model
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Email { get; set; }
    
    public ICollection<Course> Courses { get; set; }
}