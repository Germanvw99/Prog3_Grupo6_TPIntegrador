using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace Vistas
{
    public partial class ProveedoresModificar : System.Web.UI.Page
    {
        //private readonly Proveedores proveedor = new Proveedores();
        private readonly NegocioProveedores negocioProveedor = new NegocioProveedores();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = negocioProveedor.ObtenerTablaSesion();

            foreach (DataRow dr in dt.Rows)

            {
                ImgLogo.ImageUrl = dr["pro_ruta_imagen"].ToString();
                TxtDni.Text = dr["pro_dni"].ToString();
                TxtNombre.Text = dr["pro_razon_social"].ToString();
                TxtDireccion.Text = dr["pro_direccion"].ToString();
                TxtEmail.Text = dr["pro_email"].ToString();
                TxtTelefono.Text = dr["pro_telefono"].ToString();
                TxtContacto.Text = dr["pro_nombre_contacto"].ToString();
                TxtEstados.Text = dr["pro_codigo_estado"].ToString();

            }
        }
    }
}