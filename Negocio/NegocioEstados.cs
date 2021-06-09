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
    public class NegocioEstados
    {
        private readonly DaoEstados daoEstados = new DaoEstados();
        public DataTable ObtenerEstados()
        {
            return daoEstados.ObtenerEstados();
        }
    }
}