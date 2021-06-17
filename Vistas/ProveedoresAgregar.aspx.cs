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
        private string imagenURL = "Imagenes/proveedores/__default.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checkeo si el usuario esta autorizado a entrar a el link
            //if (NegocioUsuarios.getInstance().isAdmin() != true)
            //{
            //    Response.Redirect("home.aspx");
            //}

            if (!Page.IsPostBack)
            {
                CargarEstados();
            }
        }
        private void LimpiarCampos()
        {
            //TxtNombre.Text = string.Empty;
            //TxtDescripcion.Text = string.Empty;
            //imagenURL = "Imagenes/proveedores/__default.png";
        }
        private void CargarEstados()
        {
            DataTable dt = negocioEstado.ObtenerEstados();
            foreach (DataRow dr in dt.Rows)
            {
                DdlEstados.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
            }
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtRazonSocial.Text.Trim()) && !string.IsNullOrEmpty(TxtDni.Text.Trim()) && !string.IsNullOrEmpty(TxtDireccion.Text.Trim()))
            {
                if (FUProveedor.HasFile)
                {
                    string imagenNombre = FUProveedor.PostedFile.FileName;
                    imagenURL = "Imagenes/proveedores/" + imagenNombre;
                }
                proveedor.SetDni(TxtDni.Text.Trim());
                proveedor.SetRazonSocial(TxtRazonSocial.Text.Trim());
                proveedor.SetDireccion(TxtDireccion.Text.Trim());
                proveedor.SetEmail(TxtEmail.Text.Trim());
                proveedor.SetTelefono(TxtTelefono.Text.Trim());
                proveedor.SetNombreContacto(TxtContacto.Text.Trim());
                proveedor.SetRutaImagen(imagenURL);
                estado.SetCodigo(Int32.Parse(DdlEstados.SelectedValue));
                proveedor.SetEstado(estado);
                int agrego = negocioProveedor.agregarProveedor(proveedor);
                if (agrego == 0) { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se pudo agregar el proveedor');", true); }
                if (agrego == 1) { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se agregó el proveedor');", true); }
                if (agrego == 2) { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El proveedor ya existe');", true); }
                //    LimpiarCampos();
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
        protected void IrListarProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProveedoresListado.aspx");
        }
        protected void IrListarVentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProveedoresListado.aspx");
        }
    }
}