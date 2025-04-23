using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using DAL;

namespace BLL
{
    public class ContactoBLL
    {
        private ContactoDAL dal = new ContactoDAL();

        public void Insertar(Contacto contacto)
        {
            dal.Insertar(contacto);
        }

        public List<Contacto> ObtenerTodos()
        {
            return dal.ObtenerTodos();
        }

        public void Actualizar(Contacto contacto)
        {
            dal.Actualizar(contacto);
        }

        public void Eliminar(int id)
        {
            dal.Eliminar(id);
        }

    }
}
