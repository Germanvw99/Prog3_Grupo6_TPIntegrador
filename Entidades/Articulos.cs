using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class Articulos
	{
		private int art_codigo;
		private Marcas art_marca_codigo;
		private Categorias categoria_codigo;
		private string art_nombre;
		private string art_descripcion;
		private int art_punto_pedido;
		private decimal art_precio_lista;
		private string art_ruta_imagen;
		private Estados estado;

		public Articulos() { }

		//
		public int GetCodigo()
		{
			return art_codigo;
		}
		public Marcas GetMarca()
		{
			return art_marca_codigo;
		}
		public Categorias GetCategoria()
		{
			return categoria_codigo;
		}
		public string GetNombre()
		{
			return art_nombre;
		}
		public string GetDescripcion()
		{
			return art_descripcion;
		}
		public int GetPuntoPedido()
		{
			return art_punto_pedido;
		}
		public decimal GetPrecioLista()
		{
			return art_precio_lista;
		}
		public string GetRutaImagen()
		{
			return art_ruta_imagen;
		}
		public Estados GetEstado()
		{
			return estado;
		}
		//
		public void SetCodigo(int art_codigo)
		{
			this.art_codigo = art_codigo;
		}
		public void SetMarca(Marcas art_marca_codigo)
		{
			this.art_marca_codigo = art_marca_codigo;
		}
		public void SetCategoria(Categorias categoria_codigo)
		{
			this.categoria_codigo = categoria_codigo;
		}
		public void SetNombre(string art_nombre)
		{
			this.art_nombre = art_nombre;
		}
		public void SetDescripcion(string art_descripcion)
		{
			this.art_descripcion = art_descripcion;
		}
		public void SetPuntoPedido(int art_punto_pedido)
		{
			this.art_punto_pedido = art_punto_pedido;
		}
		public void SetPrecioLista(decimal art_precio_lista)
		{
			this.art_precio_lista = art_precio_lista;
		}
		public void SetRutaImagen(string art_ruta_imagen)
		{
			this.art_ruta_imagen = art_ruta_imagen;
		}
		public void SetEstado(Estados estado)
		{
			this.estado = estado;
		}
	}
}