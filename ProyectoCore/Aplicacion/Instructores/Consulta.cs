using MediatR;
using Persistencia.DapperConexion.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Instructores
{
    public class Consulta
    {
        public class Lista : IRequest<List<InstructorModel>> { }

        public class Manejador : IRequestHandler<Lista, List<InstructorModel>>
        {
            private readonly IInstructor _instructorRepository;
            public Manejador(IInstructor instructorRepository)
            {
                _instructorRepository = instructorRepository;
            }
            public async Task<List<InstructorModel>> Handle(Lista request, CancellationToken cancellationToken)
            {
                //Llamamos a Repositorio para que nos devuelta la lista Instructores
                var resultado = await _instructorRepository.ObtenerLista();
                return resultado.ToList();

            }
        }

    }
}