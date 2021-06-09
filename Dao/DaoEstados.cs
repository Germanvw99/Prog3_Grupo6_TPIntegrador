using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Dao
{
    public class DaoEstados
    {
        private readonly AccesoDatos accDatos = new AccesoDatos();
        public DataTable ObtenerEstados() {
            string strTabla = "Estados";
            string srtSQL = "SELECT est_codigo, est_nombre FROM Estados";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }
    }
}
