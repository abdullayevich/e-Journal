using EJournal.Domain.Entities;
using EJournal.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Interfaces
{
    public interface IStudentsService
    {
        public Task<IEnumerable<StudentCreateDto>> GetAllAsync();

        public Task<StudentCreateDto> GetAsync(long id);

        public Task<bool> CreateAsync(StudentCreateDto dto);

        public Task<bool> DeleteAsync(long id);

        public Task<bool> UpdateAsync(long id, StudentCreateDto dto); 
    }
}
