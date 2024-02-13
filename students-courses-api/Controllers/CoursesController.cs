using Microsoft.AspNetCore.Mvc;
using Students.Courses.Api.Interfaces;
using Students.Courses.Entity.Models;

namespace Students.Courses.Api.Controllers;

[Route("courses")]
public class CoursesController : BaseApiController
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _courseService.GetCourses();
        
        return Ok(students.ToList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(Guid id)
    {
        var student = await _courseService.GetCourse(id);

        return Ok(student);
    }
}