using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dao
{
    public class DaoProveedores
    {
        private readonly AccesoDatos accDatos = new AccesoDatos();
        public DataTable ObtenerProveedores()
        {
            string strTabla = "Proveedores";
            string srtSQL = "SELECT pro_dni,pro_razon_social,pro_direccion,pro_email,pro_telefono,pro_nombre_contacto,pro_ruta_imagen, est_nombre FROM Proveedores INNER JOIN Estados ON Proveedores.pro_codigo_estado=Estados.est_codigo";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }
    }
}