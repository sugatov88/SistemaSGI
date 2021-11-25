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
    public class EditarModel : PageModel
    {


        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public CrearProductoVm ProductosVm { get; set; }



        public async Task<IActionResult> OnGet(int id)
        {
            ProductosVm = new CrearProductoVm()
            {
                ListaCategorias = await _contexto.Categoria.ToListAsync(),
                ListaProvedores = await _contexto.Proveedores.ToListAsync(),
                Productos = await _contexto.Productos.FindAsync(id)




            };
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)


            {
                var ProductosDesdeDb = await _contexto.Productos.FindAsync(ProductosVm.Productos.Id);
                ProductosDesdeDb.Nombre = ProductosVm.Productos.Nombre;
                ProductosDesdeDb.CategoriaId = ProductosVm.Productos.CategoriaId;
                ProductosDesdeDb.Unidades = ProductosVm.Productos.Unidades;
                ProductosDesdeDb.Precio = ProductosVm.Productos.Precio;
                ProductosDesdeDb.ProveedoresId = ProductosVm.Productos.ProveedoresId;
                ProductosDesdeDb.Marca = ProductosVm.Productos.Marca;


         
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
