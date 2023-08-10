﻿using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Persistencia.DapperConexion
{
    public class FactoryConnection : IFactoryConnection
    {
        private IDbConnection _connection;
        //Conexion configuracion:
        private readonly IOptions<ConexionConfiguracion> _configs;
        public FactoryConnection(IOptions<ConexionConfiguracion> configs)
        {
            _configs = configs;
        }
        public void CloseConnection()
        {
            //Creamos la condicion para poder cerrar la cadena de conexion
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public IDbConnection GetConnection()
        {
            if (_connection == null)
            {
                //Contiene la cadena de conexion                //ConexionSQL a DefaultConnection
                _connection = new SqlConnection(_configs.Value.DefaultConnection);
            }
            //Comprobamos el estado de Conexion
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }
    }
}