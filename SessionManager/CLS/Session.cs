using System;
using System.Data;

namespace SessionManager.CLS
{
    // Esta clase es el patron de diseño singleton

    public sealed class Session 
    {
        private static Session _instance;
        private static readonly object Lock = new object();

        // El constructor es privado por lo cual la clase no puede ser instanciada en otras clases
        private Session()
        {
        }

        //este metodo es el que utilizaremos en la diferentes clases que necesitemos usar la sesion
        public static Session Instance
        {
            get
            {
                // Check if instance needs to be created to avoid unnecessary lock
                // cada vez que le requieres una instancia
                if (_instance is null)
                {
                    // Lock thread so only one thread can create the first instance
                    lock (Lock)
                    {
                        // Mira si la instancia ha sido creada
                        // Evita que dos hilos creen mas intancias
                        if (_instance is null)
                        {
                            _instance = new Session();
                        }
                    }
                }

                return _instance;
            }
        }

        // Metodo login para comprobar la sesion(consumiendo)
        public bool Login(string username, string password)
        {
            bool authorized;
            DataTable table = new DataTable();

            try
            {
                table = CacheManager.CLS.Cache.Login(username, password);

                if (table.Rows.Count == 1)
                {
                    Usuario.IdUsuario = table.Rows[0]["IdUsuario"].ToString();
                    Usuario.NombreUsuario = table.Rows[0]["NombreUsuario"].ToString();
                    Usuario.Contrasena = table.Rows[0]["Contrasena"].ToString();
                    Usuario.Email = table.Rows[0]["Email"].ToString();
                    authorized = true;
                }
                else
                {
                    authorized = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                authorized = false;
            }


            return authorized;
        }
    }
}