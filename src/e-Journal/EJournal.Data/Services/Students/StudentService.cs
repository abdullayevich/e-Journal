using e_Journal.Api.Secruity;
using EJournal.DataAcces.DbContexts;
using EJournal.DataAcces.Interfaces;
using EJournal.DataAcces.Interfaces.Students;
using EJournal.Domain.Entities;
using EJournal.Service.Dtos.Students;
using EJournal.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _appDbContext;
        public StudentService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CreateAsync(StudentCreateDto dto)
        {
            PasswordHasher hasher = new PasswordHasher();
            var entity = (Student)dto;
            var res = hasher.Hash(dto.Password);
            entity.Salt = res.salt;
            entity.PasswordHash = res.passwordHash;
            _appDbContext.Students.Add(entity);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var entity = await _appDbContext.Students.FindAsync(id);
            if (entity is not null)
            {
                _appDbContext.Students.Remove(entity);
                var result = await _appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new NotFoundException("Student not found!");
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _appDbContext.Students.OrderBy(x => x.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(long id)
        {
            var result = await _appDbContext.Students.FindAsync(id);
            if (result is null) return new Student();
            else throw new NotFoundException("Student not found!");
        }

        public async Task<bool> UpdateByIdAsync(long id, Student obj)
        {
            var entity = await _appDbContext.Students.FindAsync(id);
            _appDbContext.Entry(entity!).State = EntityState.Detached;
            if (entity is not null)
            {
                obj.Id = id;
                _appDbContext.Students.Update(obj);
                var result = await _appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new NotFoundException("Student not found!");
        }
    }
}
