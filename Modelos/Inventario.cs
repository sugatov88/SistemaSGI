using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{
    public class Inventario
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Producto")]
        public int productosId {  get; set; }
        
        public Productos  productos { get; set; }
        [Display(Name= "Codigo")]
        public string codigo { get; set; }
        [Display(Name= "Stock")]
        public string stock { get; set; }

       
    }
}
