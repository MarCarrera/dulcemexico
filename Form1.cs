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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'escuelaDataSet.alumno' Puede moverla o quitarla según sea necesario.
            this.alumnoTableAdapter.Fill(this.escuelaDataSet.alumno);
            MostrarPosicion();

        }
        private void MostrarPosicion()
        {
            int iTotal = alumnoBindingSource.Count;
            int iPos;
            if (iTotal == 0)
            {
                label8.Text = "No Registros";
            }
            else
            {
                iPos = alumnoBindingSource.Position + 1;
                label8.Text = iPos.ToString() + " de " + iTotal.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alumnoBindingSource.Position = 0;
            MostrarPosicion();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            alumnoBindingSource.Position -= 1;
            MostrarPosicion();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            alumnoBindingSource.Position = alumnoBindingSource.Count - 1;
            MostrarPosicion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            alumnoBindingSource.Position += 1;
            MostrarPosicion();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable miTabla = escuelaDataSet.alumno;
            DataRowCollection cfilas = miTabla.Rows;
            DataRow nuevaFila;
            try
            {
                nuevaFila = miTabla.NewRow();
                nuevaFila[0] = "00000000";
                nuevaFila[1] = "Nombre";
                nuevaFila[2] = "1";
                nuevaFila[3] = "01/01/1990";
                nuevaFila[4] = "01/01/1990";
                cfilas.Add(nuevaFila);
                button4.PerformClick();
                MostrarPosicion();
                txtNC.Focus();
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataRowView vistaFilaActual;
            String NL = Environment.NewLine;
            if (MessageBox.Show("Desea borrar este registro?" + NL,
            "Buscar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                vistaFilaActual = (DataRowView)alumnoBindingSource.Current;
                vistaFilaActual.Row.Delete();
                MostrarPosicion();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (escuelaDataSet.HasChanges())
            {
                this.alumnoTableAdapter.Update(this.escuelaDataSet.alumno);
                MessageBox.Show("Base de datos actualizada...");
            }
        }
    }
}
