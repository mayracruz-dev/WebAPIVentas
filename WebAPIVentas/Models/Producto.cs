using System;
using System.Collections.Generic;

namespace WebAPIVentas.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public decimal Precio { get; set; }
    }
}
