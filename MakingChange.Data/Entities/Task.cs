using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingChange.Data.Entities
{
    public class Task
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual long Points { get; set; }
        public virtual Department Department { get; set; }
        public virtual Person Responsible { get; set; }
        public virtual IList<TaskCandidate> Candidates { get; set; }
        public virtual IList<TaskStatus> Statuses { get; set; }

        public Task()
        {
            Candidates = new List<TaskCandidate>();
            Statuses = new List<TaskStatus>();
        }

        public virtual void AddCandidate(TaskCandidate candidate)
        {
            candidate.Task = this;
            Candidates.Add(candidate);
        }

        public virtual void AddStatus(TaskStatus status)
        {
            status.Task = this;
            Statuses.Add(status);
        }
    }
}
