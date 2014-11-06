using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingChange.Data.Entities
{
    public class Project
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Person Manager { get; set; }
        public virtual IList<Department> Departments { get; set; }

        public Project()
        {
            Departments = new List<Department>();
        }

        public virtual void AddDepartment(Department department)
        {
            department.Project = this;
            Departments.Add(department);
        }
    }
}
