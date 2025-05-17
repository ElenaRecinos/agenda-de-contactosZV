using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using ReaLTaiizor.Controls;
using MaterialSkin;
using System.Windows.Forms.VisualStyles;
using EL;

namespace GUI
{
    public partial class FrmMenuPrincipal : MaterialSkin.Controls.MaterialForm
    {

        private readonly AgendaDbContext _context;
        private readonly ContactoBLL _contactoBLL;
        private readonly string _nombreUsuario;
        private readonly string _rolUsuario;

        private bool cerrarSesion = false;


        public FrmMenuPrincipal(string nombreUsuario, string rolUsuario)
        {
            InitializeComponent();
            _context = new AgendaDbContext();
            _contactoBLL = new ContactoBLL(_context);
            lblNombreUser.Text = nombreUsuario;
            lblRol.Text = rolUsuario;
            DlblUser.Text = nombreUsuario;
            _nombreUsuario = nombreUsuario;
            _rolUsuario = rolUsuario;

            var skinManager = MaterialSkin.MaterialSkinManager.Instance;

            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Grey900,
                Primary.Indigo100, Accent.LightBlue200,
                TextShade.WHITE

            );

            this.FormClosed += FrmMenuPrincipal_FormClosed;

            //solo mostrar un panel
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Visible = true;
            metroPanelContacto.Visible = false;
            mPanelPerfil.Visible = false;
            mPanelPerfil.BackgroundColor = Color.FromArgb(34, 34, 34);

            CargarDashboard();
        }

        //AJUSTES DE MENU PRINCIPAL - HOME


        //control de Horario y fecha
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        // Al iniciar formulario
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

            try
            {
                if (_rolUsuario == "Editor")
                {
                    // Desactivar los menús y módulos que no debería ver
                    exportarToolStripMenuItem1.Enabled = false;
                    importarToolStripMenuItem1.Enabled = true;
                    cerrarSesionToolStripMenuItem1.Enabled = true;

                    // Si tienes otras opciones en el menú:
                    royalMenuStrip.Visible = false;
                    configuraciónToolStripMenuItem1.Enabled = false;
                    importarToolStripMenuItem1.Enabled = false;
                    exportarToolStripMenuItem1.Enabled = false;
                }


                var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AgendaConnection"].ConnectionString;
                var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);

                //Configuración de base de datos visual
                string servidor = builder.DataSource;
                string baseDatos = builder.InitialCatalog;
                string usuarioBD = builder.IntegratedSecurity ? "(Autenticación Windows)" : builder.UserID;

                lblServidor.Text = $"Servidor: {servidor}";
                lblNombre.Text = $"Base de datos: {baseDatos}";
                mlblNombreContact.Text = baseDatos;
                lblUsuario.Text = $"Usuario: {usuarioBD}";
            }
            catch (Exception ex)
            {
                lblServidor.Text = "Servidor: (no disponible)";
                lblNombre.Text = "Base de datos: (no disponible)";
                mlblNombreContact.Text = "(no disponible)";
                lblUsuario.Text = "Usuario: (no disponible)";

                MessageBox.Show($"Error al leer configuración: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int totalContactos = _context.Contactos.Count();
            int totalGrupos = _context.Grupos.Count();

            lblContRegis.Text = totalContactos.ToString();
            lblGroupRegis.Text = totalGrupos.ToString();

            var datos = _context.Contactos
            .GroupBy(c => c.Grupo != null ? c.Grupo.Nombre : "Sin grupo")
            .Select(g => new { NombreGrupo = g.Key, Cantidad = g.Count() })
            .ToList();

            parrotPieGraph.Numbers.Clear();


            foreach (var item in datos)
            {
                parrotPieGraph.Numbers.Add(item.Cantidad);
            }


            var usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == _nombreUsuario);

            //Agrega la foto de perfil establecida por el usuarios

            if (usuario != null && usuario.FotoPerfil != null)
            {
                using (MemoryStream ms = new MemoryStream(usuario.FotoPerfil))
                {
                    pbPerfil.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pbPerfil.Image = Properties.Resources.Icon;
            }

            //Mostrar contactos como historial
            poisonDataGridView1.DataSource = _context.Contactos
            .Select(c => new
            {
                Nombre = c.Nombre,
                Telefono = c.Telefonos,
                Correo = c.Email,
                Grupo = c.Grupo != null ? c.Grupo.Nombre : "Sin grupo"
            })
            .ToList();

            poisonDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            poisonDataGridView1.RowHeadersVisible = false;
            poisonDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            poisonDataGridView1.ReadOnly = true;

            // Agrega una insignia de rol a los usuarios 
            if (lblRol.Text == "Administrador")
            {
                pbInsing.Image = Properties.Resources.Admin;
            }
            else
            {
                pbInsing.Image = Properties.Resources.Star;
            }

            TextEnable();

            // cargar imagen

            if (usuario.FotoPerfil != null)
            {
                using (MemoryStream ms = new MemoryStream(usuario.FotoPerfil))
                {
                    parrotPbPerfil.Image = Image.FromStream(ms);
                }
            }
            else
            {
                // Imagen por defecto si no hay
                parrotPbPerfil.Image = Properties.Resources.Icon;
            }

        }

        // menu botón gestionar contactos
        private void gestionarContactosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormContacto formContacto = new FormContacto(_context);
            formContacto.ShowDialog();
        }

        // menu botón de importar
        private void importarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                try
                {
                    ofd.Filter = "Archivos CSV (*.csv)|*.csv";
                    ofd.Title = "Seleccionar archivo CSV para importar";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = ofd.FileName;

                        var duplicados = _contactoBLL.ImportarContactos(filePath);
                        MessageBox.Show($"Importación completada. Duplicados ignorados: {duplicados}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //menu botón de exportar
        private void exportarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.Title = "Guardar contactos como";
                saveFileDialog.FileName = "Contactos.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _contactoBLL.ExportarContactosCSV(saveFileDialog.FileName);
                    MessageBox.Show("Contactos exportados correctamente en:\n" + saveFileDialog.FileName);
                }
            }
        }

        //menu botón de salir
        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Panel dock menu lateral izquierdo 
        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        // Menu botón cerrar sesión
        private void cerrarSesionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cerrarSesion = true;
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        //Cierra las ventanas al salir
        private void FrmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!cerrarSesion)
            {
                Application.Exit();
            }
        }



        //AJUSTES DE MENU PRINCIPAL - GESTOR DE CONTACTOS
        private void parrotpbAgendaDB_Click(object sender, EventArgs e)
        {
            FormContacto formContacto = new FormContacto(_context);
            formContacto.ShowDialog();
        }

        private void hOMEToolStrip_Click(object sender, EventArgs e)
        {
            CargarDashboard();
            panelContenido.Visible = true;
            mPanelPerfil.Visible = false;
            metroPanelContacto.Visible = false;

            if (mPanelPerfil.Visible == false)
            {
                mtxtBoxNombre.Enabled = false;
                mtxtBoxNombre.BackColor = Color.FromArgb(30, 30, 30);
                mtxtBoxNombre.BorderColorB = Color.DarkSlateGray;
                mtxtBoxContraseña.Enabled = false;
                mtxtBoxContraseña.BackColor = Color.FromArgb(30, 30, 30);
                mtxtBoxContraseña.BorderColorB = Color.DarkSlateGray;
                pPbEye.Enabled = false;
            }
        }

        private void cONTACTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarDashboard();
            panelContenido.Visible = false;
            mPanelPerfil.Visible = false;
            metroPanelContacto.Visible = true;
            metroPanelContacto.Dock = DockStyle.Fill;
            metroPanelContacto.BackgroundColor = Color.FromArgb(30, 30, 30);

            if (mPanelPerfil.Visible == false)
            {
                mtxtBoxNombre.Enabled = false;
                mtxtBoxNombre.BackColor = Color.FromArgb(30, 30, 30);
                mtxtBoxNombre.BorderColorB = Color.DarkSlateGray;
                mtxtBoxContraseña.Enabled = false;
                mtxtBoxContraseña.BackColor = Color.FromArgb(30, 30, 30);
                mtxtBoxContraseña.BorderColorB = Color.DarkSlateGray;
                pPbEye.Enabled = false;
            }
        }

        private void aCCOUNTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarDashboard();
            panelContenido.Visible = false;
            metroPanelContacto.Visible = false;
            mPanelPerfil.Visible = true;
            mPanelPerfil.Dock = DockStyle.Fill;

        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            mtxtBoxNombre.Enabled = true;
            mtxtBoxNombre.BackColor = Color.White;
            mtxtBoxNombre.BorderColorB = Color.DarkSlateGray;
            mtxtBoxContraseña.Enabled = true;
            mtxtBoxContraseña.BackColor = Color.White;
            mtxtBoxContraseña.BorderColorB = Color.DarkSlateGray;
            pPbEye.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (mtxtBoxContraseña.Enabled == false && mtxtBoxNombre.Enabled == false)
            {
                //Cuadro emergente
                hpNotifyAccount.Type = HopeNotify.AlertType.Warning;
                hpNotifyAccount.Visible = true;
                ShowNotify();
                hpNotifyAccount.Text = "Los cuadros están bloqueados";
                return;
            }

            else
            {
                string nuevoNombre = mtxtBoxNombre.Text.Trim();
                string nuevaContra = mtxtBoxContraseña.Text.Trim();

                if (string.IsNullOrEmpty(nuevoNombre) || string.IsNullOrEmpty(nuevaContra))
                {
                    //Cuadro emergente
                    hpNotifyAccount.Type = HopeNotify.AlertType.Info;
                    hpNotifyAccount.Visible = true;
                    ShowNotify();
                    hpNotifyAccount.Text = "Nombre y contraseña no pueden estar vacíos.";
                    return;
                }
                var resultado = MessageBox.Show("¿Estás seguro de que deseas actualizar los datos?", "Confirmar cambios", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.No)
                    return;


                var usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == _nombreUsuario);
                if (usuario != null)
                {
                    usuario.NombreUsuario = nuevoNombre;
                    usuario.Contraseña = nuevaContra;
                    _context.SaveChanges();

                    //Cuadro emergente
                    hpNotifyAccount.Type = HopeNotify.AlertType.Success;
                    hpNotifyAccount.Visible = true;
                    ShowNotify();
                    hpNotifyAccount.Text = "Datos actualizados correctamente.";

                    mtxtBoxNombre.Enabled = false;
                    mtxtBoxContraseña.Enabled = false;

                    CargarUsuarios(); // recarga el DataGridView
                }
            }



        }

        private void CargarUsuarios()
        {
            if (_rolUsuario == "Administrador")
            {
                pDataGriedViewPerfil.DataSource = _context.Usuarios
                    .Select(u => new
                    {
                        ID = u.Id,
                        Usuario = u.NombreUsuario,
                        Rol = u.Rol
                    }).ToList();
            }
            else
            {
                pDataGriedViewPerfil.DataSource = _context.Usuarios
                    .Where(u => u.NombreUsuario == _nombreUsuario)
                    .Select(u => new
                    {
                        ID = u.Id,
                        Usuario = u.NombreUsuario,
                        Rol = u.Rol
                    }).ToList();
            }

            pDataGriedViewPerfil.ClearSelection();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (pDataGriedViewPerfil.SelectedRows.Count == 0)
            {
                //Cuadro emergente
                hpNotifyAccount.Type = HopeNotify.AlertType.Warning;
                hpNotifyAccount.Visible = true;
                ShowNotify();
                hpNotifyAccount.Text = "Selecciona un usuario para eliminar.";
                return;
            }

            var fila = pDataGriedViewPerfil.SelectedRows[0];
            int idUsuario = (int)fila.Cells["ID"].Value;
            var usuario = _context.Usuarios.Find(idUsuario);

            if (usuario == null)
                return;

            if (usuario.Rol == "Administrador")
            {

                //Cuadro emergente
                hpNotifyAccount.Type = HopeNotify.AlertType.Error;
                hpNotifyAccount.Visible = true;
                ShowNotify();
                hpNotifyAccount.Text = "No puedes eliminar a un administrador.";
                return;
            }

            var resultado = MessageBox.Show("¿Seguro que deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.No)
                return;

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            //Cuadro emergente
            hpNotifyAccount.Type = HopeNotify.AlertType.Success;
            hpNotifyAccount.Visible = true;
            ShowNotify();
            hpNotifyAccount.Text = "Usuario eliminado correctamente.";

            CargarUsuarios();
        }


        //Crear variables de timer 
        private System.Timers.Timer timerNotify;
        private System.Timers.Timer timerAncho;

        // Final del timer para ocultar la notificación
        private void OffNotificacion(object sender, EventArgs e)
        {
            if (hpNotifyAccount.InvokeRequired)
            {
                hpNotifyAccount.Invoke(new Action(() =>
                {
                    hpNotifyAccount.Visible = false;
                }));
            }
            else
            {
                hpNotifyAccount.Visible = false;
            }

            timerNotify.Stop();
            timerNotify.Dispose();
        }

        //Mostrar notificación
        private void ShowNotify()
        {
            int anchoInicial = 120;
            int anchoObjetivo = 345;
            int alto = 34;
            int anchoActual = anchoInicial;

            Point posicionFinal = new Point(578, 480);
            int leftInicial = posicionFinal.X + (anchoObjetivo - anchoInicial); // <-- clave para que quede fijo

            // Reset posición y tamaño antes de animar
            hpNotifyAccount.Size = new Size(anchoInicial, alto);
            hpNotifyAccount.Location = new Point(leftInicial, posicionFinal.Y);

            // Timer para animar el ancho
            timerAncho = new System.Timers.Timer();
            timerAncho.Interval = 1;
            timerAncho.Elapsed += (s, e) =>
            {
                if (anchoActual < anchoObjetivo)
                {
                    anchoActual += 10;

                    if (hpNotifyAccount.InvokeRequired)
                    {
                        hpNotifyAccount.Invoke(new Action(() =>
                        {
                            hpNotifyAccount.Left = posicionFinal.X + (anchoObjetivo - anchoActual);
                            hpNotifyAccount.Width = anchoActual;
                        }));
                    }
                    else
                    {
                        hpNotifyAccount.Left = posicionFinal.X + (anchoObjetivo - anchoActual);
                        hpNotifyAccount.Width = anchoActual;
                    }
                }
                else
                {
                    timerAncho.Stop();
                    timerAncho.Dispose();
                }
            };
            timerAncho.Start();

            // Temporizador para ocultar la notificación después de 5 seg
            timerNotify = new System.Timers.Timer();
            timerNotify.Interval = 5000;
            timerNotify.Elapsed += OffNotificacion;
            timerNotify.Start();
        }

        // Cierra todos los formularios vivos, incluso los ocultos
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TextEnable()
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == _nombreUsuario);
            if (usuario != null)
            {
                mtxtBoxNombre.Text = usuario.NombreUsuario;
                mtxtBoxContraseña.Text = usuario.Contraseña;

                mtxtBoxNombre.Enabled = false;
                mtxtBoxContraseña.Enabled = false;
            }
        }

        private void pPbEye_Click(object sender, EventArgs e)
        {
            if (mtxtBoxContraseña.UseSystemPasswordChar == true)
            {
                mtxtBoxContraseña.UseSystemPasswordChar = false;
                mtxtBoxContraseña.PasswordChar = new char();
            }
            else
            {
                mtxtBoxContraseña.UseSystemPasswordChar = true;
            }

        }

        private void parrotPbPerfil_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Selecciona una nueva foto de perfil";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] imagenBytes = File.ReadAllBytes(ofd.FileName);

                // Buscar el usuario actual por nombre
                var usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == _nombreUsuario);
                if (usuario != null)
                {
                    usuario.FotoPerfil = imagenBytes;
                    _context.SaveChanges();

                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        parrotPbPerfil.Image = Image.FromStream(ms);
                    }

                    MessageBox.Show("Foto de perfil actualizada correctamente.");
                }
            }
        }

        private void CargarDashboard()
        {
            // 1. Cargar total de contactos
            lblContRegis.Text = _context.Contactos.Count().ToString();

            // 2. Cargar total de grupos
            lblGroupRegis.Text = _context.Grupos.Count().ToString();

            // 3. Cargar datos en el DataGridView
            poisonDataGridView1.DataSource = _context.Contactos
                .Select(c => new
                {
                    Nombre = c.Nombre,
                    Telefono = c.Telefonos,
                    Correo = c.Email,
                    Grupo = c.Grupo != null ? c.Grupo.Nombre : "Sin grupo"
                }).ToList();

            poisonDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            poisonDataGridView1.RowHeadersVisible = false;
            poisonDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            poisonDataGridView1.ReadOnly = true;

            // 4. Cargar datos para el gráfico
            var datos = _context.Contactos
                .GroupBy(c => c.Grupo != null ? c.Grupo.Nombre : "Sin grupo")
                .Select(g => new { NombreGrupo = g.Key, Cantidad = g.Count() })
                .ToList();

            parrotPieGraph.Numbers.Clear();

            foreach (var item in datos)
            {
                parrotPieGraph.Numbers.Add(item.Cantidad);
            }
        }

    }
}
