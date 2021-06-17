using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;
using System.Web.SessionState;
namespace Negocio
{
	public class NegocioVentas : System.Web.UI.Page
	{
		private readonly DaoVentas daoVentas = new DaoVentas();
		public DataTable ObtenerVentas()
		{
			return daoVentas.ObtenerVentas();
		}
		//USO SESION PARA VER VENTAS
		//SI NO EXISTE, CREA LA SESION
		public void CrearSesion()
		{
			if (Session["TablaSesionVentas"] == null)
			{
				Session["TablaSesionVentas"] = CrearTablaSesion();
			}
		}
		private DataTable CrearTablaSesion()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("ven_codigo", typeof(string));
			dt.Columns.Add("ven_usuarios_dni", typeof(string));
			dt.Columns.Add("usu_apellido", typeof(string));
			dt.Columns.Add("usu_nombre", typeof(string));
			dt.Columns.Add("usu_direccion", typeof(string));
			dt.Columns.Add("usu_ciudad", typeof(string));
			dt.Columns.Add("ven_medio_pago_codigo", typeof(string));
			dt.Columns.Add("mp_nombre", typeof(string));
			dt.Columns.Add("ven_fecha", typeof(string));
			dt.Columns.Add("ven_fecha_requerida", typeof(string));
			dt.Columns.Add("ven_fecha_envio", typeof(string));
			dt.Columns.Add("ven_total_facturado", typeof(string));
			dt.Columns.Add("ven_codigo_estado", typeof(string));
			dt.Columns.Add("est_nombre", typeof(string));
			return dt;
		}
		// RETORNA UNA TABLA DE LA SESION.
		// EN CASO DE QUE LA SESION SEA NULL RETORNA UNA TABLA NULL
		public DataTable ObtenerTablaSesionVentas()
		{
			DataTable dt = new DataTable();
			if (Session["TablaSesionVentas"] != null)
			{
				dt = (DataTable)Session["TablaSesionVentas"];
			}
			return dt;
		}
		// SI NO EXISTE VEN_CODIGO AGREGA LA VENTA A LA SESION
		// RETORNA TRUE SI AGREGO
		// RETORNA FALSE SI NO AGREGO
		public bool AgregarVentaEnLaSesion(Ventas venta)
		{
			if (VerificarItem(venta.GetCodigo()))
			{
				AgregarVenta(venta);
				return true;
			}
			else
			{
				return false;
			}
		}
		// VERIFICA LA EXISTENCIA DEL VEN_CODIGO EN LA SESION
		// SI EL VEN_CODIGO EXISTE RETORNA FALSE
		// SI EL VEN_CODIGO NO EXISTE RETORNA TRUE
		private bool VerificarItem(int ven_codigo)
		{
			DataTable dt = ObtenerTablaSesionVentas();
			foreach (DataRow row in dt.Rows)
			{
				if (Int32.Parse(row["ven_codigo"].ToString()) == ven_codigo)
				{
					return false;
				}
			}
			return true;
		}
		private void AgregarVenta(Ventas venta)
		{
			DataTable dt = ObtenerTablaSesionVentas();
			DataRow dr = dt.NewRow();
			dr["ven_codigo"] = venta.GetCodigo();
			dr["ven_usuarios_dni"] = venta.GetUsuario().Dni;
			dr["usu_apellido"] = venta.GetUsuario().Apellido;
			dr["usu_nombre"] = venta.GetUsuario().Nombre;
			dr["usu_direccion"] = venta.GetUsuario().Direccion;
			dr["usu_ciudad"] = venta.GetUsuario().Ciudad;
			dr["ven_medio_pago_codigo"] = venta.GetMedioPago().GetCodigo();
			dr["mp_nombre"] = venta.GetMedioPago().GetNombre();
			dr["ven_fecha"] = venta.GetFecha();
			//dr["ven_fecha_requerida"]
			//dr["ven_fecha_envio"]
			dr["ven_total_facturado"] = venta.GetTotalFacturado();
			dr["ven_codigo_estado"] = venta.GetEstado().GetCodigo();
			dr["est_nombre"] = venta.GetEstado().GetNombre();
			dt.Rows.Add(dr);
		}
		public bool EliminarSesion()
		{
			if (Session["TablaSesionVentas"] != null)
			{
				Session["TablaSesionVentas"] = null;
				return true;
			}
			return false;
		}
	}
}