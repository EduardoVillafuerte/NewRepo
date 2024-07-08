using System;
using System.Windows.Forms;

namespace ExamenProgreso3_Progra_1.Forms
{
    public partial class MenuForm : Form
    {        
        public MenuForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormManager formmanager = new FormManager();
            formmanager.Inventory.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormManager formmanager = new FormManager();
            formmanager.Create.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormManager formmanager = new FormManager();
            formmanager.Delete.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormManager formmanager = new FormManager();
            formmanager.Update.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormManager formmanager = new FormManager();
            formmanager.Validacionccedula.Show();
            this.Hide();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            FormManager formmanager = new FormManager();
            this.Hide();

        }
    }
}
