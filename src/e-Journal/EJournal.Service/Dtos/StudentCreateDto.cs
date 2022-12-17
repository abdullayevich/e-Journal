namespace EJournal.Service.Dtos
{
    public class StudentCreateDto
    {
        public string FullName { get; set; } = string.Empty;
        
        public string ImagePath { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        
        public string Password { get; set; } = string.Empty;
        
        public int GroupId { get; set; } 
    }
}
