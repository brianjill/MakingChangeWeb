using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using MakingChange.Data.Entities;
using NHibernate;
using NHibernate.Cfg;

namespace MakingChange.Data
{
    public static class FnhConfig
    {
        private static DataFactory _df;
        private static ISessionFactory _sf;
        
        public static void Create()
        {
            _df = new DataFactory(true);
            using (var sf = _df.CreateSessionFactory())
            {
                sf.Close();
            }
        }

        public static void AddProject(Project project)
        {
            using (var sf = _df.CreateSessionFactory())
            using (var session = sf.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                session.SaveOrUpdate(project.Manager);
                foreach (var department in project.Departments)
                {
                    session.SaveOrUpdate(department);
                }
                
                session.SaveOrUpdate(project);
                trans.Commit();
            }
        }

        public static ISession OpenSession()
        {
            _sf = Fluently.Configure().BuildSessionFactory();
            var session = _sf.OpenSession();
            return session;
        }
    }
}
