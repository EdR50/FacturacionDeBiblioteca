using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library.GUI
{
    public partial class Manage : Form
    {
        public Manage()
        {
            InitializeComponent();
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            RenderInfoBookManage();
            RenderUserInfoManage();
        }

        private void RenderInfoBookManage()
        {
            var bookInfoManage = CacheManager.CLS.Cache.RenderInfoBooksManage();


            
            dg.AutoGenerateColumns = false;
            dg.DataSource = bookInfoManage;
        }

        
        private void RenderUserInfoManage()
        {
            usernameDisplay.Text = SessionManager.CLS.Usuario.NombreUsuario;
            emDisplay.Text = SessionManager.CLS.Usuario.Email;
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Close();
        }
    }
}
