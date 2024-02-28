using MediatR;
using Microsoft.EntityFrameworkCore;
using Students.Courses.Entity.Models;
using Students.Courses.Repository.Context;

namespace Students.Courses.Services.Students;

public class StudentsList
{
    public class Query : IRequest<List<Student>> {}

    public class Handler : IRequestHandler<Query, List<Student>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Students.ToListAsync();
        }
    }
}