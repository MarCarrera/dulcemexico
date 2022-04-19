using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using conexionSQL.BusinessLayer;


namespace conexionSQL
{
    public partial class DM_productos : Form
    {
        public CN_productos objCN = new CN_productos();
        private string idProducto = null;
        private bool editar = false;
        public DM_productos()
        {
            InitializeComponent();
        }

        private void DM_productos_Load(object sender, EventArgs e)
        {
           /* // TODO: esta línea de código carga datos en la tabla 'dulcemexicoDataSet.ventas' Puede moverla o quitarla según sea necesario.
            this.ventasTableAdapter.Fill(this.dulcemexicoDataSet.ventas);
            // TODO: esta línea de código carga datos en la tabla 'dulcemexicoDataSet.productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.dulcemexicoDataSet.productos);*/

            MostrarProductos();


        }
        #region Methods
        private void MostrarProductos()
        {
            //objeto para refrescar la tabla productos
            CN_productos obj = new CN_productos();
            dgvProductos.DataSource = obj.MostrarProd();
        }

        private void LimpiarForm()
        {
            txtID.Clear();
            txtDescripcion.Clear();
            txtOrigen.Clear();
            txtStock.Clear();
            txtPrecioUni.Clear();

        }


        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if(editar == false)
            {
                try
                {
                    objCN.Insertar(txtID.Text, txtDescripcion.Text, txtOrigen.Text, txtStock.Text, txtPrecioUni.Text);
                    MessageBox.Show("Producto agregado con exito.");
                    MostrarProductos();
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro por: " + ex);
                }
            }
            //EDITAR
            if (editar == true)
            {
                try
                {
                    objCN.Editar(txtID.Text, txtDescripcion.Text, txtOrigen.Text, txtStock.Text, txtPrecioUni.Text);
                    MessageBox.Show("Producto actualizado con exito.");
                    MostrarProductos();
                    LimpiarForm();
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por:" + ex);
                }
            }
               
            

        
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                txtID.Text = dgvProductos.CurrentRow.Cells["id_prod"].Value.ToString();
                editar = true;
                //idProducto = dgvProductos.CurrentRow.Cells["id_prod"].Value.ToString();
                txtDescripcion.Text = dgvProductos.CurrentRow.Cells["descripcion"].Value.ToString();
                txtOrigen.Text = dgvProductos.CurrentRow.Cells["origen"].Value.ToString();
                txtStock.Text = dgvProductos.CurrentRow.Cells["stock"].Value.ToString();
                txtPrecioUni.Text = dgvProductos.CurrentRow.Cells["precio_uni"].Value.ToString();
            }
            else MessageBox.Show("Seleccione una fila por favor.");
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvProductos.SelectedRows.Count > 0)
            {
                idProducto = dgvProductos.CurrentRow.Cells["id_prod"].Value.ToString();
                objCN.Eliminar(idProducto);
                MessageBox.Show("Producto eliminado.");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Seleccione una fila porfavor.");
            }
        }
    }
}
