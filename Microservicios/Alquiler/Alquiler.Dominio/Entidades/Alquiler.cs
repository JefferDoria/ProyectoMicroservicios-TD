using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Usuario.Dominio.Entidades
{
    [CollectionProperty("alquiler")]
    [BsonIgnoreExtraElements]
    public class Usuario : EntityToLower<ObjectId>
    {
        public double IdAlquiler { get; set; }

        public string fechaInicio { get; set; }

        public string FechaFin { get; set; }

        
    }
}
