using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;

namespace SistemaSGI.Pages.Productoss
{
    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public DetalleModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        [BindProperty]
        public Productos Productos { get; set; }
        public async void OnGet(int id)
        {
            Productos = await _contexto.Productos
                .Where(c => c.Id == id)
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync();
            Productos = await _contexto.Productos
                .Where(c => c.Id == id)
                .Include(c => c._proveedor)
                .FirstOrDefaultAsync();

        }


    }

 }

