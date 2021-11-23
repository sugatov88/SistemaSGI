using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;

namespace SistemaSGI.Pages.Clientes
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }
        
        
    
        public async void OnGet(int id)
            {

            Cliente = await _contexto.Cliente.FindAsync(id);
            }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)

            {
                var ClienteDesdeDb = await _contexto.Cliente.FindAsync(Cliente.Id);

                ClienteDesdeDb.nombre = Cliente.nombre;
               
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
