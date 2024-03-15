using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Courses.Api.Interfaces;
using Students.Courses.Entity.Models;
using Students.Courses.Repository.Context;
using Students.Courses.Services.Students;

namespace Students.Courses.Api.Controllers;

[Route("students")]
public class StudentsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await Mediator.Send(new StudentsList.Query());
        
        return Ok(students.ToList());
    }

    [HttpGet("{id}")]
    public async ValueTask<ActionResult<Student>> GetStudent(Guid id)
    {
        return await Mediator.Send(new StudentDetails.Query { Id = id });
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(Student student)
    {
        await Mediator.Send(new CreateStudent.Command { Student = student });
        
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditStudent(Guid id, Student student)
    {
        student.Id = id;
        await Mediator.Send(new EditStudent.Command { Student = student });

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        await Mediator.Send(new DeleteStudents.Command { Id = id });

        return Ok();
    }
}