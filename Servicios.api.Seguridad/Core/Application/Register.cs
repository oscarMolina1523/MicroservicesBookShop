using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Servicios.api.Seguridad.Core.Dto;
using Servicios.api.Seguridad.Core.Entities;
using Servicios.api.Seguridad.Core.JwtLogin;
using Servicios.api.Seguridad.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servicios.api.Seguridad.Core.Application
{
    public class Register
    {

        public class UsuarioRegisterCommand : IRequest<UsuarioDto>
        {
            public string Nombre { get; set; }

            public string Apellido { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            public string Email { get; set; }
        }

        public class UsuarioRegisterValidation : AbstractValidator<UsuarioRegisterCommand>
        {
            public UsuarioRegisterValidation()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
            }
        }


        public class UsuarioRegisterHandler : IRequestHandler<UsuarioRegisterCommand, UsuarioDto>
        {
            private readonly SeguridadContexto _contexto;
            private readonly UserManager<Usuario> _userManager;
            private readonly IMapper _mapper;
            private readonly IJwtGenerator _jwtGenerator;


            public UsuarioRegisterHandler(SeguridadContexto contexto, UserManager<Usuario> userManager, IMapper mapper, IJwtGenerator jwtGenerator)
            {
                _contexto = contexto;
                _userManager = userManager;
                _mapper = mapper;
                _jwtGenerator = jwtGenerator;
            }


            public async Task<UsuarioDto> Handle(UsuarioRegisterCommand request, CancellationToken cancellationToken)
            {
                var existe = await _contexto.Users.Where(x=>x.Email==request.Email).AnyAsync();
                if (existe)
                {
                    throw new Exception("El email de usuario ya existe");

                }
                existe = await _contexto.Users.Where(x => x.UserName == request.Username).AnyAsync();
                if (existe)
                {
                    throw new Exception("El userName ya existe");
                }

                var usuario = new Usuario
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Email = request.Email,
                    UserName = request.Username,

                };
                var resultado= await _userManager.CreateAsync(usuario, request.Password);
                if (resultado.Succeeded)
                {
                    var usuarioDto= _mapper.Map<Usuario, UsuarioDto>(usuario);
                    usuarioDto.Token = _jwtGenerator.createTocken(usuario);
                    return usuarioDto;
                }

                throw new Exception("No se pudo registrar el usuario");
                

            }
        }

    }
}
