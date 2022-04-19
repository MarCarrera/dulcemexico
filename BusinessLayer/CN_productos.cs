using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace conexionSQL.BusinessLayer
{
    public class CN_productos
    {
        //INSTANCIA DE LA CLASE DE DATOS PRODUCTOS
        private CD_productos objCD = new CD_productos();

        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objCD.Mostrar();
            return tabla;
        }
        public void Insertar(string id_prod, string descripcion, string origen, string stock, string precio)
        {
            objCD.Insertar(id_prod,descripcion,origen,Convert.ToInt32(stock),Convert.ToDouble(precio));
        }
        public void Editar(string id_prod, string descripcion, string origen, string stock, string precio)
        {
            objCD.Editar(id_prod, descripcion, origen, Convert.ToInt32(stock), Convert.ToDouble(precio));
        }
        public void Eliminar(string id_prod)
        {
            objCD.Eliminar(id_prod);
        }
    }
}
