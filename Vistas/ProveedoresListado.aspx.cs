using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;
using Entidades;

namespace Vistas
{
	public partial class ProveedoresListado : System.Web.UI.Page
	{
		private readonly NegocioProveedores negocioProveedor = new NegocioProveedores();
		private readonly NegocioEstados negocioEstado = new NegocioEstados();
		private Proveedores proveedor = new Proveedores();
		private readonly Estados estado = new Estados();

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
			}
		}

		private void CargarEstados()
		{
			DdlEstados.Items.Add(new ListItem("-- Elija un estado --", "0"));
			DataTable dt = negocioEstado.ObtenerEstados();
			foreach (DataRow dr in dt.Rows)
			{
				DdlEstados.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
			}
		}
		private void CargarGridView()
		{
			GrdProveedores.DataSource = negocioProveedor.ObtenerProveedores();
			GrdProveedores.DataBind();
		}
		protected void GrdProveedores_PreRender(object sender, EventArgs e)
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
		protected void GrdProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "eventoVerDetalle")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM CATEGORIASLISTADO.ASPX
				int fila = Convert.ToInt32(e.CommandArgument);
				TxtCuil.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_dni")).Text;
				TxtRazonSocial.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_razon_social")).Text;
				TxtDireccion.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_direccion")).Text;
				TxtMail.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_email")).Text;
				TxtTelefono.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_telefono")).Text;
				TxtNombreContacto.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_nombre_contacto")).Text;
				//
				string rutaImage = ((Image)GrdProveedores.Rows[fila].FindControl("pro_ruta_imagen")).ImageUrl;
				ImgLogo.ImageUrl = rutaImage;

				//MOSTRAR MODAL
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModal').modal('show');</script>", false);
			}
			if (e.CommandName == "eventoEditar")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM MARCASLISTADO.ASPX
				int fila = Convert.ToInt32(e.CommandArgument);

				proveedor.SetDni(((Label)GrdProveedores.Rows[fila].FindControl("pro_dni")).Text);
				proveedor.SetRazonSocial(((Label)GrdProveedores.Rows[fila].FindControl("pro_razon_social")).Text);
				proveedor.SetDireccion(((Label)GrdProveedores.Rows[fila].FindControl("pro_direccion")).Text);
				proveedor.SetEmail(((Label)GrdProveedores.Rows[fila].FindControl("pro_email")).Text);
				proveedor.SetTelefono(((Label)GrdProveedores.Rows[fila].FindControl("pro_telefono")).Text);
				proveedor.SetNombreContacto(((Label)GrdProveedores.Rows[fila].FindControl("pro_nombre_contacto")).Text);

				// AQUI RECUPERO LA RUTA DE LA IMAGEN
				string rutaImage = ((Image)GrdProveedores.Rows[fila].FindControl("pro_ruta_imagen")).ImageUrl;
				proveedor.SetRutaImagen(rutaImage);

				// RECUPERO CAMPO OCULTO CODIGO DE ESTADO
				int codigo = Int32.Parse(((Label)GrdProveedores.Rows[fila].FindControl("est_codigo")).Text);
				estado.SetCodigo(codigo);
				estado.SetNombre(((Label)GrdProveedores.Rows[fila].FindControl("est_nombre")).Text);
				proveedor.SetEstado(estado);

				// AGREGO LO SELECCIONADO EN LA SESION
				negocioProveedor.AgregarProveedorEnLaSesion(proveedor);
				Response.Redirect("ProveedoresModificar.aspx");
			}
			if (e.CommandName == "eventoEliminar")
			{

				// RECUPERO EL CONTENIDO DEL WEBFORM PROVEEDORESLISTADO.ASPX
				int fila = Convert.ToInt32(e.CommandArgument);
				//SETEO EL CODIGO DEL PROVEEDOR A ELIMINAR
				string proDni = ((Label)GrdProveedores.Rows[fila].FindControl("pro_dni")).Text;
				proveedor.SetDni(proDni);
				//
				// MUESTRO EL NOMBRE Y EL LOGO DEL PROVEEDOR A ELIMINAR EN UN MODAL
				TxtNombreModalEliminar.Text = ((Label)GrdProveedores.Rows[fila].FindControl("pro_razon_social")).Text;
				string rutaImage = ((Image)GrdProveedores.Rows[fila].FindControl("pro_ruta_imagen")).ImageUrl;
				ImageModalEliminar.ImageUrl = rutaImage;

				// AGREGO LO SELECCIONADO EN LA SESION
				negocioProveedor.AgregarProveedorEliminar(proveedor);

				//
				//MOSTRAR MODAL
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModalEliminar').modal('show');</script>", false);
			}
		}

		protected void BtnEliminarProveedor_Click(object sender, EventArgs e)
		{
			proveedor = negocioProveedor.ObtenerProveedorEliminar();
			if (negocioProveedor.eliminarProveedor(proveedor))
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se eliminó el proveedor " + TxtNombreModalEliminar.Text + "');", true);
				CargarGridView();
			}
			else
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se pudo eliminar el proveedor " + TxtNombreModalEliminar.Text + " porque contiene dependencias en la DB.');", true);
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

		// LINKBUTTON AGREGAR
		protected void LnAgregarProveedor_Click(object sender, EventArgs e)
		{
			Response.Redirect("ProveedoresAgregar.aspx");
		}

		#region FILTRADO DE PROVEEDORES

		protected void BtnFiltrar_Click(object sender, EventArgs e)
		{
			GrdProveedores.DataSource = negocioProveedor.filtrarConsultaProveedor(TxtCodigo.Text, TxtNombre.Text, DdlEstados.SelectedValue);
			GrdProveedores.DataBind();
		}

		protected void BtnQuitarFiltro_Click(object sender, EventArgs e)
		{
			CargarGridView();
			limpiarCampos();
		}

		private void limpiarCampos()
		{
			TxtCodigo.Text = string.Empty;
			TxtNombre.Text = string.Empty;
			DdlEstados.SelectedValue = "0";
		}
		#endregion
	}
}