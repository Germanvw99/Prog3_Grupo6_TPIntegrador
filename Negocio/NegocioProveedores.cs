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
	public class NegocioProveedores : System.Web.UI.Page
	{
		private readonly DaoProveedores daoProveedor = new DaoProveedores();

		public DataTable ObtenerProveedores()
		{
			return daoProveedor.ObtenerProveedores();
		}

		#region SESION PROVEEDOR

		public void AgregarProveedorEliminar(Proveedores proveedor)
		{
			Session["SesionProveedorEliminar"] = proveedor;
		}

		public Proveedores ObtenerProveedorEliminar()
		{
			Proveedores proveedor = new Proveedores();
			if (Session["SesionProveedorEliminar"] != null)
			{
				proveedor = (Proveedores)Session["SesionProveedorEliminar"];
			}
			return proveedor;
		}

		//USO SESION PARA MODIFICAR PROVEEDORES. SI NO EXISTE, CREA LA SESION
		private void CrearSesionProveedor()
		{
			if (Session["SesionProveedor"] == null)
			{
				Proveedores proveedor = new Proveedores();
				Session["SesionProveedor"] = proveedor;
			}
		}

		// RETORNA LA SESION PROVEEDOR. EN CASO DE QUE LA SESION SEA NULL RETORNA UN PROVEEDOR NULL
		public Proveedores ObtenerSesionProveedor()
		{
			Proveedores proveedor = new Proveedores();
			if (Session["SesionProveedor"] != null)
			{
				proveedor = (Proveedores)Session["SesionProveedor"];
			}
			return proveedor;
		}
		// AGREGA UNA PROVEEDOR A LA SESION
		public void AgregarProveedorEnLaSesion(Proveedores proveedor)
		{
			EliminarSesionProveedor();
			CrearSesionProveedor();
			Proveedores proveedorSesion = ObtenerSesionProveedor();
			proveedorSesion.SetDni(proveedor.GetDni());
			proveedorSesion.SetRazonSocial(proveedor.GetRazonSocial());
			proveedorSesion.SetDireccion(proveedor.GetDireccion());
			proveedorSesion.SetEmail(proveedor.GetEmail());
			proveedorSesion.SetTelefono(proveedor.GetTelefono());
			proveedorSesion.SetNombreContacto(proveedor.GetNombreContacto());
			proveedorSesion.SetRutaImagen(proveedor.GetRutaImagen());
			Estados estado = new Estados();
			estado.SetNombre(proveedor.GetEstado().GetNombre());
			estado.SetCodigo(proveedor.GetEstado().GetCodigo());
			proveedorSesion.SetEstado(estado);
		}

		// ELIMINA LA SESION CATEGORIA
		private void EliminarSesionProveedor()
		{
			if (Session["SesionProveedor"] != null)
			{
				Session["SesionProveedor"] = null;
			}
		}

		#endregion

		#region AGREGAR PROVEEDOR
		// RETORNA 0 --> NO AGREGO EL PROVEEDOR
		// RETORNA 1 --> AGREGO EL PROVEEDOR
		// RETORNA 2 --> EL PROVEEDOR YA EXISTE, NO FUE AGREGADO
		public int agregarProveedor(Proveedores proveedor)
		{
			if (buscarProveedorPorDni(proveedor) == 0)
			{
				int agregar = daoProveedor.agregarProveedor(proveedor);
				if (agregar == 1) return 1;
				else return 0;
			}
			else
			{
				return 2;
			}
		}
		//BUSCAR MARCA POR NOMBRE
		private int buscarProveedorPorDni(Proveedores proveedor)
		{
			return daoProveedor.buscarProveedorPorDni(proveedor);
		}

		#endregion

		#region MODIFICAR PROVEEDOR

		//USADO PARA MODIFICAR PROVEEDOR
		//BUSCAR PROVEEDOR POR NOMBRE Y CODIGO DE PROVEEDOR NO COINCIDENTE PARA EVITAR QUE EXISTAN PROVEEDORES CON EL MISMO NOMBRE
		private int buscarProveedorPorNombreCodigoNoCoincidente(Proveedores proveedor)
		{
			return daoProveedor.buscarProveedorPorNombreCodigoNoCoincidente(proveedor);
		}

		//MODIFICAR PROVEEDOR
		public int modificarProveedor(Proveedores proveedor)
		{
			if (buscarProveedorPorNombreCodigoNoCoincidente(proveedor) == 0)
			{
				int agregar = daoProveedor.modificarProveedor(proveedor);
				if (agregar == 1) return 1;
				else return 0;
			}
			else
			{
				return 2;
			}
		}

		#endregion

		#region ELIMINAR PROVEEDOR

		//ELIMINAR MARCA
		public bool eliminarProveedor(Proveedores proveedor)
		{
			int eliminar = daoProveedor.eliminarProveedor(proveedor);
			if (eliminar == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		#endregion

		//FILTRADO DE PROVEEDORES
		public DataTable filtrarConsultaProveedor(string Codigo, string Nombre, string codEstado)
		{
			string ClausulaSQLConsulta = "";
			if (!Codigo.Equals(""))
			{
				ConstruirClausulaSQL("pro_dni", Codigo, ref ClausulaSQLConsulta);
			}
			if (!Nombre.Equals(""))
			{
				ConstruirClausulaSQL("pro_razon_social", Nombre, ref ClausulaSQLConsulta);
			}
			if (!codEstado.Equals("0"))
			{
				ConstruirClausulaSQL("pro_codigo_estado", codEstado, ref ClausulaSQLConsulta);
			}
			return daoProveedor.filtrarConsultaProveedor(ref ClausulaSQLConsulta);
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
				case "pro_dni":
					d1 = " = ";
					d2 = "";
					break;
				case "pro_codigo_estado":
					d1 = " = ";
					d2 = "";
					break;
				case "pro_razon_social":
					d1 = " LIKE '%";
					d2 = "%'";
					break;
			}
			// CONSTRUYO LA CLAUSULA
			Clausula = Clausula + NombreCampo + d1 + Valor + d2;
		}

		public bool ValidarContenido(ref string mensaje,string razonS, string dni, string direcc, string email, string telefo, string contac, string estado)
        {
			if (string.IsNullOrWhiteSpace(razonS.Trim())) mensaje += "Razon social";

			try
			{
				if (string.IsNullOrWhiteSpace(dni.Trim())) { mensaje += "-Dni/Cuil"; }
				else if (int.Parse(dni.Trim()) < 0) mensaje += "-Dni/Cuil invalido";
				else if (!(dni.Trim().Count() >= 8 && dni.Trim().Count() <= 11)) mensaje += "-Dni/Cuil invalido";
			}
			catch (Exception)
			{
				mensaje += "-Dni/Cuil invalido";
			}

			if (string.IsNullOrWhiteSpace(direcc.Trim())) mensaje += "-Dirección";
			if (string.IsNullOrWhiteSpace(email.Trim())) mensaje += "-mail";

			try
			{
				if (string.IsNullOrWhiteSpace(telefo.Trim())) { mensaje += "-Teléfono"; }
				//else if (telefo.Trim().Count() != 11) mensaje += "-Teléfono invalido (11 digitos)"; 
				else if (int.Parse(telefo.Trim()) < 0) mensaje += "-Telefono invalido";
			}
			catch (Exception)
			{
				mensaje += "-Telefono invalido";
			}

			if (string.IsNullOrWhiteSpace(contac.Trim())) mensaje += "-Contacto";
			if (estado == "0") mensaje += "-Estado";

			if (string.IsNullOrEmpty(mensaje))
			{
				return true;
			}

			return false;
		}
	}
}