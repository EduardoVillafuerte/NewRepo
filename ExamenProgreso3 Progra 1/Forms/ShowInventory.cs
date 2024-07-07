using System;

using System.Windows.Forms;

namespace ExamenProgreso3_Progra_1.Forms
{
    public partial class ShowInventory : Form
    {
        public ShowInventory()
        {
            InitializeComponent();
        }

        private void ShowInventory_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'programacion_I_ExamDataSet.Products' Puede moverla o quitarla según sea necesario.
            this.productsTableAdapter.Fill(this.programacion_I_ExamDataSet.Products);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }   
    }
}
