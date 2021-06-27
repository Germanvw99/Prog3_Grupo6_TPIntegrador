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
		NegocioCategorias negocioCategorias = new NegocioCategorias();
		NegocioMarcas negocioMarcas = new NegocioMarcas();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				// Cargar categorias y marcas para el sidebar
				CargarCategorias();
				CargarMarcas();
				Session["tablacarrito"] = null;
				//  Response.Redirect("Vistausuario.aspx");
			}
			// Modifica la parte visual dependiendo del tipo de usuario
			if (Session["User"] != null)
			{
				DataTable dt = (DataTable)Session["User"];

				Usuarios objUsuario = NegocioUsuarios.getInstance().LeerTablaUsuario(dt);
				if (objUsuario != null)
				{
					// USUARIO LOGUEADO

					// HEADER GENERAL
					userPanelLoggedIn.Visible = true;
					ImgUser.ImageUrl = objUsuario.Ruta_Img;

					userPanelLoggedOff.Visible = false;

					// SIDEBAR GENERAL
					heroUser.Visible = true;
					funcionesAdmin.Visible = false;
					userPanelMarcas.Visible = false;
					userPanelCategorias.Visible = false;

					// En caso de que haya un usuario Logueado, identificar si es Administrador o Usuario
					if (objUsuario.Codigo_Perfil == 1)
					{
						// Admin
						// SIDEBAR
						userPanelMarcas.Visible = false;
						userPanelCategorias.Visible = false;
						lblTipoUsuario.Text = objUsuario.Username + " (Administrador)";
						funcionesAdmin.Visible = true;
					}
					else
					{
						// Usuario
						lblTipoUsuario.Text = objUsuario.Username + " (Usuario)";
						userPanelMarcas.Visible = true;
						userPanelCategorias.Visible = true;
					}
				}
			}
			else
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

		protected void btnResetearFiltro_Click(object sender, EventArgs e)
		{
			Response.Redirect("Vistausuario.aspx");
		}

		protected void CargarCategorias()
        {
			DataTable dt = negocioCategorias.ObtenerCategorias();
			RBLCategorias.Items.Add(new ListItem("Todas", "-1"));
			foreach (DataRow dr in dt.Rows)
			{
				RBLCategorias.Items.Add(new ListItem(dr["cat_nombre"].ToString(), dr["cat_codigo"].ToString()));
			}
		}

		protected void CargarMarcas()
        {
			DataTable dt = negocioMarcas.ObtenerMarcas();
			DdlMarcas.Items.Add(new ListItem(" - Todas - ", "-1"));
			foreach (DataRow dr in dt.Rows)
			{
				DdlMarcas.Items.Add(new ListItem(dr["mar_nombre"].ToString(), dr["mar_codigo"].ToString()));
			}
		}
		protected void ImgUser_Click(object sender, ImageClickEventArgs e)
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
			// Checkea que el usuario este logueado, en caso de estar desconecado lo redirecciona
			if (Session["User"] == null)

			{
				Response.Redirect("login.aspx");
			}
			else
			{
				Response.Redirect("Carrito.aspx");
			}
		}

		protected void btnLogOff_Click(object sender, EventArgs e)
		{
			Session.Remove("User");
			Response.Redirect("Home.aspx");
		}

		protected void ImgMarca_Command(object sender, CommandEventArgs e)
		{
			if (e.CommandName == "marcas")
			{
				Session["tablapormarca"] = e.CommandArgument.ToString();
				Response.Redirect("Vistausuario.aspx");
			}
		}

		protected void BtnCategorias_Command(object sender, CommandEventArgs e)
		{
			if (e.CommandName == "categorias")
			{
				Session["tablapormarca"] = e.CommandArgument.ToString();
				Response.Redirect("Vistausuario.aspx");
			}
		}

		protected void btbuscar_Click(object sender, EventArgs e)
		{
			Session["Busquedad"] = tbbuscardor.Text;
		}

		// Botones redireccion
		protected void IrListarUsuarios_Click(object sender, EventArgs e)
		{
			Response.Redirect("UsuariosListado.aspx");
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
		protected void IrListarStock_Click(object sender, EventArgs e)
		{
			Response.Redirect("ControlStockListado.aspx");
		}
		protected void IrReportes_Click(object sender, EventArgs e)
		{
			Response.Redirect("Reportes.aspx");
		}

        protected void btnBuscarFiltro_Click(object sender, EventArgs e)
        {
			string Nombre = "";
			int Categoria = 0;
			int Marca = 0;
			int PrecioMin = 0;
			int PrecioMax = 0;

			if(txtNombre.Text.Trim() != "")
            {
				Nombre = txtNombre.Text;
            }
			if (RBLCategorias.SelectedIndex > 0)
			{
				Categoria = RBLCategorias.SelectedIndex;
			}
			if (DdlMarcas.SelectedIndex > 0)
			{
				Marca = DdlMarcas.SelectedIndex;
			}
			if (txtPrecioMin.Text != "")
            {
				PrecioMin = Convert.ToInt32(txtPrecioMin.Text);

			}
			if (txtPrecioMax.Text != "")
			{
				PrecioMax = Convert.ToInt32(txtPrecioMax.Text);

			}
			// Crea un string de búsqueda
			DataTable Filtro = n.filtrarConsultaSidebar(Nombre,Categoria,Marca,PrecioMin,PrecioMax);
			Session["tablaArticulosSidebar"] = Filtro;
			//Session["tablapormarca"] = CrearBusquedaFiltro();
			Response.Redirect("Vistausuario.aspx");
		}

    }
}