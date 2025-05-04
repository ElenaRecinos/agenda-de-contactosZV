using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EL;

namespace DAL
{
    public class ContactoDAL
    {
        private readonly AgendaDbContext _context;

        public ContactoDAL(AgendaDbContext context)
        {
            _context = context;
        }

        public bool ExisteContactoIgual(Contacto contacto)
        {
            var numeroTelefono = contacto.Telefonos.First().Numero.ToLower();
            var tipoTelefono = contacto.Telefonos.First().Tipo.ToLower();

            return _context.Contactos
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

        public void Insertar(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            _context.SaveChanges();
        }

        public List<Contacto> ObtenerTodos()
        {
            return _context.Contactos.Include("Telefonos").Include("Grupo").ToList();
        }

        public Contacto ObtenerPorId(int id)
        {
            return _context.Contactos.Include("Telefonos").Include("Grupo").FirstOrDefault(c => c.Id == id);
        }

        public void Actualizar(Contacto contacto)
        {
            var existente = _context.Contactos.Include("Telefonos").FirstOrDefault(c => c.Id == contacto.Id);

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

                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var contacto = _context.Contactos.Find(id);
            if (contacto != null)
            {
                _context.Contactos.Remove(contacto);
                _context.SaveChanges();
            }
        }

        public List<Contacto> BuscarContactos(string criterio)
        {
            int id;
            bool esId = int.TryParse(criterio, out id);

            return _context.Contactos
                .Include("Telefonos").Include("Grupo")
                .Where(c => (esId && c.Id == id) ||
                            c.Nombre.Contains(criterio) ||
                            c.Apellido.Contains(criterio))
                .ToList();
        }

        public void GuardarCambios()
        {
            _context.SaveChanges();
        }

        public bool ContactoExiste(string email, string telefonoNumero)
        {
            return _context.Contactos.Any(c =>
                c.Email == email || c.Telefonos.Any(t => t.Numero == telefonoNumero));
        }

    }
}
