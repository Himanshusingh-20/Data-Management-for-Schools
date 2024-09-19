using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkXyz.Entities;

namespace WorkXyz.Repositories.Interfaces
{
    public interface ITeacherRepo
    {
        Task<IEnumerable<Teacher>> GetAll();
        Task<Teacher> GetById(int id);
        Task Insert(Teacher teacher);   
        Task Update(Teacher teacher);
        Task Delete(int id);


    }
}
