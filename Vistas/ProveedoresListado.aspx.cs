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
    public partial class ProveedoresListado : System.Web.UI.Page
    {
        private readonly NegocioProveedores negocioProveedor = new NegocioProveedores();
        private readonly Proveedores proveedor = new Proveedores();
        private readonly Estados estado = new Estados();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (NegocioUsuarios.getInstance().isAdmin() != true)
            {
                Response.Redirect("home.aspx");
            }
            if (!Page.IsPostBack)
            {
                CargarGridView();
            }
        }
        private void CargarGridView()
        {
            GrdProveedores.DataSource = negocioProveedor.ObtenerProveedores();
            GrdProveedores.DataBind();
        }
        protected void GrdProveedores_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
            {
                // OBLIGAR A GRIDVIEW A USAR <THEAD> EN LUGAR DE <TBODY>
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                // OBLIGA A GRIDVIEW A USAR <TFOOT> EN LUGAR DE <TBODY>
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void GrdProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eventoVer")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                TxtCuil.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_dni")).Text;
                TxtRazonSocial.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_razon_social")).Text;
                TxtDireccion.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_direccion")).Text;
                TxtMail.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_email")).Text;
                TxtTelefono.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_telefono")).Text;
                TxtNombreContacto.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_nombre_contacto")).Text;
                TxtEstado.Text = ((Label)GrdProveedores.Rows[fila].FindControl("est_nombre")).Text;

                //RECUPERO CAMPO OCULTO
                HiddenField rutaImagen = (HiddenField)GrdProveedores.Rows[fila].FindControl("urlImage");
                ImgLogo.ImageUrl = rutaImagen.Value;


                //MOSTRAR MODAL
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModal').modal('show');</script>", false);
            }
            if (e.CommandName == "eventoEditar") {
                int fila = Convert.ToInt32(e.CommandArgument);

                proveedor.SetDni(((Label)GrdProveedores.Rows[fila].FindControl("pro_dni")).Text);
                proveedor.SetRazonSocial(((Label)GrdProveedores.Rows[fila].FindControl("pro_dni")).Text);
                proveedor.SetDireccion(((Label)GrdProveedores.Rows[fila].FindControl("pro_direccion")).Text);
                proveedor.SetEmail(((Label)GrdProveedores.Rows[fila].FindControl("pro_email")).Text);
                proveedor.SetTelefono(((Label)GrdProveedores.Rows[fila].FindControl("pro_telefono")).Text);
                proveedor.SetNombreContacto(((Label)GrdProveedores.Rows[fila].FindControl("pro_nombre_contacto")).Text);
                
                //AQUI RECUPERO LA RUTA DE LA IMAGEN
                HiddenField rutaImagen = (HiddenField)GrdProveedores.Rows[fila].FindControl("urlImage");
                proveedor.SetRutaImagen(rutaImagen.Value);

                estado.SetNombre(((Label)GrdProveedores.Rows[fila].FindControl("est_nombre")).Text);
                proveedor.SetEstado(estado);

                negocioProveedor.CrearSesion();
                negocioProveedor.AgregarProveedorEnLaSesion(proveedor);

                Response.Redirect("ProveedoresModificar.aspx");

            }
            if (e.CommandName == "eventoEliminar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);

                TxtRazonSocialEliminar.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_razon_social")).Text;
                //MOSTRAR MODAL
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModalEliminar').modal('show');</script>", false);


            }
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
        protected void LnAgregarProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProveedoresAgregar.aspx");
        }
    }
}