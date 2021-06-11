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

                if (objUsuario.Codigo_Perfil == 2)
                {


                    cargarlistview();
                }
                else
                {

                    Response.Redirect("Home.aspx");

                }
            }
        }

        public void cargarlistview()
        {


           // ListView1.DataSource = negocioArticulos.ObtenerArticulos();
           //ListView1.DataBind();



        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}