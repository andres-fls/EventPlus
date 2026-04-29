using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eventPlus.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Password { get; set; }

        public string Rol { get; set; } // Lider o Invitado

        // SOLO PARA INVITADOS
        public string Cedula { get; set; }

        public string Telefono { get; set; }

        public string Genero { get; set; }

        public int? Edad { get; set; }
    }
}