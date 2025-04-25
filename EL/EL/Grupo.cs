using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    //Para Grupo
    [Table("Grupo")]
    public class Grupo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Contacto> Contactos { get; set; }

        public Grupo()
        {
            Contactos = new List<Contacto>();
        }
    }
}
