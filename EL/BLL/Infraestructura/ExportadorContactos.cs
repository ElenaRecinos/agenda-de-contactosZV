using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using System.IO;

namespace BLL.Infraestructura
{
    class ExportadorContactos
    {
        public void ExportarCSV(List<Contacto> contactos, string filePath)
        {
            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine("Id;Nombre;Apellido;Email;Telefono;Tipo;Grupo");

                foreach (var c in contactos)
                {
                    var telefono = c.Telefonos.FirstOrDefault();
                    writer.WriteLine($"{c.Id};{c.Nombre};{c.Apellido};{c.Email};{telefono?.Numero};{telefono?.Tipo};{c.Grupo?.Nombre}");
                }
            }
        }  
}
}
