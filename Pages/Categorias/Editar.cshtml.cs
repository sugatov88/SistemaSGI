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
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
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
            if (ModelState.IsValid)

            {
                var CategoriaDesdeDb = await _contexto.Categoria.FindAsync(Categoria.Id);

                CategoriaDesdeDb.NombreCategoria = Categoria.NombreCategoria;
               
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
