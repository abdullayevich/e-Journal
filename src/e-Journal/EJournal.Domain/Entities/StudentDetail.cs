using EJournal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.Domain.Entities;

public class StudentDetail : BaseEntity
{
    public double HomeWorkMark { get; set; }
    public double ExamResult { get; set; }
    public double TotalResult { get; set; }
    public Student? Student { get; set; }
    public long StudentId { get; set; }
}
