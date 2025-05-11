namespace GUI
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.PictureBox pbView;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.btnIniciarSesion = new MaterialSkin.Controls.MaterialButton();
            this.btnCrearUsuario = new MaterialSkin.Controls.MaterialButton();
            this.txtUsuario = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtContraseña = new MaterialSkin.Controls.MaterialTextBox2();
            this.toolTipUser = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPass = new System.Windows.Forms.ToolTip(this.components);
            this.hopeNotifyLogin = new ReaLTaiizor.Controls.HopeNotify();
            this.pbPasswordWarning = new System.Windows.Forms.PictureBox();
            this.pbUsuarioWarning = new System.Windows.Forms.PictureBox();
            this.BlblWelcome = new ReaLTaiizor.Controls.BigLabel();
            pbView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pbView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPasswordWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuarioWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // pbView
            // 
            pbView.BackColor = System.Drawing.Color.Transparent;
            pbView.Cursor = System.Windows.Forms.Cursors.Hand;
            pbView.Image = global::GUI.Properties.Resources.View;
            pbView.Location = new System.Drawing.Point(467, 241);
            pbView.Name = "pbView";
            pbView.Size = new System.Drawing.Size(22, 22);
            pbView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbView.TabIndex = 17;
            pbView.TabStop = false;
            pbView.Click += new System.EventHandler(this.pbView_Click);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarSesion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnIniciarSesion.Depth = 0;
            this.btnIniciarSesion.HighEmphasis = true;
            this.btnIniciarSesion.Icon = null;
            this.btnIniciarSesion.Location = new System.Drawing.Point(175, 304);
            this.btnIniciarSesion.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnIniciarSesion.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnIniciarSesion.Size = new System.Drawing.Size(98, 36);
            this.btnIniciarSesion.TabIndex = 8;
            this.btnIniciarSesion.Text = "Conectar";
            this.btnIniciarSesion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnIniciarSesion.UseAccentColor = false;
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click_1);
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCrearUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearUsuario.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.btnCrearUsuario.Depth = 0;
            this.btnCrearUsuario.HighEmphasis = true;
            this.btnCrearUsuario.Icon = global::GUI.Properties.Resources.agregar_usuario;
            this.btnCrearUsuario.Location = new System.Drawing.Point(338, 304);
            this.btnCrearUsuario.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCrearUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCrearUsuario.Size = new System.Drawing.Size(160, 36);
            this.btnCrearUsuario.TabIndex = 9;
            this.btnCrearUsuario.Text = "Crear usuario";
            this.btnCrearUsuario.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCrearUsuario.UseAccentColor = true;
            this.btnCrearUsuario.UseVisualStyleBackColor = true;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click_1);
            // 
            // txtUsuario
            // 
            this.txtUsuario.AnimateReadOnly = false;
            this.txtUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsuario.Depth = 0;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUsuario.HideSelection = true;
            this.txtUsuario.Hint = "Ingrese el usuario...";
            this.txtUsuario.LeadingIcon = global::GUI.Properties.Resources.agregar_usuario;
            this.txtUsuario.Location = new System.Drawing.Point(175, 164);
            this.txtUsuario.MaxLength = 32767;
            this.txtUsuario.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.PrefixSuffixText = null;
            this.txtUsuario.ReadOnly = false;
            this.txtUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.ShortcutsEnabled = true;
            this.txtUsuario.Size = new System.Drawing.Size(323, 48);
            this.txtUsuario.TabIndex = 12;
            this.txtUsuario.TabStop = false;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsuario.TrailingIcon = null;
            this.txtUsuario.UseSystemPasswordChar = false;
            this.txtUsuario.MouseCaptureChanged += new System.EventHandler(this.pbUsuarioWarning_Mouse);
            // 
            // txtContraseña
            // 
            this.txtContraseña.AnimateReadOnly = false;
            this.txtContraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtContraseña.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtContraseña.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContraseña.Depth = 0;
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtContraseña.HideSelection = true;
            this.txtContraseña.Hint = "ingrese la contraseña...";
            this.txtContraseña.LeadingIcon = global::GUI.Properties.Resources.Password;
            this.txtContraseña.Location = new System.Drawing.Point(175, 228);
            this.txtContraseña.MaxLength = 32767;
            this.txtContraseña.MouseState = MaterialSkin.MouseState.OUT;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '●';
            this.txtContraseña.PrefixSuffixText = null;
            this.txtContraseña.ReadOnly = false;
            this.txtContraseña.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtContraseña.SelectedText = "";
            this.txtContraseña.SelectionLength = 0;
            this.txtContraseña.SelectionStart = 0;
            this.txtContraseña.ShortcutsEnabled = true;
            this.txtContraseña.Size = new System.Drawing.Size(323, 48);
            this.txtContraseña.TabIndex = 13;
            this.txtContraseña.TabStop = false;
            this.txtContraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtContraseña.TrailingIcon = null;
            this.txtContraseña.UseSystemPasswordChar = true;
            this.txtContraseña.MouseCaptureChanged += new System.EventHandler(this.pbUPasswordWarning_Mouse);
            // 
            // toolTipUser
            // 
            this.toolTipUser.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // hopeNotifyLogin
            // 
            this.hopeNotifyLogin.Close = true;
            this.hopeNotifyLogin.CloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(148)))), ((int)(((byte)(154)))));
            this.hopeNotifyLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeNotifyLogin.ErrorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeNotifyLogin.ErrorTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeNotifyLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeNotifyLogin.InfoBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeNotifyLogin.InfoTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeNotifyLogin.Location = new System.Drawing.Point(537, 372);
            this.hopeNotifyLogin.Name = "hopeNotifyLogin";
            this.hopeNotifyLogin.Size = new System.Drawing.Size(132, 34);
            this.hopeNotifyLogin.SuccessBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeNotifyLogin.SuccessTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeNotifyLogin.TabIndex = 16;
            this.hopeNotifyLogin.Text = "Notificador";
            this.hopeNotifyLogin.Type = ReaLTaiizor.Controls.HopeNotify.AlertType.Success;
            this.hopeNotifyLogin.Visible = false;
            this.hopeNotifyLogin.WarningBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeNotifyLogin.WarningTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            // 
            // pbPasswordWarning
            // 
            this.pbPasswordWarning.Image = global::GUI.Properties.Resources.Alert_Icon;
            this.pbPasswordWarning.Location = new System.Drawing.Point(504, 251);
            this.pbPasswordWarning.Name = "pbPasswordWarning";
            this.pbPasswordWarning.Size = new System.Drawing.Size(25, 24);
            this.pbPasswordWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPasswordWarning.TabIndex = 15;
            this.pbPasswordWarning.TabStop = false;
            this.pbPasswordWarning.Visible = false;
            // 
            // pbUsuarioWarning
            // 
            this.pbUsuarioWarning.Image = global::GUI.Properties.Resources.Alert_Icon;
            this.pbUsuarioWarning.Location = new System.Drawing.Point(504, 173);
            this.pbUsuarioWarning.Name = "pbUsuarioWarning";
            this.pbUsuarioWarning.Size = new System.Drawing.Size(25, 24);
            this.pbUsuarioWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUsuarioWarning.TabIndex = 14;
            this.pbUsuarioWarning.TabStop = false;
            this.pbUsuarioWarning.Visible = false;
            // 
            // BlblWelcome
            // 
            this.BlblWelcome.AutoSize = true;
            this.BlblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.BlblWelcome.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.BlblWelcome.Location = new System.Drawing.Point(187, 54);
            this.BlblWelcome.Name = "BlblWelcome";
            this.BlblWelcome.Size = new System.Drawing.Size(311, 48);
            this.BlblWelcome.TabIndex = 21;
            this.BlblWelcome.Text = "INICIAR SESION";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(686, 425);
            this.Controls.Add(this.BlblWelcome);
            this.Controls.Add(pbView);
            this.Controls.Add(this.hopeNotifyLogin);
            this.Controls.Add(this.pbPasswordWarning);
            this.Controls.Add(this.pbUsuarioWarning);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.btnIniciarSesion);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(pbView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPasswordWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuarioWarning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnIniciarSesion;
        private MaterialSkin.Controls.MaterialButton btnCrearUsuario;
        private MaterialSkin.Controls.MaterialTextBox2 txtUsuario;
        private MaterialSkin.Controls.MaterialTextBox2 txtContraseña;
        private System.Windows.Forms.PictureBox pbUsuarioWarning;
        private System.Windows.Forms.PictureBox pbPasswordWarning;
        private System.Windows.Forms.ToolTip toolTipUser;
        private System.Windows.Forms.ToolTip toolTipPass;
        private ReaLTaiizor.Controls.HopeNotify hopeNotifyLogin;
        private ReaLTaiizor.Controls.BigLabel BlblWelcome;
    }
}