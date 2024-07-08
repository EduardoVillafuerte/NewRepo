using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamenProgreso3_Progra_1.Forms
{
    public partial class DeleteForm : Form
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["ExamenProgreso3_Progra_1.Properties.Settings.Programacion_I_ExamConnectionString"].ConnectionString;

        public DeleteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int id);

            string consulta_traercount = "select * from Products where Id = @id";
            string insertarproductos = "delete from Products where Id = @id";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand(consulta_traercount, conexion);
                cmd.Parameters.AddWithValue("@id", id);
                object count = cmd.ExecuteScalar();
                if (count != null)
                {
                    SqlCommand comando = new SqlCommand(insertarproductos, conexion);
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Eliminado correctamente", "Exito", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("El ID ingresado no existe.", "Error", MessageBoxButtons.OK);

                }
                FormManager formManager = new FormManager();
                formManager.Menu.Show();
                this.Hide();
            }
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'programacion_I_ExamDataSet.Products' Puede moverla o quitarla según sea necesario.
            this.productsTableAdapter.Fill(this.programacion_I_ExamDataSet.Products);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormManager formManager = new FormManager();
            formManager.Menu.Show();
            this.Hide();
        }
    }
}
