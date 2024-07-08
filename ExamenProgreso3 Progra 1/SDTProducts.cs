using ExamenProgreso3_Progra_1.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenProgreso3_Progra_1
{
    public class Productos
    {
        public int Id { get; set; }
        public string ProductoName { get; set; } 
        public decimal ProductoPrice { get; set; }
        public int ProductoNum { get; set; }
        public int NFactura { get; set; }
        public decimal Total { get; set; }
        public int Cantidad { get; set;}
    }
    public class FormManager
    {
        public Form Inventory { get; set; } = new ShowInventory();
        public Form Create { get; set; } = new CreateForm();
        public Form Delete { get; set; } = new DeleteForm();
        public Form Facturacion { get; set; } = new FacturacionForm();
        public Form Update { get; set; } = new UpdateForm();
        public Form Validacionccedula { get; set; } = new Validacion();
        public Form Menu { get; set; } = new MenuForm();
        public Form Aggusuario { get; set; } = new Agregarusuario();

    }
}

