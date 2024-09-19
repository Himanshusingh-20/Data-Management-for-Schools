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
    public class UserRepo : IUserRepo
    {
        private ApplictaionDbContext _context;

        public UserRepo(ApplictaionDbContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> Login(string username, string password)
        {

            return await _context.UserInfos.FirstOrDefaultAsync(x => x.UserName.ToLower() == username && x.Password == password);
        }

        public async Task Register(UserInfo userInfo)
        {
           await  _context.UserInfos.AddAsync(userInfo);
           await _context.SaveChangesAsync();
        }
    }
}
