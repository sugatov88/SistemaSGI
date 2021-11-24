using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{
    public class Categoria
    {
        

        [Key]
        //[Display(Name = "codigo")]
        public int Id { get; set; }
        
        [Required(ErrorMessage="Este campo es obligatorio")]
        [Display(Name = "Categoria")]
        public string nombreCategoria { get; set; }

       
    }
}
