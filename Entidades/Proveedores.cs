using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedores
    {
        private string pro_dni;
        private string pro_razon_social;
        private string pro_direccion;
        private string pro_email;
        private string pro_telefono;
        private string pro_nombre_contacto;
        private string pro_ruta_imagen;
        private Estados estado;
        
        public Proveedores() { }

        //
        public string GetDni()
        {
            return pro_dni;
        }

        public string GetRazonSocial()
        {
            return pro_razon_social;
        }

        public string GetDireccion()
        {
            return pro_direccion;
        }

        public string GetEmail()
        {
            return pro_email;
        }

        public string GetTelefono()
        {
            return pro_telefono;
        }

        public string GetNombreContacto()
        {
            return pro_nombre_contacto;
        }

        public string GetRutaImagen()
        {
            return pro_ruta_imagen;
        }

        public Estados GetEstado()
        {
            return estado;
        }

        //
        public void SetDni(string pro_dni)
        {
            this.pro_dni = pro_dni;
        }

        public void SetRazonSocial(string pro_razon_social)
        {
            this.pro_razon_social = pro_razon_social;
        }

        public void SetDireccion(string pro_direccion)
        {
            this.pro_direccion= pro_direccion;
        }

        public void SetEmail(string pro_email)
        {
            this.pro_email= pro_email;
        }

        public void SetTelefono(string pro_telefono)
        {
            this.pro_telefono= pro_telefono;
        }

        public void SetNombreContacto(string pro_nombre_contacto)
        {
            this.pro_nombre_contacto= pro_nombre_contacto;
        }

        public void SetRutaImagen(string pro_ruta_imagen)
        {
            this.pro_ruta_imagen= pro_ruta_imagen;
        }

        public void SetEstado(Estados estado)
        {
            this.estado= estado;
        }
    }
}
