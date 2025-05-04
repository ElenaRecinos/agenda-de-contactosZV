using EL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BLL.Infraestructura
{
    class ImportadorContactos
    {
        private readonly ContactoDAL _dal;
        private readonly GrupoDAL _grupoDAL;

        public ImportadorContactos(ContactoDAL contactoDAL, GrupoDAL grupoDAL)
        {
            _dal = contactoDAL;
            _grupoDAL = grupoDAL;
        }

        public int ImportarContactos(string filePath)
        {
            try
            {
                int duplicados = 0;

                var lineas = File.ReadAllLines(filePath, Encoding.UTF8);
                for (int i = 1; i < lineas.Length; i++)
                {
                    var partes = lineas[i].Split(';');

                    if (partes.Length < 7) continue;

                    string nombre = partes[1];
                    string apellido = partes[2];
                    string email = partes[3];
                    string telefonoNumero = partes[4];
                    string tipo = partes[5];
                    string grupoNombre = partes[6];

                    bool existe = _dal.ContactoExiste(email, telefonoNumero);

                    if (existe)
                    {
                        duplicados++;
                        continue;
                    }

                    var grupo = _grupoDAL.ObtenerGrupoPorNombre(grupoNombre.Trim().ToLower());

                    if (grupo == null)
                    {

                        grupo = new Grupo { Nombre = grupoNombre };
                        _grupoDAL.Insertar(grupo);
                    }

                    var nuevoContacto = new Contacto
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        Email = email,
                        GrupoId = grupo.Id,
                        Telefonos = new List<Telefono>
                        {
                            new Telefono { Numero = telefonoNumero, Tipo = tipo }
                        }
                    };

                    _dal.Insertar(nuevoContacto);
                }

                _dal.GuardarCambios();

                return duplicados;
            }

            catch (IOException ex)
            {
                throw new Exception("El archivo está abierto en otro programa. Ciérralo antes de importar.", ex);
            }
        }
    }
}
