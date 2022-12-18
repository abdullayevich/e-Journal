using EJournal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.Service.ViewDtos
{
    public class StudentViewDto
    {
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public GroupViewDto? Group { get; set; }

        public static implicit operator StudentViewDto(Student student)
        {
            return new StudentViewDto
            {
                FullName = student.FullName,
                Email = student.Email,
                Group = (GroupViewDto)student.Group!,
            };
        }
    }
}
