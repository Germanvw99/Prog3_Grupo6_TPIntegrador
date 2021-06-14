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

                if (objUsuario.Codigo_Perfil != 2)
                {
                    Response.Redirect("Home.aspx");
                }
            }

        }

        public void cargarlistviewpormarca()
        {
            //  int e = Convert.ToInt32((String)Session["tablapormarca"]);
            // SqlDataSource1.SelectCommand= "SELECT art_codigo,art_nombre,art_descripcion,art_punto_pedido,art_precio_lista,art_ruta_imagen,est_nombre, mar_nombre, cat_nombre FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo  where art_marca_codigo = " + 9;
            ListView1.DataSource = negocioArticulos.ObtenerArticulosdemarca((String)Session["tablapormarca"]);
            ListView1.DataBind();

        }

        public void cargarlistview(string busquedad=" ")
        {
            ListView1.DataSource = negocioArticulos.ObtenerArticulosBuscados(busquedad);
            ListView1.DataBind();

        }

        protected void ListView1_PreRender(object sender, EventArgs e)
        {
            if (Session["Busquedad"] != null)
            {
                //Label1.Text = Session["Busquedad"].ToString();
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

        protected void Button3_Click(object sender, EventArgs e)
        {

        }


        protected void Button2_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "agregar")
            {
                String s = e.CommandArgument.ToString();
                String[] arreglo = s.Split('@');

                articulo.SetCodigo(Convert.ToInt32(arreglo[0]));
                articulo.SetNombre(arreglo[1]);
                articulo.SetDescripcion(arreglo[2]);
                articulo.SetPrecioLista(Convert.ToDecimal(arreglo[3]));

                //String id = arreglo[0];
                //String nombre = arreglo[1];
                //String descripcion = arreglo[2];
                //String precio = arreglo[3];
                //n.agregarfilacarrito(id, nombre, descripcion, precio);
                //aca  termine .

                n.agregarfilacarrito(articulo);
            }
        }

        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "agregar")
            {
                String s = e.CommandArgument.ToString();
                String[] arreglo = s.Split('@');

                articulo.SetCodigo(Convert.ToInt32(arreglo[0]));
                articulo.SetNombre(arreglo[1]);
                articulo.SetDescripcion(arreglo[2]);
                articulo.SetPrecioLista(Convert.ToDecimal(arreglo[3]));

                //String id = arreglo[0];
                //String nombre = arreglo[1];
                //String descripcion = arreglo[2];
                //String precio = arreglo[3];
                //n.agregarfilacarrito(id, nombre, descripcion, precio);
                //aca  termine .

                n.agregarfilacarrito(articulo);
            }
        }

        protected void ImageButton3_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName== "EventoImg")
            {
                Session["ArticuloSelec"] = e.CommandArgument.ToString();
            }
            Response.Redirect("DetalleArticulo.aspx");

        }
    }
}