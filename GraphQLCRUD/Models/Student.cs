﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }
    }
}
