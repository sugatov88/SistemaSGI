using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;

namespace SistemaSGI.Pages.Inventarios
{
    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public DetalleModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        [BindProperty]
        public Inventario Inventarios { get; set; }
        public  void OnGet(int id)
        {
            Inventarios = _contexto.Inventario
                .Where(c => c.Id == id)
                .Include(c => c.Categoria)
                .FirstOrDefault();
            Inventarios =  _contexto.Inventario
                .Where(c => c.Id == id)
                .Include(c => c._proveedor)
                .FirstOrDefault();

        }
        //public async void OnGet(int id)
        //{
        //    Inventarios = await _contexto.Inventario
        //        .Where(c => c.Id == id)
        //        .Include(c => c.Categoria)
        //        .FirstOrDefaultAsync();
        //    Inventarios = await _contexto.Inventario
        //        .Where(c => c.Id == id)
        //        .Include(c => c._proveedor)
        //        .FirstOrDefaultAsync();

        //}


    }

 }

