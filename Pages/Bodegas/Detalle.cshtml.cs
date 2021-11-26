using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;


namespace SistemaSGI.Pages.Bodegas
{

    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public  DetalleModel (ApplicationDbContext contexto)
          {
            _contexto = contexto;
        }

        [BindProperty]
        public Bodega Bodega { get; set; }



        public  void OnGet(int id)
        {

            Bodega =  _contexto.Bodega.Find(id);
        }
    }

}
