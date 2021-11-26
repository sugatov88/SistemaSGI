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
    public class CrearModel : PageModel
    {
          
    
        private readonly ApplicationDbContext _contexto;

        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Proveedores Proveedores { get; set; }
        public void OnGet()
        {
        }
        public  IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _contexto.Proveedores.Add(Proveedores);
                _contexto.SaveChanges();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
