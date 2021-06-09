using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        public String Dni { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public String Direccion { get; set; }
        public String Ciudad { get; set; }
        public String Provincia { get; set; }
        public String Codigo_Postal { get; set; }
        public String Ruta_Img { get; set; }
        public int Estado { get; set; }
        public int Codigo_Perfil { get; set; }

        public Usuarios() { }

        public Usuarios(String Dni, String Username, String Password, String Nombre, String Apellido, String Telefono, String Email, String Direccion, String Ciudad, String Provincia, String Codigo_Postal, String Ruta_Img, int Estado, int Codigo_Perfil)
        {
            this.Dni = Dni;
            this.Username = Username;
            this.Username = Password;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Telefono = Telefono;
            this.Email = Email;
            this.Direccion = Direccion;
            this.Ciudad = Ciudad;
            this.Provincia = Provincia;
            this.Codigo_Postal = Codigo_Postal;
            this.Ruta_Img = Ruta_Img;
            this.Estado = Estado;
            this.Codigo_Perfil = Codigo_Perfil;
        }

    }
}
