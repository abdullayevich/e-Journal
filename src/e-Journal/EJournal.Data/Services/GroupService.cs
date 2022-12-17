using EJournal.DataAcces.DbContexts;
using EJournal.DataAcces.Interfaces;
using EJournal.Domain.Entities;
using EJournal.Service.Dtos;
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
        public GroupService(AppDbContext appDbContext) 
        {
            this._appDbContext = appDbContext;
        }
        public async Task<bool> CreateAsync(GroupCreateDto dto)
        {
            var entity = (Group)dto;
            _appDbContext.Groups.Add(entity);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _appDbContext.Groups.FindAsync(id);
            if (entity is not null)
            {
                _appDbContext.Groups.Remove(entity);
                var result = await _appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else { return false; }
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _appDbContext.Groups.OrderBy(x => x.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Group> GetAsync(long id)
        {
            var result = await _appDbContext.Groups.FindAsync(id);
            if (result is null) return new Group();
            else return result;
        }

        public async Task<bool> UpdateAsync(long id, Group obj)
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
            else return false;
        }
    }
}
