using AutoMapper;
using Servicios.api.Seguridad.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Seguridad.Core.Dto
{
    public class MappingProfile:Profile
    {

        public MappingProfile() {
            CreateMap<Usuario, UsuarioDto>();
        }

    }
}
