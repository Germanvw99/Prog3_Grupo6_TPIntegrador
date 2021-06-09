using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class CategoriasListado : System.Web.UI.Page
    {
        private readonly NegocioCategorias negocioCategorias = new NegocioCategorias();
        private readonly Estados estado = new Estados();
        private readonly Categorias categorias = new Categorias();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarGridView();
            }
        }
        private void CargarGridView()
        {
            GrdCategorias.DataSource = negocioCategorias.ObtenerCategorias();
            GrdCategorias.DataBind();
        }
        protected void GrdCategorias_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0) ||
              (gv.ShowHeaderWhenEmpty == true))
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
        protected void GrdCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eventoVer")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                TxtCodigoModal.Text = ((Label)GrdCategorias.Rows[fila].FindControl("cat_codigo")).Text;
                TxtNombreModal.Text = ((Label)GrdCategorias.Rows[fila].FindControl("cat_nombre")).Text;
                TxtDescripcionModal.Text = ((Label)GrdCategorias.Rows[fila].FindControl("cat_descripcion")).Text;
                TxtEstadoModal.Text = ((Label)GrdCategorias.Rows[fila].FindControl("est_nombre")).Text;

                //RECUPERO CAMPO OCULTO
                HiddenField rutaImagen = (HiddenField)GrdCategorias.Rows[fila].FindControl("urlImage");
                ImgLogo.ImageUrl = rutaImagen.Value;


                //MOSTRAR MODAL
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModal').modal('show');</script>", false);
            }
            if (e.CommandName == "eventoEditar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                categorias.SetCodigo(Int32.Parse(((Label)GrdCategorias.Rows[fila].FindControl("cat_codigo")).Text));
                categorias.SetNombre(((Label)GrdCategorias.Rows[fila].FindControl("cat_nombre")).Text);
                categorias.SetDescripcion(((Label)GrdCategorias.Rows[fila].FindControl("cat_descripcion")).Text);

                //AQUI RECUPERO LA RUTA DE LA IMAGEN
                HiddenField rutaImagen = (HiddenField)GrdCategorias.Rows[fila].FindControl("urlImage");
                categorias.SetRutaImagen(rutaImagen.Value);

                estado.SetNombre(((Label)GrdCategorias.Rows[fila].FindControl("est_nombre")).Text);

                categorias.SetEstado(estado);

                negocioCategorias.CrearSesion();
                negocioCategorias.AgregarCategoriaEnLaSesion(categorias);

                Response.Redirect("CategoriasModificar.aspx");

            }
            if (e.CommandName == "eventoEliminar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                TxtNombreModalEliminar.Text = ((Label)GrdCategorias.Rows[fila].FindControl("cat_nombre")).Text;

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
        protected void LnAgregarCategorias_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriasAgregar.aspx");
        }
    }
}