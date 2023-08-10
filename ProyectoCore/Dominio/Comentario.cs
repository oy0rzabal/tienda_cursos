using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public class Comentario
    {
        //Creacion de las columnas
        public Guid ComentarioId { get; set; }
        public string Alumno { get; set; }
        public int Puntaje { get; set; }
        public string ComentarioTexto { get; set; }
        public Guid CursoId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        //Anclaje a otra DB:
        public CursoDto Curso {get; set;}
    }
}


//Trancsal SQl