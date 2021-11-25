using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;

namespace SistemaSGI.Pages.Bodegas
{
    public class EliminarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EliminarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Bodega Bodega { get; set; }
        
        
    
        public async void OnGet(int id)
            {

            Bodega = await _contexto.Bodega.FindAsync(id);
            }

        public async Task<IActionResult> OnPost()
        {
          

            {
                var BodegaDesdeDb = await _contexto.Bodega.FindAsync(Bodega.Id);
                if(BodegaDesdeDb== null)
                {
                    return NotFound();
                }
                _contexto.Bodega.Remove(BodegaDesdeDb);
                BodegaDesdeDb.Codigo = Bodega.Codigo;
                BodegaDesdeDb.Stock = Bodega.Stock;

                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
           
        }
    }
}
