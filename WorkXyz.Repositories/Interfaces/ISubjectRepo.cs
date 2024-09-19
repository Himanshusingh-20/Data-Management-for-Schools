using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkXyz.Entities;

namespace WorkXyz.Repositories.Interfaces
{
    public interface ISubjectRepo
    {
       Task< IEnumerable<Subjects>> GetAll();
        Task<Subjects> GetById(int id);
        Task Insert(Subjects subject);
        Task Update(Subjects subject);
        Task Delete(int id);

    }
}
