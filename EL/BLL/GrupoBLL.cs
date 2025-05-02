using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EL;

namespace BLL
{
   public class GrupoBLL
      {
        private readonly GrupoDAL _dal;

        public GrupoBLL(AgendaDbContext context)
        {
            _dal = new GrupoDAL(context);
        }
   
        // Inserta un nuevo grupo.
        public void Insertar(Grupo grupo)
        {
            _dal.Insertar(grupo);
        }
 
        /// Obtiene todos los grupos.
        public List<Grupo> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }
    }
    
}
