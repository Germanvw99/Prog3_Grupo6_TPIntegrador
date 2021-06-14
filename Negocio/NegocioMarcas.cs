using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;
using System.Web.SessionState;
namespace Negocio {
	public class NegocioMarcas: System.Web.UI.Page {
		private readonly DaoMarcas daoMarca = new Dao.DaoMarcas();
		public DataTable ObtenerMarcas() {
			return daoMarca.ObtenerMarcas();
		}

		#region SESION MARCAS

		public void AgregarMarcaEliminar(Marcas marca)
        {
				Session["SesionMarcaEliminar"] = marca;
		}

		public Marcas ObtenerMarcaEliminar()
		{
			Marcas marca = new Marcas();
			if (Session["SesionMarcaEliminar"] != null)
			{
				marca = (Marcas)Session["SesionMarcaEliminar"];
			}
			return marca;
		}

		//USO SESION PARA MODIFICAR MARCAS. SI NO EXISTE, CREA LA SESION
		private void CrearSesionMarca() {
			if (Session["SesionMarca"] == null) {
				Marcas marca = new Marcas();
				Session["SesionMarca"] = marca;
			}
		}

		// RETORNA LA SESION MARCA. EN CASO DE QUE LA SESION SEA NULL RETORNA UNA MARCA NULL
		public Marcas ObtenerSesionMarca() {
			Marcas marca = new Marcas();
			if (Session["SesionMarca"] != null) {
				marca = (Marcas) Session["SesionMarca"];
			}
			return marca;
		}
		// AGREGA UNA MARCA A LA SESION
		public void AgregarMarcaEnLaSesion(Marcas Marca) {
			EliminarSesionMarca();
			CrearSesionMarca();
			Marcas marcaSesion = ObtenerSesionMarca();
			marcaSesion.SetCodigo(Marca.GetCodigo());
			marcaSesion.SetNombre(Marca.GetNombre());
			marcaSesion.SetDescripcion(Marca.GetDescripcion());
			marcaSesion.SetRutaImagen(Marca.GetRutaImagen());
			Estados estado = new Estados();
			estado.SetNombre(Marca.GetEstado().GetNombre());
			estado.SetCodigo(Marca.GetEstado().GetCodigo());
			marcaSesion.SetEstado(estado);
		}

		// ELIMINA LA SESION MARCA
		private void EliminarSesionMarca() {
			if (Session["SesionMarca"] != null) {
				Session["SesionMarca"] = null;
			}
		}

		#endregion






		//AGREGAR MARCA
		// RETORNA 0 --> NO AGREGO LA MARCA
		// RETORNA 1 --> AGREGO LA MARCA
		// RETORNA 2 --> LA MARCA YA EXISTE, NO FUE AGREGADA
		public int agregarMarca(Marcas marca) {
			if (buscarMarcaPorNombre(marca) == 0) {
				int agregar = daoMarca.agregarMarca(marca);
				if (agregar == 1) return 1;
				else return 0;
			}
			else {
				return 2;
			}
		}
		//BUSCAR MARCA POR NOMBRE
		private int buscarMarcaPorNombre(Marcas marca) {
			return daoMarca.buscarMarcaPorNombre(marca);
		}

		//BUSCAR MARCA POR NOMBRE Y CODIGO DE MARCA NO COINCIDENTE PARA EVITAR QUE EXISTAN MARCAS CON EL MISMO NOMBRE
		private int buscarMarcaPorNombreCodigoNoCoincidente(Marcas marca) {
			return daoMarca.buscarMarcaPorNombreCodigoNoCoincidente(marca);
		}

		//MODIFICAR MARCA
		public int modificarMarca(Marcas marca) {
			if (buscarMarcaPorNombreCodigoNoCoincidente(marca) == 0) {
				int agregar = daoMarca.modificarMarca(marca);
				if (agregar == 1) return 1;
				else return 0;
			}
			else {
				return 2;
			}
		}

		//ELIMINAR MARCA
		public bool eliminarMarca(Marcas marca) {
			int eliminar = daoMarca.eliminarMarca(marca);
			if (eliminar == 1) {
				return true;
			}
			else {
				return false;
			}
		}
	}
}