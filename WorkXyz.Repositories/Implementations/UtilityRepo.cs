using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkXyz.Repositories.Interfaces;

namespace WorkXyz.Repositories.Implementations
{
    public class UtilityRepo : IUtilityRepo
    {
        private IWebHostEnvironment _evn;
        private IHttpContextAccessor _contextAccessor;

        public UtilityRepo(IWebHostEnvironment evn, IHttpContextAccessor contextAccessor)
        {
            _evn = evn;
            _contextAccessor = contextAccessor;
        }

        public Task DeleteFilePath(string filePath, string DirName)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return Task.CompletedTask;
            }
            var filename= Path.GetFileName(filePath);
            var completeFilePath = Path.Combine(_evn.WebRootPath, DirName, filename);
            if (File.Exists(completeFilePath))
            {
                File.Delete(completeFilePath);
            }
            return Task.CompletedTask;

        }

        public async Task<string> EditFilePath(string DirName, IFormFile file, string fullPath)
        {
            await DeleteFilePath(fullPath, DirName);
            return await SaveImagePath(DirName, file);
        }

        public async Task<string> SaveImagePath(string DirName, IFormFile file)
        {
            string dir = Path.Combine(_evn.WebRootPath, DirName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var extension = Path.GetExtension(file.FileName);
            var filename= $"{ Guid.NewGuid() }{extension}";
            string completeFilePath = Path.Combine(dir, filename);
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                await File.WriteAllBytesAsync(completeFilePath, content);
            }
            var basicPathUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var fullPathUrl= Path.Combine(basicPathUrl, DirName, filename).Replace("\\","/");
            return fullPathUrl;

        }
    }
}
