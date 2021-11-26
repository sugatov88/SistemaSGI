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

    public class IndexModel : PageModel

    {
        private readonly ApplicationDbContext _contexto;

        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Inventario> Inventarios { get; set; }

        //public async Task OnGet()
        //{
        //    Inventarios = await _contexto.Inventario.Include(c=>c.Categoria).ToListAsync();
        //    Inventarios = await _contexto.Inventario.Include(c => c._proveedor).ToListAsync();
        //    Inventarios = await _contexto.Inventario.Include(c => c.Bodega).ToListAsync();
        //}
        public void OnGet()
        {
            Inventarios =  _contexto.Inventario.Include(c => c.Categoria).ToList();
            Inventarios =  _contexto.Inventario.Include(c => c._proveedor).ToList();
            Inventarios =  _contexto.Inventario.Include(c => c.Bodega).ToList();
        }

    }
}