using EJournal.Service.Helpers;
using EJournal.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.Service.Services
{
    public class FIleService : IFileService
    {
        private readonly string images = "Images";
        private readonly string rootpath;

        public FIleService(IWebHostEnvironment environment)
        {
            rootpath = environment.WebRootPath;
        }
        public async Task<string> SaveImageAsync(IFormFile filename)
        {
            string imageName = ImageHelper.MakeUniqueImageName(filename.FileName);
            string imagePath = Path.Combine(rootpath,images,imageName);
            var stream = new FileStream(imagePath, FileMode.Create);
            try
            {
                await stream.CopyToAsync(stream);
                return Path.Combine(images,imageName);


            }
            catch 
            {
                return "";
                
            }
            finally { stream.Close(); }
        }
    }
}
