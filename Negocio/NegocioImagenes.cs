using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Drawing;

namespace Negocio
{
	public class NegocioImagenes : System.Web.UI.Page
	{
		static string globalPath = HttpContext.Current.Server.MapPath("/Imagenes/");
		public static string SubirImagenArticulo(HttpPostedFile file)
		{
			string nombreArchivo = Path.GetFileName(file.FileName);
			string finalPath = globalPath + "articulos/" + nombreArchivo;
			file.SaveAs(finalPath);
			return ("Imagenes/articulos/") + nombreArchivo;
		}

		public static string SubirImagen(HttpPostedFile file)
		{
			string nombreArchivo = Path.GetFileName(file.FileName);
			string finalPath = globalPath + "usuarios/" + nombreArchivo;
			file.SaveAs(finalPath);
			return ("Imagenes/usuarios/") + nombreArchivo;
		}

		public static string SubirImagenCategoria(HttpPostedFile file)
		{
			string nombreArchivo = Path.GetFileName(file.FileName);
			string finalPath = globalPath + "categorias/" + nombreArchivo;
			file.SaveAs(finalPath);
			return ("Imagenes/categorias/") + nombreArchivo;
		}

		public static string SubirImagenMarca(HttpPostedFile file)
		{
			string nombreArchivo = Path.GetFileName(file.FileName);
			string finalPath = globalPath + "marcas/" + nombreArchivo;
			file.SaveAs(finalPath);
			return ("Imagenes/marcas/") + nombreArchivo;
		}
		public static string SubirImagenProveedor(HttpPostedFile file)
		{
			string nombreArchivo = Path.GetFileName(file.FileName);
			string finalPath = globalPath + "proveedores/" + nombreArchivo;
			file.SaveAs(finalPath);
			return ("Imagenes/proveedores/") + nombreArchivo;
		}

		public static bool validarArchivo(HttpPostedFile file)
		{
			bool answ;

			// Valida que la extensión del archivo sea .JPG o PNG
			string extension = Path.GetExtension(file.FileName);
			if (extension != ".jpg" && extension != ".png")
			{
				answ = false;
			}
			else
			{
				answ = true;
			}
			return answ;
		}
	}
}