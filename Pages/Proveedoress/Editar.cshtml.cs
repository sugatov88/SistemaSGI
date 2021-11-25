using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;

namespace SistemaSGI.Pages.Proveedoress
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Proveedores Proveedores { get; set; }
        
        
    
        public async void OnGet(int id)
            {

            Proveedores = await _contexto.Proveedores.FindAsync(id);
            }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)

            {
                var ProveedoresDesdeDb = await _contexto.Proveedores.FindAsync(Proveedores.Id);
                ProveedoresDesdeDb.Nombre = Proveedores.Nombre;
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
