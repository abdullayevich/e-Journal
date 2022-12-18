using EJournal.Domain.Entities;
using EJournal.Service.Dtos;
using EJournal.Service.Dtos.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.Interfaces.Students;

public interface IStudentService
{
    public Task<IEnumerable<Student>> GetAllAsync();

    public Task<Student> GetByIdAsync(long id);

    public Task<bool> CreateAsync(StudentCreateDto dto);

    public Task<bool> DeleteByIdAsync(long id);

    public Task<bool> UpdateByIdAsync(long id, StudentCreateDto dto);  
}
