using e_Journal.Api.Secruity;
using EJournal.DataAcces.DbContexts;
using EJournal.DataAcces.Interfaces;
using EJournal.DataAcces.Interfaces.Teachers;
using EJournal.Domain.Entities;
using EJournal.Service.Dtos;
using EJournal.Service.Dtos.Teachers;
using EJournal.Service.Exceptions;
using EJournal.Service.Interfaces;
using EJournal.Service.ViewDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Services.Teachers
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IFileService fileService;
        public TeacherService(AppDbContext appDbContext,IFileService fileService)
        {
            this._appDbContext = appDbContext;
            this.fileService=fileService;
        }
        public async Task<bool> CreateAsync(TeacherCreateDto dto)
        {
            PasswordHasher hasher = new PasswordHasher();
            var entity = (Teacher)dto;
            var res = hasher.Hash(dto.Password);
            entity.Salt = res.salt;
            entity.PasswordHash = res.passwordHash;
            if(dto.ImagePath!= null)
            {
                entity.ImagePath = await fileService.SaveImageAsync(dto.ImagePath);
            }
            _appDbContext.Teachers.Add(entity);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var entity = await _appDbContext.Teachers.FindAsync(id);
            if (entity is not null)
            {
                _appDbContext.Teachers.Remove(entity);
                var result = await _appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new NotFoundException("Teacher not found!");
        }

        public async Task<IEnumerable<TeacherViewDto>> GetAllAsync()
        {
             var res = await _appDbContext.Teachers.OrderBy(x => x.Id)
                .AsNoTracking()
                .ToListAsync();
            return res.ConvertAll(x => (TeacherViewDto)x);
        }

        public async Task<Teacher> GetByIdAsync(long id)
        {
            var result = await _appDbContext.Teachers.FindAsync(id);
            if (result is null) throw new NotFoundException("Teacher not found!");
            else return result;
        }

        public async Task<bool> UpdateByIdAsync(long id, TeacherCreateDto dto) 
        {
            PasswordHasher hasher = new PasswordHasher();
            var entity = await _appDbContext.Teachers.FindAsync(id);
            var obj = (Teacher)dto;
            if (entity is not null)
            {
                _appDbContext.Entry(entity!).State = EntityState.Detached;
                obj.ImagePath = await fileService.SaveImageAsync(dto.ImagePath);
                var res = hasher.Hash(dto.Password);
                obj.PasswordHash = res.passwordHash;
                obj.Salt = res.salt;
                obj.Id = id;
                _appDbContext.Teachers.Update(obj);
                var result = await _appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new NotFoundException("Teacher not found!");
        }
    }
}
