using DAL;
using EL;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ReaLTaiizor.Controls;


namespace GUI
{
    public partial class FormCrearUsuario : MaterialSkin.Controls.MaterialForm
    {
        public FormCrearUsuario()
        {
            InitializeComponent();
            var skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Grey900,
                Primary.Indigo100, Accent.LightBlue200,
                TextShade.WHITE
            );
            cyberbtnGuardar.ForeColor = Color.FromArgb(245, 245, 245);
            cyberbtnLogin.ForeColor = Color.Black;
            bigLabelAccount.Font = new Font("Segoe MDL2 Assets", 36F, FontStyle.Bold);
            bigLabelAccount.ForeColor = Color.FromArgb(0, 0, 192);

        }
         
        //Bandera para controlar el cierre de aplicación doble
        private bool volverDesdeBoton = false;

        //Iniciar formulario
        private void FormCrearUsuario_Load(object sender, EventArgs e)
        {

            var context = new AgendaDbContext();
            var usuarioDAL = new UsuarioDAL(context);

            if (usuarioDAL.ExisteAdmin())
            {
                MTcmbRol.Items.Clear();
                MTcmbRol.Items.Add("Editor");
                MTcmbRol.SelectedIndex = 0;
                MTcmbRol.Enabled = false;  // desactivar cambio de rol
            }
            else
            {
                MTcmbRol.Items.Clear();
                MTcmbRol.Items.Add("Administrador");
                MTcmbRol.SelectedIndex = 0;
                MTcmbRol.Enabled = false;  // siempre fijo en Admin la primera vez
            }
            this.FormClosed += FormCrearUsuario_FormClosed;

        }

        //botón de guardar cuenta
        private void cyberbtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MTtxtUsuario.Text) || string.IsNullOrWhiteSpace(MTtxtContraseña.Text))
            {
                //Cuadro emergente
                hopeNotifyAccount.Type = HopeNotify.AlertType.Warning;
                hopeNotifyAccount.Visible = true;
                ShowNotify();
                hopeNotifyAccount.Text = "Usuario y contraseña son obligatorios.";
                return;

            }

            var context = new AgendaDbContext();
            var usuarioDAL = new UsuarioDAL(context);

            if (usuarioDAL.ExisteUsuario(MTtxtUsuario.Text.Trim()))
            {
                //Cuadro emergente
                hopeNotifyAccount.Type = HopeNotify.AlertType.Error;
                hopeNotifyAccount.Visible = true;
                ShowNotify();
                hopeNotifyAccount.Text = "Este usuario ya existe.";
                return;

            }

            var nuevoUsuario = new Usuario
            {
                NombreUsuario = MTtxtUsuario.Text.Trim(),
                Contraseña = MTtxtContraseña.Text.Trim(),
                Rol = MTcmbRol.SelectedItem.ToString()
            };

            if (parrotpicFotoPerfil.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    parrotpicFotoPerfil.Image.Save(ms, parrotpicFotoPerfil.Image.RawFormat);
                    nuevoUsuario.FotoPerfil = ms.ToArray();
                }
            }

            usuarioDAL.Insertar(nuevoUsuario);

            //Cuadro emergente
            hopeNotifyAccount.Type = HopeNotify.AlertType.Success;
            hopeNotifyAccount.Visible = true;
            ShowNotify();
            hopeNotifyAccount.Text = "¡Usuario creado exitosamente!.";
        }

        //Cargar una imagen de perfil
        private void parrotpicFotoPerfil_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Seleccionar imagen de perfil";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    parrotpicFotoPerfil.Image = Image.FromFile(ofd.FileName);
                    parrotpicFotoPerfil.FilterEnabled = false;
                }
            }
        }

        //plasmar una imagen PNG de fondo
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Image marco = Properties.Resources.Marco;
            e.Graphics.DrawImage(marco, 105, 65, 50, 50);
        }

        //Volver a la ventana FormLogin
        private void cyberbtnLogin_Click(object sender, EventArgs e)
        {
            volverDesdeBoton = true;
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        //Al cerrar la ventana automaáticamente se dirige a FormLogin
        private void FormCrearUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!volverDesdeBoton)
            {
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
            }
        }

        //Crear variables de timer 

        private System.Timers.Timer timerNotify;
        private System.Timers.Timer timerAncho;

        //Mostrar notificación
        private void ShowNotify()
        {
            int anchoInicial = 120;
            int anchoObjetivo = 300;
            int alto = 34;
            int anchoActual = anchoInicial;

            Point posicionFinal = new Point(130, 547);
            int leftInicial = posicionFinal.X + (anchoObjetivo - anchoInicial); 

            hopeNotifyAccount.Size = new Size(anchoInicial, alto);
            hopeNotifyAccount.Location = new Point(leftInicial, posicionFinal.Y);

            timerAncho = new System.Timers.Timer();
            timerAncho.Interval = 1;
            timerAncho.Elapsed += (s, e) =>
            {
                if (anchoActual < anchoObjetivo)
                {
                    anchoActual += 10;

                    if (hopeNotifyAccount.InvokeRequired)
                    {
                        hopeNotifyAccount.Invoke(new Action(() =>
                        {
                            hopeNotifyAccount.Left = posicionFinal.X + (anchoObjetivo - anchoActual);
                            hopeNotifyAccount.Width = anchoActual;
                        }));
                    }
                    else
                    {
                        hopeNotifyAccount.Left = posicionFinal.X + (anchoObjetivo - anchoActual);
                        hopeNotifyAccount.Width = anchoActual;
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

        // Final del timer para ocultar la notificación
        private void OffNotificacion(object sender, EventArgs e)
        {
            if (hopeNotifyAccount.InvokeRequired)
            {
                hopeNotifyAccount.Invoke(new Action(() =>
                {
                    hopeNotifyAccount.Visible = false;

                }));
            }
            else
            {
                hopeNotifyAccount.Visible = false;

                if (hopeNotifyAccount.Text == "¡Usuario creado exitosamente!.")
                {
                    FormLogin formLogin = new FormLogin();
                    formLogin.Show();
                    this.Close();
                }
            }

            timerNotify.Stop();
            timerNotify.Dispose();    
        }

}
}
