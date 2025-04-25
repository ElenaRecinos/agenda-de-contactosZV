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
        private int? contactoSeleccionadoId = null;

        public FormContacto()
        {
            InitializeComponent();
        }

        //Muestra la información de contactos en DataGridView
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
                Tipo = c.Telefonos.FirstOrDefault() != null ? c.Telefonos.FirstOrDefault().Tipo : "",
                 Grupo = c.Grupo!= null ? c.Grupo.Nombre : "",

            }).ToList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool hayError = false;

                //  Validar txtNombre
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text == "Ingrese el nombre...")
                {
                    txtNombre.BackColor = Color.IndianRed;
                    txtNombre.ForeColor = Color.White;
                    hayError = true;
                }
                else
                {
                    txtNombre.BackColor = Color.White;
                    txtNombre.ForeColor = Color.Black;
                }

                //  Validar txtApellido
                if (string.IsNullOrWhiteSpace(txtApellido.Text) || txtApellido.Text == "Ingrese el apellido...")
                {
                    txtApellido.BackColor = Color.IndianRed;
                    txtApellido.ForeColor = Color.White;
                    hayError = true;
                }
                else
                {
                    txtApellido.BackColor = Color.White;
                    txtApellido.ForeColor = Color.Black;
                }

                //  Validar txtEmail
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.Text == "Ingrese el email...")
                {
                    txtEmail.BackColor = Color.IndianRed;
                    txtEmail.ForeColor = Color.White;
                    hayError = true;
                }
                else
                {
                    txtEmail.BackColor = Color.White;
                    txtEmail.ForeColor = Color.Black;
                }

                //  Validar txtTelefono
                if (string.IsNullOrWhiteSpace(txtTelefono.Text) || txtTelefono.Text == "Ingrese el teléfono...")
                {
                    txtTelefono.BackColor = Color.IndianRed;
                    txtTelefono.ForeColor = Color.White;
                    hayError = true;
                }
                else
                {
                    txtTelefono.BackColor = Color.White;
                    txtTelefono.ForeColor = Color.Black;
                }

                if (cmbTipo.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un tipo de teléfono.");
                    return;
                }

                if (hayError)
                {
                    MessageBox.Show("¡Hay cuadros de texto vacíos o incompletos!");
                    return;
                }

                // barra de progreso

                this.Cursor = Cursors.WaitCursor;
                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;

                for (int i = 0; i <= 100; i += 20)
                {
                    progressBar1.Value = i;
                    await Task.Delay(100);
                }

                if (progressBar1.Value == 100)

                {
                    progressBar1.Visible = false;
                    this.Cursor = Cursors.Default;

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
                        Telefonos = new List<EL.Telefono> { telefono },
                        GrupoId = (int)cmbGrupos.SelectedValue
                    };

                    BLL.ContactoBLL servicio = new BLL.ContactoBLL();

                    //  Antes de Insertar validar duplicados
                    if (servicio.ExisteContactoIgual(contacto))
                    {
                        MessageBox.Show("Error: No su pudo Guardar este Contacto. Ya existe otro Contacto Igual.");
                        return;
                    }
                    servicio.Insertar(contacto);


                    MessageBox.Show("¡Contacto guardado con éxito!");
                    CargarContactos();
                }
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

            // Cargar los grupos 
            GrupoBLL grupoServicio = new GrupoBLL();
            var grupos = grupoServicio.ObtenerTodos();

            cmbGrupos.DataSource = grupos;
            cmbGrupos.DisplayMember = "Nombre";  //  Muestra el nombre del grupo
            cmbGrupos.ValueMember = "Id";        //  Guarda el Id del grupo

            // Placeholder para Nombre
            txtNombre.Text = "Ingrese el nombre...";
            txtNombre.ForeColor = Color.Gray;

            // Placeholder para Apellido
            txtApellido.Text = "Ingrese el apellido...";
            txtApellido.ForeColor = Color.Gray;

            // Placeholder para Email
            txtEmail.Text = "Ingrese el email...";
            txtEmail.ForeColor = Color.Gray;

            // Placeholder para Teléfono
            txtTelefono.Text = "Ingrese el teléfono...";
            txtTelefono.ForeColor = Color.Gray;

            // Placeholder para Buscar
            txtBuscar.Text = "🔍||Búsqueda...";
            txtBuscar.ForeColor = Color.Gray;

            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(new string[] { "Móvil", "Casa", "Trabajo", "Empresa" });
            cmbTipo.SelectedIndex = 0;

            CargarContactos();
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
  
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtBuscar.Clear();

            cmbTipo.SelectedIndex = 0;

            txtNombre.Text = "Ingrese el nombre...";
            txtNombre.ForeColor = Color.Gray;
            txtNombre.BackColor = Color.White;

            txtApellido.Text = "Ingrese el apellido...";
            txtApellido.ForeColor = Color.Gray;
            txtApellido.BackColor = Color.White;

            txtEmail.Text = "Ingrese el email...";
            txtEmail.ForeColor = Color.Gray;
            txtEmail.BackColor = Color.White;

            txtTelefono.Text = "Ingrese el teléfono...";
            txtTelefono.ForeColor = Color.Gray;
            txtTelefono.BackColor = Color.White;

            txtBuscar.Text = "🔍||Búsqueda...";
            txtBuscar.ForeColor = Color.Gray;

            // control de barra de progreso

            this.Cursor = Cursors.WaitCursor;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            for (int i = 0; i <= 100; i += 20)
            {
                progressBar1.Value = i;
                await Task.Delay(100);
            }

            if (progressBar1.Value == 100)
            {
                progressBar1.Visible = false;
                this.Cursor = Cursors.Default;


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
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvContactos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un contacto completo para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas eliminar este contacto?",
                "Confirmar eliminación", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                // barra de progreso
                this.Cursor = Cursors.WaitCursor;

                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;

                for (int i = 0; i <= 100; i += 20)
                {
                    progressBar1.Value = i;
                    await Task.Delay(100);
                }

                if (progressBar1.Value == 100)

                {
                    progressBar1.Visible = false;
                    this.Cursor = Cursors.Default;

                    int idContacto = Convert.ToInt32(dgvContactos.SelectedRows[0].Cells["Id"].Value);

                    BLL.ContactoBLL servicio = new BLL.ContactoBLL();
                    servicio.Eliminar(idContacto);

                    MessageBox.Show("¡Contacto eliminado!");
                    CargarContactos();
                }
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            // Valida si hay una fila seleccionada
            if (dgvContactos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un contacto completo en la tabla para actualizar.");
                return;
            }

            // Valida placeholders llenos con el bool

            bool hayError = false;

            //  Validar txtNombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text == "Ingrese el nombre...")
            {
                txtNombre.BackColor = Color.IndianRed;
                txtNombre.ForeColor = Color.White;
                hayError = true;
            }
            else
            {
                txtNombre.BackColor = Color.White;
                txtNombre.ForeColor = Color.Black;
            }

            //  Validar txtApellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text) || txtApellido.Text == "Ingrese el apellido...")
            {
                txtApellido.BackColor = Color.IndianRed;
                txtApellido.ForeColor = Color.White;
                hayError = true;
            }
            else
            {
                txtApellido.BackColor = Color.White;
                txtApellido.ForeColor = Color.Black;
            }

            // Validar txtEmail
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.Text == "Ingrese el email...")
            {
                txtEmail.BackColor = Color.IndianRed;
                txtEmail.ForeColor = Color.White;
                hayError = true;
            }
            else
            {
                txtEmail.BackColor = Color.White;
                txtEmail.ForeColor = Color.Black;
            }

            //  Validar txtTelefono
            if (string.IsNullOrWhiteSpace(txtTelefono.Text) || txtTelefono.Text == "Ingrese el teléfono...")
            {
                txtTelefono.BackColor = Color.IndianRed;
                txtTelefono.ForeColor = Color.White;
                hayError = true;
            }
            else
            {
                txtTelefono.BackColor = Color.White;
                txtTelefono.ForeColor = Color.Black;
            }

            if (hayError)
            {
                MessageBox.Show("¡Hay cuadros de textos vacíos!");
                return;
            }
            // Obtiene el Id desde la fila seleccionada
            int idContacto = Convert.ToInt32(dgvContactos.SelectedRows[0].Cells["Id"].Value);

            // barra de progreso
            this.Cursor = Cursors.WaitCursor;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            for (int i = 0; i <= 100; i += 20)
            {
                progressBar1.Value = i;
                await Task.Delay(100);
            }

            if (progressBar1.Value == 100)

            {
                progressBar1.Visible = false;
                this.Cursor = Cursors.Default;

                //  Crea el contacto actualizado
                var contacto = new EL.Contacto
                {
                    Id = idContacto,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Telefonos = new List<EL.Telefono>
    {
        new EL.Telefono
        {
            Numero = txtTelefono.Text,
            Tipo = cmbTipo.SelectedItem.ToString()
        }
    },
                      Grupo = new EL.Grupo
                      {
                          Id = (int)cmbGrupos.SelectedValue
                      }
                };

                BLL.ContactoBLL servicio = new BLL.ContactoBLL();
                servicio.Actualizar(contacto);

                MessageBox.Show("¡Contacto actualizado!");
                CargarContactos();

                // actualiza placeholders

                txtNombre.Clear();
                txtApellido.Clear();
                txtEmail.Clear();
                txtTelefono.Clear();
                txtBuscar.Clear();

                cmbTipo.SelectedIndex = 0;

                txtNombre.Text = "Ingrese el nombre...";
                txtNombre.ForeColor = Color.Gray;

                txtApellido.Text = "Ingrese el apellido...";
                txtApellido.ForeColor = Color.Gray;

                txtEmail.Text = "Ingrese el email...";
                txtEmail.ForeColor = Color.Gray;

                txtTelefono.Text = "Ingrese el teléfono...";
                txtTelefono.ForeColor = Color.Gray;

            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Ingrese el nombre...")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;
                txtNombre.BackColor = Color.White;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Text = "Ingrese el nombre...";
                txtNombre.ForeColor = Color.Gray;
            }
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "Ingrese el apellido...")
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.Black;
                txtApellido.BackColor = Color.White;
            }
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.Text = "Ingrese el apellido...";
                txtApellido.ForeColor = Color.Gray;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Ingrese el email...")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
                txtEmail.BackColor = Color.White;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Ingrese el email...";
                txtEmail.ForeColor = Color.Gray;
            }
        }
        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "Ingrese el teléfono...")
            {
                txtTelefono.Text = "";
                txtTelefono.ForeColor = Color.Black;
                txtTelefono.BackColor = Color.White;
            }
        }
        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                txtTelefono.Text = "Ingrese el teléfono...";
                txtTelefono.ForeColor = Color.Gray;
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "🔍||Búsqueda...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "🔍||Búsqueda...";
                txtBuscar.ForeColor = Color.Gray;

                //cargar todos los contactos
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
            }

        private async void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvContactos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un contacto para recuperar.");
                return;
            }

            int idContacto = Convert.ToInt32(dgvContactos.SelectedRows[0].Cells["Id"].Value);

            ContactoBLL servicio = new ContactoBLL();
            var contacto = servicio.ObtenerPorId(idContacto);

            // barra de progreso
            this.Cursor = Cursors.WaitCursor;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            for (int i = 0; i <= 100; i += 20)
            {
                progressBar1.Value = i;
                await Task.Delay(100);
            }

            if (progressBar1.Value == 100)

            {
                progressBar1.Visible = false;
                this.Cursor = Cursors.Default;

                // Aplica color original al texto
                txtNombre.ForeColor = Color.Black;
                txtApellido.ForeColor = Color.Black;
                txtEmail.ForeColor = Color.Black;
                txtTelefono.ForeColor = Color.Black;
                txtBuscar.ForeColor = Color.Gray;


                // Llenar los TextBox
                txtNombre.Text = contacto.Nombre;
                txtApellido.Text = contacto.Apellido;
                txtEmail.Text = contacto.Email;
                txtBuscar.Text = "🔍||Búsqueda...";

                if (contacto.Telefonos.FirstOrDefault() != null)
                {
                    txtTelefono.Text = contacto.Telefonos.FirstOrDefault().Numero;
                    cmbTipo.SelectedItem = contacto.Telefonos.FirstOrDefault().Tipo;
                }
                contactoSeleccionadoId = contacto.Id; //  Guarda el Id del contacto
                MessageBox.Show("¡Contacto recuperado! ID:" + contactoSeleccionadoId );

                // Recarga Contactos
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
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();

            ContactoBLL servicio = new ContactoBLL();

            if (string.IsNullOrWhiteSpace(criterio))
            {
                // Si el cuadro está vacío, cargar todos los contactos
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
            else
            {
                //  Si escribe algo, buscar contactos
                var resultados = servicio.BuscarContactos(criterio);
                dgvContactos.DataSource = resultados.Select(c => new
                {
                    c.Id,
                    c.Nombre,
                    c.Apellido,
                    c.Email,
                    Numero = c.Telefonos.FirstOrDefault() != null ? c.Telefonos.FirstOrDefault().Numero : "",
                    Tipo = c.Telefonos.FirstOrDefault() != null ? c.Telefonos.FirstOrDefault().Tipo : ""
                }).ToList();
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarGrupo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNuevoGrupo.Text))
            {
                Grupo nuevoGrupo = new Grupo
                {
                    Nombre = txtNuevoGrupo.Text.Trim()
                };

                GrupoBLL grupoServicio = new GrupoBLL();
                grupoServicio.Insertar(nuevoGrupo);

                // Recarga el CmbBox
                var grupos = grupoServicio.ObtenerTodos();
                cmbGrupos.DataSource = grupos;
                cmbGrupos.DisplayMember = "Nombre";
                cmbGrupos.ValueMember = "Id";

                txtNuevoGrupo.Clear();
                MessageBox.Show("Grupo agregado con éxito.");
            }
        }
    }
}
