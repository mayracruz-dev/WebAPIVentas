using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using WebAPIVentas.Models;

using Microsoft.AspNetCore.Cors;

using System;

namespace WebAPIVentas.Controllers
{
    [EnableCors("ReglaCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public readonly DBVENTAContext _dbcontext;

        public ProductoController(DBVENTAContext _context)
        {
            _dbcontext = _context;
        }

        //crear api para listar

        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                lista = _dbcontext.Productos.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }

        //crear api para obtener

        [HttpGet]
        [Route("Obtener/{IdProducto:int}")]

        public IActionResult Obtener(int IdProducto)
        {
            Producto oProducto = _dbcontext.Productos.Find(IdProducto);

            if (oProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }
            else
            {
                try
                {
                    oProducto = _dbcontext.Productos.Where(p => p.IdProducto == IdProducto).FirstOrDefault();

                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oProducto });
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oProducto });
                }
            }
        }

        //crear api para guardar

        [HttpPost]
        [Route("Guardar")]

        public IActionResult Guardar([FromBodyAttribute] Producto objeto)
        {

            try
            {
                _dbcontext.Productos.Add(objeto);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Producto Creado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        //crear api para editar

        [HttpPut]
        [Route("Editar")]

        public IActionResult Editar([FromBodyAttribute] Producto objeto)
        {
            Producto oProducto = _dbcontext.Productos.Find(objeto.IdProducto);

            if (oProducto == null) 
            {
                return BadRequest("Producto no encontrado");
            }

            else
            {
                try
                {
                    oProducto.Codigo = objeto.Codigo;
                    oProducto.Descripcion = objeto.Descripcion;
                    oProducto.Marca = objeto.Marca;
                    oProducto.Precio = objeto.Precio;

                    _dbcontext.Productos.Update(oProducto);
                    _dbcontext.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "Producto Editado" });
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

                }
            }


        }

        //crear un api para eliminar

        [HttpDelete]
        [Route("Eliminar/{IdProducto:int}")]

        public IActionResult Eliminar(int IdProducto)
        {
            Producto oProducto = _dbcontext.Productos.Find(IdProducto);

            if (oProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }

            else
            {
                try
                {

                    _dbcontext.Productos.Remove(oProducto);
                    _dbcontext.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "Producto Eliminado" });
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

                }
            }

        }
    }
}
