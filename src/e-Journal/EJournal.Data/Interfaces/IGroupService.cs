using EJournal.Domain.Entities;
using EJournal.Service.Dtos;
using EJournal.Service.ViewDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Interfaces
{
    public interface IGroupService
    {
        public Task<IEnumerable<GroupViewDto>> GetAllAsync();

        public Task<Group> GetByIdAsync(long id);

        public Task<bool> CreateAsync(GroupCreateDto dto);

        public Task<bool> DeleteByIdAsync(long id);

        public Task<bool> UpdateByIdAsync(long id, Group obj); 
    }
}
