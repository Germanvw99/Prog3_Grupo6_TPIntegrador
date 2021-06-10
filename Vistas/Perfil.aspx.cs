using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Checkeo si el usuario esta autorizado a entrar a el link
            if (Session["User"] == null)
            {
                Response.Redirect("home.aspx");
            }

            if (!IsPostBack)
            {
                // Se obtiene la información del usuario
                DataTable dt = (DataTable)Session["User"];

                Usuarios objUsuario = NegocioUsuarios.getInstance().LeerTablaUsuario(dt);

                // Se rellena la interfaz con la información del usuario
                lblUsername.Text = objUsuario.Username;

                // Rellena los txt del formulario
                txtDni.Text = objUsuario.Dni;
                txtUsername.Text = objUsuario.Username;
                txtNombre.Text = objUsuario.Nombre;
                txtApellido.Text = objUsuario.Apellido;
                txtEmail.Text = objUsuario.Email;
                txtTelefono.Text = objUsuario.Telefono;
                txtDireccion.Text = objUsuario.Direccion;
                txtCodigo_Postal.Text = objUsuario.Codigo_Postal;
                txtCiudad.Text = objUsuario.Ciudad;
                txtProvincia.Text = objUsuario.Provincia;

                // Estado de los txt
                EsconderUI();

            }
        }

        protected void btnActivarForm_Click(object sender, EventArgs e)
        {
            // Activa el form
            HabilitarUI();
        }

        protected void btnEnviarForm_Click(object sender, EventArgs e)
        {
            // Envia form para modificar usuario
            bool editado = NegocioUsuarios.getInstance().EditUser(GetEntity());

            if (editado)
            {
                EsconderUI();
                lblNotificacion.Text = "Perfil editado!";

            }
            else
            {
                lblNotificacion.Text = "No se pudo editar el perfil!";
            }
        }

        private Usuarios GetEntity()
        {

            Usuarios objUsuario = new Usuarios();
            objUsuario.Dni = txtDni.Text;
            objUsuario.Nombre = txtNombre.Text;
            objUsuario.Apellido = txtApellido.Text;
            objUsuario.Email = txtEmail.Text;
            objUsuario.Telefono = txtTelefono.Text;
            objUsuario.Direccion = txtDireccion.Text;
            objUsuario.Codigo_Postal = txtCodigo_Postal.Text;
            objUsuario.Ciudad = txtCiudad.Text;
            objUsuario.Provincia = txtProvincia.Text;


            return objUsuario;
        }

        private void EsconderUI()
        {
            lblNotificacion.Text = "";
            txtDni.Enabled = false;
            txtUsername.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            txtCodigo_Postal.Enabled = false;
            txtCiudad.Enabled = false;
            txtProvincia.Enabled = false;

            btnEnviarForm.Enabled = false;
        }

        private void HabilitarUI()
        {
            lblNotificacion.Text = "";
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            txtCodigo_Postal.Enabled = true;
            txtCiudad.Enabled = true; ;
            txtProvincia.Enabled = true;

            btnEnviarForm.Enabled = true;
        }

    }
}