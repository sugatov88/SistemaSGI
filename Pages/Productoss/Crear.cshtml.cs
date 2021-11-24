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

namespace SistemaSGI.Pages.Productoss
{
    public class CrearModel : PageModel
    {
          
    
        private readonly ApplicationDbContext _contexto;

        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Productos Productos { get; set; }
        [BindProperty]
        public CrearProductoVm ProductosVm { get; set; }
        public async Task<IActionResult> OnGet()
        {
            ProductosVm = new CrearProductoVm()
            {
                ListaCategorias = await _contexto.Categoria.ToListAsync(),
                Productos=new Modelos.Productos()




            };
            return Page();

        }
        
        public async Task <IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _contexto.Productos.AddAsync(Productos);
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
