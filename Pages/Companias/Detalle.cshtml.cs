using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;


namespace SistemaSGI.Pages.Companias
{

    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public  DetalleModel (ApplicationDbContext contexto)
          {
            _contexto = contexto;
        }

        [BindProperty]
        public Compania Compania { get; set; }



        public  void OnGet(int id)
        {

            Compania =  _contexto.Compania.Find(id);
        }
    }

}
