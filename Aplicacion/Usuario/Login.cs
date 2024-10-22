﻿using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Errores;
using Aplicacion.Interfaces;
using Dominio.Usuario;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Usuario
{
    public class Login
    {
        public class Query : IRequest<User>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty().WithMessage("El correo no puede ser vacio");
                RuleFor(x => x.Password).NotEmpty().WithMessage("Debe proporcionar una contraseña");
            }
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,
                IJwtGenerator jwtGenerator)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtGenerator = jwtGenerator;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user is null) throw new RestException(HttpStatusCode.Unauthorized);

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password,false);

                if (result.Succeeded)
                {
                    //TODO Generar token
                    return new User
                    {
                        DisplayName = user.Nombre,
                        Email = user.Email,
                        Token = _jwtGenerator.CreateToken(user),
                    };
                }
                throw new RestException(HttpStatusCode.Unauthorized);

            }
        }
    }
}
