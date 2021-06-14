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
            cargartabla();
           
        }


        public void cargartabla()
        {
            DataTable dt = (DataTable)Session["carrito"];
            GridView1.DataSource = dt;
            GridView1.DataBind();

            CantidadProductos();
            MontoPagar();
          
        }

        protected void CantidadProductos()
        {
            LbcantidadProductos.Text = Convert.ToString(GridView1.Rows.Count);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
            int cantidadFilas = GridView1.Rows.Count;
            for (int x = 0; x < cantidadFilas; x++)
            {
                monto += Convert.ToDecimal(GridView1.Rows[x].Cells[6].Text);
            }
            Lbmonto.Text = "$" + monto;

            //foreach(GridViewRow fila in GridView1.Rows)
            //{

            //    monto += Convert.ToDecimal(((Label)fila.Cells[3].FindControl("Label4")).Text);
            //    //((Label)fila.Cells["Peso"].FindControl("Lbl_Peso")).Text)

            //}
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["carrito"] = null;
            cargartabla();
        }
    }

    /*    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

        }*/


}
