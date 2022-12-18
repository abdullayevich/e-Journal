﻿using EJournal.Domain.Entities;
using EJournal.Service.Attirbutes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EJournal.Service.Dtos
{
    public class StudentCreateDto
    {
        [Required,MaxLength(50),MinLength(2)]
        public string FullName { get; set; } = string.Empty;
        
        public IFormFile? ImagePath { get; set; }
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
                Email = dto.Email,
                GroupId = dto.GroupId
            }; 
        }
    }
}
