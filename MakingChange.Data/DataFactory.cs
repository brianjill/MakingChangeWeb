using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace MakingChange.Data
{
    internal class DataFactory
    {
        string _dbFile = string.Empty;
        bool _overwriteExisting = false;

        public DataFactory(string dbFile, bool overwriteExisting)
        {
            _dbFile = dbFile;
            _overwriteExisting = overwriteExisting;
        }

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile(_dbFile)
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataFactory>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private void BuildSchema(Configuration config)
        {
            if (_overwriteExisting)
            {
                if (File.Exists(_dbFile)) File.Delete(_dbFile);

                var se = new SchemaExport(config);
                se.Create(false, true);
            }
        }
    }
}
