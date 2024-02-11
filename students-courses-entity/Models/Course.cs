using Students.Courses.Entity.Models.Base;

namespace Students.Courses.Entity.Models;

public class Course : Model
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
}