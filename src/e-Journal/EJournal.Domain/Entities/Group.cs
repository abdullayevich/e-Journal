using EJournal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.Domain.Entities;

public class Group : BaseEntity
{
    public string GroupName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string AssistantName { get; set; } = string.Empty;
    public int TotalStudent { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Teacher? Teacher { get; set; }
    public long TeacherId { get; set; }
}