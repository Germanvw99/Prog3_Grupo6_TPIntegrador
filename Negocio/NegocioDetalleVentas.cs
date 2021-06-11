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
    public class NegocioDetalleVentas : System.Web.UI.Page
    {
        private readonly DaoDetalleVentas daoDetalleVentas = new DaoDetalleVentas();
        public DataTable ObtenerDetalleVentas(string CodigoVenta)
        {
            return daoDetalleVentas.ObtenerDetalleVentas(CodigoVenta);
        }

        //USO SESION PARA VER DETALLEVENTAS
        //SI NO EXISTE, CREA LA SESION
        public void CrearSesionDetalleVenta(string ven_codigo)
        {
            Session["detalleVenta"] = ven_codigo;
        }

        public string ObtenerSesionDetalleVenta()
        {
            if (Session["detalleVenta"] != null)
            {
                return (String)Session["detalleVenta"];
            }
            return null;
        }
    }
}