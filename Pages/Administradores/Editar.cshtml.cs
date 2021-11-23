using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;

namespace SistemaSGI.Pages.Administradores
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Administrador Administrador { get; set; }
        
        
    
        public async void OnGet(int id)
            {

            Administrador = await _contexto.Administrador.FindAsync(id);
            }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)

            {
                var AdministradorDesdeDb = await _contexto.Administrador.FindAsync(Administrador.Id);

                AdministradorDesdeDb.nombre = Administrador.nombre;
               
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
