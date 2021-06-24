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
    public partial class DetalleArticulo : System.Web.UI.Page
    {

        NegocioArticulos nega = new NegocioArticulos();
        Articulos articu = new Articulos();
        private string detalleArt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ArticuloSelec"] != null)
            {
               // Label1.Text = Session["ArticuloSelec"].ToString();
                CargarAtributos();
            }
            else
            {
                Label1.Text = "Esta vacia";
            }
            

        }

        protected void CargarAtributos()
        {
            detalleArt = Session["ArticuloSelec"].ToString();

            Lbnombre.Text = detalleArt.Split('@')[1];
            Lbdetalle.Text = detalleArt.Split('@')[2];
            Lbcategoria.Text = detalleArt.Split('@')[8];
            Lbmarca.Text = detalleArt.Split('@')[7];
            Lbprecio.Text = detalleArt.Split('@')[4];
            ImageButton2.ImageUrl = detalleArt.Split('@')[5];

        }

        protected void Btmas_Click(object sender, EventArgs e)
        {
            ValorDefecto();
            
            int cantida = Convert.ToInt32(tbcantidad.Text);

            tbcantidad.Text = Convert.ToString(cantida + 1);
        }

        protected void Btmenos_Click(object sender, EventArgs e)
        {

            ValorDefecto();

            int cantida = Convert.ToInt32(tbcantidad.Text) - 1;

            if (cantida >= 0)
            {
                tbcantidad.Text = Convert.ToString(cantida);
            }
            
        }


        protected void btcarrito_Click(object sender, EventArgs e)
        {
           
            if (RealizarAccion())
            {
                articu.SetCodigo(Convert.ToInt32(detalleArt.Split('@')[0]));
                articu.SetNombre(Lbnombre.Text);
                articu.SetDescripcion(Lbdetalle.Text);
                articu.SetPrecioLista(Convert.ToDecimal(Lbprecio.Text));
                Int16 cantidad = Convert.ToInt16(tbcantidad.Text);
                nega.agregarfilacarrito(articu, cantidad);

                ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Se agrego al carrito!','success')", true);
            }



        }
        
        protected void BtcomprarAhora_Click(object sender, EventArgs e)
        {
            if(RealizarAccion())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('se puede comprar!','success')", true);
            }
           
        }

        protected bool RealizarAccion()
        {
            ValorDefecto();

            if (tbcantidad.Text != "0")
            {
                //Label2.Text = Convert.ToString(nega.ObtenerStockArticulo(detalleArt.Split('@')[0]));

                if (nega.ControlDeStock(Convert.ToInt32(tbcantidad.Text), detalleArt.Split('@')[0]))
                {
                    
                    return true;

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Cantidad no disponible!','warning')", true);
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Ingrese la cantidad!','info')", true);

            }

            return false;
        }

        protected void ValorDefecto()
        {
            if (string.IsNullOrEmpty(tbcantidad.Text.Trim())) tbcantidad.Text = "0";
        }
    }
}