﻿using MediatR;
using Students.Courses.Entity.Models;
using Students.Courses.Repository.Context;

namespace Students.Courses.Services.Students;

public class StudentDetails
{
    public class Query : IRequest<Student>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Student>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }
        
        public async Task<Student> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Students.FindAsync(request.Id);
        }
    }
}