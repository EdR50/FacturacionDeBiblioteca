using System;
using System.Windows.Forms;
using SessionManager.CLS;

namespace library.GUI
{
    public partial class Login : Form
    {
        //usuarios
        private string _username;
        private string _password;

        private bool _validated;

        public bool Validated
        {
            get => _validated;
        }

        public Login()
        {
            InitializeComponent();
            _validated = false;
        }

        private void Validation()
        {
            try
            {
                var initialSession = SessionManager.CLS.Session.Instance;
                _validated = initialSession.Login(txtNom.Text, txtCon.Text);
                if (_validated)
                {
                    Close();
                }
                else
                {
                    Console.WriteLine(@"Error en el usuario");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validation();
        }
    }
}