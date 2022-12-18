using EJournal.DataAcces.DbContexts;
using EJournal.DataAcces.Interfaces;
using EJournal.DataAcces.Interfaces.Teachers;
using EJournal.Domain.Entities;
using EJournal.Service.Dtos;
using EJournal.Service.Dtos.Teachers;
using EJournal.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Services
{
    public class GroupService : IGroupService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITeacherService teacherService;
        public GroupService(AppDbContext appDbContext, ITeacherService teacherService) 
        {
            this._appDbContext = appDbContext;
            this.teacherService = teacherService;
        }
        public async Task<bool> CreateAsync(GroupCreateDto dto)
        {
            var entity = (Group)dto;
            _appDbContext.Groups.Add(entity);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var entity = await _appDbContext.Groups.FindAsync(id);
            if (entity is not null)
            {
                _appDbContext.Groups.Remove(entity);
                var result = await _appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new NotFoundException("Group not found!");
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            var res = await _appDbContext.Groups.OrderBy(x => x.Id).Include(x=>x.Teacher)
                .AsNoTracking()
                .ToListAsync();
            
            return res;
        }

        public async Task<Group> GetByIdAsync(long id)
        {
            var result = await _appDbContext.Groups.FindAsync(id);
            if (result is null) throw new NotFoundException("Group not found!");
            else return result;
        }

        public async Task<bool> UpdateByIdAsync(long id, Group obj)
        {
            var entity = await _appDbContext.Groups.FindAsync(id);
            _appDbContext.Entry<Group>(entity!).State = EntityState.Detached;
            if (entity is not null)
            {
                obj.Id = id;
                _appDbContext.Groups.Update(obj);
                var result = await _appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new NotFoundException("Group not found!");
        }
    }
}
