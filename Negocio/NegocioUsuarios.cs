﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Entidades;
using Dao;

namespace Negocio
{
    public class NegocioUsuarios
    {
        #region
        private static NegocioUsuarios objUsuario = null;
        private NegocioUsuarios() { }
        public static NegocioUsuarios getInstance()
        {
            if (objUsuario == null)
            {
                objUsuario = new NegocioUsuarios();
            }
            return objUsuario;
        }
        #endregion
        public Usuarios Login(String username, String password)
        {
            try
            {
                return CrearSessionUsuario(DaoUsuarios.getInstance().Login(username, password));
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        public bool RegistUser(Usuarios objUsuario)
        {
            try
            {
                int filasEditadas = DaoUsuarios.getInstance().Register(objUsuario);
                bool answ = false;

                if (filasEditadas > 0)
                {
                    answ = true;
                }
                return answ;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public bool EditUser(Usuarios objUsuario)
        {
            try
            {
                bool answ = false;
                answ = DaoUsuarios.getInstance().EditUser(objUsuario);

                // Si el usuario se modifico, entonces se vuelve a crear el Session
                CrearSessionUsuario(DaoUsuarios.getInstance().LeerUsuario(objUsuario.Dni));

                return answ;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public bool EditPassword(String nuevaPassword, String Dni)
        {
            try
            {
                bool answ = false;

                // Devuelve el valor correspondiente a si fue hubo filas editadas
                int filasEditadas = DaoUsuarios.getInstance().EditPassword(nuevaPassword, Dni);

                // Chekea si hubo modificaciones
                if (filasEditadas > 0)
                {
                    answ = true;
                }

                return answ;
            }catch (Exception exc)
            {
                throw exc;
            }
        }

        public bool VerificarAntiguaPassword(String username, String antiguaPassword)
        {
            try
            {
                Usuarios objUsuario = null;
                bool answ = false;

                // Devuelve el valor correspondiente a si las contraseñas son iguales
                objUsuario = DaoUsuarios.getInstance().VerificarAntiguaPassword(username, antiguaPassword);

                if (objUsuario != null)
                {
                    answ = true;
                }
                else
                {
                    answ = false;
                }

                return answ;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        // Verificaciones del registro

        public bool VerificarUsernameDuplicado(String username)
        {
            Usuarios objUsuario = null;
            bool answ = false;
            try
            {
                objUsuario = DaoUsuarios.getInstance().LeerUsername(username);
                if (objUsuario != null)
                {
                    answ = true;
                }
                else
                {
                    answ = false;
                }
                return answ;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public bool VerificarDniDuplicado(String Dni)
        {
            Usuarios objUsuario = null;
            bool answ = false;
            try
            {
                objUsuario = DaoUsuarios.getInstance().LeerUsuario(Dni);

                if(objUsuario != null)
                {
                    answ = true;
                }
                else
                {
                    answ = false;
                }
                return answ;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        // Next()

        private  Usuarios CrearSessionUsuario(Usuarios objUsuario)
        {
            if(objUsuario != null)
            {
               DataTable dt = CrearTablaUsuario(objUsuario);

                // Se crea la Session con el DataTable creado
                System.Web.HttpContext.Current.Session["User"] = dt;
            }
            else
            {
                // Elimino el Session
                System.Web.HttpContext.Current.Session.Remove("User");
            }
            return objUsuario;
        }


        private DataTable CrearTablaUsuario(Usuarios objUsuario)
        {
            // Se crea un DataTable
            DataTable dt = new DataTable("UserTable");
            dt.Columns.Add("usu_dni", typeof(String));
            dt.Columns.Add("usu_username", typeof(String));
            dt.Columns.Add("usu_nombre", typeof(String));
            dt.Columns.Add("usu_apellido", typeof(String));
            dt.Columns.Add("usu_telefono", typeof(String));
            dt.Columns.Add("usu_email", typeof(String));
            dt.Columns.Add("usu_direccion", typeof(String));
            dt.Columns.Add("usu_ciudad", typeof(String));
            dt.Columns.Add("usu_provincia", typeof(String));
            dt.Columns.Add("usu_codigo_postal", typeof(String));
            dt.Columns.Add("usu_ruta_imagen", typeof(String));
            dt.Columns.Add("usu_codigo_estado", typeof(Int32));
            dt.Columns.Add("usu_perfil_codigo", typeof(Int32));

            // Se rellena el DataTable con una fila que contiene la información del usuario
            DataRow row = dt.NewRow();
            row["usu_dni"] = objUsuario.Dni;
            row["usu_username"] = objUsuario.Username;
            row["usu_nombre"] = objUsuario.Nombre;
            row["usu_apellido"] = objUsuario.Apellido;
            row["usu_telefono"] = objUsuario.Telefono;
            row["usu_email"] = objUsuario.Email;
            row["usu_direccion"] = objUsuario.Direccion;
            row["usu_ciudad"] = objUsuario.Ciudad;
            row["usu_provincia"] = objUsuario.Provincia;
            row["usu_codigo_postal"] = objUsuario.Codigo_Postal;
            row["usu_ruta_imagen"] = objUsuario.Ruta_Img;
            row["usu_codigo_estado"] = objUsuario.Estado;
            row["usu_perfil_codigo"] = objUsuario.Codigo_Perfil;

            dt.Rows.Add(row);
            return dt;
        }

        public Usuarios LeerTablaUsuario(DataTable dt)
        {
            Usuarios objUsuario = new Usuarios();
            if(dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    objUsuario.Dni = row["usu_dni"].ToString();
                    objUsuario.Username = row["usu_username"].ToString();
                    objUsuario.Nombre = row["usu_nombre"].ToString();
                    objUsuario.Apellido = row["usu_apellido"].ToString();
                    objUsuario.Telefono = row["usu_telefono"].ToString();
                    objUsuario.Email = row["usu_email"].ToString();
                    objUsuario.Direccion = row["usu_direccion"].ToString();
                    objUsuario.Ciudad = row["usu_ciudad"].ToString();
                    objUsuario.Provincia = row["usu_provincia"].ToString();
                    objUsuario.Codigo_Postal = row["usu_codigo_postal"].ToString();
                    objUsuario.Ruta_Img = row["usu_ruta_imagen"].ToString();
                    objUsuario.Estado = Convert.ToInt32(row["usu_codigo_estado"]);
                    objUsuario.Codigo_Perfil = Convert.ToInt32(row["usu_perfil_codigo"]);
                }
            }
            return objUsuario;
        }

        public bool isAdmin()
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session["User"];
            Usuarios objUsuario = LeerTablaUsuario(dt);

            if(objUsuario.Codigo_Perfil == 1)
            {
                return true;
            }
            else { return false; }
        }

       
    }
}