using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMondo.Model
{
    public class ProductoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Nombre")]
        public string? Nombre { get; set; }
        [BsonElement("Categoria")]
        public string? Categoria { get; set; }
        [BsonElement("Precio")]
        public double Precio { get; set; }
        [BsonElement("FechaRegistro")]
        public DateTime FechaRegistro { get; set; }
    }
}
