using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entidades
{
	public class DetalleVenta
	{
		private Ventas venta;
		private int dt_numero_linea;
		private Articulos articulo;
		private int dt_cantidad_unidades;
		private decimal dt_precio_unitario;
		//
		public DetalleVenta() { }
		//
		public Ventas GetVenta()
		{
			return this.venta;
		}
		public int GetNumeroLinea()
		{
			return this.dt_numero_linea;
		}
		public Articulos GetArticulo()
		{
			return this.articulo;
		}
		public int GetCantidadUnidades()
		{
			return this.dt_cantidad_unidades;
		}
		public decimal GetPrecioUnitario()
		{
			return this.dt_precio_unitario;
		}
		//
		public void SetVenta(Ventas venta)
		{
			this.venta = venta;
		}
		public void SetNumeroLinea(int dt_numero_linea)
		{
			this.dt_numero_linea = dt_numero_linea;
		}
		public void SetArticulo(Articulos articulo)
		{
			this.articulo = articulo;
		}
		public void SetCantidadUnidades(int dt_cantidad_unidades)
		{
			this.dt_cantidad_unidades = dt_cantidad_unidades;
		}
		public void SetPrecioUnitario(decimal dt_precio_unitario)
		{
			this.dt_precio_unitario = dt_precio_unitario;
		}
	}
}