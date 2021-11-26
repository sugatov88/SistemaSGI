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
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }
        
        
    
        public void OnGet(int id)
            {

            Cliente =  _contexto.Cliente.Find(id);
            }

        public  IActionResult OnPost()
        {
            if (ModelState.IsValid)

            {
                var ClienteDesdeDb =  _contexto.Cliente.Find(Cliente.Id);

                ClienteDesdeDb.Nombre = Cliente.Nombre;
                ClienteDesdeDb.Apellido = Cliente.Apellido;
                ClienteDesdeDb.Documento = Cliente.Documento;
                ClienteDesdeDb.Direccion = Cliente.Direccion;
                ClienteDesdeDb.Email = Cliente.Email;
                ClienteDesdeDb.Telefono = Cliente.Telefono;

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
