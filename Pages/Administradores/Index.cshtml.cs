using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaSGI.Datos;
using SistemaSGI.Modelos;

namespace SistemaSGI.Pages.Administradores
{

    public class IndexModel : PageModel

    {
        private readonly ApplicationDbContext _contexto;

        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Administrador> Administradores { get; set; }

        public async Task OnGet()
        {
            Administradores = await _contexto.Administrador.ToListAsync();
        }
    }
}
