using GraphQLCRUD.Models;
using GraphQLCRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private IList<Subject> _subjects;
        public SubjectService()
        {
            _subjects = new List<Subject> {
                new Subject (){SubjectId =1 , Name= "Math"  },
                new Subject (){SubjectId =2 , Name= "Physics"  },
                new Subject (){SubjectId =3 , Name= "Chemistry"  },
                new Subject (){SubjectId =4 , Name= "History"  },
                new Subject (){SubjectId =5 , Name= "Geography"  },
                new Subject (){SubjectId =6 , Name= "Music"  },
            };
        }
        public IQueryable<Subject> GetAll()
        {
            return _subjects.AsQueryable(); 
        }
    }
}
