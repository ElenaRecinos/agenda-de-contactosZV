using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL
{
    [Table("Grupo")]
    public class Grupo
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }
}
