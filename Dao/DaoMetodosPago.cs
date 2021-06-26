using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{    public class DaoMetodosPago
    {
        private readonly AccesoDatos accDatos = new AccesoDatos();

		public DataTable ObtenerMetodos()
		{
			string strTabla = "Medios_de_pago";
			string srtSQL = "SELECT mp_codigo, mp_nombre, mp_otros_detalles FROM Medios_de_pago ORDER BY  mp_nombre ASC";
			return accDatos.ObtenerTabla(strTabla, srtSQL);
		}
	}
}
