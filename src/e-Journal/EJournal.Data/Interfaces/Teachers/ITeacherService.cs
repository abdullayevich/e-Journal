using EJournal.Domain.Entities;
using EJournal.Service.Dtos;
using EJournal.Service.Dtos.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Interfaces.Teachers
{
    public interface ITeacherService
    {
        public Task<IEnumerable<Teacher>> GetAllAsync();

        public Task<Teacher> GetByIdAsync(long id);

        public Task<bool> CreateAsync(TeacherCreateDto obj);

        public Task<bool> DeleteByIdAsync(long id);

        public Task<bool> UpdateByIdAsync(long id, Teacher obj);

    }
}
