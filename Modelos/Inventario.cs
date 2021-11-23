using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{
    public class Inventario
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public int productosId {  get; set; }
        [Required]
        public Productos  productos { get; set; }
        [Required]
        public string codigo { get; set; }
        [Required]
        public string stock { get; set; }

       
    }
}
