using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Usuario.Dominio.Entidades
{
    [CollectionProperty("pelicula")]
    [BsonIgnoreExtraElements]
    public class Usuario : EntityToLower<ObjectId>
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apelldio { get; set; }

        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string Tarjeta { get; set; }
    }
}
