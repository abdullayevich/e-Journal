using EJournal.DataAcces.DbContexts;
using EJournal.DataAcces.Interfaces;
using EJournal.Domain.Entities;
using EJournal.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            throw new NotImplementedException(); 
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeacherCreateDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TeacherCreateDto> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(long id, TeacherCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
