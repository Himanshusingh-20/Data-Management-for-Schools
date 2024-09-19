using Microsoft.EntityFrameworkCore;
using WorkXyz.Entities;
using WorkXyz.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkXyz.Repositories.Implementations
{
    public class StudentNewRepo : IStudentNewRepo
    {
        private readonly ApplictaionDbContext _context;

        public StudentNewRepo(ApplictaionDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var studentsNew= await GetById(id);
            _context.StudentsNew.Remove(studentsNew);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StudentsNew>> GetAll()
        {
            return await _context.StudentsNew.Include(x => x.Branch).ToListAsync(); ;
        }

        public async Task<StudentsNew> GetById(int id)
        {
            return await _context.StudentsNew.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task Insert(StudentsNew studentsNew)
        {
           await _context.StudentsNew.AddAsync(studentsNew);
            await _context.SaveChangesAsync();

        }

        public async Task Update(StudentsNew studentsNew)
        {
            _context.StudentsNew.Update(studentsNew);
           await _context.SaveChangesAsync();
        }
    }
}
