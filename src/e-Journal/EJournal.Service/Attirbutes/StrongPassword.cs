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
            string password = value!.ToString()!;
            if (password is null) return false;
            else
            {
                if (password.Length < 8)
                    return false;
                else if (password.Length > 50)
                    return false;

                bool isDigit = password.Any(x => char.IsDigit(x));
                bool isLower = password.Any(x => char.IsLower(x));
                bool isUpper = password.Any(x => char.IsUpper(x));

                if (!isLower)
                    return false;
                if (!isUpper)
                    return false;
                if (!isDigit)
                    return false;
                return true;
            }
        }
    }
}
