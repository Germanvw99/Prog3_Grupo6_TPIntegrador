using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class MediosPago
    {
        private int mp_codigo;
        private string mp_nombre;
        private string mp_otros_detalles;

        public MediosPago() { }

        //
        public int GetCodigo() { return mp_codigo; }
        public string GetNombre() { return mp_nombre; }
        public string GetImagenUrl() { return mp_otros_detalles; }

        public void SetCodigo(int mp_codigo) { this.mp_codigo = mp_codigo; }
        public void SetNombre(string mp_nombre) { this.mp_nombre = mp_nombre; }
        public void SetImagenUrl(string mp_otros_detalles) { this.mp_otros_detalles = mp_otros_detalles; }
        //

    }
}
