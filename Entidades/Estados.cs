using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class Estados
	{
		private int est_codigo;
		private string est_nombre;

		//
		public Estados() { }

		//
		public int GetCodigo()
		{
			return est_codigo;
		}

		public string GetNombre()
		{
			return est_nombre;
		}

		//
		public void SetCodigo(int est_codigo)
		{
			this.est_codigo = est_codigo;
		}

		public void SetNombre(string est_nombre)
		{
			this.est_nombre = est_nombre;
		}
	}
}