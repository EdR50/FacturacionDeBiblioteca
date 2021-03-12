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
            // var sqlQuery = $"SELECT  a.Idlibro, a.Titulo, a.Descripcion, b.NombreEditorial , a.Precio, a.Idioma, a.Cover from libros a, editoriales b, libros_editoriales c where a.Idlibro = c.IdLibro and b.IdEditorial = c.IdEditorial";

            var sqlQuery =
                "select " +
                "t1.Idlibro, Isbn, Titulo, Descripcion, Precio, Idioma, FechaLanzamiento, NumeroPag, Cover, stock, concat(NombreAutor , ' ' , ApellidoAutor) as NombreAutor, ApellidoAutor, NombreEditorial " +
                "from libros t1 " +
                "inner join libros_autores la on t1.Idlibro = la.IdLibro " +
                "inner join autores a on la.IdAutor = a.IdAutor " +
                "inner join libros_editoriales le on t1.Idlibro = le.IdLibro " +
                "inner join editoriales e on le.IdEditorial = e.IdEditorial;";

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
            var sql = $"Titulo like '%{word}%' OR Idioma like '%{word}%' OR Descripcion like '%{word}%' OR NombreAutor like '%{word}%'";
            return sql;
        }
    }
}