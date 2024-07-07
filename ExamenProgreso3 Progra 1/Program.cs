using ExamenProgreso3_Progra_1.Forms;
using System;
using System.Windows.Forms;

namespace ExamenProgreso3_Progra_1
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuForm());
        }
    }
}regrwes
