using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.Service.Helpers
{
    public class ImageHelper
    {
        public static string MakeUniqueImageName(string imageName)
        {
            string extension = Path.GetExtension(imageName);
            string name = "IMG_" + Guid.NewGuid().ToString();
            return name + extension; 
        }
    }
}
