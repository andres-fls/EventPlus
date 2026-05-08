using MongoDB.Driver;
using System.Configuration;
using eventPlus.Models;

namespace eventPlus.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase database;

        public MongoContext()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            string connectionString =
                ConfigurationManager.AppSettings["MongoConnection"];

            string databaseName =
                ConfigurationManager.AppSettings["DatabaseName"];

            MongoClient client = new MongoClient(connectionString);

            database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Usuario> Usuarios =>
            database.GetCollection<Usuario>("Usuarios");

        public IMongoCollection<Evento> Eventos =>
            database.GetCollection<Evento>("Eventos");
    }
}