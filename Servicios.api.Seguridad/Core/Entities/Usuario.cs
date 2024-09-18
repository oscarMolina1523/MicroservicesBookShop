using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Seguridad.Core.Entities
{
    public class Usuario:IdentityUser
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Direccion { get; set; }
    }
}
