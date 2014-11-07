using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;

namespace MakingChange.Data
{
    internal class DataFactory
    {
        readonly bool _overwriteExisting;

        public DataFactory(bool overwriteExisting=false)
        {
            _overwriteExisting = overwriteExisting;
        }

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(ConfigurationManager.ConnectionStrings["MakingChangeConnection"].ConnectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataFactory>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }
        
        private void BuildSchema(Configuration config)
        {
            if (_overwriteExisting)
            {
                var se = new SchemaExport(config);
                se.Create(false, true);
            }
        }
        
    }
}
