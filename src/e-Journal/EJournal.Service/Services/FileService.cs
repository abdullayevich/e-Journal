using EJournal.Service.Helpers;
using EJournal.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.Service.Services
{
    public class FileService : IFileService
    {
        private readonly string rootpath;
        private readonly string images = "Images";
        public FileService(IWebHostEnvironment environment)
        {
            rootpath = environment.WebRootPath;
        }
        public async Task<string> SaveImageAsync(IFormFile file)
        {
            string imageName = MakeImageName.MakeUniqueName(file.FileName);
            string imagePath = Path.Combine(rootpath,images, imageName);
            var stream = new FileStream(imagePath, FileMode.Create);
            try
            {
                await stream.CopyToAsync(stream);
                return Path.Combine(images, imageName);

            }
            catch 
            {

                return "";
            }
            finally { stream.Close(); }
        }
    }
}
