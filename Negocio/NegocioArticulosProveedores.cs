using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Dao;
using Entidades;
using System.Data;
using System.Web.SessionState;
namespace Negocio
{
	public class NegocioArticulosProveedores : System.Web.UI.Page
	{
		private readonly DaoArticulosProveedores daoArticuloProveedor = new DaoArticulosProveedores();
		public DataTable ObtenerArticulosProveedores()
		{
			return daoArticuloProveedor.ObtenerArticulosProveedores();
		}

		#region FILTRADO DE CONTROL STOCKS

		public DataTable filtrarConsultaControlStock(string codProv, string nomProv, string codArt, string nomArt)
		{
			string ClausulaSQLConsulta = "";
			if (!codProv.Equals("0"))
			{
				ConstruirClausulaSQL("axp_proveedor_dni", codProv, ref ClausulaSQLConsulta);
			}
			if (!nomProv.Equals(""))
			{
				ConstruirClausulaSQL("pro_razon_social", nomProv, ref ClausulaSQLConsulta);
			}
			if (!codArt.Equals("0"))
			{
				ConstruirClausulaSQL("axp_articulo_codigo", codArt, ref ClausulaSQLConsulta);
			}
			if (!nomArt.Equals(""))
			{
				ConstruirClausulaSQL("art_nombre", nomArt, ref ClausulaSQLConsulta);
			}
			return daoArticuloProveedor.filtrarConsultaControlStock(ref ClausulaSQLConsulta);
		}

		private void ConstruirClausulaSQL(string NombreCampo, string Valor, ref string Clausula)
		{
			string d1 = ""; // Delimitador 1
			string d2 = ""; // Delimitador 2
			if (Clausula == "")
			{
				Clausula = Clausula + " WHERE ";
			}
			else
			{
				Clausula = Clausula + " AND ";
			}
			// USO UN SWITCH
			switch (NombreCampo)
			{
				case "axp_proveedor_dni":
					d1 = " = ";
					d2 = "";
					break;
				case "pro_razon_social":
					d1 = " LIKE '%";
					d2 = "%'";
					break;
				case "axp_articulo_codigo":
					d1 = " = ";
					d2 = "";
					break;
				case "art_nombre":
					d1 = " LIKE '%";
					d2 = "%'";
					break;
			}
			// CONSTRUYO LA CLAUSULA
			Clausula = Clausula + NombreCampo + d1 + Valor + d2;
		}
		#endregion

		#region AGREGAR STOCK
		// RETORNA TRUE --> NO AGREGO STOCK
		// RETORNA FALSE --> AGREGO EL ARTICULO
		public bool agregarStock(ArticulosProveedores articuloProveedor)
		{
			int agregar = daoArticuloProveedor.agregarStock(articuloProveedor);
			if (agregar == 1)
			{
				return true;
			}

			else
			{
				return false;
			}
		}
        #endregion

        #region USO SESION PARA MODIFICAR STOCK. SI NO EXISTE, CREA LA SESION
        private void CrearSesionArticuloProveedor()
		{
			if (Session["SesionArticuloProveedor"] == null)
			{
				ArticulosProveedores articuloProveedor = new ArticulosProveedores();
				Session["SesionArticuloProveedor"] = articuloProveedor;
			}
		}

		// RETORNA LA SESION ARTICULOPROVEEDOR. EN CASO DE QUE LA SESION SEA NULL RETORNA UN ARTICULOPROVEEDOR NULL
		public ArticulosProveedores ObtenerSesionArticuloProveedor()
		{
			ArticulosProveedores articuloProveedor = new ArticulosProveedores();
			if (Session["SesionArticuloProveedor"] != null)
			{
				articuloProveedor = (ArticulosProveedores)Session["SesionArticuloProveedor"];
			}
			return articuloProveedor;
		}
		// AGREGA UN ARTICULOPROVEEDOR A LA SESION
		public void AgregarArticuloProveedorEnLaSesion(ArticulosProveedores articuloProveedor)
		{
			EliminarSesionArticulProveedor();
			CrearSesionArticuloProveedor();
			ArticulosProveedores articuloProveedorSession = ObtenerSesionArticuloProveedor();
			//
			Articulos articulo = new Articulos();
			articulo.SetCodigo(articuloProveedor.GetArticulo().GetCodigo());
			articulo.SetNombre(articuloProveedor.GetArticulo().GetNombre());
			articuloProveedorSession.SetArticulo(articulo);
			//
			Proveedores proveedor = new Proveedores();
			proveedor.SetDni(articuloProveedor.GetProveedor().GetDni());
			proveedor.SetRazonSocial(articuloProveedor.GetProveedor().GetRazonSocial());
			articuloProveedorSession.SetProveedor(proveedor);
			//
			articuloProveedorSession.SetPrecioUnitario(articuloProveedor.GetPreciounitario());
			articuloProveedorSession.SetStockActual(articuloProveedor.GetStockActual());
		}

		// ELIMINA LA SESION CATEGORIA
		private void EliminarSesionArticulProveedor()
		{
			if (Session["SesionArticuloProveedor"] != null)
			{
				Session["SesionArticuloProveedor"] = null;
			}
		}
		#endregion

	}
}