using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using MakingChange.Data.Entities;

namespace MakingChange.Data.Mappings
{
    public class TaskCandidateMap : ClassMap<TaskCandidate>
    {
        public TaskCandidateMap()
        {
            Id(x => x.Id);
            Map(x => x.Chosen);
            //References(x => x.Candidate);
            //References(x => x.Task);
            HasOne<Person>(x => x.Candidate).PropertyRef(x => x.ShortName).ForeignKey("Person");
            HasOne<Task>(x => x.Task).PropertyRef(x => x.Name).ForeignKey("Task");
        }
    }
}
