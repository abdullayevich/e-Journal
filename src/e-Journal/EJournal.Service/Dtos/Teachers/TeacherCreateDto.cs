using EJournal.Domain.Entities;
using EJournal.Service.Attirbutes;
using Microsoft.AspNetCore.Http;
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
        public IFormFile? ImagePath { get; set; }

        public static implicit operator Teacher(TeacherCreateDto dto)
        {
            return new Teacher()
            {
                FullName = dto.FullName,
                Email = dto.Email,
<<<<<<< HEAD:src/e-Journal/EJournal.Service/Dtos/Teachers/TeacherCreateDto.cs
                ImagePath = dto.ImagePath
=======
>>>>>>> 8f8bf2e (Add IFormFile):src/e-Journal/EJournal.Service/Dtos/TeacherCreateDto.cs
            };
        }
    }
}
