using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EL;

namespace DAL
{
    public class AgendaDbContext : DbContext
    {
        public AgendaDbContext() : base("name=AgendaConnection") { }

        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
    }
}
