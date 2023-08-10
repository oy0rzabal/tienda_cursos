using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Cursos;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Org.BouncyCastle.Utilities.Collections;

//Arreglar errores:

namespace WebAPI.Controllers
{
    // hhtp://localhost:500/api/Cursos/1
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : MiControllerBase
    {
         private readonly IMediator _mediator;
         public CursosController(IMediator mediator){
             _mediator = mediator;
         }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<CursoDto>>> Get(){
            return await Mediator.Send(new Consulta.ListaCursos());
        }


        // hhtp://localhost:500/api/Cursos/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDto>> Detalle(Guid id){
            return await Mediator.Send(new ConsultaId.CursoUnico{Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, Editar.Ejecuta data){
            data.CursoId = id;
            return await Mediator.Send(data);
        }

        [HttpDelete("{}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
            return await Mediator.Send(new Eliminar.Ejecuta{Id=id});
        }
    }
}


//-------------------------Creacio del Procedure
//CREATE PROCEDURE usp_obtener_curso_paginacion(
//    @NombreCurso nvarchar(500),
//    @Ordenamiento nvarchar(500),
//    @NumeroPagina int,
//    @CantidadElementos int,
//    @TotalRecords int OUTPUT,
//    @TotalPaginas int OUTPUT
//)AS
//BEGIN/*Inicio*/
//	/*Enviame ya no cuenta*/
//  SET NOCOUNT ON
//  SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
//  /*Declarame Inicio como un entero*/
//   DECLARE @Inicio int
//   /*Declarame Fin como un entero*/
//   DEClARE @Fin int
//   /*Si Numero de Pagina = 1*/
//   IF @NumeroPagina = 1
//   BEGIN/*Inicio*/
//   /*Realizame esta Formula = Numero de pagina menos Cantidad de elementos - Conitidad de Elementos*/
//SET @Inicio = (@NumeroPagina - @CantidadElementos) -@CantidadElementos
// /*Realizame Numerode pagina * Cantidad de Elementos*/
//SET @Fin = @NumeroPagina * @CantidadElementos
//   /*Finalizamelo*/
//   END

//   /*Si la condicion de arriba no se ejecuta ralizame lo sigiente*/
//   ELSE
//  BEGIN/*Inicio*/
//   SET @Inicio = ((@NumeroPagina * @CantidadElementos) -@CantidadElementos) +1
//   SET @Fin = @NumeroPagina * @CantidadElementos
//   END

//   /*Create una tabla como #TMP*/
//   CREATE TABLE #TMP(
//    rowNumber int IDENTITY(1,1,), /*Numero de columna como identificador*/
//    ID uniqueidentifier/*Identificador Unico*/
//)
// /* Inicio de la condicion*/
//  DECLARE @SQL nvarchar(max)
//  SET @SQL = 'SELECT CursoId FROM Curso'

//  IF @NombreCurso Is Not NUll
//  BEGIN /*Inicio*/
//     SET  @SQL = @SQL + 'WHERE Titulo LIKE ''%' + @NombreCurso + '%'''
//    END /*Final*/

//	/*SI Ordenamiento es nulo*/
//    IF @Ordenamiento IS NOT NULL
//    BEGIN /*Inicio*/
//	/* Dame como resultado Ordenamiento con SQL y arrojamelo Ordenadamente*/
//      SET @SQL = @SQL + 'ORDER BY' + @Ordenamiento
//    END
//	/* --SELECT CursoId FROM Curso WHERE Titulo LIKE '% ASP %' ORDER BY TITULO */

//	INSERT INTO #TMP(ID)
//	EXEC sp_executes @SQL

//	SELECT @TotalRecords = Count(*) FROM #TMP

//	IF @TotalRecords > @CantidadElementos
//		BEGIN
//			SET @TotalPaginas = @TotalRecords / @CantidadElementos
//			IF (@TotalRecords % @CantidadElementos) > 0

//                BEGIN
//                    SET @TotalPaginas = @TotalPaginas + 1
//				END
//		END
//	ELSE
//		BEGIN
//			SET @TotalPaginas = 1
//		END

//	SELECT
//		c.CursoId,
//		c.Titulo,
//		c.Descripcion,
//		c.FechaPublicacion,
//		c.FotoPortada,
//		c.FechaCreacion,
//		p.PrecioActual,
//		p.Promocion
//	FROM #TMP t INNER JOIN dbo.Curso c
//						ON t.ID = c.CursoId
//						LEFT JOIN Precio p
//						On c.CursoId = p.CursoId
//	WHERE t.rowNumber >= @Inicio AND t.rowNumber <= @Fin
//END