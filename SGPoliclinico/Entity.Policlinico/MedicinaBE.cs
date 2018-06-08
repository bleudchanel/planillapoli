using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Policlinico
{
    public class MedicinaBE
    {
           public int Id { get; set; }
           public string Codigo { get; set; }
           public string Descripcion  {get; set;}
           public int Id_Proveedor  {get; set;}
           public int Id_Tipo  {get; set;}
           public int Id_Categoria  {get; set;}
           public int Id_Unidad  {get; set;}
           public int Id_Referencia  {get; set;}
           public int? StockMin  {get; set;}
           public int? StockAct  {get; set;}
           public decimal PreCosto  {get; set;}
           public decimal PreVenta { get; set; }
           public string FechaVencimiento  {get; set;}
           public string Lote { get; set; }
           public int IdUsuario  {get; set;}

           public int idEstado { get; set; }

          
    }
}
