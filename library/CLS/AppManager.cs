using library.GUI;
using System;
using System.Windows.Forms;

namespace library.CLS
{
    class AppManager : ApplicationContext
    {
        private bool SplashScreen()
        {
            // bool result = true;
            var splash = new Splash();
            splash.ShowDialog();
            return true;
        }

        private bool LoginScreen()
        {
            bool result = true;
            Login login = new Login();
            login.ShowDialog();
            result = login.Validated;
            return result;
        }

        public AppManager()
        {
            if (SplashScreen())
            {
                if (LoginScreen())
                {
                    var home = new Home();
                    home.ShowDialog();
                }
            }
        }
    }
}