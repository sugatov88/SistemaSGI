using System;
using System.Collections.Generic;
using System.Linq;

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
        
        
    
        public  void OnGet(int id)
            {

            Compania =  _contexto.Compania.Find(id);
            }

        public IActionResult OnPost()
        {
          

            {
                var CompaniaDesdeDb =  _contexto.Compania.Find(Compania.Id);
                if(CompaniaDesdeDb== null)
                {
                    return NotFound();
                }
                _contexto.Compania.Remove(CompaniaDesdeDb);
                CompaniaDesdeDb.Nombre = Compania.Nombre;
               
                 _contexto.SaveChanges();
                return RedirectToPage("Index");
            }
           
        }
    }
}
