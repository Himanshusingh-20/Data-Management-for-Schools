using WorkXyz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkXyz.Repositories.Interfaces
{
    public interface IStudentNewRepo
    {
      Task<  IEnumerable<StudentsNew>> GetAll();
       Task< StudentsNew> GetById(int id);
        Task Insert(StudentsNew studentsNew);
        Task Update(StudentsNew studentsNew);
        Task Delete(int id);
    }
}
