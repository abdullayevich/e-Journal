using System.Data;

namespace e_Journal.Api.Dtos
{
    public class GroupCreateDto
    {
        public string GroupName { get; set; } =string.Empty;
        public string AssistantName { get; set; } = string.Empty;
        public int TotalStudent { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TeacherId { get; set; }
    }
}
