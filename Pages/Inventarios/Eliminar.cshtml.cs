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
    public class EliminarModel : PageModel
    {


        private readonly ApplicationDbContext _contexto;

        public EliminarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public CrearInventarioVm InventariosVm { get; set; }



        public async Task<IActionResult> OnGet(int id)
        {
            InventariosVm = new CrearInventarioVm()
            {
                ListaCategorias = await _contexto.Categoria.ToListAsync(),
                ListaProvedores = await _contexto.Proveedores.ToListAsync(),
                Inventario = await _contexto.Inventario.FindAsync(id)




            };
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {


            {
                var productos = await _contexto.Inventario.FindAsync(InventariosVm.Inventario.Id);
                if (productos == null)
                {
                    return NotFound();
                }

                _contexto.Inventario.Remove(productos);
                

                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }

        }
    }
}
