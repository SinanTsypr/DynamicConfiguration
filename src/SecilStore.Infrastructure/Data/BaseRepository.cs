using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using SecilStore.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SecilStore.Infrastructure.Data
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        protected IMongoCollection<T> mongoCollection;

        public BaseRepository(string mongoDBConnectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(mongoDBConnectionString);
            var database = client.GetDatabase(dbName);
            mongoCollection = database.GetCollection<T>(collectionName);
        }

        public virtual List<T> GetList()
        {
            return mongoCollection.Find(m => true).ToList();
        }

        public virtual T GetById(string id)
        {
            var docId = new ObjectId(id);
            return mongoCollection.Find<T>(m => m.Id == id).FirstOrDefault();
        }

        public virtual T Create(T model)
        {
            mongoCollection.InsertOne(model);
            return model;
        }

        public virtual void Update(string id, T model)
        {
            var docId = new ObjectId(id);
            mongoCollection.ReplaceOne(m => m.Id == id, model);
        }

        public virtual void Delete(T model)
        {
            mongoCollection.DeleteOne(m => m.Id == model.Id);
        }

        public virtual void Delete(string id)
        {
            var docId = new ObjectId(id);
            mongoCollection.DeleteOne(m => m.Id == id);
        }
    }
}
