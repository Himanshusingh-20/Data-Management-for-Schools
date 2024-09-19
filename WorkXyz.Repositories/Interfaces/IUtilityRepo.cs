using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkXyz.Repositories.Interfaces
{
    public interface IUtilityRepo
    {
        Task <string>SaveImagePath(string DirName, IFormFile file);
        Task<string> EditFilePath(string DirName, IFormFile file, string fullPath);
        Task DeleteFilePath(string filePath, string DirName);

    }
}
