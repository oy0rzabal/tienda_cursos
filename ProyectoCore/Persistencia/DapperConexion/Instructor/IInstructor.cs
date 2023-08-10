using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistencia.DapperConexion.Instructor
{
    public interface IInstructor
    {
        //Importame InstructorModel para poder devoler una lista
        Task<IEnumerable<InstructorModel>> ObtenerLista();

        Task<InstructorModel> ObtenerPorId(Guid id);

        //Task<int> se pusieron por que nos va devolver un entero y se actualiza para poderse eliminar
        Task<int> Nuevo(string nombre, string apellidos, string titulo);

        Task<int> Actualiza(Guid instructorId, string nombre, string apellidos, string titulo);

        Task<int> Elimina(Guid id);
    }
}