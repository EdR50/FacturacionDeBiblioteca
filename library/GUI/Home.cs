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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            
        }

        private void Home_Load(object sender, EventArgs e)
        {
            RenderInfoBook();
            RenderUserInfo();
        }
        
        
        //Mostrar lista de libros
        private void RenderInfoBook()
        {
            var bookInfo = CacheManager.CLS.Cache.RenderInfoBooks();
            

            // Mostrando los libros en la tabla
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bookInfo;
        }

        //Mostrar informacion del usuario actual en la sesion.
        private void RenderUserInfo()
        {
            usernameDisplay.Text = SessionManager.CLS.Usuario.NombreUsuario;
            emDisplay.Text = SessionManager.CLS.Usuario.Email;
        }
        
        
    }
}
