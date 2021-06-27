using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Vistas
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checkeo si el usuario esta autorizado a entrar a el link
            if (Session["User"] == null)

            {
                Response.Redirect("home.aspx");
            }
            else
            {
            cargartabla();

            }

           
        }


        public void cargartabla()
        {
            DataTable dt = (DataTable)Session["carrito"];
            GvCarro.DataSource = dt;
            GvCarro.DataBind();

            // Renderiza información en pantalla
            CantidadProductos();
            LbcantidadProductos.Text = CantidadProductos().ToString();
            MontoPagar();
          
        }

        protected int CantidadProductos()
        {
            return (GvCarro.Rows.Count);

        }

        protected void GvCarro_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "eventoEliminar") {
                int fila = Convert.ToInt32(e.CommandArgument);

                DataTable dt = (DataTable)Session["carrito"];

                    foreach (DataRow f in dt.Rows)
                    {
                        if (Convert.ToInt32(f) == fila)
                        {
                            f.Delete();
                        }

                    }

                    Session["carrito"] = dt;

                    cargartabla();

                }
            }

        protected void GvCarro_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int indice =e.RowIndex;
            EliminarArticulo((DataTable)Session["carrito"], indice);
            cargartabla();
        }

        protected void EliminarArticulo(DataTable tb, int indice)
        {
            tb.Rows[indice].Delete();
        }

        protected void MontoPagar()
        {
            decimal monto = 0;
            int cantidadFilas = GvCarro.Rows.Count;
            for (int x = 0; x < cantidadFilas; x++)
            {
                monto += Convert.ToDecimal(GvCarro.Rows[x].Cells[6].Text);
            }
            Lbmonto.Text = "$" + monto;

        }

        protected void BtnEliminarCarro_Click(object sender, EventArgs e)
        {
            Session["carrito"] = null;
            cargartabla();
        }

        protected void BtnConfirmarCarro_Click(object sender, EventArgs e)
        {
            if(CantidadProductos() > 0)
            {
                // HAY PRODUCTOS EN EL CARRO.
                Response.Redirect("ConfirmarPedido.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('No se han seleccionado artículos!','warning')", true);
            }
        }
    }

}
