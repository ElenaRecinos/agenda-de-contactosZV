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
            // Aquí llamamos al método de exportar que vimos antes
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
            MessageBox.Show("Funcionalidad de importar contactos aún no implementada.");
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de impresión aún no implementada.");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de cerrar sesión aún no implementada.");
            // Podría cerrar este formulario y mostrar el login si existiera
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGestionarContactos_Click(object sender, EventArgs e)
        {
            FormContacto formContacto = new FormContacto(_context);
            formContacto.ShowDialog();
        }
    }
}
