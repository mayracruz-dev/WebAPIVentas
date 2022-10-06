using System;
using System.Collections.Generic;

namespace WebAPIVentas.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apllidos { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Usuario1 { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
