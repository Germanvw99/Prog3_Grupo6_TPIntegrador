using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;

namespace Vistas
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {

        private  NegocioDetalleVentas Neg = new NegocioDetalleVentas();
        protected void Page_Load(object sender, EventArgs e)
        {
            cargargridview();
        }


        public void cargargridview()
        {
            DataTable dt = new DataTable();
            dt = Neg.obtenertabladetalledecompra();

            
            DataTable t =Neg.ObtenerDetalleVentas((String)Session["factura"]);
            foreach(DataRow fila in t.Rows)
            {
                DataRow row = dt.NewRow();
                row["Factura"] = (string)Session["factura"];
                row["Producto"] = fila["art_nombre"].ToString();
                row["Importe"] = fila["dt_precio_unitario"].ToString();
                row["Cantidad"] = fila["dt_cantidad_unidades"].ToString();
                row["Total"] = fila["dt_total"].ToString();
                dt.Rows.Add(row);



            }
            GridView1.DataSource = dt;
            GridView1.DataBind();



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComprasUsuario.aspx");
        }
    }
}