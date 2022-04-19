using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace conexionSQL.DataLayer
{
    public class CD_clientes
    {
        //INSTANCIA DE CONEXION A LA BASE DE DATOS
        private Conexion conexion = new Conexion();

        //LECTURA DE DATOS SQL
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //METODO QUE CONSULTA LA TABLA CLIENTES Y LA MUESTRA EN UNA TABLA
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from clientes";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerraConexion();
            comando.Parameters.Clear();
            return tabla;
        }
        //METODO QUE INSERTA UN REGISTRO EN LA TABLA CLIENTES
        public void Insertar(string id_cliente, string ap_pat, string ap_mat, string nombre, string tipo_cliente,
            string direccion, string colonia, string cp, string telefono, string email)
        {
            //INSERTAR CON T-SQL

            /*comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insert into productos values('"+id_prod+"','"+descripcion+"','"+origen+"','"+stock+"','"+precio+"')";
            comando.CommandType = CommandType.Text; 
            comando.ExecuteNonQuery();*/

            //INSERTAR CON PROCEDIMIENTO ALMACENADO
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_INSERTARCLIENTE";
            //Tipo de comando
            comando.CommandType = CommandType.StoredProcedure;
            //Nombres de los parametros del SP
            comando.Parameters.AddWithValue("@id_cliente", id_cliente);
            comando.Parameters.AddWithValue("@ap_pat", ap_pat);
            comando.Parameters.AddWithValue("@ap_mat", ap_mat);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@tipo_cliente", tipo_cliente);
            comando.Parameters.AddWithValue("@direccion", direccion);
            comando.Parameters.AddWithValue("@colonia", colonia);
            comando.Parameters.AddWithValue("@cp", cp);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@email", email);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();



        }
        //METODO QUE EDITA UN REGISTRO EN LA TABLA CLIENTES
        public void Editar(string id_cliente, string ap_pat, string ap_mat, string nombre, string tipo_cliente,
            string direccion, string colonia, string cp, string telefono, string email)
        {
            //EDITAR CON PROCEDIMIENTO ALMACENADO
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_EDITARCLIENTE";
            //Tipo de comando
            comando.CommandType = CommandType.StoredProcedure;
            //Nombres de los parametros del SP
            comando.Parameters.AddWithValue("@id_cliente", id_cliente);
            comando.Parameters.AddWithValue("@ap_pat", ap_pat);
            comando.Parameters.AddWithValue("@ap_mat", ap_mat);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@tipo_cliente", tipo_cliente);
            comando.Parameters.AddWithValue("@direccion", direccion);
            comando.Parameters.AddWithValue("@colonia", colonia);
            comando.Parameters.AddWithValue("@cp", cp);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@email", email);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
        //METODO QUE ELIMINA UN REGUSTRO EN LA TABLA CLIENTES
        public void Eliminar(string id_cliente)
        {
            //ELIMINAR CON PROCEDIMIENTO ALMACENADO
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_ELIMINARCLIENTE";
            //Tipo de comando
            comando.CommandType = CommandType.StoredProcedure;
            //Nombres de los parametros del SP
            comando.Parameters.AddWithValue("@id_cliente", id_cliente);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

    }
}
