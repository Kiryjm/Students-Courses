using AutoMapper;
using Students.Courses.Entity.Models;

namespace Students.Courses.Services.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Student, Student>();
    }
}