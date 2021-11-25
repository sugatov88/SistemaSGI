using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{
    public class Inventario
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Producto")]
        public int ProductosId {  get; set; }
        
        public Productos  Productos { get; set; }
        [Display(Name= "Codigo")]
        public string Codigo { get; set; }
        [Display(Name= "Stock")]
        public string Stock { get; set; }

       
    }
}
