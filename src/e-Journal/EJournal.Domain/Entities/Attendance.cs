using EJournal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournal.Domain.Entities;

public class Attendance : BaseEntity
{
    public bool IsAttent { get; set; }
    public Group? Group { get; set; }
    public int GroupId { get; set; }
}
