using EJournal.Service.Dtos.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Interfaces.Students
{
    public interface IStudentLoginService
    {
        public Task<(bool isSuccessful, string Message)> LoginAsync(StudentLoginDto dto);
    }
}
