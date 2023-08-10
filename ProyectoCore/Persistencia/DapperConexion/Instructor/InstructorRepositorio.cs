using Dapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DapperConexion.Instructor
{
    public class InstructorRepositorio : IInstructor
    {
        //Variable de Representacion
        private readonly IFactoryConnection _factoryConnection;

        public InstructorRepositorio(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }

        public async Task<int> Actualiza(Guid instructorId, string nombre, string apellidos, string titulo)
        {
            var storeProcedure = "usp_instructor_editar";
            try
            {

                var connection = _factoryConnection.GetConnection();
                //Creamos el parametro de conection del storeprocedure
                var resultados = await connection.ExecuteAsync(
                    //Ejecuta cuantas veces obtendremos el resultado
                    storeProcedure,
                    new
                    {
                        InstructorId = instructorId,
                        Nombre = nombre,
                        Apellidos = apellidos,
                        Titulo = titulo
                    },
                    commandType: CommandType.StoredProcedure
                );

                //Se cierra la conexion y retornamos los resultados
                _factoryConnection.CloseConnection();
                return resultados;


            }

            //Creamos la funcion para poder comprobar si se pudo ejecutar la instruccion
            catch (Exception e)
            {
                throw new Exception("No se pudo editar la data del instructor", e);
            }

        }

        public async Task<int> Elimina(Guid id)
        {
            var storeProcedure = "usp_instructor_elimina";
            try
            {
                //Obtenemos la conexion  despues vamos a ejecutar el procedure 
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(
                    storeProcedure,
                    new
                    {
                        InstructorId = id
                    },
                    commandType: CommandType.StoredProcedure
                );
                _factoryConnection.CloseConnection();
                return resultado;

                //Procedure:
                //CREATE PROCEDURE ups_instructor_elimina(
                //    @InstructorId uniqueidentifier
                //    )
                //    as
                //    Begin
                //    DELETE FROM CursoInstructor WHERE InstructorId = @InstructorId
                //    delete from Instructor where InstructorId = @InstructorId
                //    end
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo eliminar el instructor", e);
            }
        }

        //Va crear como nuevos datos, Nombre, Apellidos, Titulos
        public async Task<int> Nuevo(string nombre, string apellidos, string titulo)
        {
            //Obtenemos los Procesamiento Proceduree
            var storeProcedure = "usp_instructor_nuevo";

            try
            {
                //Creamos nueva coneection
                var connection = _factoryConnection.GetConnection();

                //Pbtenemos el resultado de la conexion del procesamiento procedure
                var resultado = await connection.ExecuteAsync(
                storeProcedure,
                new
                {
                    //Dentro de SQL crearemos una query donde mencionaremos lo siguiente pero con @
                    InstructorId = Guid.NewGuid(),
                    Nombre = nombre,
                    Apellidos = apellidos,
                    Titulo = titulo


                    //CREATE PROCEDURE ups_instructor_nuevo(
                    //    @InstructorId uniqueidentifer,
                    //    @Nombre nvarchar(500),
                    //    @Apellidos nvarchar(500),
                    //    @Titulo nvarchar(500),
                    //)
                    //    AS
                    //        BEGIN

                    //        INSERT INTO Instructor(InstructorId, Nombre, Apellidos, Grado)
                    //        VALUES(@InstructorId, @Nombre, @Apellidos, @Titulo)
                    //        END
                //Ten encuenta que debes de acomodar bien la sintasix para que no tengas problemas.
                },
                commandType: CommandType.StoredProcedure
                );

                _factoryConnection.CloseConnection();

                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo guardar el nuevo instructor", e);
            }


        }

        //Hacemos la variable para poder obtener Lista model
        public async Task<IEnumerable<InstructorModel>> ObtenerLista()
        {
            IEnumerable<InstructorModel> instructorList = null; //me devuelve la lista en nulos en face
            var storeProcedure = "usp_Obtener_Instructores";//Obtener instructores
            try
            {
                var connection = _factoryConnection.GetConnection();
                //Especificamos que nos va devovler la data almacenada como un query
                instructorList = await connection.QueryAsync<InstructorModel>(storeProcedure, null, commandType: CommandType.StoredProcedure);

            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta de datos", e);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }
            return instructorList;
        }

        public async Task<InstructorModel> ObtenerPorId(Guid id)
        {
            
            var storeProcedure = "usp_obtener_instructor_por_id";
            InstructorModel instructor = null;
            try
            {
                
                var connection = _factoryConnection.GetConnection();
                instructor = await connection.QueryFirstAsync<InstructorModel>(
                    storeProcedure,
                    new
                    {
                        Id = id
                    },
                    commandType: CommandType.StoredProcedure
                );

                return instructor;

            }
            catch (Exception e)
            {
                throw new Exception("No se pudo encontrar el instructor", e);
            }


        }
    }
}

//
//Estructura Basica de un Procedure
//    //Create Procedurre nombre de asignacion
//    CREATE PROCEDURE usp_Obtener_Instructores
//    //como
//    as
//        //Begind = Incio del Procedure
//        BEGIN
//            //Seleccionamos 
//            SELECT 
//                X.IntructorId,
//                X.Nombre,
//                X.Apellidos,
//                X.Grado
//            //Me va deolver toda la lista ed los Instructores
//            FROM Instructor X

//        //Fin del Procedure:
//        END