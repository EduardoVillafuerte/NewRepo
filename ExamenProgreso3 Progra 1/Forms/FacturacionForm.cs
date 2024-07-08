using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExamenProgreso3_Progra_1.Forms
{
    public partial class FacturacionForm : Form
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["ExamenProgreso3_Progra_1.Properties.Settings.Programacion_I_ExamConnectionString"].ConnectionString;
        decimal total = 0;
        string basePath = "C:/Algoritmos/C/Facturas/facturaN";
        string extension = ".txt";
        string path = $"";
        int a = 0;
        decimal acumulador =0;
        public int Cedula { get; set; }


        public FacturacionForm()
        {
            InitializeComponent();
            button1.Hide();
        }    

        private void FacturacionForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'programacion_I_ExamDataSet.Products' Puede moverla o quitarla según sea necesario.
            this.productsTableAdapter.Fill(this.programacion_I_ExamDataSet.Products);

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            FormManager manager = new FormManager();
            manager.Menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox2.Text, out int Id);
            int.TryParse(textBox3.Text, out int cantidad);
            if(ActualizarInventario(cantidad, Id))
            {
                MessageBox.Show("Se agrego al carrito","Exito!",MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No existen suficientes elementos en existencia","Error",MessageBoxButtons.OK);
            }
            this.productsTableAdapter.Fill(this.programacion_I_ExamDataSet.Products);
            textBox2.Text = null;
            textBox3.Text = null;
        }

        private bool ActualizarInventario(int valor, int Id)
        {
            btn1.Hide();
            button1.Show();
            int numerofactura = traernumerofactura();
            path = $"{basePath}{numerofactura}{extension}";

            if (a == 0)
            {   
                Productos products = new Productos();
                int cedula = Cedula;
                string consulta_traernombre = "select Nombre from clientes where cedula = @cedula";
                string consulta_traerlastnombre = "select apellido from clientes where cedula = @cedula";
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    SqlCommand comm1 = new SqlCommand(consulta_traernombre, conexion);
                    comm1.Parameters.AddWithValue("@cedula", cedula);
                    object name = comm1.ExecuteScalar();

                    SqlCommand comm2 = new SqlCommand(consulta_traerlastnombre, conexion);
                    comm2.Parameters.AddWithValue("@cedula", cedula);
                    object lastname = comm2.ExecuteScalar();

                    using (StreamWriter write = new StreamWriter(path, true))
                    {
                        write.WriteLine($"-----------------Facturación Marathon Sports-------------------");
                        write.WriteLine($"Cedula: {cedula}");
                        write.WriteLine($"Nombre del usuario: {name.ToString()} {lastname.ToString()}");
                        write.WriteLine($"Número de factura: {numerofactura}");
                        write.WriteLine($"Id | Descripción | Precio | Cantidad | Total");
                        write.WriteLine();
                        a = 1;
                    }
                }
            }

            string consulta_traercount = "select ProCount from Products where Id = @id";
            string consulta_traername = "select ProName from Products where Id = @id";
            string consulta_traerprince = "select ProPrice from Products where Id = @id";
            string consulta_actualizar = "update products set ProCount = @valor where Id = @id";
            string consultafacturacion = "insert into Facturacion (Id,Cedula,Cantidad,NFactura) values (@id,1234567890,@valor,@nfactura)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand(consulta_traercount, conexion);
                cmd.Parameters.AddWithValue("@id", Id);
                object resultado = cmd.ExecuteScalar();
                int productCount = Convert.ToInt32(resultado);

                if (productCount - valor >= 0)
                {
                    SqlCommand comando = new SqlCommand(consulta_actualizar, conexion);
                    comando.Parameters.AddWithValue("@valor", productCount - valor);
                    comando.Parameters.AddWithValue("@id", Id);
                    comando.ExecuteNonQuery();

                    SqlCommand com = new SqlCommand(consultafacturacion, conexion);
                    com.Parameters.AddWithValue("@valor", valor);
                    com.Parameters.AddWithValue("@id", Id);
                    com.Parameters.AddWithValue("@nfactura", numerofactura);
                    com.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand(consulta_traername, conexion);
                    cmd1.Parameters.AddWithValue("@id", Id);
                    object Proname = cmd1.ExecuteScalar();

                    SqlCommand cmd2 = new SqlCommand(consulta_traerprince, conexion);
                    cmd2.Parameters.AddWithValue("@id", Id);
                    object productPrice = cmd2.ExecuteScalar();

                    total = Convert.ToDecimal(productPrice)*valor;
                    List<Productos> listaProductos = new List<Productos> {
                        new Productos { Id = Id, ProductoName = Proname.ToString(), ProductoPrice = Convert.ToDecimal(productPrice), ProductoNum = valor, NFactura = numerofactura, Total = total, Cantidad = valor }
                    };

                    acumulador += total;
                    using (StreamWriter writer = new StreamWriter(path,true))
                    {
                        foreach (var producto in listaProductos)
                        {
                            writer.WriteLine($"{producto.Id} | {producto.ProductoName} | {producto.ProductoPrice} | {producto.ProductoNum} | {producto.Total}");
                            writer.WriteLine(); 
                        }
                    }
                    return true;
                }
                else
                {

                return false; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void Actualizarnumerofactura(int numerofactura)
        {
            
            string consulta_actualizar = "update NumeroFact set NumeroFacturas = @num";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta_actualizar, conexion);
                comando.Parameters.AddWithValue("@num", numerofactura+1);
                int filasAfectadas = comando.ExecuteNonQuery();       
            
            }
        }

        private int traernumerofactura()
        {
            string consulta_traer = "select * from NumeroFact";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(consulta_traer, conexion);
                conexion.Open();
                object resultado = cmd.ExecuteScalar();
                int number = Convert.ToInt32(resultado);
                return number;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (StreamWriter write = new StreamWriter(path, true))
            {
                write.WriteLine($"                                 IVA 15% = {double.Parse(acumulador.ToString()) * 0.15}");
                write.WriteLine($"                                 Subtotal = {acumulador}");
                write.WriteLine($"                                 Total = {double.Parse(acumulador.ToString()) * 1.15}");
                write.WriteLine();
                a = 1;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true,
                Verb = "open"
            });
            FormManager manager = new FormManager();
            manager.Menu.Show();
            this.Hide();
            int numerofactura = traernumerofactura();
            Actualizarnumerofactura(numerofactura);
            a = 0;
            acumulador = 0;
        }
    }
}
