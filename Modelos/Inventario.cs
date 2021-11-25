using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{
    public class Inventario
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
       
        public int CategoriaId {get;set;}
       

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }

        [Display(Name = "Unidades")]
        public int Unidades { get; set; }

        [Display(Name = "Precio")]
        public int Precio { get; set; }
       

        public int ProveedoresId { get; set; }
       


        [Display(Name = "Proveedor")]
        public Proveedores _proveedor { get; set; }

        [Display(Name = "Marca")]
        public string Marca { get; set; }

        
        public int BodegaId { get; set; }
        [Display(Name = "Bodega")]
        public Bodega Bodega { get; set; }




    }
}
