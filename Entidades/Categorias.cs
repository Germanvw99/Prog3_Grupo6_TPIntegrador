using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categorias
    {
        private int cat_codigo;
        private string cat_nombre;
        private string cat_descripcion;
        private string cat_ruta_imagen;
        private Estados estado;

        public Categorias() { }


        //
        public int GetCodigo() { return this.cat_codigo; }
        public string GetNombre() { return this.cat_nombre; }
        public string GetDescripcion() { return this.cat_descripcion; }
        public string GetRutaImagen() { return this.cat_ruta_imagen; }
        public Estados GetEstado() { return this.estado; }

        //
        public void SetCodigo(int cat_codigo) { this.cat_codigo = cat_codigo; }
        public void SetNombre(string cat_nombre) { this.cat_nombre = cat_nombre; }
        public void SetDescripcion(string cat_descripcion) { this.cat_descripcion = cat_descripcion; }
        public void SetRutaImagen(string cat_ruta_imagen) { this.cat_ruta_imagen = cat_ruta_imagen; }
        public void SetEstado(Estados estado) { this.estado = estado; }


    }
}
