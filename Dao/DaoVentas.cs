using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Dao
{
    public class DaoVentas
    {
        private readonly AccesoDatos accDatos = new AccesoDatos();
        public DataTable ObtenerVentas()
        {
            string strTabla = "Ventas";
            string srtSQL = "SELECT ven_codigo,ven_usuarios_dni, usu_apellido, usu_nombre,usu_direccion, usu_ciudad, ven_medio_pago_codigo, mp_nombre, ven_fecha,ven_fecha_requerida,ven_fecha_envio,ven_total_facturado,ven_codigo_estado, est_nombre FROM Ventas INNER JOIN Usuarios ON ven_usuarios_dni=usu_dni INNER JOIN Medios_de_pago ON ven_medio_pago_codigo = mp_codigo INNER JOIN Estados ON ven_codigo_estado=est_codigo";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }

        public DataTable filtrarConsultaVenta(ref string ClausulaSQLConsultaVenta)
        {
            string strTabla = "Venta";
            string srtSQL = "SELECT DISTINCT ven_codigo,ven_usuarios_dni, usu_apellido, usu_nombre,usu_direccion, usu_ciudad, ven_medio_pago_codigo, mp_nombre, ven_fecha, ven_fecha_requerida,ven_fecha_envio,ven_total_facturado,ven_codigo_estado, est_nombre FROM Ventas INNER JOIN Usuarios ON ven_usuarios_dni = usu_dni INNER JOIN Medios_de_pago ON ven_medio_pago_codigo = mp_codigo INNER JOIN Estados ON ven_codigo_estado = est_codigo INNER JOIN DetalleFactura ON dt_venta_codigo = ven_codigo INNER JOIN Articulos ON art_codigo = dt_articulo_codigo INNER JOIN Categorias ON art_categoria_codigo = cat_codigo INNER JOIN Marcas ON art_marca_codigo = mar_codigo " + ClausulaSQLConsultaVenta;
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }
    }
}