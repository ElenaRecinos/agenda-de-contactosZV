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
        // Insertar grupo
        public void Insertar(Grupo grupo)
        {
            using (var context = new AgendaDbContext())
            {
                context.Grupos.Add(grupo);
                context.SaveChanges();
            }
        }

        //  Lista a todos los grupos
        public List<Grupo> ObtenerTodos()
        {
            using (var context = new AgendaDbContext())
            {
                return context.Grupos.ToList();
            }
        }
    }
}
