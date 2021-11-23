using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{
  
     public class Proveedores
    {
        [Key]
        public int Id { get; set; }  
        [Required]
        public string nombre { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string web { get; set; }
        [Required]
        public string telefono { get; set; }

    }

}
