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
        public CrearInventarioVm InventariosVm { get; set; }



        //public async Task <IActionResult> OnGet()
        //{
        //    InventariosVm = new CrearInventarioVm()
        //    {
        //        ListaCategorias = await _contexto.Categoria.ToListAsync(),
        //        ListaProvedores=await _contexto.Proveedores.ToListAsync(),
        //        ListaBodegas = await _contexto.Bodega.ToListAsync(),
        //        Inventario =new Modelos.Inventario()




        //    };
        //    return Page();

        //}


        public IActionResult OnGet()
        {
            InventariosVm = new CrearInventarioVm()
            {
                ListaCategorias = _contexto.Categoria.ToList(),
                ListaProvedores =  _contexto.Proveedores.ToList(),
                ListaBodegas =  _contexto.Bodega.ToList(),
                Inventario = new Modelos.Inventario()




            };
            return Page();

        }

        //public async Task <IActionResult> OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _contexto.Inventario.AddAsync(InventariosVm.Inventario);
        //        await _contexto.SaveChangesAsync();
        //        return RedirectToPage("Index");
        //    }
        //    else
        //    {
        //        return Page();
        //    }
        //}

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                 _contexto.Inventario.Add(InventariosVm.Inventario);
                _contexto.SaveChanges();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
