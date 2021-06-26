using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoDetalleVentas
    {
        private readonly AccesoDatos accDatos = new AccesoDatos();
        SqlConnection conn = null;
        public DataTable ObtenerDetalleVentas(string CodigoVenta)
        {
            string strTabla = "DetalleFactura";
            string srtSQL = "SELECT SUM(dt_precio_unitario * dt_cantidad_unidades) AS 'dt_total',art_nombre,dt_articulo_codigo,dt_cantidad_unidades,dt_precio_unitario FROM DetalleFactura INNER JOIN articulos on art_codigo = dt_articulo_codigo WHERE dt_venta_codigo =" + Int32.Parse(CodigoVenta) + "GROUP BY art_nombre,dt_articulo_codigo,dt_cantidad_unidades,dt_precio_unitario";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }

        public int GenerarDetallesVentas(int venta_cod,int dt_articulo_codigo, int dt_cantidad_unidades, decimal prm_dt_precio_unitario)
        {
            int filasEditadas = 0;
            try
            {
                conn = accDatos.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spAgregarDetalleVenta", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prm_dt_venta_codigo", venta_cod);
                cmd.Parameters.AddWithValue("@prm_dt_articulo_codigo", dt_articulo_codigo);
                cmd.Parameters.AddWithValue("@prm_dt_cantidad_unidades", dt_cantidad_unidades);
                cmd.Parameters.AddWithValue("@prm_dt_precio_unitario", prm_dt_precio_unitario);

                // Obtengo el index de la venta agregada
                filasEditadas = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {

                throw exc;
            }
            finally
            {
                conn.Close();
            }
            return filasEditadas;
        }
    }
}