using EJournal.Domain.Entities;

namespace EJournal.Service.Dtos
{
    public class TeacherCreateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        public static implicit operator Teacher(TeacherCreateDto dto)
        {
            return new Teacher()
            {
                FullName = dto.FullName,
                Email = dto.email,
                ImagePath= dto.ImagePath
            };
        }
    }
}
