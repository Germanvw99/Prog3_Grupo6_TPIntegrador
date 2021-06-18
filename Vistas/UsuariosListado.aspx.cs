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
    public partial class UsuariosAdministrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			//if (NegocioUsuarios.getInstance().isAdmin() != true)
			//{
			//   Response.Redirect("home.aspx");
			// }
			if (!Page.IsPostBack)
			{
				CargarGridView();
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

		protected void BtnEliminarUsuario_Click(object sender, EventArgs e)
        {
			// RECUPERO EL CONTENIDO DEL WEBFORM
			Usuarios objUsuario = NegocioUsuarios.getInstance().ObtenerUsuarioAEliminar();

			// ELIMINO AL USUARIO DE LA BASE DE DATOS
			bool eliminado = NegocioUsuarios.getInstance().EliminarUsuarioDni(objUsuario.Dni, objUsuario.Codigo_Perfil);

			if(eliminado)
            {
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se eliminó al usuario " + objUsuario.Username + "');", true);
				CargarGridView();
			}
            else
            {
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se puso eliminar al usuario " + objUsuario.Username + " porque es administrador');", true);
				CargarGridView();
			}
		}

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

		protected void LnAgregarArticulos_Click(object sender, EventArgs e)
		{
			Response.Redirect("ArticulosAgregar.aspx");
		}
		protected void IrListarVentas_Click(object sender, EventArgs e)
		{
			Response.Redirect("VentasListado.aspx");
		}

	}
}