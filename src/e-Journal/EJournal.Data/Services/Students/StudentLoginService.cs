using EJournal.DataAcces.DbContexts;
using EJournal.DataAcces.Interfaces.Students;
using EJournal.Service.Attirbutes;
using EJournal.Service.Dtos.Students;
using EJournal.Service.Secruity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Services.Students
{
    public class StudentLoginService : IStudentLoginService
    {
        private readonly AppDbContext _appDbContext;
        public StudentLoginService(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<(bool isSuccessful, string Message)> LoginAsync(StudentLoginDto dto)
        {
            var student = await _appDbContext.Students.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (student is null) throw new Exception("Email is wrong!");
            else 
            {
                PasswordHasher passwordHasher = new PasswordHasher();
                var result = passwordHasher.Verify(dto.Password, student.Salt, student.PasswordHash);
                if (result) 
                {
                    IdentitySingelton.SaveId(student.Id);
                    return (true, "");
                } 
                else return (false, "Password is wrong!"); 
            }
        }
    }
}
