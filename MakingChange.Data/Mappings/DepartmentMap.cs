using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MakingChange.Data.Entities;

namespace MakingChange.Data.Mappings
{
    public class DepartmentMap : ClassMap<Department>
    {
        public DepartmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);

            //References(x => x.Leader);
            //References(x => x.Project);
            HasOne<Person>(x => x.Leader).PropertyRef(x => x.ShortName).ForeignKey("Person");
            HasOne<Project>(x => x.Project).PropertyRef(x => x.Name).ForeignKey("Project");

            HasMany(x => x.TaskList)
                .Cascade.All()
                .Inverse()
                .Table("Task");
        }
    }
}
