using EJournal.Domain.Entities;
using EJournal.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Interfaces
{
    public interface ITeacherService
    {
        public Task<IEnumerable<Teacher>> GetAllAsync();

        public Task<Teacher> GetAsync(long id);

        public Task<bool> CreateAsync(TeacherCreateDto obj); 

        public Task<bool> DeleteAsync(long id);

        public Task<bool> UpdateAsync(long id, Teacher obj);

    }
}
