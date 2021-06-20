using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
	public class AccesoDatos
	{
		private readonly string rutaDB = "Data Source=Localhost\\sqlexpress;Initial Catalog=Grupo6_TPIntegradorV6;Integrated Security=True";

		public SqlConnection ObtenerConexion()
		{
			try
			{
				SqlConnection Conn = new SqlConnection(rutaDB);
				Conn.Open();
				return Conn;
			}
			catch
			{
				return null;
			}
		}

		public SqlDataAdapter ObtenerAdaptador(string strSQL, SqlConnection conn)
		{
			try
			{
				SqlDataAdapter adap = new SqlDataAdapter(strSQL, conn);
				return adap;
			}
			catch
			{
				return null;
			}
		}

		public DataTable ObtenerTabla(string strTabla, string strSQL)
		{
			DataSet Ds = new DataSet();
			SqlConnection Conn = ObtenerConexion();
			SqlDataAdapter adap = ObtenerAdaptador(strSQL, Conn);
			adap.Fill(Ds, strTabla);
			Conn.Close();
			return Ds.Tables[strTabla];
		}

		public int EjecutarConsulta(string strSQL)
		{
			SqlConnection Conn = ObtenerConexion();
			SqlCommand Comm = new SqlCommand(strSQL, Conn);
			int filasAfectadas = Comm.ExecuteNonQuery();
			Conn.Close();
			return filasAfectadas;
		}

		public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
		{
			int FilasCambiadas;
			SqlConnection Conn = ObtenerConexion();
			SqlCommand cmd = new SqlCommand();
			cmd = Comando;
			cmd.Connection = Conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = NombreSP;
            try
            {
				FilasCambiadas = cmd.ExecuteNonQuery();
			}
			catch
            {
				FilasCambiadas = -1;
            }
			Conn.Close();
			return FilasCambiadas;
		}

		public int cantidadFilasAfectadas(string consultaSql)
		{
			SqlConnection Conexion = ObtenerConexion();
			SqlCommand comando = new SqlCommand(consultaSql, Conexion);
			int contarFilasAfectadas = (int)comando.ExecuteScalar();
			Conexion.Close();
			return contarFilasAfectadas;
		}
	}
}