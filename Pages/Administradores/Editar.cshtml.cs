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
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Administrador Administrador { get; set; }
        
        
    
        public  void OnGet(int? id)
            {

            Administrador =  _contexto.Administrador.Find(id);
            }

        public  IActionResult OnPost()
        {
            if (ModelState.IsValid)

            {
                var AdministradorDesdeDb =  _contexto.Administrador.Find(Administrador.Id);
                AdministradorDesdeDb.Nombre = Administrador.Nombre;
                AdministradorDesdeDb.Apellido = Administrador.Apellido;
                AdministradorDesdeDb.Documento = Administrador.Documento;
                AdministradorDesdeDb.Direccion = Administrador.Direccion;
                AdministradorDesdeDb.Email = Administrador.Email;
                AdministradorDesdeDb.Telefono = Administrador.Telefono;

                 _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
