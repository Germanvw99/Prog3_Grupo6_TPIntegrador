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
    public partial class Formulario_web11 : System.Web.UI.Page

    {

        NegocioArticulos n = new NegocioArticulos();
        private readonly NegocioArticulos negocioArticulos = new NegocioArticulos();
        private readonly Articulos articulo = new Articulos();
        private readonly Categorias categoria = new Categorias();
        private readonly Estados estado = new Estados();
        private readonly Marcas marca = new Marcas();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataTable dt = (DataTable)Session["User"];

                Usuarios objUsuario = NegocioUsuarios.getInstance().LeerTablaUsuario(dt);    
            }

        }

        public void cargarlistviewpormarca()
        {
            ListViewProductos.DataSource = negocioArticulos.ObtenerArticulosdemarca((String)Session["tablapormarca"]);
            ListViewProductos.DataBind();

        }

        public void cargarlistview(string busquedad="")
        {
            ListViewProductos.DataSource = negocioArticulos.ObtenerArticulosBuscados(busquedad);
            ListViewProductos.DataBind();
        }

        protected void ListViewProductos_PreRender(object sender, EventArgs e)
        {
            if (Session["Busquedad"] != null)
            {
                cargarlistview(Session["Busquedad"].ToString());
                Session["Busquedad"] = null;
            }
            else if (Session["tablapormarca"] != null)
            {
                cargarlistviewpormarca();
                Session["tablapormarca"] = null;
            }
            else
            {
                cargarlistview();
            }

        }

        protected void BtnAgregarCarrito_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "agregar")
            {
                // Checkea que el usuario este logueado, en caso de estar desconecado lo redirecciona
                if (Session["User"] == null)

                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    // Chekea que haya suficiente stock para agregar al carrito
                    String s = e.CommandArgument.ToString();
                    String[] arreglo = s.Split('@');
                    if (n.ControlDeStock(1,arreglo[0].ToString()))
                    {

                        articulo.SetCodigo(Convert.ToInt32(arreglo[0]));
                        articulo.SetNombre(arreglo[1]);
                        articulo.SetDescripcion(arreglo[2]);
                        articulo.SetPrecioLista(Convert.ToDecimal(arreglo[3]));
                        n.agregarfilacarrito(articulo);

                        ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Se agrego al carrito!','success')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Stock no disponible!','warning')", true);
                    }                  
                }
            }
        }

        protected void BtnBuscarTodo_Click(object sender, EventArgs e)
        {
            cargarlistview();
        }

        protected void ProductImage_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName== "EventoImg")
            {
                Session["ArticuloSelec"] = e.CommandArgument.ToString();
            }
            Response.Redirect("DetalleArticulo.aspx");

        }
    }
}