using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conexionSQL
{
    public partial class DM_ventas : Form
    {
        public DM_ventas()
        {
            InitializeComponent();
        }

        private void DM_ventas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dulcemexicoDataSet.ventas' Puede moverla o quitarla según sea necesario.
            this.ventasTableAdapter.Fill(this.dulcemexicoDataSet.ventas);

        }
    }
}
