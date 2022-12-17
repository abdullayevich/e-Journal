using EJournal.Domain.Entities;
using EJournal.Service.Attirbutes;
using System.ComponentModel.DataAnnotations;

namespace EJournal.Service.Dtos
{
    public class StudentCreateDto
    {
        [Required,MaxLength(50),MinLength(2)]
        public string FullName { get; set; } = string.Empty;
        
        public string ImagePath { get; set; } = string.Empty;
        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required,StrongPassword(ErrorMessage = "Password must contain capital and small letter and number")]
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
