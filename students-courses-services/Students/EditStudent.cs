using MediatR;
using Students.Courses.Entity.Models;
using Students.Courses.Repository.Context;

namespace Students.Courses.Services.Students;

public class EditStudent
{
    public class Command : IRequest
    {
        public Student Student;
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }
        
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(request.Student.Id);

            student.Name = request.Student.Name ?? student.Name;

            await _context.SaveChangesAsync();
        }
    }
}