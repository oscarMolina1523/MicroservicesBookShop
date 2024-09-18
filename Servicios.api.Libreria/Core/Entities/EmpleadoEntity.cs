using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Core.Entities
{
    [BsonCollection("Empleado")]
    public class EmpleadoEntity:Document
    {
        [BsonElement("nombre")]
        public string Nombre { get; set; }
    }
}
