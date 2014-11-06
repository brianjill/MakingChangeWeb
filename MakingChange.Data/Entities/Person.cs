using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingChange.Data.Entities
{
    public class Person
    {
        public virtual long Id { get; set; }
        public virtual string ShortName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Type { get; set; }
        public virtual Project Project { get; set; } //if not null, it means this person is manager
        public virtual Department Department { get; set; }  //if not null, it means this person is department leader
        public virtual IList<Task> Tasks { get; set; } //if not null, it means this person is either member or volunteer
        public virtual IList<TaskCandidate> TaskSignUp { get; set; } //if not null, it means this person is either member or volunteer
    }
}
