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
    public class EliminarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EliminarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }
        
        
    
        public  void OnGet(int id)
            {

            Cliente =  _contexto.Cliente.Find(id);
            }

        public  IActionResult OnPost()
        {
          

            {
                var ClienteDesdeDb =  _contexto.Cliente.Find(Cliente.Id);
                if(ClienteDesdeDb== null)
                {
                    return NotFound();
                }
                _contexto.Cliente.Remove(ClienteDesdeDb);
                ClienteDesdeDb.Nombre = Cliente.Nombre;
               
                 _contexto.SaveChanges();
                return RedirectToPage("Index");
            }
           
        }
    }
}
