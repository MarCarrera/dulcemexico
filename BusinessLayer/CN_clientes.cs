using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using conexionSQL.DataLayer;

namespace conexionSQL.BusinessLayer
{
    public class CN_clientes
    {
        //INSTANCIA DE LA CLASE DE DATOS CLIENTES
        private CD_clientes objCD = new CD_clientes();

        public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();
            tabla = objCD.Mostrar();
            return tabla;
        }
        public void Insertar(string id_cliente, string ap_pat, string ap_mat, string nombre, string tipo_cliente,
            string direccion, string colonia, string cp, string telefono, string email)
        {
            objCD.Insertar(id_cliente, ap_pat, ap_mat, nombre, tipo_cliente, direccion, colonia, cp, telefono, email);
        }
        public void Editar(string id_cliente, string ap_pat, string ap_mat, string nombre, string tipo_cliente,
            string direccion, string colonia, string cp, string telefono, string email)
        {
            objCD.Editar(id_cliente, ap_pat, ap_mat, nombre, tipo_cliente, direccion, colonia, cp, telefono, email);
        }
        public void Eliminar(string id_cliente)
        {
            objCD.Eliminar(id_cliente);
        }
    }
}
