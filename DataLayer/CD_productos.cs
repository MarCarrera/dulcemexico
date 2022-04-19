using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexionSQL
{
    public class CD_productos
    {
        //INSTANCIA DE CONEXION A LA BASE DE DATOS
        private Conexion conexion = new Conexion();

        //LECTURA DE DATOS SQL
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        
        //METODO QUE CONSULTA LA TABLA PRODUCTOS Y LA MUESTRA EN UNA TABLA
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select id_prod, descripcion, origen, stock, precio_uni from productos";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerraConexion();
            comando.Parameters.Clear();
            return tabla;
        }
        //METODO QUE INSERTA UN REGISTRO EN LA TABLA PRODUCTOS
        public void Insertar(string id_prod, string descripcion, string origen, int stock, double precio)
        {
            //INSERTAR CON T-SQL

            /*comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insert into productos values('"+id_prod+"','"+descripcion+"','"+origen+"','"+stock+"','"+precio+"')";
            comando.CommandType = CommandType.Text; 
            comando.ExecuteNonQuery();*/

            //INSERTAR CON PROCEDIMIENTO ALMACENADO
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_INSERTARPRODUCTO";
            //Tipo de comando
            comando.CommandType = CommandType.StoredProcedure;
            //Nombres de los parametros del SP
            comando.Parameters.AddWithValue("@id_prod", id_prod);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@origen", origen);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@precio_uni", precio);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();



        }
        //METODO QUE EDITA UN REGISTRO EN LA TABLA PRODUCTOS
        public void Editar(string id_prod, string descripcion, string origen, int stock, double precio)
        {
            //EDITAR CON PROCEDIMIENTO ALMACENADO
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_EDITARPRODUCTO";
            //Tipo de comando
            comando.CommandType = CommandType.StoredProcedure;
            //Nombres de los parametros del SP
            comando.Parameters.AddWithValue("@id_prod", id_prod);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@origen", origen);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@precio_uni", precio);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
        //METODO QUE ELIMINA UN REGUSTRO EN LA TABLA PRODUCTOS
        public void Eliminar(string id_prod)
        {
            //ELIMINAR CON PROCEDIMIENTO ALMACENADO
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_ELIMINARPRODUCTO";
            //Tipo de comando
            comando.CommandType = CommandType.StoredProcedure;
            //Nombres de los parametros del SP
            comando.Parameters.AddWithValue("@id_prod", id_prod);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
    }
}
