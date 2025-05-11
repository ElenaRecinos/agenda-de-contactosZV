namespace GUI
{
    partial class FrmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarContactosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeGruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblContRegis = new System.Windows.Forms.Label();
            this.lblGrupRegis = new System.Windows.Forms.Label();
            this.pbPerfil = new System.Windows.Forms.PictureBox();
            this.lblNombreUser = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.btnGestionarContactos = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblServidor = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.chartGrupos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.configuraciónToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(892, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarContactosToolStripMenuItem,
            this.exportarToolStripMenuItem,
            this.importarToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // gestionarContactosToolStripMenuItem
            // 
            this.gestionarContactosToolStripMenuItem.Name = "gestionarContactosToolStripMenuItem";
            this.gestionarContactosToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.gestionarContactosToolStripMenuItem.Text = "Gestionar contactos...";
            this.gestionarContactosToolStripMenuItem.Click += new System.EventHandler(this.gestionarContactosToolStripMenuItem_Click);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.exportarToolStripMenuItem.Text = "Exportar...";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
            // 
            // importarToolStripMenuItem
            // 
            this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
            this.importarToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.importarToolStripMenuItem.Text = "Importar...";
            this.importarToolStripMenuItem.Click += new System.EventHandler(this.importarToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar sesion";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeGruposToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // listaDeGruposToolStripMenuItem
            // 
            this.listaDeGruposToolStripMenuItem.Name = "listaDeGruposToolStripMenuItem";
            this.listaDeGruposToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.listaDeGruposToolStripMenuItem.Text = "Lista de Grupos";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(464, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestor de Contactos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contactos registrados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Grupos  registrados:";
            // 
            // lblContRegis
            // 
            this.lblContRegis.AutoSize = true;
            this.lblContRegis.Location = new System.Drawing.Point(26, 169);
            this.lblContRegis.Name = "lblContRegis";
            this.lblContRegis.Size = new System.Drawing.Size(14, 13);
            this.lblContRegis.TabIndex = 4;
            this.lblContRegis.Text = "X";
            // 
            // lblGrupRegis
            // 
            this.lblGrupRegis.AutoSize = true;
            this.lblGrupRegis.Location = new System.Drawing.Point(228, 169);
            this.lblGrupRegis.Name = "lblGrupRegis";
            this.lblGrupRegis.Size = new System.Drawing.Size(14, 13);
            this.lblGrupRegis.TabIndex = 5;
            this.lblGrupRegis.Text = "Y";
            // 
            // pbPerfil
            // 
            this.pbPerfil.Image = ((System.Drawing.Image)(resources.GetObject("pbPerfil.Image")));
            this.pbPerfil.Location = new System.Drawing.Point(29, 36);
            this.pbPerfil.Name = "pbPerfil";
            this.pbPerfil.Size = new System.Drawing.Size(43, 43);
            this.pbPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPerfil.TabIndex = 6;
            this.pbPerfil.TabStop = false;
            // 
            // lblNombreUser
            // 
            this.lblNombreUser.AutoSize = true;
            this.lblNombreUser.Location = new System.Drawing.Point(89, 45);
            this.lblNombreUser.Name = "lblNombreUser";
            this.lblNombreUser.Size = new System.Drawing.Size(98, 13);
            this.lblNombreUser.TabIndex = 7;
            this.lblNombreUser.Text = "Nombre de Usuario";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(193, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 16);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(89, 66);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(23, 13);
            this.lblRol.TabIndex = 9;
            this.lblRol.Text = "Rol";
            // 
            // btnGestionarContactos
            // 
            this.btnGestionarContactos.Location = new System.Drawing.Point(16, 303);
            this.btnGestionarContactos.Name = "btnGestionarContactos";
            this.btnGestionarContactos.Size = new System.Drawing.Size(143, 38);
            this.btnGestionarContactos.TabIndex = 10;
            this.btnGestionarContactos.Text = "Gestionar contactos...";
            this.btnGestionarContactos.UseVisualStyleBackColor = true;
            this.btnGestionarContactos.Click += new System.EventHandler(this.btnGestionarContactos_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label8.Location = new System.Drawing.Point(23, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "Base de datos:";
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(21, 404);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(14, 13);
            this.lblServidor.TabIndex = 15;
            this.lblServidor.Text = "X";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(21, 417);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(14, 13);
            this.lblNombre.TabIndex = 16;
            this.lblNombre.Text = "Y";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(20, 430);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(14, 13);
            this.lblUsuario.TabIndex = 17;
            this.lblUsuario.Text = "Z";
            // 
            // chartGrupos
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGrupos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGrupos.Legends.Add(legend1);
            this.chartGrupos.Location = new System.Drawing.Point(440, 97);
            this.chartGrupos.Name = "chartGrupos";
            this.chartGrupos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Grupos";
            this.chartGrupos.Series.Add(series1);
            this.chartGrupos.Size = new System.Drawing.Size(440, 244);
            this.chartGrupos.TabIndex = 18;
            this.chartGrupos.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(802, 417);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(30, 13);
            this.lblHora.TabIndex = 19;
            this.lblHora.Text = "Hora";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(802, 430);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 20;
            this.lblFecha.Text = "Fecha";
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 482);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.chartGrupos);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblServidor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnGestionarContactos);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblNombreUser);
            this.Controls.Add(this.pbPerfil);
            this.Controls.Add(this.lblGrupRegis);
            this.Controls.Add(this.lblContRegis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenuPrincipal";
            this.Text = "FrmMenuPrincipal";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrupos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarContactosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblContRegis;
        private System.Windows.Forms.Label lblGrupRegis;
        private System.Windows.Forms.PictureBox pbPerfil;
        private System.Windows.Forms.Label lblNombreUser;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Button btnGestionarContactos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGrupos;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeGruposToolStripMenuItem;
    }
}