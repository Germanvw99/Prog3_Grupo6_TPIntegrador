using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("Vistausuario.aspx");
            if (Session["User"] != null)
            {
                DataTable dt = (DataTable)Session["User"];

                Usuarios objUsuario = NegocioUsuarios.getInstance().LeerTablaUsuario(dt);
                if (objUsuario != null)
                {
                    // USUARIO LOGUEADO

                    // HEADER GENERAL


                    // SIDEBAR GENERAL

                    funcionesAdmin.Visible = false;
                    ;



                    // En caso de que haya un usuario Logueado, identificar si es Administrador o Usuario
                    if (objUsuario.Codigo_Perfil == 1)
                    {
                        // Admin
                        // SIDEBAR

                        funcionesAdmin.Visible = true;
                    }
                    else
                    {
                        // Usuario

                        funcionesAdmin.Visible = false;


                    }
                }
            }
            else
            {
                // USUARIO DESLOGUEADO

                //HEADER GENERAL


                //SIDEBAR GENERAL

                funcionesAdmin.Visible = false;
            }

        }



    // Botones redireccion
    protected void IrListarUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuariosListado.aspx");
        }
        protected void IrListarArticulos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArticulosListado.aspx");
        }
        protected void IrListarMarcas_Click(object sender, EventArgs e)
        {
            Response.Redirect("MarcasListado.aspx");
        }
        protected void IrListarCategorias_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriasListado.aspx");
        }
        protected void IrListarProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProveedoresListado.aspx");
        }
        protected void IrListarVentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("VentasListado.aspx");
        }
        protected void IrListarStock_Click(object sender, EventArgs e)
        {
            Response.Redirect("ControlStockListado.aspx");
        }
    }
}