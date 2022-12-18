using EJournal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.Service.ViewDtos
{
    public class GroupViewDto
    {
        public string GroupName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string AssistantName { get; set; } = string.Empty;
        public int TotalStudent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TeacherViewDto? Teacher { get; set; }

        public static implicit operator GroupViewDto(Group group)
        {
            return new GroupViewDto
            {
                GroupName = group.GroupName,
                Status = group.Status,
                AssistantName = group.AssistantName,
                TotalStudent = group.TotalStudent,
                StartDate = group.StartDate,
                EndDate = group.EndDate,
                Teacher = (TeacherViewDto)group.Teacher!,
            };
        }
    }
}
