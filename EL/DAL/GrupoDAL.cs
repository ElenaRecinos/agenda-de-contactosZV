using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public class GrupoDAL
    {

        private readonly AgendaDbContext _context;

        public GrupoDAL(AgendaDbContext context)
        {
            _context = context;
        }

        // Insertar grupo
        public void Insertar(Grupo grupo)
        {
            _context.Grupos.Add(grupo);
            _context.SaveChanges();
        }

        //  Lista a todos los grupos
        public List<Grupo> ObtenerTodos()
        {
            return _context.Grupos.ToList();
        }

        public Grupo ObtenerGrupoPorNombre(string nombre)
        {
            return _context.Grupos.FirstOrDefault(g => g.Nombre.ToLower() == nombre.ToLower());
        }

    }
}
