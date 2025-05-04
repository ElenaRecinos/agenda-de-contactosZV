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

namespace GUI
{
    public partial class FrmMenuPrincipal: Form
    {

        private readonly AgendaDbContext _context;
        private readonly ContactoBLL _contactoBLL;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            _context = new AgendaDbContext();
            _contactoBLL = new ContactoBLL(_context);

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void gestionarContactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormContacto formContacto = new FormContacto(_context);
            formContacto.ShowDialog();
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void btnGestionarContactos_Click(object sender, EventArgs e)
        {
            FormContacto formContacto = new FormContacto(_context);
            formContacto.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AgendaConnection"].ConnectionString;
                var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);

                string servidor = builder.DataSource;
                string baseDatos = builder.InitialCatalog;
                string usuario = builder.IntegratedSecurity ? "(Autenticación Windows)" : builder.UserID;

                lblServidor.Text = $"Servidor: {servidor}";
                lblNombre.Text = $"Base de datos: {baseDatos}";
                lblUsuario.Text = $"Usuario: {usuario}";
            }
            catch (Exception ex)
            {
                lblServidor.Text = "Servidor: (no disponible)";
                lblNombre.Text = "Base de datos: (no disponible)";
                lblUsuario.Text = "Usuario: (no disponible)";

                MessageBox.Show($"Error al leer configuración: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int totalContactos = _context.Contactos.Count();
            int totalGrupos = _context.Grupos.Count();

            lblContRegis.Text = totalContactos.ToString();
            lblGrupRegis.Text = totalGrupos.ToString();

            var datos = _context.Contactos
        .GroupBy(c => c.Grupo != null ? c.Grupo.Nombre : "Sin grupo")
        .Select(g => new { NombreGrupo = g.Key, Cantidad = g.Count() })
        .ToList();

            chartGrupos.Series["Grupos"].Points.Clear(); 

            foreach (var item in datos)
            {
                chartGrupos.Series["Grupos"].Points.AddXY(item.NombreGrupo, item.Cantidad);
            }
        }
    }
}
