using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Errores;
using Aplicacion.Interfaces;
using Dominio.Usuario;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Usuario
{
    public class Register
    {
        public class Command : IRequest<User>
        {
            public string Nombre { get; set; }
            public string Email { get; set; }
            public string Rut { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Contacto { get; set; }
            public string Ubicacion { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command,User>
        {
            private readonly ApplicationDbContext _context;
            private readonly UserManager<AppUser> _userManager;
            private readonly IJwtGenerator _jwetGenerator;

            public Handler(ApplicationDbContext context, UserManager<AppUser> userManager,
                IJwtGenerator jwetGenerator)
            {
                _context = context;
                _userManager = userManager;
                _jwetGenerator = jwetGenerator;
            }

            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _context.Users.AnyAsync(x => x.Email == request.Email))
                    throw new RestException(HttpStatusCode.BadRequest,new {Email = "Email ya existe"});
                if(await _context.Users.AnyAsync(x => x.RutUsuario == request.Rut))
                    throw new RestException(HttpStatusCode.BadRequest,new {Rut = "El rut ya se encuentre registrado"});
                if (await _context.Users.AnyAsync(x => x.UserName == request.UserName))
                    throw new RestException(HttpStatusCode.BadRequest, new { Rut = "El usuario ya se encuentre registrado" });
                   
                var user = new AppUser
                {
                    RutUsuario = request.Rut,
                    Email = request.Email,
                    Nombre = request.Nombre,
                    UserName = request.UserName,
                    Contacto = request.Contacto,
                    Correo = request.Email,
                    Ubicacion = request.Ubicacion
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    return new User
                    {
                        DisplayName = user.Nombre,
                        Email = user.Email,
                        Token = _jwetGenerator.CreateToken(user),
                    };
                }
                
                throw new RestException(HttpStatusCode.BadRequest,result.Errors.ToString());
            }
        }

    }
}
