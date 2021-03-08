using System;
using System.Data;

namespace CacheManager.CLS
{
    public static class Cache
    {
        public static DataTable Login(string username, string password)
        {
            DataTable table = new DataTable();
            var queryHandler = new DataManager.CLS.Query(); // esta variable se encarga de instanciar la clase Query

            string sqlQuery =
                $"SELECT IdUsuario, NombreUsuario, Contrasena from usuarios WHERE NombreUsuario='{username}' AND Contrasena = '{password}'";

            try
            {
                table = queryHandler.ExecuteSelectQuery(sqlQuery);
            }
            catch (Exception e)
            {
                table = new DataTable();
            }

            return table;
        }


        // Metodos del Home
        public static DataTable RenderInfoBooks()
        {
            var table = new DataTable();
            var queryHandler = new DataManager.CLS.Query();
            string sqlQuery = $"SELECT Idlibro, Titulo, Descripcion, Precio, Idioma, Cover FROM libros";

            try
            {
                table = queryHandler.ExecuteSelectQuery(sqlQuery);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return table;
        }


        public static DataTable UserInfo(string userName)
        {
            var table = new DataTable();
            var sqlQuery = $"SELECT * FROM usuario WHERE NombreUsuario = '{userName}'";
            var queryHandler = new DataManager.CLS.Query();

            try
            {
                table = queryHandler.ExecuteSelectQuery(sqlQuery);
            }
            catch (Exception e)
            {
                table = new DataTable();
            }

            return table;
        }
    }
}