﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MakingChange.Data.Entities;
using FluentNHibernate.Mapping;

namespace MakingChange.Data.Mappings
{
    public class TaskMap : ClassMap<Task>
    {
        public TaskMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Points);

            //References(x => x.Department);
            //References(x => x.Responsible);
            HasOne<Person>(x => x.Responsible).PropertyRef(x => x.ShortName).ForeignKey("Person");
            HasOne<Department>(x => x.Department).PropertyRef(x => x.Name).ForeignKey("Department");

            HasMany(x => x.Candidates)
                .Cascade.All()
                .Inverse()
                .Table("TaskCandidate");

            HasMany(x => x.Statuses)
                .Cascade.All()
                .Inverse()
                .Table("TaskStatus");
        }
    }
}
