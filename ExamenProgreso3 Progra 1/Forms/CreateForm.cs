using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamenProgreso3_Progra_1.Forms
{
    public partial class CreateForm : Form
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["ExamenProgreso3_Progra_1.Properties.Settings.Programacion_I_ExamConnectionString"].ConnectionString;

        public CreateForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'programacion_I_ExamDataSet1.Products' table. You can move, or remove it, as needed.

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                string Nombreprodu = textBox1.Text;
                int Cantidadprodu = Convert.ToInt32(textBox2.Text);
                float PrecioProdu = float.Parse(textBox4.Text);
                string consulta_traercount = "select ProName from Products where ProName = @name";
                string insertarproductos = "insert into Products (ProName,ProPrice,ProCount) values (@Nprodu,@Pprodu,@Cprodu)";
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand(consulta_traercount, conexion);
                    cmd.Parameters.AddWithValue("@name", Nombreprodu);
                    object count = cmd.ExecuteScalar();
                    if (count == null)
                    {
                        SqlCommand com = new SqlCommand(insertarproductos, conexion);
                        com.Parameters.AddWithValue("@Nprodu", Nombreprodu);
                        com.Parameters.AddWithValue("@Cprodu", Cantidadprodu);
                        com.Parameters.AddWithValue("@Pprodu", PrecioProdu);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Guardado exitosamente!","Exito", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("El producto ya existe!", "Error", MessageBoxButtons.OK);
                    }
                }
                FormManager formManager = new FormManager();
                formManager.Menu.Show();
                this.Hide();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormManager formManager = new FormManager();
            formManager.Menu.Show();
            this.Hide();
        }
    }
}
    