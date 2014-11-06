using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MakingChange.Data.Entities;
using FluentNHibernate.Mapping;

namespace MakingChange.Data.Mappings
{
    public class TaskStatusMap : ClassMap<TaskStatus>
    {
        public TaskStatusMap()
        {
            Id(x => x.Id);
            Map(x => x.Status);
            Map(x => x.PercentComplete);
            Map(x => x.Date);
            References(x => x.Task);
        }
    }
}
