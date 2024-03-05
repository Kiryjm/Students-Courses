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
    public async Task<ActionResult<Student>> GetStudent(Guid id)
    {
        return await Mediator.Send(new StudentDetails.Query { Id = id });
    }
}