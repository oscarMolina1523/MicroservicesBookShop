using Servicios.api.Seguridad.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Seguridad.Core.JwtLogin
{
    public interface IJwtGenerator
    {
        string createTocken(Usuario usuario);
    }
}
