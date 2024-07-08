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
            this.productsTableAdapter.Fill(this.programacion_I_ExamDataSet.Products);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormManager Windows = new FormManager();
            Windows.Menu.Show();
            this.Hide();
        }   
    }
}
