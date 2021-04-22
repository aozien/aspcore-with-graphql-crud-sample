using GraphQLCRUD.DTO;
using GraphQLCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD.Services.Interfaces
{
    public interface IStudentService
    {
        IQueryable<Student> GetAll();

        Student Create(CreateStudentDTO createDTO);
        Student Delete(DeleteStudentDTO deleteDTO);
    }
}
