using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakingChange.Data.Entities;

namespace MakingChange.Data
{
    public static class OcDataRepository
    {
        private static DataFactory _df;
        public static void Create(string dbFile)
        {
            _df = new DataFactory(dbFile, true);
            using (var sf = _df.CreateSessionFactory())
            {
                sf.Close();
            }
        }

        public static void AddPerson(string dbFile, Person person)
        {
            using (var sf = _df.CreateSessionFactory())
            using (var session = sf.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                session.SaveOrUpdate(person);
                trans.Commit();
            }
        }

        public static void AddProject(string dbFile, Project project)
        {
            using (var sf = _df.CreateSessionFactory())
            using (var session = sf.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                session.SaveOrUpdate(project.Manager);
                session.SaveOrUpdate(project);
                trans.Commit();
            }
        }
    }
}
