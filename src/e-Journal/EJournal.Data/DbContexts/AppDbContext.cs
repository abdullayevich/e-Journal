using EJournal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.DataAcces.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
                
        }
        public virtual DbSet<Teacher> Teachers { get; set; } = default!;
        public virtual DbSet<Student> Students { get; set; } = default!;
        public virtual DbSet<Attendance> Attendances { get; set; } = default!;
        public virtual DbSet<Group> Groups { get; set; } = default!;
        public virtual DbSet<StudentDetail> StudentDetails { get; set; } = default!;
    }
}
