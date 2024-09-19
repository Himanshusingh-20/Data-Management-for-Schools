using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkXyz.Entities;
using WorkXyz.Repositories.Interfaces;

namespace WorkXyz.Repositories.Implementations
{
    public class TeacherRepo : ITeacherRepo
    {
        private readonly ApplictaionDbContext _context;
        public TeacherRepo(ApplictaionDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            var teacher= await GetById(id);
             _context.Teachers.Remove( teacher);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetById(int id)
        {
            return await _context.Teachers.Include(y=>y.TeacherSubjects).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Teacher teacher)
        {
          await  _context.Teachers.AddAsync(teacher);
           await _context.SaveChangesAsync();
        }

        public async Task Update(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
           await _context.SaveChangesAsync();
        }
    }
}
