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
    public partial class ArticulosAgregar : System.Web.UI.Page
    {
        private readonly NegocioMarcas negocioMarcas = new NegocioMarcas();
        private readonly NegocioCategorias negocioCategorias = new NegocioCategorias();
        private readonly NegocioEstados negocioEstados = new NegocioEstados();
        private readonly NegocioArticulos negocioArticulo = new NegocioArticulos();
        //
        private readonly Articulos articulo = new Articulos();
        private readonly Categorias categoria = new Categorias();
        private readonly Estados estado = new Estados();
        private readonly Marcas marca = new Marcas();
        //
        private string imagenURL = "Imagenes/articulos/__default.png";
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (NegocioUsuarios.getInstance().isAdmin() != true)
            //{
            //    Response.Redirect("home.aspx");
            //}
            if (!Page.IsPostBack)
            {
                CargarMarcas();
                CargarCategorias();
                CargarEstados();
            }
        }
        private void CargarMarcas()
        {
            DdlMarcas.Items.Add(new ListItem("", "0"));
            DataTable dt = negocioMarcas.ObtenerMarcas();
            foreach (DataRow dr in dt.Rows)
            {
                DdlMarcas.Items.Add(new ListItem(dr["mar_nombre"].ToString(), dr["mar_codigo"].ToString()));
            }
        }
        private void CargarCategorias()
        {
            DdlCategorias.Items.Add(new ListItem("", "0"));
            DataTable dt = negocioCategorias.ObtenerCategorias();
            foreach (DataRow dr in dt.Rows)
            {
                DdlCategorias.Items.Add(new ListItem(dr["cat_nombre"].ToString(), dr["cat_codigo"].ToString()));
            }
        }
        private void CargarEstados()
        {
            DdlEstados.Items.Add(new ListItem("", "0"));
            DataTable dt = negocioEstados.ObtenerEstados();
            foreach (DataRow dr in dt.Rows)
            {
                DdlEstados.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
            }
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtNombre.Text.Trim()) && !string.IsNullOrEmpty(TxtDescripcion.Text.Trim()) &&
            !string.IsNullOrEmpty(TxtPuntoPedido.Text.Trim()) && !string.IsNullOrEmpty(DdlCategorias.SelectedItem.ToString()) &&
            !string.IsNullOrEmpty(DdlEstados.SelectedItem.ToString()) && !string.IsNullOrEmpty(DdlMarcas.SelectedItem.ToString()))
            {
                if (FUArticulo.HasFile)
                {
                    string imagenNombre = FUArticulo.PostedFile.FileName;
                    imagenURL = "Imagenes/articulos/" + imagenNombre;
                }
                articulo.SetNombre(TxtNombre.Text.Trim());
                articulo.SetDescripcion(TxtDescripcion.Text.Trim());
                //
                marca.SetCodigo(Int32.Parse(DdlMarcas.SelectedValue));
                articulo.SetMarca(marca);
                //
                categoria.SetCodigo(Int32.Parse(DdlCategorias.SelectedValue));
                articulo.SetCategoria(categoria);
                //
                estado.SetCodigo(Int32.Parse(DdlEstados.SelectedValue));
                articulo.SetEstado(estado);
                //
                articulo.SetPuntoPedido(Int32.Parse(TxtPuntoPedido.Text.Trim()));
                articulo.SetPrecioLista(Decimal.Parse(TxtPrecioLista.Text.Trim()));
                //
                articulo.SetRutaImagen(imagenURL);
                //
                int agrego = negocioArticulo.agregarArticulo(articulo);
                if (agrego == 0) { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se puso agregar el artículo');", true); }
                if (agrego == 1) { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se agregó el artículo');", true); }
                if (agrego == 2) { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El artículo ya existe');", true); }
                //LimpiarCampos();
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
        protected void IrListarVentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("VentasListado.aspx");
        }
        // AGREGAR MARCAS Y CATEGORIAS
        protected void IrAgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("MarcasAgregar.aspx");
        }
        protected void IrAgregarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriasAgregar.aspx");
        }
    }
}