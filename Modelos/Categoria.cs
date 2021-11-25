using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{
    public class Categoria
    {
        

        [Key]
        //[Display(Name = "Codigo")]
        public int Id { get; set; }
        
        [Required(ErrorMessage="Este campo es obligatorio")]
        [Display(Name = "Categoria")]
        public string NombreCategoria { get; set; }

       
    }
}
