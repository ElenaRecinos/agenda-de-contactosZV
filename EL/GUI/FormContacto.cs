using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using EL;
using DAL;

namespace GUI
{
    public partial class FormContacto : Form
    {
        public FormContacto()
        {
            InitializeComponent();
        }

        private void CargarContactos()
        {
            ContactoBLL servicio = new ContactoBLL();
            var lista = servicio.ObtenerTodos();

            dgvContactos.DataSource = lista.Select(c => new
            {
                c.Id,
                c.Nombre,
                c.Apellido,
                c.Email,
                Numero = c.Telefonos.FirstOrDefault() != null ? c.Telefonos.FirstOrDefault().Numero : "",
                Tipo = c.Telefonos.FirstOrDefault() != null ? c.Telefonos.FirstOrDefault().Tipo : ""

            }).ToList();
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
                if (cmbTipo.SelectedItem == null)

                    if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        MessageBox.Show("Por favor, escribe un número de teléfono.");
                        return;
                    }

                if (cmbTipo.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un tipo de teléfono.");
                    return;
                }


                var telefono = new EL.Telefono
                {
                    Numero = txtTelefono.Text,
                    Tipo = cmbTipo.SelectedItem.ToString()
                };

                EL.Contacto contacto = new EL.Contacto
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Telefonos = new List<EL.Telefono> { telefono }
                };

                BLL.ContactoBLL servicio = new BLL.ContactoBLL();
                servicio.Insertar(contacto);

                MessageBox.Show("Contacto guardado con éxito.");

                CargarContactos(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el contacto: " + ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormContacto_Load(object sender, EventArgs e)
        {

            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(new string[] { "Móvil", "Casa", "Trabajo", "Empresa" });
            cmbTipo.SelectedIndex = 0;

            CargarContactos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {   
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();

            cmbTipo.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvContactos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un contacto completo para eliminar.");
                return;
            }

            int idContacto = Convert.ToInt32(dgvContactos.SelectedRows[0].Cells["Id"].Value);

            BLL.ContactoBLL servicio = new BLL.ContactoBLL();
            servicio.Eliminar(idContacto);

            MessageBox.Show("Contacto eliminado.");
            CargarContactos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvContactos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un contacto completo para actualizar.");
                return;
            }

            int idContacto = Convert.ToInt32(dgvContactos.SelectedRows[0].Cells["Id"].Value);

           
            var contacto = new EL.Contacto
            {
                Id = idContacto,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text
            };

            BLL.ContactoBLL servicio = new BLL.ContactoBLL();
            servicio.Actualizar(contacto);

            MessageBox.Show("Contacto actualizado.");
            CargarContactos(); 
        }
    }
}
