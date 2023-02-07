using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alquiler.Dominio.Entidades
{
    [CollectionProperty("Alquiler")]
    [BsonIgnoreExtraElements]
    public class Alquiler : EntityToLower<ObjectId>
    {
        public double IdAlquiler { get; set; }

        public string FechaInicio { get; set; }

        public string FechaFin { get; set; }

        public double IdCliente { get; set; }

        public double IdPelicula { get; set; }
    }
}
