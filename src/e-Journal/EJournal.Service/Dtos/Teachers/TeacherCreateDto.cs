using EJournal.Domain.Entities;
using EJournal.Service.Attirbutes;
using System.ComponentModel.DataAnnotations;


namespace EJournal.Service.Dtos.Teachers
{
    public class TeacherCreateDto
    {
        [Required, MinLength(2), MaxLength(50)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required, StrongPassword]
        public string Password { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        public static implicit operator Teacher(TeacherCreateDto dto)
        {
            return new Teacher()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                ImagePath = dto.ImagePath
            };
        }
    }
}
