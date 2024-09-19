using WorkXyz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkXyz.Repositories.Interfaces
{
    public interface IBranchRepo
    {
       Task< IEnumerable<Branch>> GetAll();
       Task< Branch> GetById(int id);
        Task Update(Branch branch);
        Task<int> Insert(Branch branch);
        Task Delete(int id);

    }
}
