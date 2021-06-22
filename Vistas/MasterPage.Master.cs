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
    public partial class MasterPage : System.Web.UI.MasterPage


    {
        NegocioArticulos n = new NegocioArticulos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Session["tablacarrito"] = null;

            }
            // Modifica la parte visual dependiendo del tipo de usuario
            if (Session["User"] != null)
            {
                DataTable dt = (DataTable)Session["User"];

                Usuarios objUsuario = NegocioUsuarios.getInstance().LeerTablaUsuario(dt);
                if(objUsuario != null)
                {
                    // USUARIO LOGUEADO

                    // HEADER GENERAL
                    userPanelLoggedIn.Visible = true;

                    userPanelLoggedOff.Visible = false;

                    // SIDEBAR GENERAL
                    heroUser.Visible = true;
                    funcionesAdmin.Visible = false;
                    userPanelMarcas.Visible = false;



                    // En caso de que haya un usuario Logueado, identificar si es Administrador o Usuario
                    if (objUsuario.Codigo_Perfil == 1)
                    {
                        // Admin
                        // SIDEBAR
                        userPanelMarcas.Visible = false;
                        lblTipoUsuario.Text = objUsuario.Username+" (Administrador)";
                        funcionesAdmin.Visible = true;
                    }
                    else
                    {
                        // Usuario
                        lblTipoUsuario.Text = objUsuario.Username + " (Usuario)";
                        userPanelMarcas.Visible = true;
                        

                    }
                }
            }else
            {
                // USUARIO DESLOGUEADO

                //HEADER GENERAL
                userPanelLoggedIn.Visible = false;
                userPanelLoggedOff.Visible = true;
                userPanelMarcas.Visible = true;

                //SIDEBAR GENERAL
                heroUser.Visible = false;
                funcionesAdmin.Visible = false;
            }
               
        }




        protected void Img_user_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }



        // REDIRECCIONES AGREGAR
        protected void LbAgregarArticulos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArticulosAgregar.aspx");
        }

        protected void LbAgregarProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProveedoresAgregar.aspx");
        }

        protected void LbAgregarCategorias_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriasAgregar.aspx");
        }

        protected void LbAgregarMarcas_Click(object sender, EventArgs e)
        {
            Response.Redirect("MarcasAgregar.aspx");
        }

        protected void LbAgregarControlStock_Click(object sender, EventArgs e)
        {
            Response.Redirect("ControlStockAgregar.aspx");
        }



        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }

        protected void btnLogOff_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("Home.aspx");
        }

        protected void ImageButton2_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "marcas")
            {
                    
                Session["tablapormarca"] = e.CommandArgument.ToString();
                Response.Redirect("Vistausuario.aspx");
                
            }
        }

        protected void btbuscar_Click(object sender, EventArgs e)
        {
            Session["Busquedad"] = tbbuscardor.Text;
        }
    }
}

