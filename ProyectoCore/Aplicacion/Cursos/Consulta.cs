using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;
using Microsoft.EntityFrameworkCore;


//Contiene errores porfavor a corregirlos:
namespace Aplicacion.Cursos
{
    public class Consulta
    {
        public class ListaCursos: IRequest<List<CursoDto>> {}

        public class Manejador: IRequestHandler<ListaCursos, List<CursoDto>>
        {
            private readonly CursosOnlineContext _context;

            public Manejador(CursosOnlineContext context){
                _context = context;
            }

            public async Task<List<CursoDto>> Handle(ListaCursos request, CancellationToken cancellationToken)
            {
                //Incluiremos los datos a una lista y la devolveremos como vista 
                var cursos = await _context.Curso
               .Include(x => x.ComentarioLista)
               .Include(x => x.PrecioPromocion)
               .Include(x => x.InstructoresLink)
               .ThenInclude(x => x.Instructor).ToListAsync();

                return cursos; 
            }

            //Dto Se caracterisa por que regresa data a un cliente
            
        }
    }
}