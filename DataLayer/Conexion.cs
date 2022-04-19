using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace conexionSQL
{
    public class Conexion
    {
        //CADENA DE CONEXION A LA BASE DE DATOS SQL SERVER
        private SqlConnection conexion = new SqlConnection(
            @"Data Source=DESKTOP-UIOAJRJ\MSSQLSERVERDEV;Initial Catalog=dulcemexico;
            Integrated Security=True");

        //ABRIR CONEXION
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }
        //CERRAR CONEXION
        public SqlConnection CerraConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
            return conexion;
        }



    }
}
