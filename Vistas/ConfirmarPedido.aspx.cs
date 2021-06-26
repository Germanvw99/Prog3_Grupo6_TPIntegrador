using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Negocio;
using Entidades;
using System.Data;


namespace Vistas
{
    public partial class ConfirmarPedido : System.Web.UI.Page
    {
        private readonly NegocioMetodoPago negocioMetodoPago = new NegocioMetodoPago();

        Usuarios objUsuario = new Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar sesion
            /*if (Session["User"] != null)

            {
                Response.Redirect("home.aspx");
            }*/
            // Cargo datos
            if (!Page.IsPostBack)
            {
            DataTable dt = (DataTable)Session["User"];
            objUsuario = NegocioUsuarios.getInstance().LeerTablaUsuario(dt);
                rellenarDatos();
            }

        }

        private void rellenarDatos()
        {
            txtDni.Enabled = false;
            txtDni.Text = objUsuario.Dni;
            CargarMetodosPago();
        }

        private void CargarMetodosPago()
        {
            DdlPago.Items.Add(new ListItem("- Elegir -", "0"));
            DdlPago.Items[0].Selected = true;
            DdlPago.Items[0].Attributes["disabled"] = "disabled";
            DataTable dt = negocioMetodoPago.ObtenerMetodos();
            foreach (DataRow dr in dt.Rows)
            {
                DdlPago.Items.Add(new ListItem(dr["mp_nombre"].ToString(), dr["mp_codigo"].ToString()));
            }
        }
    }
}