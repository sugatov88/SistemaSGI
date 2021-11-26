using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;

namespace SistemaSGI.Pages.Administradores
{
    public class EliminarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EliminarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Administrador Administrador { get; set; }
        
        
    
        public  void OnGet(int id)
            {

            Administrador =  _contexto.Administrador.Find(id);
            }

        public  IActionResult OnPost()
        {
          

            {
                var AdministradorDesdeDb =  _contexto.Administrador.Find(Administrador.Id);
                if(AdministradorDesdeDb== null)
                {
                    return NotFound();
                }
                _contexto.Administrador.Remove(AdministradorDesdeDb);
                AdministradorDesdeDb.Nombre = Administrador.Nombre;
               
                 _contexto.SaveChanges();
                return RedirectToPage("Index");
            }
           
        }
    }
}
