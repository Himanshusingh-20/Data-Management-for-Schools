using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkXyz.Entities;

namespace WorkXyz.Repositories.Interfaces
{
    public interface IUserRepo
    {
        Task Register(UserInfo userInfo);
        Task<UserInfo> Login(string username, string password);


    }
}
  