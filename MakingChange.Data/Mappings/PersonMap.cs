using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MakingChange.Data.Entities;

namespace MakingChange.Data.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id);
            Map(x => x.ShortName);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Type);

            References(x => x.Project);
            References(x => x.Department);

            HasMany(x => x.Tasks)
                .Cascade.All()
                .Inverse()
                .Table("Task");

            HasMany(x => x.TaskSignUp)
                .Cascade.All()
                .Inverse()
                .Table("TaskCandidate");

        }
    }
}
