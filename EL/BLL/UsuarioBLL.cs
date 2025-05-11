using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL _dal;

        public UsuarioBLL(AgendaDbContext context)
        {
            _dal = new UsuarioDAL(context);
        }

        public Usuario Login(string nombreUsuario, string contraseña)
        {
            return _dal.ValidarLogin(nombreUsuario, contraseña);
        }
    }
}
