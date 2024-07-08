using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenProgreso3_Progra_1.Forms
{
    public partial class Validacion : Form
    {

        public Validacion()
        {
            InitializeComponent();
            label2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int cedula);

            if (ComprobarCedula(cedula))
            {
                this.Hide();
                FacturacionForm Fact = new FacturacionForm();
                Fact.Cedula = cedula; 
                Fact.Show();
            }
            else
            {
                label2.Show();
            }


        }


        private bool ComprobarCedula(int valor)
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ExamenProgreso3_Progra_1.Properties.Settings.Programacion_I_ExamConnectionString"].ConnectionString;
            string consulta = "select Count(*) from clientes where cedula = @valor";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@valor", valor);
                conexion.Open();
                int count = (int)comando.ExecuteScalar();
                return count > 0;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormManager manager = new FormManager();
            manager.Menu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormManager manager = new FormManager();
            manager.Aggusuario.Show();
            this.Hide();
        }
    }
}
