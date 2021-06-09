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
    public partial class MarcasListado : System.Web.UI.Page
    {
        private readonly NegocioMarcas negocioMarcas = new NegocioMarcas();
        private readonly Estados estado = new Estados();
        private readonly Marcas marca = new Marcas();


        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack) {
                CargarGridView();
            }
        }
        private void CargarGridView() {
            GrdMarcas.DataSource = negocioMarcas.ObtenerMarcas();
            GrdMarcas.DataBind();
        }
        protected void GrdMarcas_PreRender(object sender, EventArgs e) {
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
        protected void GrdMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eventoVer")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                TxtCodigoModal.Text = ((Label)GrdMarcas.Rows[fila].FindControl("mar_codigo")).Text;
                TxtNombreModal.Text = ((Label)GrdMarcas.Rows[fila].FindControl("mar_nombre")).Text;
                TxtEsloganModal.Text = ((Label)GrdMarcas.Rows[fila].FindControl("mar_descripcion")).Text;
                TxtEstadoModal.Text = ((Label)GrdMarcas.Rows[fila].FindControl("est_nombre")).Text;

                //RECUPERO CAMPO OCULTO
                HiddenField rutaImagen = (HiddenField)GrdMarcas.Rows[fila].FindControl("urlImage");
                ImgLogo.ImageUrl = rutaImagen.Value;


                //MOSTRAR MODAL
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModal').modal('show');</script>", false);
            }
            if (e.CommandName == "eventoEditar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);

                marca.SetCodigo(Int32.Parse(((Label)GrdMarcas.Rows[fila].FindControl("mar_codigo")).Text));
                marca.SetNombre(((Label)GrdMarcas.Rows[fila].FindControl("mar_nombre")).Text);
                marca.SetDescripcion(((Label)GrdMarcas.Rows[fila].FindControl("mar_descripcion")).Text);

                //AQUI RECUPERO LA RUTA DE LA IMAGEN
                HiddenField rutaImagen = (HiddenField)GrdMarcas.Rows[fila].FindControl("urlImage");
                marca.SetRutaImagen(rutaImagen.Value);

                estado.SetNombre(((Label)GrdMarcas.Rows[fila].FindControl("est_nombre")).Text);
               
                marca.SetEstado(estado);

                negocioMarcas.CrearSesion();
                negocioMarcas.AgregarMarcaEnLaSesion(marca);

                Response.Redirect("MarcasModificar.aspx");
            }



            if (e.CommandName == "eventoEliminar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                TxtNombreModalEliminar.Text = ((Label)GrdMarcas.Rows[fila].FindControl("mar_nombre")).Text;

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

        protected void LnAgregarMarcas_Click(object sender, EventArgs e)
        {
            Response.Redirect("MarcasAgregar.aspx");
        }
    }
}