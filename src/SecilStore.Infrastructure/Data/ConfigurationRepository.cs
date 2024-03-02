using MongoDB.Driver;
using SecilStore.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecilStore.Infrastructure.Data
{
    public class ConfigurationRepository : BaseRepository<Configuration>
    {
        public ConfigurationRepository(string mongoDBConnectionString, string dbName, string collectionName) : base(mongoDBConnectionString, dbName, collectionName)
        {
        }

        public Configuration GetByName(string name, string applicationName)
        {
            return mongoCollection.Find<Configuration>(x => x.Name == name && x.ApplicationName == applicationName && x.IsActive).FirstOrDefault();
        }

        public List<Configuration> GetListByApplicationName(string applicationName)
        {
            return mongoCollection.Find<Configuration>(x => x.ApplicationName == applicationName && x.IsActive).ToList();
        }
    }
}
