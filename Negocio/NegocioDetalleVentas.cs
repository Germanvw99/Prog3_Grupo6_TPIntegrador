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

        public void GenerarDetallesVentas(int venta_cod)
        {
            DataTable dt = (DataTable)Session["carrito"];

            foreach (DataRow dr in dt.Rows)
            {
                // GENERA UN DETALLE DE VENTA.
                int dt_articulo_codigo = Convert.ToInt32(dr[0]);
                int dt_cantidad_unidades = Convert.ToInt32(dr[4]);
                decimal dt_precio_unitario = Convert.ToDecimal(dr[5]);
                daoDetalleVentas.GenerarDetallesVentas(venta_cod, dt_articulo_codigo, dt_cantidad_unidades, dt_precio_unitario);

                // LO ELIMINA DE STOCK

            }

            // ELIMINA EL SESSION DE CARRITO.
            Session.Remove("carrito");
        }

        public string ObtenerSesionDetalleVenta()
        {
            if (Session["detalleVenta"] != null)
            {
                return (String)Session["detalleVenta"];
            }
            return null;
        }

        public DataTable obtenertabladetalledecompra()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Factura", typeof(string));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Importe", typeof(string));
            dt.Columns.Add("Cantidad", typeof(string));
            dt.Columns.Add("Total", typeof(string));
            return dt;

        }
    }
}