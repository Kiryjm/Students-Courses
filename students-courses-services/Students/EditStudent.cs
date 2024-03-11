using AutoMapper;
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
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(request.Student.Id);

            if (student is null)
            {
                throw new InvalidOperationException("Student was not found");
            }

            _mapper.Map(request.Student, student);

            await _context.SaveChangesAsync();
        }
    }
}