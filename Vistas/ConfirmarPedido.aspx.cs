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
    public partial class ConfirmarPedido : System.Web.UI.Page
    {
        private readonly NegocioVentas negocioVentas = new NegocioVentas();
        private readonly NegocioMetodoPago negocioMetodoPago = new NegocioMetodoPago();
        private readonly NegocioDetalleVentas negocioDetalleVentas = new NegocioDetalleVentas();
        private readonly NegocioArticulos negocioArticulos = new NegocioArticulos();

        Usuarios objUsuario = new Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar sesion
            if (Session["User"] == null)
            {
                Response.Redirect("home.aspx");
            }
            // Cargo datos
            if (!Page.IsPostBack)
            {
            DataTable dt = (DataTable)Session["User"];
            objUsuario = NegocioUsuarios.getInstance().LeerTablaUsuario(dt);
                RellenarDatos();
            }

        }

        private void RellenarDatos()
        {
            txtDni.Enabled = false;
            txtUsername.Enabled = false;
            txtName.Enabled = false;
            txtLastname.Enabled = false;
            txtCodigo_Postal.Enabled = false;
            txtDireccion.Enabled = false;
            txtDni.Text = objUsuario.Dni;
            txtUsername.Text = objUsuario.Username;
            txtName.Text = objUsuario.Nombre;
            txtLastname.Text = objUsuario.Apellido;
            txtCodigo_Postal.Text = objUsuario.Codigo_Postal;
            txtDireccion.Text = objUsuario.Direccion;

            txtDni.Text = objUsuario.Dni;

            CargarMetodosPago();

            DataTable dt = (DataTable)Session["carrito"];
            GvCarro.DataSource = dt;
            GvCarro.DataBind();

            // Renderiza información en pantalla
            //cant productos
            lblCantProductos.Text = CantidadProductos().ToString();
            // monto pagar
            lblMontoPagar.Text = "$ "+MontoPagar().ToString();

        }

        private int CantidadProductos()
        {
            int cant = 0;
            int cantidadFilas = GvCarro.Rows.Count;
            for (int i = 0; i < cantidadFilas; i++)
            {
                cant += Convert.ToInt32(GvCarro.Rows[i].Cells[4].Text);
            }
            return cant;
        }

        private decimal MontoPagar()
        {
            decimal monto = 0;
            int cantidadFilas = GvCarro.Rows.Count;
            for (int i = 0; i < cantidadFilas; i++)
            {
                monto += Convert.ToDecimal(GvCarro.Rows[i].Cells[5].Text);
            }
            return monto;

        }

        private void CargarMetodosPago()
        {
            DdlPago.Items.Add(new ListItem("- Elegir -", "-1"));
            DdlPago.Items[0].Selected = true;
            DdlPago.Items[0].Attributes["disabled"] = "disabled";
            DataTable dt = negocioMetodoPago.ObtenerMetodos();
            foreach (DataRow dr in dt.Rows)
            {
                DdlPago.Items.Add(new ListItem(dr["mp_nombre"].ToString(), dr["mp_codigo"].ToString()));
            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            // VALIDAR STOCK
            bool stockDisponible = negocioArticulos.ValidarStockCarrito();
            if(stockDisponible)
            {
                // REALIZAR COMPRA
                Ventas objVentas = new Ventas();
                MediosPago objMedioPago = new MediosPago();
                DataTable dt = (DataTable)Session["User"];
                objUsuario = NegocioUsuarios.getInstance().LeerTablaUsuario(dt);


                // Settea valores
                objMedioPago.SetCodigo(DdlPago.SelectedIndex);
                objVentas.SetMedioPago(objMedioPago);
                objVentas.SetUsuario(objUsuario);
                objVentas.SetTotalFacturado(MontoPagar());

                // Genera una nueva venta.
                int venta_cod = negocioVentas.NuevaVenta(objVentas);

                // Genera los detalles de ventas correspondientes.
                negocioDetalleVentas.GenerarDetallesVentas(venta_cod);

                //MOSTRAR MODAL
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModal').modal('show');</script>", false);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Stock no disponible!','warning')", true);
            }
        }


        protected void BtnSalirPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect("perfil.aspx");
        }
    }
}