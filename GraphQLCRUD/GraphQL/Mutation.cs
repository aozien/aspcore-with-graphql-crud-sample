using GraphQLCRUD.DTO;
using GraphQLCRUD.Models;
using GraphQLCRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD.GraphQL
{
    public class Mutation
    {
        private readonly IStudentService _studentService;

        public Mutation(IStudentService studentService )
        {
            _studentService = studentService;
        }

        public Student CreateStudent(CreateStudentDTO createDTO) {
            return _studentService.Create(createDTO);
        }
        public Student DeleteStudent(DeleteStudentDTO deleteDTO){
            return _studentService.Delete(deleteDTO);
        }
    }
}
