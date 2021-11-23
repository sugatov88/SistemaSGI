using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;

namespace SistemaSGI.Pages.Categorias
{
    public class EliminarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EliminarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }
        
        
    
        public async void OnGet(int id)
            {

            Categoria = await _contexto.Categoria.FindAsync(id);
            }

        public async Task<IActionResult> OnPost()
        {
          

            {
                var CategoriaDesdeDb = await _contexto.Categoria.FindAsync(Categoria.Id);
                if(CategoriaDesdeDb== null)
                {
                    return NotFound();
                }
                _contexto.Categoria.Remove(CategoriaDesdeDb);
                CategoriaDesdeDb.nombreCategoria = Categoria.nombreCategoria;
               
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
           
        }
    }
}
