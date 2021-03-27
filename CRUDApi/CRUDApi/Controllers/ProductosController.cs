using CRUDApi.Data;
using CRUDApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoContext productoContexto;

        public ProductosController(ProductoContext productoContexto)
        {
            this.productoContexto = productoContexto;
        }

        // Peticion asyncrona get del dataset de productos
        // Peticion GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> getProductos()
        {
            IEnumerable<Producto> listaProductos = await productoContexto.Producto.ToListAsync();

            return Ok(listaProductos);
        }

        // Peticion GET: api/Productos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> getProducto(int id)
        {
            Producto producto = await productoContexto.Producto.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // Peticion POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<Producto>> addProducto(Producto producto)
        {
            Producto ultimoProducto = await productoContexto.Producto.OrderByDescending(o => o.Id).FirstOrDefaultAsync();

            if(ultimoProducto!=null && ultimoProducto.Id > 0)
            {
                producto.Id = ultimoProducto.Id + 1;
            }

            productoContexto.Producto.Add(producto);
            await productoContexto.SaveChangesAsync();

            return CreatedAtAction(nameof(getProducto), new { id = producto.Id }, producto);
        }

        // Peticion PUT: api/Productos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> updateProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            productoContexto.Entry(producto).State = EntityState.Modified;
            await productoContexto.SaveChangesAsync();

            return NoContent();
        }

        // Peticion DELETE: api/Productos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteProducto(int id)
        {
            Producto producto = await productoContexto.Producto.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            productoContexto.Producto.Remove(producto);
            await productoContexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
