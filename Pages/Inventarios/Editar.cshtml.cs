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
        public CrearInventarioVm InventariosVm { get; set; }



        //public async Task<IActionResult> OnGet(int id)
        //{
        //    InventariosVm = new CrearInventarioVm()
        //    {
        //        ListaCategorias = await _contexto.Categoria.ToListAsync(),
        //        ListaProvedores = await _contexto.Proveedores.ToListAsync(),
        //        ListaBodegas = await _contexto.Bodega.ToListAsync(),
        //        Inventario = await _contexto.Inventario.FindAsync(id)




        //    };
        //    return Page();

        //}

        public IActionResult OnGet(int? id)
        {
            InventariosVm = new CrearInventarioVm()
            {
                ListaCategorias = _contexto.Categoria.ToList(),
                ListaProvedores =  _contexto.Proveedores.ToList(),
                ListaBodegas =  _contexto.Bodega.ToList(),
                Inventario = _contexto.Inventario.Find(id)




            };
            return Page();

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)


            {
                var ProductosDesdeDb =  _contexto.Inventario.Find(InventariosVm.Inventario.Id);
                ProductosDesdeDb.Nombre = InventariosVm.Inventario.Nombre;
                ProductosDesdeDb.Unidades = InventariosVm.Inventario.Unidades;
                ProductosDesdeDb.Precio = InventariosVm.Inventario.Precio;
                ProductosDesdeDb.Marca = InventariosVm.Inventario.Marca;
                _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
        //public async Task<IActionResult> OnPost()
        //{
        //    if (ModelState.IsValid)


        //    {
        //        var ProductosDesdeDb = await _contexto.Inventario.FindAsync(InventariosVm.Inventario.Id);
        //        ProductosDesdeDb.Nombre = InventariosVm.Inventario.Nombre;
        //        ProductosDesdeDb.Unidades = InventariosVm.Inventario.Unidades;
        //        ProductosDesdeDb.Precio = InventariosVm.Inventario.Precio;
        //        ProductosDesdeDb.Marca = InventariosVm.Inventario.Marca;
        //        await _contexto.SaveChangesAsync();
        //        return RedirectToPage("Index");
        //    }
        //    else
        //    {
        //        return Page();
        //    }
        //}

    }
}
