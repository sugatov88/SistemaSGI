using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;

namespace SistemaSGI.Pages.Administradores
{
    public class CrearModel : PageModel
    {
          
    
        private readonly ApplicationDbContext _contexto;

        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Administrador Administrador { get; set; }
        public void OnGet()
        {
        }
        public async Task <IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _contexto.Administrador.AddAsync(Administrador);
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
