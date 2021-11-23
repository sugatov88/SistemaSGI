using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;

namespace SistemaSGI.Pages.Companias
{
    public class EliminarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EliminarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Compania Compania { get; set; }
        
        
    
        public async void OnGet(int id)
            {

            Compania = await _contexto.Compania.FindAsync(id);
            }

        public async Task<IActionResult> OnPost()
        {
          

            {
                var CompaniaDesdeDb = await _contexto.Compania.FindAsync(Compania.Id);
                if(CompaniaDesdeDb== null)
                {
                    return NotFound();
                }
                _contexto.Compania.Remove(CompaniaDesdeDb);
                CompaniaDesdeDb.nombre = Compania.nombre;
               
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
           
        }
    }
}
