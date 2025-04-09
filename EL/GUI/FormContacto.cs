using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using EL;

namespace GUI
{
    public partial class FormContacto: Form
    {
        public FormContacto()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                EL.Contacto contacto = new EL.Contacto
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text
                    
                };

               
                BLL.ContactoBLL servicio = new BLL.ContactoBLL();
                servicio.Insertar(contacto);

                MessageBox.Show("Contacto guardado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el contacto: " + ex.Message);
            }
        }
    }
}
