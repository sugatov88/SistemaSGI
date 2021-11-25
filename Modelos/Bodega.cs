using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{
    public class Bodega
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Seccion")]
      
        public string Codigo { get; set; }
        [Display(Name= "Stock")]
        public string Stock { get; set; }

       
    }
}
