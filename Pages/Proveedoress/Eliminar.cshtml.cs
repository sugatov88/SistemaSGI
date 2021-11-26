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
    public class EliminarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EliminarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Proveedores Proveedores { get; set; }
        
        
    
        public  void OnGet(int id)
            {

            Proveedores = _contexto.Proveedores.Find(id);
            }

        public  IActionResult OnPost()
        {
          

            {
                var ProveedoresDesdeDb =  _contexto.Proveedores.Find(Proveedores.Id);
                if(ProveedoresDesdeDb== null)
                {
                    return NotFound();
                }
                _contexto.Proveedores.Remove(ProveedoresDesdeDb);
                ProveedoresDesdeDb.Nombre = Proveedores.Nombre;
               
                 _contexto.SaveChanges();
                return RedirectToPage("Index");
            }
           
        }
    }
}
