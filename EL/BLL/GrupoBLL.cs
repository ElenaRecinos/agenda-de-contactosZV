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
          GrupoDAL dal = new GrupoDAL();

          //  Insertar grupo
          public void Insertar(Grupo grupo)
            {
                dal.Insertar(grupo);
            }

          //  Obtener todos los grupos
            public List<Grupo> ObtenerTodos()
            {
                return dal.ObtenerTodos();
            }
      }
    
}
