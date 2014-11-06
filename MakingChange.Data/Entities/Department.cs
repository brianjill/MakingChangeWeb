using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingChange.Data.Entities
{
    public class Department
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }

        public virtual Project Project { get; set; }
        public virtual Person Leader { get; set; }
        public virtual IList<Task> TaskList { get; set; }

        public Department()
        {
            TaskList = new List<Task>();
        }

        public virtual void AddTask(Task task)
        {
            task.Department = this;
            TaskList.Add(task);
        }
    }
}
