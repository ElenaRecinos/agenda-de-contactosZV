using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL
{
    //Para contactos
    [Table("Contactos")]
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public List<Telefono> Telefonos { get; set; }

        public Contacto()
        {
            Telefonos = new List<Telefono>();

        }

        public int GrupoId { get; set; }    
        public Grupo Grupo { get; set; }
    }
}
