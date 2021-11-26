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
    public class EliminarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EliminarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }
        
        
    
        public  void OnGet(int id)
            {

            Categoria =  _contexto.Categoria.Find(id);
            }

        public  IActionResult OnPost()
        {
          

            {
                var CategoriaDesdeDb =  _contexto.Categoria.Find(Categoria.Id);
                if(CategoriaDesdeDb== null)
                {
                    return NotFound();
                }
                _contexto.Categoria.Remove(CategoriaDesdeDb);
                CategoriaDesdeDb.NombreCategoria = Categoria.NombreCategoria;
               
                 _contexto.SaveChanges();
                return RedirectToPage("Index");
            }
           
        }
    }
}
