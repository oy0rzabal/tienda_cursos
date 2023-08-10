﻿using Aplicacion.ManejadorError;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Seguridad
{
    public class RolEliminar
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
        }

        public class EjecutaValida : AbstractValidator<Ejecuta>
        {
            public EjecutaValida()
            {
                RuleFor(x => x.Nombre).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            public Manejador(RoleManager<IdentityRole> roleManager)
            {
                _roleManager = roleManager;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                //Creamos el rol 
                var role = await _roleManager.FindByNameAsync(request.Nombre);
                if (role == null)
                {
                    //Manejamos la Excepcion de si no encuentra o hay una mala respuesta nos arrojara el mensaje
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No existe el rol" });
                }

                var resultado = await _roleManager.DeleteAsync(role);
                if (resultado.Succeeded)
                {
                    return Unit.Value;
                }

                throw new System.Exception("No se pudo eliminar el rol");
            }
        }
    }
}
