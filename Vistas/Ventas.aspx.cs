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
    public partial class Formulario_web12 : System.Web.UI.Page


    {
        private NegocioVentas ng = new NegocioVentas();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            cargartabla();
        }

        public void cargartabla()
        {
            string[] columnas = null;
            DataTable dt = new DataTable();
            dt = ng.obtenertabladeventas2();
            



            GridView1.DataSource = dt;
            GridView1.DataBind();
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "eventodetalle")
            {

                int fila = Convert.ToInt32(e.CommandArgument);
                string factura;

                factura =( (Label)GridView1.Rows[fila].FindControl("lblfactura")).Text;
                

                




            }
        }
    }
}