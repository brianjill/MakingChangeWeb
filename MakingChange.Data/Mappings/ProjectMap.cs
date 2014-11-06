using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MakingChange.Data.Entities;

namespace MakingChange.Data.Mappings
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            
            References(x => x.Manager);

            HasMany(x => x.Departments)
                .Cascade.All()
                .Inverse()
                .Table("Department");

        }
    }
}
