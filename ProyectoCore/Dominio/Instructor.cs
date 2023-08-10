using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public class Instructor
    {
        //Creacion de las columnas
        public Guid InstructorId{get; set;}
        public string Nombre{get; set;}
        public string Apellidos {get; set;}
        public string Grado {get; set;}
        public byte[] FotoPerfil{get; set;}


        //Anclaje a la db CursoInstructor:
        public ICollection<CursoInstructor> CursoLink {get; set;}

    }
}