
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Dominio;

namespace Dominio
{
    public class CursoInstructor
    {
        //Creacion de las columnas 
        public Guid CursoId {get; set;}

        //Creamos el anclaje a otra db:
        public Guid InstructorId {get; set;}

        public CursoDto Curso {get; set;}

        //Hacemos referencia al anclaje del Instructor:
        public Instructor Instructor {get; set;}
    }
}