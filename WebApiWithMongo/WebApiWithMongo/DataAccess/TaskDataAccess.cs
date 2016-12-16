using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWithMongo.DataAccess
{
    using MongoDB.Bson;
    using MongoDB.Driver;

    using WebApiWithMongo.Models;

    public class TaskDataAccess
    {
        private bool disposed = false;

        // To do: update the connection string with the DNS name
        // or IP address of your server. 
        //For example, "mongodb://testlinux.cloudapp.net"
        private string connectionString = "mongodb://localhost/Tasks";

        // This sample uses a database named "Tasks" and a 
        //collection named "TasksList".  The database and collection 
        //will be automatically created if they don't already exist.
        private string dbName = "Tasks";
        private string collectionName = "TasksList";

        // Default constructor.        
        public TaskDataAccess()
        {
        }

        // Gets all Task items from the MongoDB server.        
        public List<MyTask> GetAllTasks()
        {
            try
            {
                var collection = GetTasksCollection();
                return collection.Find(new BsonDocument()).ToList();
            }
            catch (MongoConnectionException)
            {
                return new List<MyTask>();
            }
        }

        // Creates a Task and inserts it into the collection in MongoDB.
        public void CreateTask(MyTask task)
        {
            var collection = GetTasksCollectionForEdit();
            try
            {
                collection.InsertOne(task);
            }
            catch (MongoCommandException ex)
            {
                string msg = ex.Message;
            }
        }

        private IMongoCollection<MyTask> GetTasksCollection()
        {
            MongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            var todoTaskCollection = database.GetCollection<MyTask>(collectionName);
            return todoTaskCollection;
        }

        private IMongoCollection<MyTask> GetTasksCollectionForEdit()
        {
            MongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            var todoTaskCollection = database.GetCollection<MyTask>(collectionName);
            return todoTaskCollection;
        }
    }
}