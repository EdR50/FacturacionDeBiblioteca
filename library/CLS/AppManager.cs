using library.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library.CLS
{
    class AppManager : ApplicationContext
    {
    
        private Boolean SplashScreen()
        {
            Boolean Result = true;
            Splash s = new Splash();
            s.ShowDialog();

            return Result;
        }

        private Boolean LoginScreen()
        {
            Boolean Result = true;
            Login l = new Login();
            l.ShowDialog();
            return Result;
        }
        public AppManager()
        {
            if (SplashScreen())
            {
                if (LoginScreen())
                {
                    Home h = new Home();
                    h.ShowDialog();
                    
                }
            }
        }
    }
}
