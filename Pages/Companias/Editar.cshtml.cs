using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        
    
        public async void OnGet(int id)
            {

            Compania = await _contexto.Compania.FindAsync(id);
            }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)

            {
                var CompaniaDesdeDb = await _contexto.Compania.FindAsync(Compania.Id);

                CompaniaDesdeDb.Nit = Compania.Nit;
                CompaniaDesdeDb.Nombre = Compania.Nombre;
                CompaniaDesdeDb.Direccion = Compania.Direccion;
                CompaniaDesdeDb.Email = Compania.Email;
                CompaniaDesdeDb.Web = Compania.Web;
                CompaniaDesdeDb.Telefono = Compania.Telefono;

                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
