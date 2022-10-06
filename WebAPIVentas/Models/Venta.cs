using System;
using System.Collections.Generic;

namespace WebAPIVentas.Models
{
    public partial class Venta
    {
        public int IdVenta { get; set; }
        public string Usuario { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
