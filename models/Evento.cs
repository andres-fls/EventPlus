using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace eventPlus.Models
{
    public class Evento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string NombreEvento { get; set; }

        public string LugarEvento { get; set; }

        public string TipoEvento { get; set; }

        public string CategoriaEvento { get; set; }

        public string DescripcionEvento { get; set; }

        public DateTime Fecha { get; set; }

        public string Hora { get; set; }

        public int CupoMaximo { get; set; }

        public string IdLider { get; set; }

        public bool Activo { get; set; } = true;

        public List<string> InvitadosIds { get; set; } = new List<string>();

    } 

}