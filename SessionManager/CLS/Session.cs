using System;

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

        public static Session Instance
        {
            get
            {
                // Check if instance needs to be created to avoid unnecessary lock
                // everytime you request an instance of the service
                if (_instance is null)
                {
                    // Lock thread so only one thread can create the first instance
                    lock (Lock)
                    {
                        // Check if instance needs to be created
                        // This is to avoid initial initialization by two threads.
                        if (_instance is null)
                        {
                            _instance = new Session();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}