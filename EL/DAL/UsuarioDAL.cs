using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        private readonly AgendaDbContext _context;
        public bool ExisteAdmin()
        {
            return _context.Usuarios.Any(u => u.Rol == "Administrador");
        }

        public bool ExisteUsuario(string nombreUsuario)
        {
            return _context.Usuarios.Any(u => u.NombreUsuario == nombreUsuario);
        }

        public Usuario ValidarUsuario(string nombreUsuario, string contraseña)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña);
        }
        public void Insertar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public bool HayUsuarios()
        {
            return _context.Usuarios.Any();
        }

        public UsuarioDAL(AgendaDbContext context)
        {
            _context = context;
        }

        public Usuario ValidarLogin(string nombreUsuario, string contraseña)
        {
            return _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña);
        }
    }
}
