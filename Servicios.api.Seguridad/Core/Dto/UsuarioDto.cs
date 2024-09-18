using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Seguridad.Core.Dto
{
    public class UsuarioDto
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }

    }
}
