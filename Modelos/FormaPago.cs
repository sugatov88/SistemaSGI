using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSGI.Modelos
{
    public class FormaPago
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string formaPago { get; set; }


    }
}
