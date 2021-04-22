using GraphQLCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD.Services.Interfaces
{
    public interface IClassificationService
    {
        IQueryable<Classification> GetAll();
    }
}
