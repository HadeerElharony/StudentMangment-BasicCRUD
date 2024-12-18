using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DAL.Entities;

namespace Test.DAL.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student,int>
    {
        Task<IEnumerable<Student>> GetStudentsWithCoursesAsync();
    }
}
