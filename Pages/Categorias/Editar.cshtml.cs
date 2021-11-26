using System;
using System.Collections.Generic;
using System.Linq;

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
        
        
    
        public  void OnGet(int? id)
            {

            Categoria =  _contexto.Categoria.Find(id);
            }

        public  IActionResult OnPost()
        {
            if (ModelState.IsValid)

            {
                var CategoriaDesdeDb =  _contexto.Categoria.Find(Categoria.Id);

                CategoriaDesdeDb.NombreCategoria = Categoria.NombreCategoria;
               
                 _contexto.SaveChanges();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
