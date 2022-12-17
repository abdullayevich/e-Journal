using EJournal.DataAcces.DbContexts;
using EJournal.DataAcces.Interfaces;
using EJournal.Domain.Entities;
using EJournal.Service.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _appDbContext;
        public TeacherService(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<bool> CreateAsync(TeacherCreateDto dto)
        {
            var entity = (Teacher)dto;
            _appDbContext.Teachers.Add(entity);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _appDbContext.Teachers.FindAsync(id);
            if(entity is not null)
            {
                _appDbContext.Teachers.Remove(entity);
                var result = await _appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else { return false; }
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _appDbContext.Teachers.OrderBy(x => x.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Teacher> GetAsync(long id)
        {
            var result = await _appDbContext.Teachers.FindAsync(id);
            if (result is null) return new Teacher();
            else return result;
        }

        public async Task<bool> UpdateAsync(long id, Teacher obj) 
        {
            var entity = await _appDbContext.Teachers.FindAsync(id);
            _appDbContext.Entry<Teacher>(entity!).State = EntityState.Detached;
            if (entity is not null)
            {
                obj.Id = id;
                _appDbContext.Teachers.Update(obj);
                var result = await _appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else return false;
        }
    }
}
