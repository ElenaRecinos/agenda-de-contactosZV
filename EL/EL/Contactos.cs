using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace EL
{
    [Table("Contactos")]
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        //agregar lista de telefonos
        public List<Telefono> Telefonos { get; set; }

        public EntornoSocial EntornoSocial { get; set; }

        public Contacto()
        {
            //Añadir teléfonos
            Telefonos = new List<Telefono>();
        }
    }

}