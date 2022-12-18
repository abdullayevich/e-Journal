using EJournal.Service.Dtos.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Interfaces.Teachers
{
    public interface ITeacherLoginService
    {
        public Task<(bool isSuccessful, string message)> LoginAsync(TeacherLoginDto dto);
    }
}
