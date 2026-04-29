using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

public class Evento
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public DateTime FechaHora { get; set; }

    public string IdLider { get; set; }

    public bool Activo { get; set; } = true;

    public List<string> InvitadosIds { get; set; } = new List<string>();
}