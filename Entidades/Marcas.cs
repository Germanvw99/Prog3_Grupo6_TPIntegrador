using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Marcas
    {
        private int mar_codigo;
        private string mar_nombre;
        private string mar_descripcion;
        private string mar_ruta_imagen;
        private Estados estado;

        public Marcas() { }
        //
        public int GetCodigo() { return mar_codigo; }
        public string GetNombre() { return mar_nombre; }
        public string GetDescripcion() { return mar_descripcion; }
        public string GetRutaImagen() { return mar_ruta_imagen; }
        public Estados GetEstado() { return estado; }

        //

        public void SetCodigo(int mar_codigo) { this.mar_codigo = mar_codigo; }
        public void SetNombre(string mar_nombre) { this.mar_nombre = mar_nombre; }
        public void SetDescripcion(string mar_descripcion) { this.mar_descripcion = mar_descripcion; }
        public void SetRutaImagen(string mar_ruta_imagen) { this.mar_ruta_imagen = mar_ruta_imagen; }
        public void SetEstado(Estados estado) { this.estado = estado; }
    }
}