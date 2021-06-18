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
	public class DaoMarcas
	{
		private readonly AccesoDatos accDatos = new AccesoDatos();
		public DataTable ObtenerMarcas()
		{
			string strTabla = "Marcas";
			string srtSQL = "SELECT mar_codigo,mar_nombre,mar_descripcion,mar_ruta_imagen,est_nombre,est_codigo FROM Marcas INNER JOIN Estados ON Marcas.mar_codigo_estado=Estados.est_codigo ORDER BY mar_nombre ASC";
			return accDatos.ObtenerTabla(strTabla, srtSQL);
		}
		public int agregarMarca(Marcas marca)
		{
			SqlCommand comando = new SqlCommand();
			armarParametrosAgregarMarca(ref comando, marca);
			return accDatos.EjecutarProcedimientoAlmacenado(comando, "spAgregarMarca");
		}
		private void armarParametrosAgregarMarca(ref SqlCommand Comando, Marcas marca)
		{
			SqlParameter SqlParametros = new SqlParameter();
			SqlParametros = Comando.Parameters.Add("@mar_nombre", SqlDbType.VarChar, 255);
			SqlParametros.Value = marca.GetNombre();

			SqlParametros = Comando.Parameters.Add("@mar_descripcion", SqlDbType.VarChar, 255);
			SqlParametros.Value = marca.GetDescripcion();

			SqlParametros = Comando.Parameters.Add("@mar_ruta_imagen", SqlDbType.VarChar, 255);
			SqlParametros.Value = marca.GetRutaImagen();

			SqlParametros = Comando.Parameters.Add("@mar_codigo_estado", SqlDbType.Int);
			SqlParametros.Value = marca.GetEstado().GetCodigo();
		}

		//BUSCAR MARCA POR NOMBRE
		public int buscarMarcaPorNombre(Marcas marca)
		{
			string consultaSql = "SELECT COUNT(mar_codigo) FROM Marcas WHERE mar_nombre LIKE '" + marca.GetNombre() + "'";
			int cantidad = accDatos.cantidadFilasAfectadas(consultaSql);
			return cantidad;
		}

		//BUSCAR MARCA POR NOMBRE Y CODIGO NO COINCIDENTE
		public int buscarMarcaPorNombreCodigoNoCoincidente(Marcas marca)
		{
			string consultaSql = "SELECT COUNT(mar_codigo) FROM Marcas WHERE mar_nombre LIKE '" + marca.GetNombre() + "' AND mar_codigo != '" + marca.GetCodigo() + "'";
			int cantidad = accDatos.cantidadFilasAfectadas(consultaSql);
			return cantidad;
		}

		public int modificarMarca(Marcas marca)
		{
			SqlCommand comando = new SqlCommand();
			armarParametrosModificarMarca(ref comando, marca);
			return accDatos.EjecutarProcedimientoAlmacenado(comando, "spModificarMarca");
		}

		private void armarParametrosModificarMarca(ref SqlCommand Comando, Marcas marca)
		{
			SqlParameter SqlParametros = new SqlParameter();
			SqlParametros = Comando.Parameters.Add("@mar_codigo", SqlDbType.Int);
			SqlParametros.Value = marca.GetCodigo();

			SqlParametros = Comando.Parameters.Add("@mar_nombre", SqlDbType.VarChar, 255);
			SqlParametros.Value = marca.GetNombre();

			SqlParametros = Comando.Parameters.Add("@mar_descripcion", SqlDbType.VarChar, 255);
			SqlParametros.Value = marca.GetDescripcion();

			SqlParametros = Comando.Parameters.Add("@mar_ruta_imagen", SqlDbType.VarChar, 255);
			SqlParametros.Value = marca.GetRutaImagen();

			SqlParametros = Comando.Parameters.Add("@mar_codigo_estado", SqlDbType.Int);
			SqlParametros.Value = marca.GetEstado().GetCodigo();
		}

		public int eliminarMarca(Marcas marca)
		{
			SqlCommand comando = new SqlCommand();
			armarParametroEliminarMarca(ref comando, marca);
			return accDatos.EjecutarProcedimientoAlmacenado(comando, "spEliminarMarca");
		}

		private void armarParametroEliminarMarca(ref SqlCommand Comando, Marcas marca)
		{
			SqlParameter SqlParametros = new SqlParameter();
			SqlParametros = Comando.Parameters.Add("@mar_codigo", SqlDbType.Int);
			SqlParametros.Value = marca.GetCodigo();
		}
		public DataTable filtrarConsultaMarca(ref string ClausulaSQLConsultaMarcas)
		{
			string strTabla = "Marca";
			string srtSQL = "SELECT mar_codigo,mar_nombre,mar_descripcion,mar_ruta_imagen,est_nombre,est_codigo FROM Marcas INNER JOIN Estados ON Marcas.mar_codigo_estado=Estados.est_codigo " + ClausulaSQLConsultaMarcas + " ORDER BY mar_nombre ASC";
			return accDatos.ObtenerTabla(strTabla, srtSQL);
		}
	}
}