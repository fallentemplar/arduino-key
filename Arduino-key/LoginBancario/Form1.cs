using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginBancario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using(var ventanaLogin = new PantallaCredenciales())
            {
                var credenciales = ventanaLogin.ShowDialog();
                string usuario = ventanaLogin.Usuario;
                string contrasena = ventanaLogin.Contrasena;
                if ((usuario + contrasena).Equals("alexisseguridad123"))
                    ObtenerDatosTabla();
                else
                {
                    MessageBox.Show("Incorrecto");
                    Application.Exit();
                }                    
            }
        }

        private SerialPort EscanearSerial()
        {
            var puertosSerialesDisponibles = SerialPort.GetPortNames();
            SerialPort puertoDestino;
            
            foreach (var puerto in puertosSerialesDisponibles)
            {
                puertoDestino = new SerialPort(puerto);
                puertoDestino.BaudRate = 9600;
                puertoDestino.Open();
                return puertoDestino;
            }
            return null;
        }

        private void ObtenerDatosTabla()
        {
            MySqlConnection mysqlCon = new MySqlConnection("server=localhost;user id=root;password=oracle;database=Banco");
            mysqlCon.Open();

            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "select idUsuario 'ID Cliente', nombre 'Nombre', email 'Email', concat('$ ', balance) 'Balance', estatus 'Estatus' from Usuarios";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, mysqlCon);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dataGridView1.DataSource = bSource;
        }
    }
}
