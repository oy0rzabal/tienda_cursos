using System.Net;
using Aplicacion.ManejadorError;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;


namespace Aplicacion.Cursos
{
    public class ConsultaId
    {

        public class CursoUnico : IRequest<Dominio.CursoDto>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<CursoUnico, Dominio.CursoDto>
        {
            private readonly CursosOnlineContext _context;
            private readonly IMapper _mapper;
            public Manejador(CursosOnlineContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<Dominio.CursoDto> Handle(CursoUnico request, CancellationToken cancellationToken)
            {
                //Devuelve la data completa
                var curso = await _context.Curso
               .Include(x => x.ComentarioLista)
               .Include(x => x.PrecioPromocion)
               .Include(x => x.InstructoresLink)
               .ThenInclude(y => y.Instructor)
               .FirstOrDefaultAsync(a => a.CursoId == request.Id);

                if (curso == null)
                {
                    //throw new Exception("No se puede eliminar curso");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "No se encontro el curso" });
                }

                var cursoDto = _mapper.Map<Curso, CursoDto>(curso);
                return cursoDto;
            }
        }

    }
}