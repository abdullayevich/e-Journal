using EJournal.DataAcces.DbContexts;
using EJournal.DataAcces.Interfaces.Teachers;
using EJournal.Service.Attirbutes;
using EJournal.Service.Dtos.Teachers;
using EJournal.Service.Secruity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Services.Teachers
{
    public class TeacherLoginAsync : ITeacherLoginService
    {
        private readonly AppDbContext _appDbContext;
        public TeacherLoginAsync(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<(bool isSuccessful, string message)> LoginAsync(TeacherLoginDto dto)
        {
            var teacher = await _appDbContext.Teachers.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (teacher is null) throw new Exception("Email is wrong");
            else
            {
                PasswordHasher passwordHasher = new PasswordHasher();
                var result = passwordHasher.Verify(dto.Password, teacher.Salt, teacher.PasswordHash);
                if (result)
                {
                    IdentitySingelton.SaveId(teacher.Id);
                    return (true, "");
                }
                else return (false, "Password is wrong!");
            }
        }
    }
}
