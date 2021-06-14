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
    public partial class ArticulosListado : System.Web.UI.Page
    { 
        private readonly NegocioArticulos negocioArticulos = new NegocioArticulos();
        private readonly Articulos articulo = new Articulos();
        private readonly Categorias categoria = new Categorias();
        private readonly Estados estado = new Estados();
        private readonly Marcas marca = new Marcas();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarGridView();
        }
    }
    private void CargarGridView()
    {
        GrdArticulos.DataSource = negocioArticulos.ObtenerArticulos();
        GrdArticulos.DataBind();
    }
    protected void GrdArticulos_PreRender(object sender, EventArgs e)
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

        protected void GrdArticulos_RowCommand(object sender, GridViewCommandEventArgs e){
            if (e.CommandName == "eventoVer")
            {
               int fila = Convert.ToInt32(e.CommandArgument);
                TxtCodigoModal.Text = ((Label)GrdArticulos.Rows[fila].FindControl("art_codigo")).Text;
                TxtNombreModal.Text = ((Label)GrdArticulos.Rows[fila].FindControl("art_nombre")).Text;
                TxtDescripcionModal.Text = ((Label)GrdArticulos.Rows[fila].FindControl("art_descripcion")).Text;
                TxtPuntoPedidoModal.Text = ((Label)GrdArticulos.Rows[fila].FindControl("art_punto_pedido")).Text;
                TxtPrecioListaModal.Text = ((Label)GrdArticulos.Rows[fila].FindControl("art_precio_lista")).Text;
                TxtMarcaNombre.Text = ((Label)GrdArticulos.Rows[fila].FindControl("mar_nombre")).Text;
                TxtCategoriaNombre.Text = ((Label)GrdArticulos.Rows[fila].FindControl("cat_nombre")).Text;
                TxtEstadoModal.Text = ((Label)GrdArticulos.Rows[fila].FindControl("est_nombre")).Text;

                //RECUPERO CAMPO OCULTO
                HiddenField rutaImagen = (HiddenField)GrdArticulos.Rows[fila].FindControl("urlImage");
                ImgLogo.ImageUrl = rutaImagen.Value;


                //MOSTRAR MODAL
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModal').modal('show');</script>", false);
               
            }
            if (e.CommandName == "eventoEditar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);

                articulo.SetCodigo(Int32.Parse(((Label)GrdArticulos.Rows[fila].FindControl("art_codigo")).Text));

                //
                marca.SetNombre(((Label)GrdArticulos.Rows[fila].FindControl("mar_nombre")).Text);
                articulo.SetMarca(marca);

                //
                categoria.SetNombre(((Label)GrdArticulos.Rows[fila].FindControl("cat_nombre")).Text);
                articulo.SetCategoria(categoria);

                articulo.SetNombre(((Label)GrdArticulos.Rows[fila].FindControl("art_nombre")).Text);
                articulo.SetDescripcion(((Label)GrdArticulos.Rows[fila].FindControl("art_descripcion")).Text);
                articulo.SetPuntoPedido(Int32.Parse(((Label)GrdArticulos.Rows[fila].FindControl("art_punto_pedido")).Text));
                articulo.SetPrecioLista(Decimal.Parse(((Label)GrdArticulos.Rows[fila].FindControl("art_precio_lista")).Text));

                //
                //RECUPERO CAMPO OCULTO
                HiddenField rutaImagen = (HiddenField)GrdArticulos.Rows[fila].FindControl("urlImage");
                articulo.SetRutaImagen(rutaImagen.Value);

                //
                estado.SetNombre(((Label)GrdArticulos.Rows[fila].FindControl("est_nombre")).Text);
                articulo.SetEstado(estado);


                negocioArticulos.CrearSesion();
                negocioArticulos.AgregarArticuloEnLaSesion(articulo);

                Response.Redirect("ArticulosModificar.aspx");

            }
            if (e.CommandName == "eventoEliminar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                TxtNombreModalEliminar.Text = ((Label)GrdArticulos.Rows[fila].FindControl("art_nombre")).Text;

                //MOSTRAR MODAL
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModalEliminar').modal('show');</script>", false);
            }
            //if (e.CommandName == "eventoAgregarCarrito")
            //{
            //    int fila = Convert.ToInt32(e.CommandArgument);
            //    String id = ((Label)GrdArticulos.Rows[fila].FindControl("art_codigo")).Text;
            //    String nombre = ((Label)GrdArticulos.Rows[fila].FindControl("art_nombre")).Text;
            //    String descripcion = ((Label)GrdArticulos.Rows[fila].FindControl("art_descripcion")).Text;
            //    String precio = ((Label)GrdArticulos.Rows[fila].FindControl("art_precio_lista")).Text;
            //    negocioArticulos.agregarfilacarrito(id,nombre,descripcion,precio);

                    /*
                articulo.SetNombre(((Label)GrdArticulos.Rows[fila].FindControl("art_nombre")).Text);
                articulo.SetDescripcion(((Label)GrdArticulos.Rows[fila].FindControl("art_descripcion")).Text);
                articulo.SetPuntoPedido(Int32.Parse(((Label)GrdArticulos.Rows[fila].FindControl("art_punto_pedido")).Text));
                articulo.SetPrecioLista(Decimal.Parse(((Label)GrdArticulos.Rows[fila].FindControl("art_precio_lista")).Text));*/
            //}
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

        protected void LnAgregarArticulos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArticulosAgregar.aspx");
        }
    }
}