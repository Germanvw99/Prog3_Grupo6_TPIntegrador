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
	public class DaoCategorias
	{
		private readonly AccesoDatos accDatos = new AccesoDatos();
		public DataTable ObtenerCategorias()
		{
			string strTabla = "Categorias";
			string srtSQL = "SELECT cat_codigo, cat_nombre, cat_descripcion, cat_ruta_imagen, est_nombre, est_codigo FROM Categorias INNER JOIN Estados ON Categorias.cat_codigo_estado=Estados.est_codigo ORDER BY cat_nombre ASC";
			return accDatos.ObtenerTabla(strTabla, srtSQL);
		}

		#region AGREGAR CATEGORIAS
		// AGREGAR CATEGORIAS
		public int agregarCategoria(Categorias categoria)
		{
			SqlCommand comando = new SqlCommand();
			armarParametrosAgregarCategoria(ref comando, categoria);
			return accDatos.EjecutarProcedimientoAlmacenado(comando, "spAgregarCategoria");
		}
		private void armarParametrosAgregarCategoria(ref SqlCommand Comando, Categorias categoria)
		{
			SqlParameter SqlParametros = new SqlParameter();
			SqlParametros = Comando.Parameters.Add("@cat_nombre", SqlDbType.VarChar, 255);
			SqlParametros.Value = categoria.GetNombre();

			SqlParametros = Comando.Parameters.Add("@cat_descripcion", SqlDbType.VarChar, 255);
			SqlParametros.Value = categoria.GetDescripcion();

			SqlParametros = Comando.Parameters.Add("@cat_ruta_imagen", SqlDbType.VarChar, 255);
			SqlParametros.Value = categoria.GetRutaImagen();

			SqlParametros = Comando.Parameters.Add("@cat_codigo_estado", SqlDbType.Int);
			SqlParametros.Value = categoria.GetEstado().GetCodigo();
		}

		//BUSCAR CATEGORIA POR NOMBRE
		public int buscarCategoriaPorNombre(Categorias categoria)
		{
			string consultaSql = "SELECT COUNT(cat_codigo) FROM Categorias WHERE cat_nombre LIKE '" + categoria.GetNombre() + "'";
			int cantidad = accDatos.cantidadFilasAfectadas(consultaSql);
			return cantidad;
		}
		#endregion

		#region MODIFICAR CATEGORIAS
		//BUSCAR CATEGORIA POR NOMBRE Y CODIGO NO COINCIDENTE
		public int buscarCategoriaPorNombreCodigoNoCoincidente(Categorias categoria)
		{
			string consultaSql = "SELECT COUNT(cat_codigo) FROM Categorias WHERE cat_nombre LIKE '" + categoria.GetNombre() + "' AND cat_codigo != '" + categoria.GetCodigo() + "'";
			int cantidad = accDatos.cantidadFilasAfectadas(consultaSql);
			return cantidad;
		}

		public int modificarCategoria(Categorias categoria)
		{
			SqlCommand comando = new SqlCommand();
			armarParametrosModificarCategoria(ref comando, categoria);
			return accDatos.EjecutarProcedimientoAlmacenado(comando, "spModificarCategoria");
		}

		private void armarParametrosModificarCategoria(ref SqlCommand Comando, Categorias categoria)
		{
			SqlParameter SqlParametros = new SqlParameter();
			SqlParametros = Comando.Parameters.Add("@cat_codigo", SqlDbType.Int);
			SqlParametros.Value = categoria.GetCodigo();

			SqlParametros = Comando.Parameters.Add("@cat_nombre", SqlDbType.VarChar, 255);
			SqlParametros.Value = categoria.GetNombre();

			SqlParametros = Comando.Parameters.Add("@cat_descripcion", SqlDbType.VarChar, 255);
			SqlParametros.Value = categoria.GetDescripcion();

			SqlParametros = Comando.Parameters.Add("@cat_ruta_imagen", SqlDbType.VarChar, 255);
			SqlParametros.Value = categoria.GetRutaImagen();

			SqlParametros = Comando.Parameters.Add("@cat_codigo_estado", SqlDbType.Int);
			SqlParametros.Value = categoria.GetEstado().GetCodigo();
		}



		#endregion

		#region ELIMINAR CATEGORIA
		public int eliminarCategoria(Categorias categoria)
		{
			SqlCommand comando = new SqlCommand();
			armarParametroEliminarCategoria(ref comando, categoria);
			return accDatos.EjecutarProcedimientoAlmacenado(comando, "spEliminarCategoria");
		}

		private void armarParametroEliminarCategoria(ref SqlCommand Comando, Categorias categoria)
		{
			SqlParameter SqlParametros = new SqlParameter();
			SqlParametros = Comando.Parameters.Add("@cat_codigo", SqlDbType.Int);
			SqlParametros.Value = categoria.GetCodigo();
		}

		#endregion

	}
}


