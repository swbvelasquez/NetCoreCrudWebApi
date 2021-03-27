using CRUDApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApi.Data
{
    public class ProductoContext : DbContext
    {
        public ProductoContext(DbContextOptions<ProductoContext> options):base(options)
        {

        }
        //Si se define el nombre de la tabla en la clase con anotaciones, no hace falta que el nombre del data set sea el mismo que la tabla
        //Caso contrario debe llamarse el data set igual a la tabla
        public DbSet<Producto> Producto { get; set; }
    }
}
