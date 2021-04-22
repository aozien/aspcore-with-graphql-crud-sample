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
    public class SubjectType : ObjectType<Subject>
    {
        protected override void Configure(IObjectTypeDescriptor<Subject> descriptor)
        {
            descriptor.Field(x => x.SubjectId).Type<IdType>();
            descriptor.Field(x => x.Name).Type<StringType>();
            descriptor.Field<StudentsResolver>(x => x.GetStudents(default,default));
        }
    }
    public class StudentsResolver
    {
        private readonly IStudentService _studentService;

        public StudentsResolver( [Service] IStudentService studentService )
        {
            _studentService = studentService;
        }
        public IEnumerable<Student> GetStudents(Subject subject, IResolverContext ctx) {

            return _studentService.GetAll().Where(x => x.SubjectId == subject.SubjectId);
        }
    }
}
