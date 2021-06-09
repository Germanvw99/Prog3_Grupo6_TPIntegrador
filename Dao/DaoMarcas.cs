using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dao
{
    public class DaoMarcas
    {
        private readonly AccesoDatos accDatos = new AccesoDatos();
        public DataTable ObtenerMarcas() {
            string strTabla = "Marcas";
            string srtSQL = "SELECT mar_codigo,mar_nombre,mar_descripcion,mar_ruta_imagen,est_nombre FROM Marcas INNER JOIN Estados ON Marcas.mar_codigo_estado=Estados.est_codigo";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }
    }
}
