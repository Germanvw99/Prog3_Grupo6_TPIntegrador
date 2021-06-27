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
	public partial class MarcasAgregar : System.Web.UI.Page
	{
		private readonly NegocioEstados negocioEstado = new NegocioEstados();
		private readonly NegocioMarcas negocioMarca = new NegocioMarcas();
		private readonly Marcas marca = new Marcas();
		private readonly Estados estado = new Estados();
		//
		private string mensaje = string.Empty;
		private string imagenURL = "Imagenes/marcas/__default.png";
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
			TxtNombre.Text = string.Empty;
			TxtDescripcion.Text = string.Empty;
			imagenURL = "Imagenes/marcas/__default.png";
			DdlEstados.SelectedValue = "0";
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
		protected void BtnAgregar_Click(object sender, EventArgs e)
		{
			//if (!string.IsNullOrEmpty(TxtNombre.Text) && !string.IsNullOrEmpty(TxtDescripcion.Text) && Int32.Parse(DdlEstados.SelectedValue) != 0)
			
			if(negocioMarca.ValidarContenido(ref mensaje,TxtNombre.Text,TxtDescripcion.Text,DdlEstados.SelectedValue))
			{
				if (FUMarca.HasFile)
				{
					// VALIDA QUE EL ARCHIVO SEA CORRECTO.
					if (NegocioImagenes.validarArchivo(FUMarca.PostedFile))
					{
						// SUBE ARCHIVO.
						imagenURL = NegocioImagenes.SubirImagenMarca(FUMarca.PostedFile);

						marca.SetNombre(TxtNombre.Text.Trim());
						marca.SetDescripcion(TxtDescripcion.Text.Trim());
						estado.SetCodigo(Int32.Parse(DdlEstados.SelectedValue));
						marca.SetEstado(estado);
						marca.SetRutaImagen(imagenURL);

						int agrego = negocioMarca.agregarMarca(marca);

						if (agrego == 0)
						{
							ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('No se puso agregar la marca!','error')", true);

							//ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se pudo agregar la marca');", true);
						}
						if (agrego == 1)
						{
							ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Se agregó la marca!','success')", true);

							//ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se agregó la marca');", true);
						}
						if (agrego == 2)
						{
							ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('La marca ya existe!','info')", true);

							//ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La marca ya existe');", true);
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
				ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "Mensaje('AGREGUE','" + mensaje + "','warning')", true);

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