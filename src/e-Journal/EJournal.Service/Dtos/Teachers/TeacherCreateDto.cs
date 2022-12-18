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
            };
        }
    }
}
