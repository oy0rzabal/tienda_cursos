using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class PaginacionCurso
    {
        public class Ejecuta : IRequest<PaginacionModel>
        {
            public string Titulo { get; set; }
            public int NumeroPagina { get; set; }
            public int CantidadElementos { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, PaginacionModel>
        {
            private readonly IPaginacion _paginacion;
            public Manejador(IPaginacion paginacion)
            {
                _paginacion = paginacion;
            }
            public async Task<PaginacionModel> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //Toda esta funcion se podria hacer para inventarios o para una tienda que tiene datos constante
                var storedProcedure = "usp_obtener_curso_paginacion";
                var ordenamiento = "Titulo";

                //Creamos variable para que pueda contener string y objetos
                var parametros = new Dictionary<string, object>();

                //Parametros va agregar "NombreCurso", como respuesta el titulo cada vez que se vaya agregando
                parametros.Add("NombreCurso", request.Titulo);

                //Va regresar como resultado los parametros de los procedure y el contenido que contiene e Paginacionmodel
                return await _paginacion.devolverPaginacion(storedProcedure, request.NumeroPagina, request.CantidadElementos, parametros, ordenamiento);

            }
        }
    }
}
