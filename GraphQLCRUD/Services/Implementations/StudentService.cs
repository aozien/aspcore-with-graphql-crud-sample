using GraphQLCRUD.DTO;
using GraphQLCRUD.Exceptions;
using GraphQLCRUD.Models;
using GraphQLCRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private IList<Student> _students;
        private int _lastId => _students.Max(a => a.StudentId);
        public StudentService()
        {
            _students = new List<Student> {
                new Student (){StudentId =1 , Name= "Marko " , SubjectId=1 },
                new Student (){StudentId =2 , Name= "Polo" , SubjectId=2 },
                new Student (){StudentId =3 , Name= "Nader" , SubjectId=3 },
                new Student (){StudentId =4 , Name= "Ali" , SubjectId=1 },
                new Student (){StudentId =5 , Name= "James" , SubjectId=2 },
                new Student (){StudentId =6 , Name= "Ahmed", SubjectId=5 },
            };
        }

        public Student Create(CreateStudentDTO createDTO)
        {
            var newStudent = new Student
            {
                Name= createDTO.Name,
                StudentId = _lastId + 1
            };
            _students.Add(newStudent);
            return newStudent;
        }

        public Student Delete(DeleteStudentDTO deleteDTO)
        {
            var student = _students.FirstOrDefault(x => x.StudentId == deleteDTO.StudentId);
            if (student == null) throw new StudentNotFoundException(){  StudentId = deleteDTO.StudentId };
            
            _students.Remove(student);
            return student;
        }

        public IQueryable<Student> GetAll()
        {
            return _students.AsQueryable(); 
        }
    }
}
