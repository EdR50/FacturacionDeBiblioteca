using System;
using System.Windows.Forms;

namespace library.GUI
{
    public partial class Login : Form
    {
        
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
                _validated = initialSession.Login(txtNom.Text.Trim(), txtCon.Text.Trim());
                if (_validated)
                {
                    Close();
                }
                else
                {
                    lble.Text = "Usuario o contraseña incorrecta";
                    txtNom.Text = "";
                    txtCon.Text = "";
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