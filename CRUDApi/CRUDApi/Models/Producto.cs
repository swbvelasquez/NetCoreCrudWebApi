using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApi.Models
{
    //La anotacion mapea el nombre de la tabla y/o columnas en base de datos
    [Table("Producto")]
    public class Producto
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
