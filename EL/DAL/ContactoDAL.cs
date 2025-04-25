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
        public bool ExisteContactoIgual(Contacto contacto)
        {
            using (var context = new AgendaDbContext())
            {
                var numeroTelefono = contacto.Telefonos.First().Numero.ToLower();
                var tipoTelefono = contacto.Telefonos.First().Tipo.ToLower();

                return context.Contactos
                    .Include("Telefonos")
                    .Any(c =>
                        c.Nombre.ToLower() == contacto.Nombre.ToLower() &&
                        c.Apellido.ToLower() == contacto.Apellido.ToLower() &&
                        c.Email.ToLower() == contacto.Email.ToLower() &&
                         c.GrupoId == contacto.GrupoId &&
                        c.Telefonos.Any(t =>
                            t.Numero.ToLower() == numeroTelefono &&
                            t.Tipo.ToLower() == tipoTelefono
                        )
                    );
            }
        }

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
                return context.Contactos.Include("Telefonos").Include("Grupo").ToList();
            }
        }

        public Contacto ObtenerPorId(int id)
        {
            using (var context = new AgendaDbContext())
            {
                return context.Contactos.Include("Telefonos").Include("Grupo").FirstOrDefault(c => c.Id == id);
            }
        }

        public void Actualizar(Contacto contacto)
        {
            using (var context = new AgendaDbContext())
            {
                var existente = context.Contactos.Include("Telefonos").FirstOrDefault(c => c.Id == contacto.Id);

                if (existente != null)
                {
                    existente.Nombre = contacto.Nombre;
                    existente.Apellido = contacto.Apellido;
                    existente.Email = contacto.Email;
                    existente.GrupoId = contacto.GrupoId;

                    if (existente.Telefonos.Any())
                    {
                        var telefonoExistente = existente.Telefonos.First();

                        var telefonoActualizado = contacto.Telefonos.First();

                        telefonoExistente.Numero = telefonoActualizado.Numero;
                        telefonoExistente.Tipo = telefonoActualizado.Tipo;
                    }

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

        public List<Contacto> BuscarContactos(string criterio)
        {
            using (var context = new AgendaDbContext())
            {
                int id;
                bool esId = int.TryParse(criterio, out id);

                return context.Contactos
                    .Include("Telefonos").Include("Grupo")
                    .Where(c => (esId && c.Id == id) ||
                                c.Nombre.Contains(criterio) ||
                                c.Apellido.Contains(criterio))                           
                    .ToList();
            }
        }
    }
}
