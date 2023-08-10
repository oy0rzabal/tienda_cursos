using Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class CursosOnlineContext: IdentityDbContext<Usuario>
    {
        public CursosOnlineContext(DbContextOptions options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CursoInstructor>().HasKey(ci => new {ci.InstructorId, ci.CursoId});
        }


        //Creacion de las entidades a las db:
        public DbSet<Comentario> Comentario {get;set;}
        public DbSet<CursoDto> Curso{get;set;}
        public DbSet<CursoInstructor> CursoInstructor{get;set;}
        public DbSet<Instructor> Instructor{get;set;}
        public DbSet<Precio> Precio{get;set;
        }
        public DbSet<Documento> Documento { get; set; }
    }
}

//Instalar: dotnet tool install --global dotnet-ef --version 3.1.1
//Crear Archivo de migracion: dotnet ef migartions add IdentityCoreInicial - p Persistencia/ -s WebApi/