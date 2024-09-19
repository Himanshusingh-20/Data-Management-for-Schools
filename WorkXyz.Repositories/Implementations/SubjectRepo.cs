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
    public class SubjectRepo : ISubjectRepo
    {
        private readonly ApplictaionDbContext _context;

        public SubjectRepo(ApplictaionDbContext context)
        {
        _context = context; 
        }

        public async Task Delete(int id)
        {
            var subject= await GetById(id);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subjects>> GetAll()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subjects> GetById(int id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Subjects subject)
        {
           await  _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Subjects subject)
        {
            _context.Subjects.Update(subject);
           await  _context.SaveChangesAsync();
        }
    }
}
