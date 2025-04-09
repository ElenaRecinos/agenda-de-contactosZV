using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    class Contactos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        //agregar lista de telefonos
        public List<Telefono> Telefonos { get; set; }

        public Entorno_Social Entorno_Social { get; set; }

        public Contactos()
        {
            //Añadir teléfonos
            Telefonos = new List<Telefono>();
        }
    }

}