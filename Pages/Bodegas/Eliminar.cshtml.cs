using System;
using System.Collections.Generic;
using System.Linq;

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
        
        
    
        public  void OnGet(int id)
            {

            Bodega =  _contexto.Bodega.Find(id);
            }

        public  IActionResult OnPost()
        {
          

            {
                var BodegaDesdeDb =  _contexto.Bodega.Find(Bodega.Id);
                if(BodegaDesdeDb== null)
                {
                    return NotFound();
                }
                _contexto.Bodega.Remove(BodegaDesdeDb);
                BodegaDesdeDb.Codigo = Bodega.Codigo;
                BodegaDesdeDb.Stock = Bodega.Stock;

                 _contexto.SaveChanges();
                return RedirectToPage("Index");
            }
           
        }
    }
}
