using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class ArticulosProveedores
	{
		private int axp_codigo;
		private Articulos articulo;
		private Proveedores proveedor;
		private int axp_stock_actual;
		private int axp_stock_anterior;
		private int axp_entrada;
		private int axp_salida;
		private Decimal axp_precio_unitario;

		public ArticulosProveedores() { }

		public int GetCodigo()
		{
			return this.axp_codigo;
		}
		public Articulos GetArticulo()
		{
			return this.articulo;
		}
		public Proveedores GetProveedor()
		{
			return this.proveedor;
		}
		public int GetStockActual()
		{
			return this.axp_stock_actual;
		}
		public int GetStockAnterior()
		{
			return this.axp_stock_anterior;
		}
		public int GetEntrada()
		{
			return this.axp_entrada;
		}
		public int GetSalida()
		{
			return this.axp_salida;
		}
		public Decimal GetPreciounitario()
		{
			return this.axp_precio_unitario;
		}

		public void SetCodigo(int axp_codigo)
		{
			this.axp_codigo = axp_codigo;
		}
		public void SetArticulo(Articulos articulo)
		{
			this.articulo = articulo;
		}
		public void SetProveedor(Proveedores proveedor)
		{
			this.proveedor = proveedor;
		}
		public void SetStockActual(int axp_stock_actual)
		{
			this.axp_stock_actual = axp_stock_actual;
		}
		public void SetStockAnterior(int axp_stock_anterior)
		{
			this.axp_stock_anterior = axp_stock_anterior;
		}
		public void SetEntrada(int axp_entrada)
		{
			this.axp_entrada = axp_entrada;
		}
		public void SetSalida(int axp_salida)
		{
			this.axp_salida = axp_salida;
		}
		public void SetPrecioUnitario(Decimal axp_precio_unitario)
		{
			this.axp_precio_unitario = axp_precio_unitario;
		}
	}
}