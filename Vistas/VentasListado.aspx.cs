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
    public partial class VentasListado : System.Web.UI.Page
    {

        private readonly NegocioVentas negocioVentas = new NegocioVentas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarGridView();
            }
        }
        private void CargarGridView()
        {
            GrdVentas.DataSource = negocioVentas.ObtenerVentas();
            GrdVentas.DataBind();
        }
        protected void GrdVentas_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
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

        protected void GrdVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}