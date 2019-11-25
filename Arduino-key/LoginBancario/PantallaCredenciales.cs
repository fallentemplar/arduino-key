using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginBancario
{
    public partial class PantallaCredenciales : Form
    {
        public string Usuario;
        public string Contrasena;

        public PantallaCredenciales()
        {
            InitializeComponent();
        }

        private void botonLogin_Click(object sender, EventArgs e)
        {
            if(campoContrasena.Text.Length>0 && campoUsuario.Text.Length > 0)
            {
                Usuario = campoUsuario.Text;
                Contrasena = campoContrasena.Text;
                this.Close();
            }
            else
                MessageBox.Show("Los campos 'Usuario' y 'Contaseña' no pueden estar vacíos");
        }
    }
}
