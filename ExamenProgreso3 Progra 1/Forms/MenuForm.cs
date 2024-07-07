using System;
using System.Windows.Forms;

namespace ExamenProgreso3_Progra_1.Forms
{
    public partial class MenuForm : Form
    {        public FormManager formmanager;
        public MenuForm()
        {
            InitializeComponent();
            formmanager = new FormManager();
        }

        private void CloseWindow()
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formmanager.Inventory.Show();
            CloseWindow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formmanager.Create.Show();
            CloseWindow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formmanager.Delete.Show(); 
            CloseWindow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formmanager.Update.Show();
            CloseWindow();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formmanager.Facturacion.Show();
            CloseWindow();
        }
    }
}
