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
    public class EditarModel : PageModel
    {


        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public CrearInventarioVm InventarioVm { get; set; }



        public async Task<IActionResult> OnGet(int id)
        {
            InventarioVm = new CrearInventarioVm()
            {
                ListaProductos = await _contexto.Productos.ToListAsync(),
                Inventario = await _contexto.Inventario.FindAsync(id)




            };
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)


            {
                var InventarioDesdeDb = await _contexto.Inventario.FindAsync(InventarioVm.Inventario.Id);
                InventarioDesdeDb.Productos = InventarioVm.Inventario.Productos;
                InventarioDesdeDb.Codigo = InventarioVm.Inventario.Codigo;
                InventarioDesdeDb.Stock = InventarioVm.Inventario.Stock;
                
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
