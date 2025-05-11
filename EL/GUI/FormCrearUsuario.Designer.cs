namespace GUI
{
    partial class FormCrearUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrearUsuario));
            this.MTcmbRol = new MaterialSkin.Controls.MaterialComboBox();
            this.cyberbtnGuardar = new ReaLTaiizor.Controls.CyberButton();
            this.cyberbtnLogin = new ReaLTaiizor.Controls.CyberButton();
            this.bigLabelAccount = new ReaLTaiizor.Controls.BigLabel();
            this.parrotpicFotoPerfil = new ReaLTaiizor.Controls.ParrotPictureBox();
            this.MTtxtUsuario = new MaterialSkin.Controls.MaterialTextBox2();
            this.MTtxtContraseña = new MaterialSkin.Controls.MaterialTextBox2();
            this.hopeNotifyAccount = new ReaLTaiizor.Controls.HopeNotify();
            this.SuspendLayout();
            // 
            // MTcmbRol
            // 
            this.MTcmbRol.AutoResize = false;
            this.MTcmbRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MTcmbRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MTcmbRol.Depth = 0;
            this.MTcmbRol.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.MTcmbRol.DropDownHeight = 174;
            this.MTcmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MTcmbRol.DropDownWidth = 121;
            this.MTcmbRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.MTcmbRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MTcmbRol.FormattingEnabled = true;
            this.MTcmbRol.Hint = "Rol de cuenta";
            this.MTcmbRol.IntegralHeight = false;
            this.MTcmbRol.ItemHeight = 43;
            this.MTcmbRol.Location = new System.Drawing.Point(60, 391);
            this.MTcmbRol.MaxDropDownItems = 4;
            this.MTcmbRol.MouseState = MaterialSkin.MouseState.OUT;
            this.MTcmbRol.Name = "MTcmbRol";
            this.MTcmbRol.Size = new System.Drawing.Size(316, 49);
            this.MTcmbRol.StartIndex = 0;
            this.MTcmbRol.TabIndex = 14;
            // 
            // cyberbtnGuardar
            // 
            this.cyberbtnGuardar.Alpha = 20;
            this.cyberbtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.cyberbtnGuardar.Background = true;
            this.cyberbtnGuardar.Background_WidthPen = 4F;
            this.cyberbtnGuardar.BackgroundPen = false;
            this.cyberbtnGuardar.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberbtnGuardar.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberbtnGuardar.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.cyberbtnGuardar.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cyberbtnGuardar.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cyberbtnGuardar.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberbtnGuardar.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.cyberbtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cyberbtnGuardar.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cyberbtnGuardar.Effect_1 = true;
            this.cyberbtnGuardar.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cyberbtnGuardar.Effect_1_Transparency = 25;
            this.cyberbtnGuardar.Effect_2 = true;
            this.cyberbtnGuardar.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.cyberbtnGuardar.Effect_2_Transparency = 20;
            this.cyberbtnGuardar.Font = new System.Drawing.Font("Arial", 11F);
            this.cyberbtnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cyberbtnGuardar.Lighting = false;
            this.cyberbtnGuardar.LinearGradient_Background = false;
            this.cyberbtnGuardar.LinearGradientPen = false;
            this.cyberbtnGuardar.Location = new System.Drawing.Point(60, 481);
            this.cyberbtnGuardar.Name = "cyberbtnGuardar";
            this.cyberbtnGuardar.PenWidth = 15;
            this.cyberbtnGuardar.Rounding = true;
            this.cyberbtnGuardar.RoundingInt = 70;
            this.cyberbtnGuardar.Size = new System.Drawing.Size(147, 50);
            this.cyberbtnGuardar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.cyberbtnGuardar.TabIndex = 17;
            this.cyberbtnGuardar.Tag = "Cyber";
            this.cyberbtnGuardar.TextButton = "Sing Up";
            this.cyberbtnGuardar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.cyberbtnGuardar.Timer_Effect_1 = 5;
            this.cyberbtnGuardar.Timer_RGB = 300;
            this.cyberbtnGuardar.Click += new System.EventHandler(this.cyberbtnGuardar_Click);
            // 
            // cyberbtnLogin
            // 
            this.cyberbtnLogin.Alpha = 20;
            this.cyberbtnLogin.BackColor = System.Drawing.Color.Transparent;
            this.cyberbtnLogin.Background = true;
            this.cyberbtnLogin.Background_WidthPen = 4F;
            this.cyberbtnLogin.BackgroundPen = false;
            this.cyberbtnLogin.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cyberbtnLogin.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberbtnLogin.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.cyberbtnLogin.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cyberbtnLogin.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cyberbtnLogin.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberbtnLogin.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.cyberbtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cyberbtnLogin.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cyberbtnLogin.Effect_1 = true;
            this.cyberbtnLogin.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cyberbtnLogin.Effect_1_Transparency = 25;
            this.cyberbtnLogin.Effect_2 = true;
            this.cyberbtnLogin.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.cyberbtnLogin.Effect_2_Transparency = 20;
            this.cyberbtnLogin.Font = new System.Drawing.Font("Arial", 11F);
            this.cyberbtnLogin.ForeColor = System.Drawing.Color.Black;
            this.cyberbtnLogin.Lighting = false;
            this.cyberbtnLogin.LinearGradient_Background = false;
            this.cyberbtnLogin.LinearGradientPen = false;
            this.cyberbtnLogin.Location = new System.Drawing.Point(230, 481);
            this.cyberbtnLogin.Name = "cyberbtnLogin";
            this.cyberbtnLogin.PenWidth = 15;
            this.cyberbtnLogin.Rounding = true;
            this.cyberbtnLogin.RoundingInt = 70;
            this.cyberbtnLogin.Size = new System.Drawing.Size(146, 50);
            this.cyberbtnLogin.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.cyberbtnLogin.TabIndex = 18;
            this.cyberbtnLogin.Tag = "Cyber";
            this.cyberbtnLogin.TextButton = "Sing In";
            this.cyberbtnLogin.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.cyberbtnLogin.Timer_Effect_1 = 5;
            this.cyberbtnLogin.Timer_RGB = 300;
            this.cyberbtnLogin.Click += new System.EventHandler(this.cyberbtnLogin_Click);
            // 
            // bigLabelAccount
            // 
            this.bigLabelAccount.AutoSize = true;
            this.bigLabelAccount.BackColor = System.Drawing.Color.Transparent;
            this.bigLabelAccount.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabelAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bigLabelAccount.Location = new System.Drawing.Point(76, 47);
            this.bigLabelAccount.Name = "bigLabelAccount";
            this.bigLabelAccount.Size = new System.Drawing.Size(285, 48);
            this.bigLabelAccount.TabIndex = 20;
            this.bigLabelAccount.Text = "Create Account";
            // 
            // parrotpicFotoPerfil
            // 
            this.parrotpicFotoPerfil.ColorLeft = System.Drawing.Color.DodgerBlue;
            this.parrotpicFotoPerfil.ColorRight = System.Drawing.Color.Indigo;
            this.parrotpicFotoPerfil.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.parrotpicFotoPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.parrotpicFotoPerfil.FilterAlpha = 100;
            this.parrotpicFotoPerfil.FilterEnabled = true;
            this.parrotpicFotoPerfil.Image = global::GUI.Properties.Resources.Perfil;
            this.parrotpicFotoPerfil.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.parrotpicFotoPerfil.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.parrotpicFotoPerfil.IsElipse = true;
            this.parrotpicFotoPerfil.IsParallax = false;
            this.parrotpicFotoPerfil.Location = new System.Drawing.Point(160, 122);
            this.parrotpicFotoPerfil.Name = "parrotpicFotoPerfil";
            this.parrotpicFotoPerfil.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.parrotpicFotoPerfil.Size = new System.Drawing.Size(88, 87);
            this.parrotpicFotoPerfil.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            this.parrotpicFotoPerfil.TabIndex = 23;
            this.parrotpicFotoPerfil.Text = "parrotPictureBox1";
            this.parrotpicFotoPerfil.TextRenderingType = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            this.parrotpicFotoPerfil.Click += new System.EventHandler(this.parrotpicFotoPerfil_Click);
            // 
            // MTtxtUsuario
            // 
            this.MTtxtUsuario.AnimateReadOnly = false;
            this.MTtxtUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MTtxtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.MTtxtUsuario.Depth = 0;
            this.MTtxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MTtxtUsuario.HideSelection = true;
            this.MTtxtUsuario.Hint = "Name";
            this.MTtxtUsuario.LeadingIcon = global::GUI.Properties.Resources.agregar_usuario;
            this.MTtxtUsuario.Location = new System.Drawing.Point(60, 259);
            this.MTtxtUsuario.MaxLength = 32767;
            this.MTtxtUsuario.MouseState = MaterialSkin.MouseState.OUT;
            this.MTtxtUsuario.Name = "MTtxtUsuario";
            this.MTtxtUsuario.PasswordChar = '\0';
            this.MTtxtUsuario.PrefixSuffixText = null;
            this.MTtxtUsuario.ReadOnly = false;
            this.MTtxtUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MTtxtUsuario.SelectedText = "";
            this.MTtxtUsuario.SelectionLength = 0;
            this.MTtxtUsuario.SelectionStart = 0;
            this.MTtxtUsuario.ShortcutsEnabled = true;
            this.MTtxtUsuario.Size = new System.Drawing.Size(316, 48);
            this.MTtxtUsuario.TabIndex = 22;
            this.MTtxtUsuario.TabStop = false;
            this.MTtxtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.MTtxtUsuario.TrailingIcon = null;
            this.MTtxtUsuario.UseSystemPasswordChar = false;
            // 
            // MTtxtContraseña
            // 
            this.MTtxtContraseña.AnimateReadOnly = false;
            this.MTtxtContraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MTtxtContraseña.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.MTtxtContraseña.Depth = 0;
            this.MTtxtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MTtxtContraseña.HideSelection = true;
            this.MTtxtContraseña.Hint = "Password";
            this.MTtxtContraseña.LeadingIcon = global::GUI.Properties.Resources.Password;
            this.MTtxtContraseña.Location = new System.Drawing.Point(60, 325);
            this.MTtxtContraseña.MaxLength = 32767;
            this.MTtxtContraseña.MouseState = MaterialSkin.MouseState.OUT;
            this.MTtxtContraseña.Name = "MTtxtContraseña";
            this.MTtxtContraseña.PasswordChar = '●';
            this.MTtxtContraseña.PrefixSuffixText = null;
            this.MTtxtContraseña.ReadOnly = false;
            this.MTtxtContraseña.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MTtxtContraseña.SelectedText = "";
            this.MTtxtContraseña.SelectionLength = 0;
            this.MTtxtContraseña.SelectionStart = 0;
            this.MTtxtContraseña.ShortcutsEnabled = true;
            this.MTtxtContraseña.Size = new System.Drawing.Size(316, 48);
            this.MTtxtContraseña.TabIndex = 21;
            this.MTtxtContraseña.TabStop = false;
            this.MTtxtContraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.MTtxtContraseña.TrailingIcon = null;
            this.MTtxtContraseña.UseSystemPasswordChar = true;
            // 
            // hopeNotifyAccount
            // 
            this.hopeNotifyAccount.Close = true;
            this.hopeNotifyAccount.CloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(148)))), ((int)(((byte)(154)))));
            this.hopeNotifyAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeNotifyAccount.ErrorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeNotifyAccount.ErrorTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeNotifyAccount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeNotifyAccount.InfoBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeNotifyAccount.InfoTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeNotifyAccount.Location = new System.Drawing.Point(277, 551);
            this.hopeNotifyAccount.Name = "hopeNotifyAccount";
            this.hopeNotifyAccount.Size = new System.Drawing.Size(150, 34);
            this.hopeNotifyAccount.SuccessBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeNotifyAccount.SuccessTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeNotifyAccount.TabIndex = 24;
            this.hopeNotifyAccount.Text = "Notificador";
            this.hopeNotifyAccount.Type = ReaLTaiizor.Controls.HopeNotify.AlertType.Success;
            this.hopeNotifyAccount.Visible = false;
            this.hopeNotifyAccount.WarningBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeNotifyAccount.WarningTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            // 
            // FormCrearUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 591);
            this.Controls.Add(this.hopeNotifyAccount);
            this.Controls.Add(this.parrotpicFotoPerfil);
            this.Controls.Add(this.MTtxtUsuario);
            this.Controls.Add(this.MTtxtContraseña);
            this.Controls.Add(this.bigLabelAccount);
            this.Controls.Add(this.cyberbtnLogin);
            this.Controls.Add(this.cyberbtnGuardar);
            this.Controls.Add(this.MTcmbRol);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCrearUsuario";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormCrearUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialComboBox MTcmbRol;
        private ReaLTaiizor.Controls.CyberButton cyberbtnGuardar;
        private ReaLTaiizor.Controls.CyberButton cyberbtnLogin;
        private ReaLTaiizor.Controls.BigLabel bigLabelAccount;
        private MaterialSkin.Controls.MaterialTextBox2 MTtxtContraseña;
        private MaterialSkin.Controls.MaterialTextBox2 MTtxtUsuario;
        private ReaLTaiizor.Controls.ParrotPictureBox parrotpicFotoPerfil;
        private ReaLTaiizor.Controls.HopeNotify hopeNotifyAccount;
    }
}