using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginBancario
{
    public partial class Form1 : Form
    {
        Stopwatch cronometro;
        SerialPort puertoDestino;
        Thread thread;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cronometro = new Stopwatch();
            using(var ventanaLogin = new PantallaCredenciales())
            {
                var credenciales = ventanaLogin.ShowDialog();
                string usuario = ventanaLogin.Usuario;
                string contrasena = ventanaLogin.Contrasena;
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, usuario+contrasena).ToUpper();
                    var puertoSerial = EscanearSerial();
                    cronometro.Start();
                    thread = new Thread(new ThreadStart(TiempoEspera));
                    thread.Start();
                    
                    puertoSerial.Write(hash);
                }
            }
        }

        private void TiempoEspera()
        {
            do
            {
                if (cronometro.ElapsedMilliseconds / 1000 >= 7)
                {
                    cronometro.Stop();
                    MessageBox.Show("Tiempo de espera agotado");
                    break;
                }
                else
                    Thread.Sleep(1000);
            } while (true);
            Application.Exit();
            thread.Abort();
            
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            
            return sBuilder.ToString();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string line = puertoDestino.ReadLine();
            puertoDestino.Close();
            ComprobarCredenciales(line);
        }

        private void ComprobarCredenciales(string credenciales)
        {
            if (credenciales.StartsWith("Y"))
            {
                MessageBox.Show("Bienvenido");
                this.BeginInvoke(new ObtenerDatosTablaEvent(ObtenerDatosTabla));
            }
            else
            {
                MessageBox.Show("Incorrecto");
                Application.Exit();
            }
        }

        private SerialPort EscanearSerial()
        {
            var puertosSerialesDisponibles = SerialPort.GetPortNames();
            
            
            foreach (var puerto in puertosSerialesDisponibles)
            {
                puertoDestino = new SerialPort(puerto);
                puertoDestino.DataReceived += serialPort1_DataReceived;
                puertoDestino.BaudRate = 9600;
                puertoDestino.Open();
                return puertoDestino;
            }
            return null;
        }

        private delegate void ObtenerDatosTablaEvent();
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