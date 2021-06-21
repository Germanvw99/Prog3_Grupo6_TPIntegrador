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
	public partial class ProveedoresAgregar : System.Web.UI.Page
	{
		private readonly NegocioEstados negocioEstado = new NegocioEstados();
		private readonly NegocioProveedores negocioProveedor = new NegocioProveedores();
		private readonly Proveedores proveedor = new Proveedores();
		private readonly Estados estado = new Estados();

		private string mensaje = string.Empty;

		private string imagenURL = "Imagenes/proveedores/__default.png";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (NegocioUsuarios.getInstance().isAdmin() != true)
			{
				Response.Redirect("home.aspx");
			}

			if (!Page.IsPostBack)
			{
				CargarEstados();
			}
		}
		private void LimpiarCampos()
		{
			TxtRazonSocial.Text = string.Empty;
			TxtDni.Text = string.Empty;
			TxtDireccion.Text = string.Empty;
			TxtEmail.Text = string.Empty;
			TxtTelefono.Text = string.Empty;
			TxtContacto.Text = string.Empty;
			DdlEstados.SelectedValue = "0";
			imagenURL = "Imagenes/proveedores/__default.png";
		}
		private void CargarEstados()
		{
			DdlEstados.Items.Add(new ListItem("Seleccione Estado", "0"));
			DataTable dt = negocioEstado.ObtenerEstados();
			foreach (DataRow dr in dt.Rows)
			{
				DdlEstados.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
			}
		}
		protected void BtnAgregar_Click(object sender, EventArgs e)
		{
			//if (!string.IsNullOrEmpty(TxtRazonSocial.Text.Trim()) && !string.IsNullOrEmpty(TxtDni.Text.Trim()) && !string.IsNullOrEmpty(TxtDireccion.Text.Trim()))
			if(ValidarContenido())
			{
				if (FUProveedor.HasFile)
				{
					// VALIDA QUE EL ARCHIVO SEA CORRECTO.
					if (NegocioImagenes.validarArchivo(FUProveedor.PostedFile))
					{
						// SUBE ARCHIVO.
						imagenURL = NegocioImagenes.SubirImagenProveedor(FUProveedor.PostedFile);
						
						GetEntity(imagenURL);

						int agrego = negocioProveedor.agregarProveedor(proveedor);
						if (agrego == 0)
						{
							ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('No se puso agregar el proveedor!','error')", true);

							//ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se pudo agregar el proveedor');", true);
						}
						if (agrego == 1)
						{
							ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Se agregó el proveedor!','success')", true);

							//ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se agregó el proveedor');", true);
						}
						if (agrego == 2)
						{
							ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('El proveedor ya existe!','info')", true);

							//ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El proveedor ya existe');", true);
						}
						LimpiarCampos();

					}
                    else
                    {
						ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Error al subir la imagen!','error')", true);

					}

				}
				else
				{
					ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Suba una imagen!','info')", true);
				}

				
			}
            else
            {
				//ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + mensaje + "');", true);
				ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "Mensaje('AGREGUE','" + mensaje + "','warning')", true);
			}
		}

		protected bool ValidarContenido()
		{

			if (string.IsNullOrWhiteSpace(TxtRazonSocial.Text.Trim())) mensaje += "Razon social";
			if (string.IsNullOrWhiteSpace(TxtDni.Text.Trim())){ mensaje += "-Dni/Cuil"; }
			else if (int.Parse(TxtDni.Text.Trim()) < 0) mensaje += "-Dni/Cuil invalido";
			else if (!(TxtDni.Text.Trim().Count() >=8 && TxtDni.Text.Trim().Count()<=11)) mensaje += "-Dni/Cuil invalido";
			if (string.IsNullOrWhiteSpace(TxtDireccion.Text.Trim())) mensaje += "-Dirección";
			if (string.IsNullOrWhiteSpace(TxtEmail.Text.Trim())) mensaje += "-mail";
			if (string.IsNullOrWhiteSpace(TxtTelefono.Text.Trim())) { mensaje += "-Teléfono"; }
			//else if (TxtTelefono.Text.Trim().Count() != 11) mensaje += "-Teléfono invalido (11 digitos)"; 
			else if (int.Parse(TxtTelefono.Text.Trim()) < 0) mensaje += "-Telefono invalido";
			if (string.IsNullOrWhiteSpace(TxtContacto.Text.Trim())) mensaje += "-Contacto";
			if (DdlEstados.SelectedValue == "0") mensaje += " Estado";

			if (string.IsNullOrEmpty(mensaje))
			{
				return true;
			}

			return false;

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
		protected void IrListarVentas_Click(object sender, EventArgs e)
		{
			Response.Redirect("VentasListado.aspx");
		}
		protected void IrListarStock_Click(object sender, EventArgs e)
		{
			Response.Redirect("ControlStockListado.aspx");
		}

		private Proveedores GetEntity(string rutaImagen)
        {
			proveedor.SetDni(TxtDni.Text.Trim());
			proveedor.SetRazonSocial(TxtRazonSocial.Text.Trim());
			proveedor.SetDireccion(TxtDireccion.Text.Trim());
			proveedor.SetEmail(TxtEmail.Text.Trim());
			proveedor.SetTelefono(TxtTelefono.Text.Trim());
			proveedor.SetNombreContacto(TxtContacto.Text.Trim());
			proveedor.SetRutaImagen(rutaImagen);
			estado.SetCodigo(Int32.Parse(DdlEstados.SelectedValue));
			proveedor.SetEstado(estado);

			return proveedor;
		}

     




	}
}