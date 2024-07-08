using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms; 

namespace ExamenProgreso3_Progra_1.Forms
{
    public partial class UpdateForm : Form
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["ExamenProgreso3_Progra_1.Properties.Settings.Programacion_I_ExamConnectionString"].ConnectionString;

        public UpdateForm()
        {
            InitializeComponent();
            textBox4.Hide();
            label6.Hide();
            label4.Hide();
            textBox2.Hide();
            label2.Hide();
            textBox1.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormManager formManager = new FormManager();
            formManager.Menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string consulta_actualizar = "update products set ProCount = @valor, ProName = @Name, ProPrice = @price where Id = @id";
                SqlCommand comando = new SqlCommand(consulta_actualizar, conexion);
                comando.Parameters.AddWithValue("@valor", Convert.ToInt64(textBox2.Text));//
                comando.Parameters.AddWithValue("@Name",  (textBox4.Text).ToString());
                comando.Parameters.AddWithValue("@price", Convert.ToDecimal(textBox1.Text));//
                comando.Parameters.AddWithValue("@id", Convert.ToInt32(textBox3.Text));
               
                if (comando.ExecuteNonQuery()>0) { 
                    MessageBox.Show("Guardado exitosamente!","Exito", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("El producto ya existe!", "Error", MessageBoxButtons.OK);
                }
                FormManager formManager = new FormManager();
                formManager.Menu.Show();
                this.Hide();
            }
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'programacion_I_ExamDataSet.Products' Puede moverla o quitarla según sea necesario.
            this.productsTableAdapter.Fill(this.programacion_I_ExamDataSet.Products);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox3.Text, out int id);

            string consulta_traercount = "select * from Products where Id = @id";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand(consulta_traercount, conexion);
                cmd.Parameters.AddWithValue("@id", id);
                object count = cmd.ExecuteScalar();
                if (count != null)
                {
                    MessageBox.Show("ID encontrado", "Exito", MessageBoxButtons.OK);
                    textBox4.Show();
                    label6.Show();
                    label4.Show();
                    textBox2.Show();
                    label2.Show();
                    textBox1.Show();
                    textBox3.Hide();
                    label9.Hide();
                    button1.Hide();
                }
                else
                {
                    MessageBox.Show("El ID ingresado no existe.", "Error", MessageBoxButtons.OK);
                    textBox3.Show();
                    label9.Show();
                    button1.Show();
                    textBox4.Hide();
                    label6.Hide();
                    label4.Hide();
                    textBox2.Hide();
                    label2.Hide();
                    textBox1.Hide();
                }
            }
        }
    }
}
