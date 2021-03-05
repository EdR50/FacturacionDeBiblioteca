using System;
using MySql.Data.MySqlClient;

namespace DataManager.CLS
{
    public class Conexion
    {
        // Variable global para realizar la conexion a la bd
        private string _mySqlString = "Server=localhost;Database=biblioteca;Uid=Desarrollo2;Pwd=admin;";
        protected MySqlConnection _connection;

        public Conexion()
        {
            _connection = new MySqlConnection(_mySqlString);
        }

        protected Boolean Connected()
        {
            var connected = false;

            try
            {
                _connection.Open();
                connected = true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                connected = false;
            }

            return connected;
        }


        protected void Disconnected()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}