using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingChange.Data.Entities
{
    public class TaskCandidate
    {
        public virtual long Id { get; set; }
        public virtual Task Task { get; set; }
        public virtual Person Candidate { get; set; }
        public virtual bool Chosen { get; set; }
    }
}
