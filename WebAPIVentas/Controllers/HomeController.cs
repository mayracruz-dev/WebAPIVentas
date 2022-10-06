using Microsoft.AspNetCore.Mvc;
using Wkhtmltopdf.NetCore;
using System;
using WebAPIVentas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace WebAPIVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        readonly IGeneratePdf _generatePdf;

        public HomeController(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        [HttpGet]
        [Route("PDF")]
        public async Task<IActionResult> GetVenta()
        {
            var ventobj = new Venta();
            {
                int idVenta = ventobj.IdVenta;
                string usuario = ventobj.Usuario;
                string descripcion = ventobj.Descripcion;
                decimal precio = ventobj.Precio;
                int cantidad = ventobj.Cantidad;
                decimal total = ventobj.Total;


            }
            return await _generatePdf.GetPdf ( "View/Venta.cshtml", ventobj);
        }
    }
}
