using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD.Models
{
    public class Classification
    {
        public int ClassificationId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
