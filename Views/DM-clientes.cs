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
    public partial class DM_clientes : Form
    {
        CN_clientes objCN = new CN_clientes();
        private string idCliente = null; 
        private bool editar = false;
        public DM_clientes()
        {
            InitializeComponent();
        }

        private void DM_clientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dulcemexicoDataSet.clientes' Puede moverla o quitarla según sea necesario.
            //this.clientesTableAdapter.Fill(this.dulcemexicoDataSet.clientes);
            MostrarClientes();

        }
        #region Methods
        private void MostrarClientes()
        {
            //objeto para refrescar la tabla productos
            CN_clientes obj = new CN_clientes();
            dgvClientes.DataSource = obj.MostrarClientes();

        }

        private void LimpiarForm()
        {
            txtIDCliente.Clear();
            txtApPat.Clear();
            txtApMat.Clear();
            txtNombre.Clear();
            txtTipoCliente.Clear();
            txtDireccion.Clear();
            txtColonia.Clear();
            txtCP.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();


        }


        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (editar == false)
            {
                try
                {
                    objCN.Insertar(txtIDCliente.Text, txtApPat.Text, txtApMat.Text, txtNombre.Text, txtTipoCliente.Text,
                        txtDireccion.Text, txtColonia.Text, txtCP.Text, txtTelefono.Text, txtEmail.Text);
                    MessageBox.Show("Cliente agregado con exito.");
                    MostrarClientes();
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el cliente por: " + ex);
                }
            }
            //EDITAR
            if (editar == true)
            {
                try
                {
                    objCN.Editar(txtIDCliente.Text, txtApPat.Text, txtApMat.Text, txtNombre.Text, txtTipoCliente.Text,
                        txtDireccion.Text, txtColonia.Text, txtCP.Text, txtTelefono.Text, txtEmail.Text);
                    MessageBox.Show("Cliente actualizado con exito.");
                    MostrarClientes();
                    LimpiarForm();
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos del cliente por:" + ex);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                editar = true;
                txtIDCliente.Text = dgvClientes.CurrentRow.Cells["id_cliente"].Value.ToString();
                txtApPat.Text = dgvClientes.CurrentRow.Cells["ap_pat"].Value.ToString();
                txtApMat.Text = dgvClientes.CurrentRow.Cells["ap_mat"].Value.ToString();
                txtNombre.Text = dgvClientes.CurrentRow.Cells["nombre"].Value.ToString();
                txtTipoCliente.Text = dgvClientes.CurrentRow.Cells["tipo_cliente"].Value.ToString();
                txtDireccion.Text = dgvClientes.CurrentRow.Cells["direccion"].Value.ToString();
                txtColonia.Text = dgvClientes.CurrentRow.Cells["colonia"].Value.ToString();
                txtCP.Text = dgvClientes.CurrentRow.Cells["cp"].Value.ToString();
                txtTelefono.Text = dgvClientes.CurrentRow.Cells["telefono"].Value.ToString();
                txtEmail.Text = dgvClientes.CurrentRow.Cells["email"].Value.ToString();
            }
            else MessageBox.Show("Seleccione una fila por favor.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                idCliente = dgvClientes.CurrentRow.Cells["id_cliente"].Value.ToString();
                objCN.Eliminar(idCliente);
                MessageBox.Show("Cliente eliminado.");
                MostrarClientes();
            }
            else
            {
                MessageBox.Show("Seleccione una fila porfavor.");
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
