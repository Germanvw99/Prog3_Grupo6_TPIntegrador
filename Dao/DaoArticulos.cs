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
	public class DaoArticulos
	{
		private readonly AccesoDatos accDatos = new AccesoDatos();
		public DataTable ObtenerArticulos()
		{
			string strTabla = "Articulos";
			string srtSQL = "SELECT art_codigo, art_nombre, art_descripcion, art_punto_pedido, art_precio_lista, art_ruta_imagen, est_nombre, est_codigo, mar_nombre, mar_codigo, cat_nombre, cat_codigo FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo ORDER BY art_nombre ASC";
			return accDatos.ObtenerTabla(strTabla, srtSQL);
		}

		#region AGREGAR ARTICULO
		//AGREGAR ARTICULO
		public int agregarArticulo(Articulos articulo)
		{
			SqlCommand comando = new SqlCommand();
			armarParametrosAgregarArticulo(ref comando, articulo);
			return accDatos.EjecutarProcedimientoAlmacenado(comando, "spAgregarArticulo");
		}
		private void armarParametrosAgregarArticulo(ref SqlCommand Comando, Articulos articulo)
		{
			SqlParameter SqlParametros = new SqlParameter();
			SqlParametros = Comando.Parameters.Add("@art_marca_codigo", SqlDbType.Int);
			SqlParametros.Value = articulo.GetMarca().GetCodigo();
			SqlParametros = Comando.Parameters.Add("@art_categoria_codigo ", SqlDbType.Int);
			SqlParametros.Value = articulo.GetCategoria().GetCodigo();
			SqlParametros = Comando.Parameters.Add("@art_nombre", SqlDbType.VarChar, 255);
			SqlParametros.Value = articulo.GetNombre();
			SqlParametros = Comando.Parameters.Add("@art_descripcion", SqlDbType.VarChar, 255);
			SqlParametros.Value = articulo.GetDescripcion();
			SqlParametros = Comando.Parameters.Add("@art_punto_pedido", SqlDbType.Int);
			SqlParametros.Value = articulo.GetPuntoPedido();
			SqlParametros = Comando.Parameters.Add("@art_precio_lista", SqlDbType.Decimal);
			SqlParametros.Value = articulo.GetPuntoPedido();
			SqlParametros = Comando.Parameters.Add("@art_ruta_imagen", SqlDbType.VarChar, 255);
			SqlParametros.Value = articulo.GetRutaImagen();
			SqlParametros = Comando.Parameters.Add("@art_codigo_estado", SqlDbType.Int);
			SqlParametros.Value = articulo.GetEstado().GetCodigo();
		}
		//BUSCAR ARTICULO POR NOMBRE
		public int buscarArticuloPorNombreMarca(Articulos articulo)
		{
			string consultaSql = "SELECT COUNT(art_codigo) FROM Articulos WHERE art_nombre LIKE '" + articulo.GetNombre() + "' AND art_marca_codigo LIKE '" + articulo.GetMarca().GetCodigo() + "'";
			int cantidad = accDatos.cantidadFilasAfectadas(consultaSql);
			return cantidad;
		}
		#endregion

		#region MODIFICAR ARTICULO
		//BUSCAR ARTICULO POR NOMBRE, MARCA Y CODIGO ARTICULO NO COINCIDENTE
		public int buscarArticuloPorNombreMarcaCodigoNoCoincidente(Articulos articulo)
		{
			string consultaSql = "SELECT COUNT(art_codigo) FROM Articulos WHERE art_nombre LIKE '" + articulo.GetNombre() + "' AND art_marca_codigo LIKE '" + articulo.GetMarca().GetCodigo() + "' AND art_codigo != " + articulo.GetCodigo();
			int cantidad = accDatos.cantidadFilasAfectadas(consultaSql);
			return cantidad;
		}

		public int modificarArticulo(Articulos articulo)
		{
			SqlCommand comando = new SqlCommand();
			armarParametrosModificarArticulos(ref comando, articulo);
			return accDatos.EjecutarProcedimientoAlmacenado(comando, "spModificarArticulo");
		}
		private void armarParametrosModificarArticulos(ref SqlCommand Comando, Articulos articulo)
		{
			SqlParameter SqlParametros = new SqlParameter();
			SqlParametros = Comando.Parameters.Add("@art_codigo", SqlDbType.Int);
			SqlParametros.Value = articulo.GetCodigo();
			SqlParametros = Comando.Parameters.Add("@art_marca_codigo", SqlDbType.Int);
			SqlParametros.Value = articulo.GetMarca().GetCodigo();
			SqlParametros = Comando.Parameters.Add("@art_categoria_codigo ", SqlDbType.Int);
			SqlParametros.Value = articulo.GetCategoria().GetCodigo();
			SqlParametros = Comando.Parameters.Add("@art_nombre", SqlDbType.VarChar, 255);
			SqlParametros.Value = articulo.GetNombre();
			SqlParametros = Comando.Parameters.Add("@art_descripcion", SqlDbType.VarChar, 255);
			SqlParametros.Value = articulo.GetDescripcion();
			SqlParametros = Comando.Parameters.Add("@art_punto_pedido", SqlDbType.Int);
			SqlParametros.Value = articulo.GetPuntoPedido();
			SqlParametros = Comando.Parameters.Add("@art_precio_lista", SqlDbType.Decimal);
			SqlParametros.Value = articulo.GetPuntoPedido();
			SqlParametros = Comando.Parameters.Add("@art_ruta_imagen", SqlDbType.VarChar, 255);
			SqlParametros.Value = articulo.GetRutaImagen();
			SqlParametros = Comando.Parameters.Add("@art_codigo_estado", SqlDbType.Int);
			SqlParametros.Value = articulo.GetEstado().GetCodigo();
		}
		#endregion

		#region ELIMINAR ARTICULO
		public int eliminarArticulo(Articulos articulo)
		{
			SqlCommand comando = new SqlCommand();
			armarParametroEliminarArticulo(ref comando, articulo);
			return accDatos.EjecutarProcedimientoAlmacenado(comando, "spEliminarArticulo");
		}
		private void armarParametroEliminarArticulo(ref SqlCommand Comando, Articulos articulo)
		{
			SqlParameter SqlParametros = new SqlParameter();
			SqlParametros = Comando.Parameters.Add("@art_codigo", SqlDbType.Char);
			SqlParametros.Value = articulo.GetCodigo();
		}
		#endregion

		public DataTable ObtenerArticulospormarca(string marca)
		{
			int marcaa = Convert.ToInt32(marca);
			string strTabla = "ArticulosMarca";
			string srtSQL = "SELECT art_codigo,art_nombre,art_descripcion,art_punto_pedido,art_precio_lista,art_ruta_imagen,est_nombre, mar_nombre, cat_nombre FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo  where art_marca_codigo = " + marcaa;

			return accDatos.ObtenerTabla(strTabla, srtSQL);
		}

		public DataTable ObtenerArticulosActivos()
		{
			string strTabla = "articulosAct";
			string srtSQL = "SELECT art_codigo,art_nombre,art_descripcion,art_punto_pedido,art_precio_lista,art_ruta_imagen,est_nombre, mar_nombre, cat_nombre FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo where est_nombre='Activo'";
			return accDatos.ObtenerTabla(strTabla, srtSQL);
		}

		public DataTable ObtenerArticulosBus(string busquedad)
		{
			string strTabla = "ArticuloBus";
			string srtSQL = "SELECT art_codigo,art_nombre,art_descripcion,art_punto_pedido,art_precio_lista,art_ruta_imagen,est_nombre, mar_nombre, cat_nombre FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo where est_nombre='Activo' and art_nombre like '%" + busquedad + "%' ";
			return accDatos.ObtenerTabla(strTabla, srtSQL);
		}

		public DataTable filtrarConsultaArticulos(ref string ClausulaSQLConsultaArticulos)
		{
			string strTabla = "Articulos";
			string srtSQL = "SELECT art_codigo, art_nombre, art_descripcion, art_punto_pedido, art_precio_lista, art_ruta_imagen, est_nombre, est_codigo, mar_nombre, mar_codigo, cat_nombre, cat_codigo FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo " + ClausulaSQLConsultaArticulos + " ORDER BY art_nombre ASC";
			return accDatos.ObtenerTabla(strTabla, srtSQL);
		}
	}
}