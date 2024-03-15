using MediatR;
using Students.Courses.Repository.Context;

namespace Students.Courses.Services.Students;

public class DeleteStudents
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
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
            var student = await _context.Students.FindAsync(request.Id);
            _context.Remove(student);

            await _context.SaveChangesAsync();
        }
    }
}