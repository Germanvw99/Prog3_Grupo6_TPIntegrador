using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;

namespace Negocio
{
    public class NegocioMetodoPago : System.Web.UI.Page
    {
        private readonly DaoMetodosPago daoMetodosPago = new Dao.DaoMetodosPago();

        public DataTable ObtenerMetodos()
        {
            return daoMetodosPago.ObtenerMetodos();
        }
    }
}
