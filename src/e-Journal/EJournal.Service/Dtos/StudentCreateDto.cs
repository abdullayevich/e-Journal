using EJournal.Domain.Entities;

namespace EJournal.Service.Dtos
{
    public class StudentCreateDto
    {
        public string FullName { get; set; } = string.Empty;
        
        public string ImagePath { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        
        public string Password { get; set; } = string.Empty;
        
        public int GroupId { get; set; }

        public static implicit operator Student(StudentCreateDto dto) 
        { 
            return new Student()
            {
                FullName = dto.FullName,
                ImagePath = dto.ImagePath,
                Email = dto.Email,
                GroupId = dto.GroupId
            }; 
        }
    }
}
