using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public class ContactoDAL
    {
        public void Insertar(Contacto contacto)
        {
            using (var context = new AgendaDbContext())
            {
                context.Contactos.Add(contacto);
                context.SaveChanges();
            }
        }

        public List<Contacto> ObtenerTodos()
        {
            using (var context = new AgendaDbContext())
            {
                return context.Contactos.Include("Telefonos").ToList();
            }
        }

        public Contacto ObtenerPorId(int id)
        {
            using (var context = new AgendaDbContext())
            {
                return context.Contactos.Include("Telefonos").FirstOrDefault(c => c.Id == id);
            }
        }

        public void Actualizar(Contacto contacto)
        {
            using (var context = new AgendaDbContext())
            {
                var existente = context.Contactos.Find(contacto.Id);
                if (existente != null)
                {
                    existente.Nombre = contacto.Nombre;
                    existente.Apellido = contacto.Apellido;
                    existente.Email = contacto.Email;
                    existente.Telefonos = contacto.Telefonos;

                    context.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var context = new AgendaDbContext())
            {
                var contacto = context.Contactos.Find(id);
                if (contacto != null)
                {
                    context.Contactos.Remove(contacto);
                    context.SaveChanges();
                }
            }
        }
    }
}
