using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSGI.Modelos.ViewModels
{
    public class CrearInventarioVm
    {
        public List<Categoria> ListaCategorias { get; set; }
        public List<Proveedores>ListaProvedores { get; set; }
        public List<Bodega> ListaBodegas { get; set; }

        public Inventario Inventario { get; set; }

    }
}
