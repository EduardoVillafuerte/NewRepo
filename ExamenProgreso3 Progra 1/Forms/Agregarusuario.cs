using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExamenProgreso3_Progra_1.Forms
{

    public partial class Agregarusuario : Form
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["ExamenProgreso3_Progra_1.Properties.Settings.Programacion_I_ExamConnectionString"].ConnectionString;
        public Agregarusuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                int Cedula = Convert.ToInt32(textBox1.Text);
                string name = textBox2.Text.ToString();
                string lastname = textBox3.Text.ToString();

                string consulta_traercount = "select * from clientes where cedula = @cedula";
                string insertarproductos = "insert into Clientes (cedula,nombre,apellido) values (@cedula,@name,@lastname)";
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand(consulta_traercount, conexion);
                    cmd.Parameters.AddWithValue("@cedula", Cedula);
                    object count = cmd.ExecuteScalar();
                    if (count == null)
                    {
                        SqlCommand com = new SqlCommand(insertarproductos, conexion);
                        com.Parameters.AddWithValue("@cedula", Cedula);
                        com.Parameters.AddWithValue("@name", name);
                        com.Parameters.AddWithValue("@lastname", lastname);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Guardado exitosamente!", "Exito", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("El usuario ya existe!", "Error", MessageBoxButtons.OK);
                    }
                }
                FormManager formManager = new FormManager();
                formManager.Validacionccedula.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormManager formManager = new FormManager();
            formManager.Validacionccedula.Show();
            this.Hide();
        }
    }
}
