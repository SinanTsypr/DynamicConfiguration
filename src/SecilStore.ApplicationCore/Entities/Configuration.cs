using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecilStore.ApplicationCore.Entities
{
    public class Configuration : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Value")]
        public string Value { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("IsActive")]
        public bool IsActive { get; set; }

        [BsonElement("ApplicationName")]
        public string ApplicationName { get; set; }
    }
}
