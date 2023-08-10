using FluentValidation;
using MediatR;
using Persistencia.DapperConexion.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Instructores
{
    internal class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public string Titulo { get; set; }
        }

        public class EjecutaValida : AbstractValidator<Ejecuta>
        {
            public EjecutaValida()
            {
                //Hacemos que no mandemos vacios o sea datos vacios
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellidos).NotEmpty();
                RuleFor(x => x.Titulo).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            //Creamos el manejador Instructor
            private readonly IInstructor _instructorRepository;
            public Manejador(IInstructor instructorRepository)
            {
                _instructorRepository = instructorRepository;
            }
            //Creamos un llamado para que unit pueda regresar como el Token Cancelado
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //Va a regresarnos como nuevo, Nombre, Apellidos y Titulo
                var resultado = await _instructorRepository.Nuevo(request.Nombre, request.Apellidos, request.Titulo);

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el instructor");
            }
        }
    }
}
