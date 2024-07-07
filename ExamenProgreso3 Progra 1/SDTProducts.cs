using ExamenProgreso3_Progra_1.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenProgreso3_Progra_1
{
    public class SDTProducts
    {
        string ProdutcoName;
        float ProductoPrice;
        int ProductoNum;

    }
    public class FormManager
    {
        public Form Inventory { get; set; } = new ShowInventory();
        public Form Create { get; set; } = new CreateForm();
        public Form Delete { get; set; } = new DeleteForm();
        public Form Facturacion { get; set; } = new FacturacionForm();
        public Form Update { get; set; } = new UpdateForm();
 
    }
}

