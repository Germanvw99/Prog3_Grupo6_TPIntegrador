using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;
using System.Web.SessionState;
namespace Negocio
{
    public class NegocioVentas : System.Web.UI.Page
    {
        private readonly DaoVentas daoVentas = new DaoVentas();
        public DataTable ObtenerVentas()
        {
            return daoVentas.ObtenerVentas();
        }
    }
}