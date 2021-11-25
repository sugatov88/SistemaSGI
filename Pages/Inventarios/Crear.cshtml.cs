using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;
using SistemaSGI.Modelos.ViewModels;

namespace SistemaSGI.Pages.Inventarios
{
    public class CrearModel : PageModel
    {


        private readonly ApplicationDbContext _contexto;

        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public CrearInventarioVm InventarioVm { get; set; }



        public async Task<IActionResult> OnGet()
        {
            InventarioVm = new CrearInventarioVm()
            {
                ListaProductos = await _contexto.Productos.ToListAsync(),
                Inventario = new Modelos.Inventario()




            };
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _contexto.Inventario.AddAsync(InventarioVm.Inventario);
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
