using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Dao
{
    public class DaoDetalleVentas
    {
        private readonly AccesoDatos accDatos = new AccesoDatos();
        public DataTable ObtenerDetalleVentas(string CodigoVenta)
        {
            string strTabla = "DetalleFactura";
            string srtSQL = "SELECT SUM(dt_precio_unitario * dt_cantidad_unidades) AS 'dt_total',art_nombre,dt_articulo_codigo,dt_cantidad_unidades,dt_precio_unitario FROM DetalleFactura INNER JOIN articulos on art_codigo = dt_articulo_codigo WHERE dt_venta_codigo =" + Int32.Parse(CodigoVenta) + "GROUP BY art_nombre,dt_articulo_codigo,dt_cantidad_unidades,dt_precio_unitario";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }
    }
}