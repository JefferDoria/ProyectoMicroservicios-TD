using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelicula.Dominio.Entidades
{
    [CollectionProperty("Pelicula")]
    [BsonIgnoreExtraElements]
    public class Pelicula : EntityToLower<ObjectId>
    {
        public double IdPelicula { get; set; }

        public string Nombre { get; set; }

        public string Duracion { get; set; }

        public double Precio { get; set; }
    }
}
