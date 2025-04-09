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
        public void Insertar(Contacto contacto)
        {
            using (var context = new AgendaDbContext())
            {
                context.Contactos.Add(contacto);
                context.SaveChanges();
            }
        }
    }
}
