using EJournal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.Service.ViewDtos
{
    public class TeacherViewDto
    {
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public static implicit operator TeacherViewDto(Teacher teacher)
        {
            return new TeacherViewDto
            {
                FullName = teacher.FullName,
                Email = teacher.Email
            };
        }
    }
}
