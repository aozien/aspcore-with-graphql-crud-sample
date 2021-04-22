using GraphQLCRUD.GraphQL.Types;
using GraphQLCRUD.Models;
using GraphQLCRUD.Services.Interfaces;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD.GraphQL
{
    public class Query
    {
        private readonly ISubjectService _subjectService;
        private readonly IStudentService _studentService;
        private readonly IClassificationService _classificationService;

        public Query(ISubjectService subjectService,
                     IStudentService studentService,
                     IClassificationService classificationService)
        {
            _subjectService = subjectService;
            _studentService = studentService;
            _classificationService = classificationService;
        }
        [UsePaging(typeof(SubjectType))]
        [UseFiltering]
        public IQueryable<Subject> Subjects => _subjectService.GetAll();
        [UsePaging(typeof(StudentType))]
        [UseFiltering]
        public IQueryable<Student> Students => _studentService.GetAll();
    }
}
