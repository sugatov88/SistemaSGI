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
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Compania Compania { get; set; }
        
        
    
        public  void OnGet(int? id)
            {

            Compania =  _contexto.Compania.Find(id);
            }

        public  IActionResult OnPost()
        {
            if (ModelState.IsValid)

            {
                var CompaniaDesdeDb =  _contexto.Compania.Find(Compania.Id);
                CompaniaDesdeDb.Nit = Compania.Nit;
                CompaniaDesdeDb.Nombre = Compania.Nombre;
                CompaniaDesdeDb.Direccion = Compania.Direccion;
                CompaniaDesdeDb.Email = Compania.Email;
                CompaniaDesdeDb.Web = Compania.Web;
                CompaniaDesdeDb.Telefono = Compania.Telefono;
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
