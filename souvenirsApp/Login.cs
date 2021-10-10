using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_logica;

namespace souvenirsApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
                var validar = UsuarioController.validarUsuario(txtUser.Text, txtPass.Text);
                if (validar)
                {
                
                    mainScreen ms = new mainScreen();
                    ms.Show();
                    this.Hide();
                }
                else
                {
                MessageBox.Show("Usuario y/o Contraseña invalidos!");
                txtUser.Text = "";
                txtPass.Text = "";
                }  

               
              
            



        }
    }
}
