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
    public class DaoVentas
    {
        private readonly AccesoDatos accDatos = new AccesoDatos();
        SqlConnection conn = null;
        public DataTable ObtenerVentas( )
        {
            string strTabla = "Ventas";
            string srtSQL = "SELECT ven_codigo,ven_usuarios_dni, usu_apellido, usu_nombre,usu_direccion, usu_ciudad, ven_medio_pago_codigo, mp_nombre, ven_fecha,ven_fecha_requerida,ven_fecha_envio,ven_total_facturado,ven_codigo_estado, est_nombre FROM Ventas INNER JOIN Usuarios ON ven_usuarios_dni=usu_dni INNER JOIN Medios_de_pago ON ven_medio_pago_codigo = mp_codigo INNER JOIN Estados ON ven_codigo_estado=est_codigo ";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }

        public DataTable ObtenerVentas2(string dni)
        {
            string strTabla = "Ventas";
            string srtSQL = "SELECT ven_codigo,ven_usuarios_dni, usu_apellido, usu_nombre,usu_direccion, usu_ciudad, ven_medio_pago_codigo, mp_nombre, ven_fecha,ven_fecha_requerida,ven_fecha_envio,ven_total_facturado,ven_codigo_estado, est_nombre FROM Ventas INNER JOIN Usuarios ON ven_usuarios_dni=usu_dni INNER JOIN Medios_de_pago ON ven_medio_pago_codigo = mp_codigo INNER JOIN Estados ON ven_codigo_estado=est_codigo where usu_dni="+ dni.ToString();
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }
        public DataTable filtrarConsultaVenta(ref string ClausulaSQLConsultaVenta)
        {
            string strTabla = "Venta";
            string srtSQL = "SELECT DISTINCT ven_codigo,ven_usuarios_dni, usu_apellido, usu_nombre,usu_direccion, usu_ciudad, ven_medio_pago_codigo, mp_nombre, ven_fecha, ven_fecha_requerida,ven_fecha_envio,ven_total_facturado,ven_codigo_estado, est_nombre FROM Ventas INNER JOIN Usuarios ON ven_usuarios_dni = usu_dni INNER JOIN Medios_de_pago ON ven_medio_pago_codigo = mp_codigo INNER JOIN Estados ON ven_codigo_estado = est_codigo INNER JOIN DetalleFactura ON dt_venta_codigo = ven_codigo INNER JOIN Articulos ON art_codigo = dt_articulo_codigo INNER JOIN Categorias ON art_categoria_codigo = cat_codigo INNER JOIN Marcas ON art_marca_codigo = mar_codigo " + ClausulaSQLConsultaVenta;
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }

        public int NuevaVenta(Ventas objVentas)
        {
            int index = 0;
            try
            {
                conn = accDatos.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spAgregarVenta", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prm_ven_usuarios_dni", objVentas.GetUsuario().Dni.ToString());
                cmd.Parameters.AddWithValue("@prm_ven_medio_pago_codigo", Convert.ToInt32(objVentas.GetMedioPago().GetCodigo()));
                cmd.Parameters.AddWithValue("@prm_ven_total_facturado", Convert.ToDecimal(objVentas.GetTotalFacturado()));

                // Obtengo el index de la venta agregada
                index = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception exc)
            {

                throw exc;
            }
            finally
            {
                conn.Close();
            }
            return index;
        }


        #region REPORTES
        public DataTable ObtenerVentas(DateTime desdeFecha, DateTime hastaFecha)
        {
            string strTabla = "Ventas";
            string srtSQL = "SELECT ven_codigo,ven_usuarios_dni, usu_apellido, usu_nombre,usu_direccion, usu_ciudad, ven_medio_pago_codigo, mp_nombre, ven_fecha,ven_fecha_requerida,ven_fecha_envio,ven_total_facturado,ven_codigo_estado, est_nombre FROM Ventas INNER JOIN Usuarios ON ven_usuarios_dni=usu_dni INNER JOIN Medios_de_pago ON ven_medio_pago_codigo = mp_codigo INNER JOIN Estados ON ven_codigo_estado=est_codigo WHERE Ventas.ven_fecha BETWEEN '" + desdeFecha + "' AND '" + hastaFecha + "'";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }

        public DataTable ObtenerVentasIngresos(DateTime desdeFecha, DateTime hastaFecha)
        {
            string strTabla = "Ventas";
            string srtSQL = "SELECT SUM(ven_total_facturado) FROM Ventas WHERE Ventas.ven_fecha BETWEEN '" + desdeFecha + "' AND '" + hastaFecha + "'";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }

        public DataTable ObtenerVentasCantidad(DateTime desdeFecha, DateTime hastaFecha)
        {
            string strTabla = "Ventas";
            string srtSQL = "SELECT COUNT(ven_codigo) FROM Ventas WHERE Ventas.ven_fecha BETWEEN '" + desdeFecha + "' AND '" + hastaFecha + "'";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }
        #endregion
    }
}