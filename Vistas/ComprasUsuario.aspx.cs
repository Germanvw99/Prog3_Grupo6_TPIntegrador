using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class Formulario_web12 : System.Web.UI.Page


    {
        private NegocioVentas ng = new NegocioVentas();
        string dni;
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            DataTable dt = (DataTable)Session["User"];

            Usuarios objUsuario = NegocioUsuarios.getInstance().LeerTablaUsuario(dt);
            dni = objUsuario.Dni.ToString();
            cargartabla();
            
        }

        public void cargartabla()
        {
            string[] columnas = null;
            DataTable dt = new DataTable();
            dt = ng.obtenertabladeventas2(dni);

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
                Session["factura"] = factura;
                Response.Redirect("CompraUsuarioDetalle.aspx");
                

                




            }
        }
    }
}