using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
       

        public string nombre { get; set; }
       
        public int categoriaId {get;set;}
       

        [Display(Name = "Categoria")]
        public Categoria categoria { get; set; }
       

        public int unidades { get; set; }
       

        public int precio { get; set; }
       

        public int proveedoresId { get; set; }
       


        [Display(Name = "Proveedor")]
        public Proveedores _proveedor { get; set; }
       

        public string marca { get; set; }


    }
}
