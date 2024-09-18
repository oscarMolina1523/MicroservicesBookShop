using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Seguridad.Core.JwtLogin
{
    public class UsuarioSesion : IUsuarioSesion
    {
        private readonly IHttpContextAccessor _httpContextAccesor;

        public UsuarioSesion(IHttpContextAccessor httpContextAccesor)
        {
            _httpContextAccesor = httpContextAccesor;
        }

        public string GetUsuarioSesion()
        {
            var userName = _httpContextAccesor.HttpContext.User?.Claims?.FirstOrDefault(x=>x.Type=="username")?.Value;
            return userName;
        }
    }
}
