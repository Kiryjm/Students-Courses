using MediatR;
using Students.Courses.Entity.Models;
using Students.Courses.Repository.Context;

namespace Students.Courses.Services.Students;

public class CreateStudent
{
    public class Command : IRequest
    {
        public Student Student { get; set; }
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
            _context.Students.Add(request.Student);

            await _context.SaveChangesAsync();
        }
    }
}