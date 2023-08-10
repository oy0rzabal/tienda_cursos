using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dominio;

namespace Dominio
{
    public class CursoDto
    {
        //Creacion de las columnas
        public Guid CursoId {get; set;}
        public string Titulo {get; set;}
        public string Descripcion {get; set;}
        public DateTime? FechaPublicacion {get; set;}
        public byte[] FotoPortada {get; set;}

        //Creacion del ancla a otra db:
        public Precio PrecioPromocion {get; set;}

        public DateTime? FechaCreacion { get; set; }


        public ICollection<Comentario> ComentarioLista {get; set;}

        //
        public ICollection<CursoInstructor> InstructoresLink {get; set;}

    }
}