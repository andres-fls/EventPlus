using MongoDB.Driver;
using System.Configuration;

namespace eventPlus.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase database;

        public MongoContext()
        {
            string connectionString =
                ConfigurationManager.AppSettings["MongoConnection"];

            string databaseName =
                ConfigurationManager.AppSettings["DatabaseName"];

            MongoClient client = new MongoClient(connectionString);

            database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Usuario> Usuarios =>
            database.GetCollection<Usuario>("usuarios");

        public IMongoCollection<Evento> Eventos =>
            database.GetCollection<Evento>("eventos");
    }
}