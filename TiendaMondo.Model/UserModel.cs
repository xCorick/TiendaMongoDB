using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMondo.Model
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string? id { get; set; }
        [BsonElement("Correo")]
        public string? Correo { get; set; }
        [BsonElement("Nombre")]
        public string? Nombre { get; set; }
        [BsonElement("Passwd")]
        public string? Passwd { get; set; }
        [BsonElement("Tipo")]
        public int Tipo { get; set; }
    }
}
