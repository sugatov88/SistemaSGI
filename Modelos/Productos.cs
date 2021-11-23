using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string nombre { get; set; }
        [Required]
        public int categoriaId {get;set;}
        [Required]
        public Categoria categoria { get; set; }
        [Required]

        public int unidades { get; set; }
        [Required]

        public int precio { get; set; }
        [Required]

        public int proveedoresId { get; set; }
        [Required]

        public Proveedores _proveedor { get; set; }
        [Required]

        public string marca { get; set; }


    }
}
