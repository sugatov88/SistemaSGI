using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSGI.Modelos.ViewModels
{
    public class CrearProductoVm
    {
        public List<Categoria> ListaCategorias { get; set; }
        public List<Proveedores>ListaProvedores { get; set; }

        public Productos Productos { get; set; }

    }
}
