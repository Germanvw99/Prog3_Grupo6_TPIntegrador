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
        private readonly NegocioArticulos negocioArticulos = new NegocioArticulos();
        
        protected void Page_Load(object sender, EventArgs e) {
            if (NegocioUsuarios.getInstance().isAdmin() != true)
            {
                Response.Redirect("home.aspx");
            }

            if (!Page.IsPostBack) {
                CargarMarcas();
                CargarCategorias();
                CargarEstados();
            }
        }
        private void CargarMarcas() {
            DataTable dt = negocioMarcas.ObtenerMarcas();
            foreach (DataRow dr in dt.Rows)
            {
                DdlMarcas.Items.Add(new ListItem(dr["mar_nombre"].ToString(),dr["mar_codigo"].ToString()));
            }
        }

        private void CargarCategorias() {
            DataTable dt = negocioCategorias.ObtenerCategorias();
            foreach (DataRow dr in dt.Rows)
            {
                DdlCategorias.Items.Add(new ListItem(dr["cat_nombre"].ToString(), dr["cat_codigo"].ToString()));
            }
        }

        private void CargarEstados() {
            DataTable dt = negocioEstados.ObtenerEstados();
            foreach (DataRow dr in dt.Rows)
            {
                DdlEstados.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
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

        protected void IrAgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("MarcasAgregar.aspx");
        }

        protected void IrAgregarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriasAgregar.aspx");
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            // Valida que el archivo sea correcto.
            if (NegocioImagenes.validarArchivo(UploadImage.PostedFile))
            {
                // Sube archivo.
                string rutaImagen = NegocioImagenes.SubirImagenArticulo(UploadImage.PostedFile);


                Articulos objArticulo = getEntity(rutaImagen);
                // Una vez validado, se sube el registro del articulo.
                if(negocioArticulos.AgregarArticulo(objArticulo))
                {
                    lblNotificacion.ForeColor = System.Drawing.Color.Green;
                    lblNotificacion.Text = "Artículo agregado!";
                    clearForm();
                }
                else
                {
                    lblNotificacion.ForeColor = System.Drawing.Color.Red;
                    lblNotificacion.Text = "Error al agregar el articulo!";
                }
            }
            else
            {
                lblNotificacion.ForeColor = System.Drawing.Color.Red;
                lblNotificacion.Text = "Error al subir la imagen!";
            }
        }

        private Articulos getEntity(String rutaImagen)
        {
            Articulos objArticulo = new Articulos();
            Marcas objMarca = new Marcas();
            Categorias objCategoria = new Categorias();
            Estados objEstado = new Estados();

            // Inicializo con valores necesarios
            objMarca.SetCodigo(Convert.ToInt32(DdlMarcas.SelectedValue));
            objCategoria.SetCodigo(Convert.ToInt32(DdlCategorias.SelectedValue));
            objEstado.SetCodigo(Convert.ToInt32(DdlEstados.SelectedValue));

            objArticulo.SetNombre(TxtNombre.Text);
            objArticulo.SetDescripcion(TxtDescripcion.Text);
            objArticulo.SetCategoria(objCategoria);
            objArticulo.SetMarca(objMarca);
            objArticulo.SetEstado(objEstado);
            objArticulo.SetRutaImagen(rutaImagen);
            objArticulo.SetPuntoPedido(Convert.ToInt32(txtPedido.Text));
            objArticulo.SetPrecioLista(Convert.ToDecimal(txtPrecio.Text));

            return objArticulo;
        }

        private void clearForm()
        {
            txtPedido.Text = "";
            TxtNombre.Text = "";
            TxtDescripcion.Text = "";
            txtPrecio.Text = "";
        }
    }
}