using GraphQLCRUD.Models;
using GraphQLCRUD.Services.Interfaces;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD.GraphQL.Types
{
    public class StudentType: ObjectType<Student>
    {
        protected override void Configure(IObjectTypeDescriptor<Student> descriptor)
        {
            descriptor.Field(x => x.StudentId).Type<IdType>();
            descriptor.Field(x => x.Name).Type<StringType>();
            descriptor.Field<SubjectsResolver>(x => x.GetSubjects(default, default));
        }
    }
    public class SubjectsResolver
    {
        private readonly ISubjectService _subjectService;

        public SubjectsResolver([Service] ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        public IEnumerable<Subject> GetSubjects(Subject subject, IResolverContext ctx)
        {

            return _subjectService.GetAll().Where(x => x.SubjectId == subject.SubjectId);
        }
    }

}
