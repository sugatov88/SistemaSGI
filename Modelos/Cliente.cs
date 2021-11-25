using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{ 
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Display(Name = "Documento")]
        public string Documento { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
      
    }
}
