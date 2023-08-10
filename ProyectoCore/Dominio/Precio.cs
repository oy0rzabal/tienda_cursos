using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Precio
    {
        //Creacion de las columnas
        public Guid PrecioId{get;set;}
        [Column(TypeName = "decimal(18,4)")]
        public decimal PrecioActual{get;set;}
        [Column(TypeName = "decimal(18,4)")]
        public decimal Promocion{get;set;}
        public Guid CursoId {get;set;}

        //Creacion de anclaje a otra db:
        public CursoDto Curso {get; set;}
    }
}