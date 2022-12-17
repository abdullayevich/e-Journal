using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.Service.Attirbutes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StrongPassword : ValidationAttribute
    {
        public StrongPassword()
        {

        }
        public override bool IsValid(object? value)
        {
            string passwd = value as string;
            if (passwd.Length < 8 || passwd.Length > 14 && !passwd.Any(char.IsLower)
                && passwd.Contains(" ") && !passwd.Any(char.IsUpper))
            {
                return false;
            }
            else return true;
        }
    }
}
