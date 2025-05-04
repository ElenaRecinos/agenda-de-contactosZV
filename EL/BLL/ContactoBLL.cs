using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using DAL;
using System.Runtime.Remoting.Contexts;
using BLL.Infraestructura;


namespace BLL
{
    public class ContactoBLL
    {
        private readonly ContactoDAL _dal;
        private readonly GrupoDAL _grupoDAL;

        public ContactoBLL(AgendaDbContext context)
        {
            _dal = new ContactoDAL(context);
            _grupoDAL = new GrupoDAL(context);
        }

        public void Insertar(Contacto contacto)
        {
            _dal.Insertar(contacto);
        }

        public List<Contacto> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        public void Actualizar(Contacto contacto)
        {
            _dal.Actualizar(contacto);
        }

        public void Eliminar(int id)
        {
            _dal.Eliminar(id);
        }

        public List<Contacto> BuscarContactos(string criterio)
        {
            return _dal.BuscarContactos(criterio);
        }

        public Contacto ObtenerPorId(int id)
        {
            return _dal.ObtenerPorId(id);
        }

        public bool ExisteContactoIgual(Contacto contacto)
        {
            return _dal.ExisteContactoIgual(contacto);
        }

        //Exportar datos registrados 
        public void ExportarContactosCSV(string filePath)
        {
            var contactos = ObtenerTodos();
            var exportador = new ExportadorContactos();
            exportador.ExportarCSV(contactos, filePath);
        }

        public int ImportarContactos(string filePath)
        {
            var importador = new ImportadorContactos(_dal, _grupoDAL);
            int duplicados = importador.ImportarContactos(filePath);
            return duplicados;
        }
    }
}
