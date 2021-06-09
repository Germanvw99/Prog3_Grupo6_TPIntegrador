using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Dao
{
    public class DaoCategorias
    {
        private readonly AccesoDatos accDatos = new AccesoDatos();
        public DataTable ObtenerCategorias()
        {
            string strTabla = "Categorias";
            string srtSQL = "SELECT cat_codigo, cat_nombre, cat_descripcion, cat_ruta_imagen, est_nombre FROM Categorias INNER JOIN Estados ON Categorias.cat_codigo_estado=Estados.est_codigo";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }
    }
}


