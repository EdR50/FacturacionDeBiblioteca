using System;
using System.Data;
using System.Windows.Forms;

namespace CacheManager.CLS
{
    public static class Cache
    {
        public static DataTable Login(string username, string password)
        {
            DataTable table = new DataTable();
            var queryHandler = new DataManager.CLS.Query(); // esta variable se encarga de instanciar la clase Query

            string sqlQuery =
                $"SELECT IdUsuario, NombreUsuario, Contrasena, Email from usuarios WHERE NombreUsuario='{username}' AND Contrasena = '{password}'";

            try
            {
                table = queryHandler.ExecuteSelectQuery(sqlQuery);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                table = new DataTable();
            }

            return table;
        }


        // Metodos del Home
        
        //Renderizar informacion de los libros en una lista
        public static DataTable RenderInfoBooks()
        {
            var table = new DataTable();
            var queryHandler = new DataManager.CLS.Query();
            var sqlQuery = $"SELECT Idlibro, Titulo, Descripcion, Precio, Idioma, Cover FROM libros";

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
        
        // Filtrar los datos de los libros (Barra de busqueda)
        public static string FilterBookInfo(string word)
        {
            var sql =  $"Titulo like '%{word}%' OR Idioma like '%{word}%' OR Descripcion like '%{word}%'";
            return sql;
        }
        
    }
}