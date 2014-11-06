using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingChange.Data.Entities
{
    public class TaskStatus
    {
        public virtual long Id { get; set; }
        public virtual Task Task { get; set; }
        public virtual string Status { get; set; }
        public virtual double PercentComplete { get; set; }
        public virtual  DateTime Date { get; set; }
    }
}
