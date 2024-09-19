using WorkXyz.Entities;
using WorkXyz.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkXyz.Repositories.Implementations
{
    public class BranchRepo : IBranchRepo
    {
        private readonly ApplictaionDbContext _context;

        public BranchRepo(ApplictaionDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            var branch = await GetById(id);
            _context.Branch.Remove(branch);
           await _context.SaveChangesAsync();        }

        public async Task<IEnumerable<Branch>> GetAll()
        {
            return await _context.Branch.ToListAsync();
        }

        public async Task<Branch> GetById(int id)
        {
           return await _context.Branch.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<int> Insert(Branch branch)
        {
            int result = 0;
            if (branch != null)
            {
                await _context.Branch.AddAsync(branch);
             result=   await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task Update(Branch branch)
        {
            _context.Branch.Update(branch);
          await _context.SaveChangesAsync();
        }
    }
}
