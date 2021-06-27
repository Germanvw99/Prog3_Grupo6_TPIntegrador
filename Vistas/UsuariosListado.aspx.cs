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
    public partial class UsuariosAdministrar : System.Web.UI.Page
    {
		NegocioEstados negocioEstados = new NegocioEstados();
		protected void Page_Load(object sender, EventArgs e)
        {
			if (NegocioUsuarios.getInstance().isAdmin() != true)
			{
			   Response.Redirect("home.aspx");
			 }
			if (!Page.IsPostBack)
			{
				CargarGridView();
				CargarEstados();
				CargarProvincias();
			}
		}
		private void CargarGridView()
		{
			GrdUsuarios.DataSource = NegocioUsuarios.getInstance().ObtenerUsuarios();
			GrdUsuarios.DataBind();

		}
		protected void GrdUsuarios_PreRender(object sender, EventArgs e)
		{
			GridView gv = (GridView)sender;

			if ((gv.ShowHeader == true && gv.Rows.Count > 0) || (gv.ShowHeaderWhenEmpty == true))
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
		protected void GrdUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "eventoVerDetalle")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM
				int fila = Convert.ToInt32(e.CommandArgument);
				// OBTENGO LOS DATOS DEL USUARIO
				Usuarios objUsuario = NegocioUsuarios.getInstance().LeerUsuarioDni(((Label)GrdUsuarios.Rows[fila].FindControl("usu_dni")).Text);

				// RELLENO CON DATOS

				TxtDni.Text = objUsuario.Dni;
				TxtUsername.Text = objUsuario.Username;
				TxtNombre.Text = objUsuario.Nombre;
				TxtApellido.Text = objUsuario.Apellido;
				TxtTelefono.Text = objUsuario.Telefono;
				TxtEmail.Text = objUsuario.Email;
				TxtCiudad.Text = objUsuario.Ciudad;
				TxtProvincia.Text = objUsuario.Provincia;
				TxtCodigo_Postal.Text = objUsuario.Codigo_Postal;
				ProfilePic.ImageUrl = objUsuario.Ruta_Img;
				txtDireccion.Text = objUsuario.Direccion;
				TxtEstado.Text = ((Label)GrdUsuarios.Rows[fila].FindControl("est_nombre")).Text;
				if(objUsuario.Codigo_Perfil == 1)
                {
					TxtCodigo_Perfil.Text = "Administrador";
                }
                else { TxtCodigo_Perfil.Text = "Usuario"; }


				TxtDni.Enabled = false;
				TxtUsername.Enabled = false;
				TxtNombre.Enabled = false;
				TxtApellido.Enabled = false;
				TxtTelefono.Enabled = false;
				TxtEmail.Enabled = false;
				TxtCiudad.Enabled = false;
				TxtProvincia.Enabled = false;
				TxtEstado.Enabled = false;
				TxtCodigo_Postal.Enabled = false;
				TxtCodigo_Perfil.Enabled = false;
				txtDireccion.Enabled = false;


				//MOSTRAR MODAL
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModal').modal('show');</script>", false);

			}
			if (e.CommandName == "eventoEditar")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM
				int fila = Convert.ToInt32(e.CommandArgument);
				// OBTENGO LOS DATOS DEL USUARIO
				Usuarios objUsuario = NegocioUsuarios.getInstance().LeerUsuarioDni(((Label)GrdUsuarios.Rows[fila].FindControl("usu_dni")).Text);
				// RELLENO CON DATOS

				txtEditarDni.Text = objUsuario.Dni;
				txtEditarUsername.Text = objUsuario.Username;
				txtEditarNombre.Text = objUsuario.Nombre;
				txtEditarApellido.Text = objUsuario.Apellido;
				txtEditarTelefono.Text = objUsuario.Telefono;
				txtEditarEmail.Text = objUsuario.Email;
				txtEditarCiudad.Text = objUsuario.Ciudad;
				txtEditarProvincia.Text = objUsuario.Provincia;
				txtEditarCodigo_Postal.Text = objUsuario.Codigo_Postal;
				ProfilePicEditar.ImageUrl = objUsuario.Ruta_Img;
				txtEditarDireccion.Text = objUsuario.Direccion;
				txtEditarCodigo_Estado.Text = ((Label)GrdUsuarios.Rows[fila].FindControl("est_nombre")).Text;
				if (objUsuario.Codigo_Perfil == 1)
				{
					txtEditarCodigo_Estado.Text = "Administrador";
				}
				else { txtEditarCodigo_Estado.Text = "Usuario"; }

				// COMPLETA DDL CON ESTADOS DE DATABASE
				if (DdlEditarTipo_usuario.Items.Count == 0)
                {
					DataTable dt = negocioEstados.ObtenerEstados();
					foreach (DataRow dr in dt.Rows)
					{
						DdlEditarTipo_usuario.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
					}
                }

				if(objUsuario.Estado == 1)
                {
					DdlEditarTipo_usuario.Items[0].Selected = true;
				}
                else { DdlEditarTipo_usuario.Items[1].Selected = true; }

				txtEditarDni.Enabled = false;
				txtEditarUsername.Enabled = false;
				txtEditarNombre.Enabled = false;
				txtEditarApellido.Enabled = false;
				txtEditarTelefono.Enabled = false;
				txtEditarEmail.Enabled = false;
				txtEditarCiudad.Enabled = false;
				txtEditarProvincia.Enabled = false;
				txtEditarCodigo_Postal.Enabled = false;
				TxtCodigo_Perfil.Enabled = false;
				txtEditarDireccion.Enabled = false;
				txtEditarCodigo_Estado.Enabled = false;

				// CREO EL SESSION PARA TRANSPORTAR LOS DATOS DEL USUARIO A EDITAR.
				NegocioUsuarios.getInstance().AgregarUsuarioAEditar(objUsuario);

				//MOSTRAR MODAL
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModalEditar').modal('show');</script>", false);
			}
			if (e.CommandName == "eventoEliminar")
			{

				// RECUPERO EL CONTENIDO DEL WEBFORM
				int fila = Convert.ToInt32(e.CommandArgument);
				// OBTENGO LOS DATOS DEL USUARIO
				Usuarios objUsuario = NegocioUsuarios.getInstance().LeerUsuarioDni(((Label)GrdUsuarios.Rows[fila].FindControl("usu_dni")).Text);

				ImageModalEliminar.ImageUrl = objUsuario.Ruta_Img;
				txtDniEliminar.Text = objUsuario.Dni;
				txtUsernameEliminar.Text = objUsuario.Username;

				// CREO EL SESSION PARA TRANSPORTAR LOS DATOS DEL USUARIO A ELIMINAR.
				NegocioUsuarios.getInstance().AgregarUsuarioAEliminar(objUsuario);

				//MOSTRAR MODAL
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModalEliminar').modal('show');</script>", false);

			}
		}

		protected void BtnEditarUsuario_Click(object sender, EventArgs e)
        {
			// RECUPERO EL CONTENIDO DEL WEBFORM
			Usuarios objUsuario = NegocioUsuarios.getInstance().ObtenerUsuarioAEditar();
			// EDITO AL USUARIO DE LA BASE DE DATOS
			int nuevoEstado = Convert.ToInt32(DdlEditarTipo_usuario.SelectedValue);
			bool editado = NegocioUsuarios.getInstance().EditarUsuarioEstado(objUsuario, nuevoEstado);

			if(editado)
            {
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se editó el usuario " + objUsuario.Username + "');", true);
				CargarGridView();
			}
			else
            {
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se puso eliminar al usuario " + objUsuario.Username + " porque es administrador');", true);
				CargarGridView();
			}
		}

		protected void BtnEliminarUsuario_Click(object sender, EventArgs e)
        {
			// RECUPERO EL CONTENIDO DEL WEBFORM
			Usuarios objUsuario = NegocioUsuarios.getInstance().ObtenerUsuarioAEliminar();

			// ELIMINO AL USUARIO DE LA BASE DE DATOS
			int eliminado = NegocioUsuarios.getInstance().EliminarUsuarioDni(objUsuario.Dni, objUsuario.Codigo_Perfil);

			if(eliminado == 1)
            {
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se eliminó al usuario " + objUsuario.Username + "');", true);
				CargarGridView();
			}
            else if(eliminado == 2)
            {
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se puso eliminar al usuario " + objUsuario.Username + " porque es administrador');", true);
				CargarGridView();
			}
			else if(eliminado == -1)
            {
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se puso eliminar al usuario " + objUsuario.Username + " porque tiene dependencias en la BD.');", true);
				CargarGridView();
			}
		}

	
		protected void BtnFiltrar_Click(object sender, EventArgs e)
		{
			GrdUsuarios.DataSource = NegocioUsuarios.getInstance().filtrarUsuarios(txtFiltrarDni.Text, txtFiltrarUsername.Text, DdlFiltrarProvincia.SelectedItem.Text, DdlFiltrarEstado.SelectedValue);
			GrdUsuarios.DataBind();
		}



		protected void BtnQuitarFiltro_Click(object sender, EventArgs e)
		{
			CargarGridView();
			limpiarCampos();
		}
		// Filtros
		private void limpiarCampos()
		{
			txtFiltrarDni.Text = string.Empty;
			txtFiltrarUsername.Text = string.Empty;
			DdlFiltrarProvincia.SelectedValue = "0";
			DdlFiltrarEstado.SelectedValue = "0";
		}

		// Rellenar Campos
		private void CargarEstados()
		{
			DdlFiltrarEstado.Items.Add(new ListItem("- Elegir -", "0"));
			DdlFiltrarEstado.Items[0].Selected = true;
			DdlFiltrarEstado.Items[0].Attributes["disabled"] = "disabled";
			DataTable dt = negocioEstados.ObtenerEstados();
			foreach (DataRow dr in dt.Rows)
			{
				DdlFiltrarEstado.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
			}
		}

		private void CargarProvincias()
		{
			DdlFiltrarProvincia.Items.Add(new ListItem("- Elegir -", "0"));
			DdlFiltrarProvincia.Items[0].Selected = true;
			DdlFiltrarProvincia.Items[0].Attributes["disabled"] = "disabled";
			DataTable dt = NegocioUsuarios.getInstance().ObtenerProvincias();
			foreach (DataRow dr in dt.Rows)
			{
				DdlFiltrarProvincia.Items.Add(new ListItem(dr["prov_nombre"].ToString(), dr["prov_codigo"].ToString()));
			}
		}

		// LINK BUTTON REDIRECCIONAMIENTO
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
	}
}