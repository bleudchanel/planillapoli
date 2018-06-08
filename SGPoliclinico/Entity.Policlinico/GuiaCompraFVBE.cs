using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Policlinico
{
    public class GuiaCompraFVBE
    {
        public int NumGuiaCom { get; set; }
           public int Tipo_Compra { get; set; }
           public int Id_Proveedor { get; set; }
           public int Tipo_Doc { get; set; }
           public string Num_Doc{ get; set; }
           public string Fecha_Recepcion { get; set; }
           public int Id_Medicamento { get; set; }
           public int StockPrevio { get; set; }
           public decimal PreCosto { get; set; }
           public decimal PreVenta{ get; set; }
           public int Cantidad { get; set; }
           public decimal SubTotal { get; set; }
           public string FechaVencimiento { get; set; }
           public string Lote { get; set; }
           public int Id_Servicio { get; set; }      
           public int? Contado { get; set; }
           public int Id_Usuario { get; set; }
    }
}
