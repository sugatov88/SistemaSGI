using Microsoft.EntityFrameworkCore;
using SistemaSGI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSGI.Datos
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options
            ): base(options)
        {

        }

        public DbSet<Administrador> Administrador { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Compania> Compania { get; set; }

        public DbSet<FormaPago> FormaPago { get; set; }

        public DbSet<Bodega> Bodega { get; set; }

        public DbSet<Inventario> Inventario { get; set; }

        public DbSet<Proveedores> Proveedores { get; set; }




        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        )
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
          
               .UseSqlServer("Server= (localdb)\\ MSSQLLocalDB; Initial Catalog =SistemaSGI_DB_2\\");
              
            }
        }

    }



 


}
