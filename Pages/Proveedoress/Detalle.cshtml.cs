using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;


namespace SistemaSGI.Pages.Proveedoress
{

    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public  DetalleModel (ApplicationDbContext contexto)
          {
            _contexto = contexto;
        }

        [BindProperty]
        public Proveedores Proveedores { get; set; }



        public async void OnGet(int id)
        {

            Proveedores = await _contexto.Proveedores.FindAsync(id);
        }
    }

}
