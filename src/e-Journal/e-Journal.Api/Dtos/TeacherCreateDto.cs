namespace e_Journal.Api.Dtos
{
    public class TeacherCreateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

    }
}
