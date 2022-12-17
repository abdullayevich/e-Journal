using EJournal.Domain.Entities;
using System.Data;

namespace EJournal.Service.Dtos
{
    public class GroupCreateDto
    {
        public string GroupName { get; set; } =string.Empty;

        public string AssistantName { get; set; } = string.Empty;

        public int TotalStudent { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public int TeacherId { get; set; }

        public static implicit operator Group(GroupCreateDto dto)
        {
            return new Group()
            {
                GroupName =dto.GroupName,
                AssistantName =dto.AssistantName,
                TotalStudent = dto.TotalStudent,
                StartDate = dto.StartTime,
                EndDate = dto.EndTime,
                TeacherId = dto.TeacherId
            };

        }
    }
}
