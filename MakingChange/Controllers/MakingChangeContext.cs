using Breeze.ContextProvider.NH;
using MakingChange.Data;
using MakingChange.Data.Entities;

namespace MakingChange.Controllers
{
    public class MakingChangeContext : NHContext
    {
        //public MakingChangeContext() : base(NHConfig.OpenSession(), NHConfig.Configuration) { }
        public MakingChangeContext()
            : base(FnhConfig.OpenSession())
        {
            
        }

        public MakingChangeContext Context
        {
            get { return this; }
        }
        public NhQueryableInclude<Project> Projects
        {
            get { return GetQuery<Project>(); }
        }
        public NhQueryableInclude<Department> Departments
        {
            get { return GetQuery<Department>(); }
        }
        public NhQueryableInclude<Task> Tasks
        {
            get { return GetQuery<Task>(); }
        }
        public NhQueryableInclude<Person> Persons
        {
            get { return GetQuery<Person>(); }
        }
        

    }
}