using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL
{
    [Table("Telefono")]
    public class Telefono
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; } 
    }
}
