using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;


namespace SistemaSGI.Pages.Administradores
{

    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public  DetalleModel (ApplicationDbContext contexto)
          {
            _contexto = contexto;
        }

        [BindProperty]
        public Administrador Administrador { get; set; }



        public  void OnGet(int id)
        {

            Administrador =  _contexto.Administrador.Find(id);
        }
    }

}
