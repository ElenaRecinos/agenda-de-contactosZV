using BLL;
using DAL;
using EL;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ReaLTaiizor.Controls;
using System.Timers;

namespace GUI
{
    public partial class FormLogin : MaterialSkin.Controls.MaterialForm
    {
        public FormLogin()
        {
            InitializeComponent();
            var skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Grey800,
                Primary.Red300, Accent.LightBlue700,
                TextShade.WHITE
            );
            BlblWelcome.Font = new Font("Segoe MDL2 Assets", 36F, FontStyle.Bold);
            BlblWelcome.ForeColor = Color.FromArgb(0, 0, 192);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            var context = new AgendaDbContext();
            var usuarioDAL = new UsuarioDAL(context);
            this.FormClosed += FormLogin_FormClosed;

        }

        //material crear usuario
        private void btnCrearUsuario_Click_1(object sender, EventArgs e)
        {
            FormCrearUsuario formCrearUsuario = new FormCrearUsuario();
            formCrearUsuario.Show();
            this.Hide(); 
        }

        //material iniciar sesion
        private void btnIniciarSesion_Click_1(object sender, EventArgs e)
        {
            var context = new AgendaDbContext();
            var usuarioDAL = new UsuarioDAL(context);

                // verifica si hay una cuenta mínima registrada
                if (!usuarioDAL.HayUsuarios())
                {
                //Cuadro emergente
                hopeNotifyLogin.Type = HopeNotify.AlertType.Warning;
                hopeNotifyLogin.Visible = true;
                ShowNotify();      
                hopeNotifyLogin.Text = "No existen usuarios. Debe crear al menos uno.";
                return;
                }

                // Verifica si no hay nada escrito en Usuario
                if (txtUsuario.Text == "")
                {
                    pbUsuarioWarning.Visible = true;

                    toolTipUser.IsBalloon = true;
                    toolTipUser.ToolTipIcon = ToolTipIcon.Info;
                    toolTipUser.ToolTipTitle = "Nombre vacío";
                    toolTipUser.AutoPopDelay = 6000;
                    toolTipUser.InitialDelay = 500;
                    toolTipUser.ReshowDelay = 100;
                    toolTipUser.SetToolTip(pbUsuarioWarning, "Debe completar el campo escribiendo su nombre de usuario.");
                    return;
                }

                // Verifica si no hay nada escrito en Contraseña
                if (txtContraseña.Text == "")
                {
                    pbPasswordWarning.Visible = true;

                    toolTipPass.IsBalloon = true;
                    toolTipPass.ToolTipIcon = ToolTipIcon.Info;
                    toolTipPass.ToolTipTitle = "Contraseña vacía";
                    toolTipPass.AutoPopDelay = 6000;
                    toolTipPass.InitialDelay = 500;
                    toolTipPass.ReshowDelay = 100;
                    toolTipPass.SetToolTip(pbPasswordWarning, "Debe completar el campo escribiendo su contraseña de usuario.");
                    return;
                }

                var usuarioAutenticado = usuarioDAL.ValidarUsuario(txtUsuario.Text, txtContraseña.Text);

                if (usuarioAutenticado != null)
                {
                    string nombreUsuario = usuarioAutenticado.NombreUsuario;
                    string rolUsuario = usuarioAutenticado.Rol;

                // Mostrar menú
                FrmMenuPrincipal menu = new FrmMenuPrincipal(nombreUsuario, rolUsuario);
                menu.Show();
                this.Hide(); 
            }
                else
                {
                    pbUsuarioWarning.Visible = true;
                    toolTipUser.IsBalloon = true;
                    toolTipUser.ToolTipIcon = ToolTipIcon.Warning;
                    toolTipUser.ToolTipTitle = "Nombre incorrecto";
                    toolTipUser.AutoPopDelay = 6000;
                    toolTipUser.InitialDelay = 500;
                    toolTipUser.ReshowDelay = 100;
                    toolTipUser.SetToolTip(pbUsuarioWarning, "Puede que el nombre de usuario no exista o que la contraseña sea incorrecta.");

                    pbPasswordWarning.Visible = true;
                    toolTipPass.IsBalloon = true;
                    toolTipPass.ToolTipIcon = ToolTipIcon.Warning;
                    toolTipPass.ToolTipTitle = "Contraseña incorrecta";
                    toolTipPass.AutoPopDelay = 6000;
                    toolTipPass.InitialDelay = 500;
                    toolTipPass.ReshowDelay = 100;
                    toolTipPass.SetToolTip(pbPasswordWarning, "La contraseña es incorrecta o el nombre de usuario es inválido.");

                //Cuadro emergente
                hopeNotifyLogin.Type = HopeNotify.AlertType.Error;
                hopeNotifyLogin.Visible = true;
                ShowNotify();
                hopeNotifyLogin.Text = "No se pudo iniciar sesión.";
                    
            }
            }
              
        // ocultar iconos con click en txtUsuario
        private void pbUsuarioWarning_Mouse(object sender, EventArgs e)
        {
            pbUsuarioWarning.Visible = false;
        }

        // ocultar iconos con click en txtContraseña
        private void pbUPasswordWarning_Mouse(object sender, EventArgs e)
        {
            pbPasswordWarning.Visible = false;
        }

        //icono de visualizar contraseña
        private void pbView_Click(object sender, EventArgs e)
        {
            if (txtContraseña.UseSystemPasswordChar == true)
            {
                txtContraseña.UseSystemPasswordChar = false;
                txtContraseña.PasswordChar = new char();
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true;
            }


        }

        //Crear variables de timer 
        private System.Timers.Timer timerNotify;
        private System.Timers.Timer timerAncho;

        // Final del timer para ocultar la notificación
        private void OffNotificacion(object sender, EventArgs e)
        {
            if (hopeNotifyLogin.InvokeRequired)
            {
                hopeNotifyLogin.Invoke(new Action(() =>
                {
                    hopeNotifyLogin.Visible = false;
                }));
            }
            else
            {
                hopeNotifyLogin.Visible = false;
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

            Point posicionFinal = new Point(330, 380);
            int leftInicial = posicionFinal.X + (anchoObjetivo - anchoInicial); // <-- clave para que quede fijo

            // Reset posición y tamaño antes de animar
            hopeNotifyLogin.Size = new Size(anchoInicial, alto);
            hopeNotifyLogin.Location = new Point(leftInicial, posicionFinal.Y);

            // Timer para animar el ancho
            timerAncho = new System.Timers.Timer();
            timerAncho.Interval = 1;
            timerAncho.Elapsed += (s, e) =>
            {
                if (anchoActual < anchoObjetivo)
                {
                    anchoActual += 10;

                    if (hopeNotifyLogin.InvokeRequired)
                    {
                        hopeNotifyLogin.Invoke(new Action(() =>
                        {
                            hopeNotifyLogin.Left = posicionFinal.X + (anchoObjetivo - anchoActual);
                            hopeNotifyLogin.Width = anchoActual;
                        }));
                    }
                    else
                    {
                        hopeNotifyLogin.Left = posicionFinal.X + (anchoObjetivo - anchoActual);
                        hopeNotifyLogin.Width = anchoActual;
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
    }
}
