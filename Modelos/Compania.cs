using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{
  
     public class Compania
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nit")]

        public string Nit { get; set; }
        [Display(Name = "Razón social")]
        public string Nombre { get; set; }
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
        [Display(Name = "E-mail")]

        public string Email { get; set; }
        [Display(Name = "Sitio Web")]
        public string Web { get; set; }
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

    }

}
