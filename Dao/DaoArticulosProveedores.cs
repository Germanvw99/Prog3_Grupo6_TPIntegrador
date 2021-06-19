using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using System.Data.SqlClient;
namespace Dao
{
	public class DaoArticulosProveedores
	{
		private readonly AccesoDatos accDatos = new AccesoDatos();
		public DataTable ObtenerArticulosProveedores()
		{
			string strTabla = "ArticulosProveedores";
			string srtSQL = "SELECT axp_codigo,axp_proveedor_dni,pro_razon_social, axp_articulo_codigo, art_nombre, mar_codigo, mar_nombre, axp_stock_actual,axp_stock_anterior,axp_entrada,axp_salida,axp_precio_unitario FROM Articulos_por_Proveedor INNER JOIN Articulos ON art_codigo = axp_articulo_codigo INNER JOIN Proveedores ON pro_dni = axp_proveedor_dni INNER JOIN Marcas ON art_marca_codigo = mar_codigo";
			return accDatos.ObtenerTabla(strTabla, srtSQL);
		}
		public DataTable filtrarConsultaControlStock(ref string ClausulaSQLConsulta)
		{
			string strTabla = "ArticulosProveedores";
			string srtSQL = "SELECT axp_codigo,axp_proveedor_dni,pro_razon_social, axp_articulo_codigo, art_nombre, mar_codigo, mar_nombre, axp_stock_actual,axp_stock_anterior,axp_entrada,axp_salida,axp_precio_unitario FROM Articulos_por_Proveedor INNER JOIN Articulos ON art_codigo = axp_articulo_codigo INNER JOIN Proveedores ON pro_dni = axp_proveedor_dni INNER JOIN Marcas ON art_marca_codigo = mar_codigo " + ClausulaSQLConsulta + " ORDER BY pro_razon_social ASC";
			return accDatos.ObtenerTabla(strTabla, srtSQL);
		}

		#region AGREGAR STOCK
		public int agregarStock(ArticulosProveedores articuloProveedor)
		{
			SqlCommand comando = new SqlCommand();
			armarParametrosAgregarArticulo(ref comando, articuloProveedor);
			return accDatos.EjecutarProcedimientoAlmacenado(comando, "spActualizarStock");
		}
		private void armarParametrosAgregarArticulo(ref SqlCommand Comando, ArticulosProveedores articuloProveedor)
		{
			SqlParameter SqlParametros = new SqlParameter();
			SqlParametros = Comando.Parameters.Add("@axp_proveedor_dni", SqlDbType.Char, 8);
			SqlParametros.Value = articuloProveedor.GetProveedor().GetDni();
			SqlParametros = Comando.Parameters.Add("@axp_articulo_codigo", SqlDbType.Int);
			SqlParametros.Value = articuloProveedor.GetArticulo().GetCodigo();
			SqlParametros = Comando.Parameters.Add("@axp_entrada", SqlDbType.Int);
			SqlParametros.Value = articuloProveedor.GetEntrada();
			SqlParametros = Comando.Parameters.Add("@axp_salida", SqlDbType.Decimal);
			SqlParametros.Value = articuloProveedor.GetSalida();
			SqlParametros = Comando.Parameters.Add("@axp_precio_unitario", SqlDbType.Decimal);
			SqlParametros.Value = articuloProveedor.GetPreciounitario();
		}
		#endregion
	}
}