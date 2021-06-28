using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoUsuarios
    {
        readonly AccesoDatos conex = new AccesoDatos();
        #region
        private static DaoUsuarios daoUsuarios = null;
        private DaoUsuarios() { }
        public static DaoUsuarios GetInstance()
        {
            if (daoUsuarios == null)
            {
                daoUsuarios = new DaoUsuarios();
            }
            return daoUsuarios;
        }
        #endregion
        
        SqlConnection conn = null;
        public Usuarios Login(String username, String password)
        {
            Usuarios objUsuario = null;

            try
            {
                conn = conex.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spLoginUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUsername", username);
                cmd.Parameters.AddWithValue("@prmPassword", password);

                SqlDataReader dr = cmd.ExecuteReader();
                
                // En caso de encontrar el usuario y verificar la contraseña recolecta información:
                if (dr.Read())
                {
                    objUsuario = new Usuarios();
                    objUsuario.Dni = dr["usu_dni"].ToString();
                    objUsuario.Username = dr["usu_username"].ToString();
                    objUsuario.Nombre = dr["usu_nombre"].ToString();
                    objUsuario.Apellido = dr["usu_apellido"].ToString();
                    objUsuario.Telefono = dr["usu_telefono"].ToString();
                    objUsuario.Email = dr["usu_email"].ToString();
                    objUsuario.Direccion = dr["usu_direccion"].ToString();
                    objUsuario.Ciudad = dr["usu_ciudad"].ToString();
                    objUsuario.Provincia = dr["usu_provincia"].ToString();
                    objUsuario.Codigo_Postal = dr["usu_codigo_postal"].ToString();
                    objUsuario.Ruta_Img = dr["usu_ruta_imagen"].ToString();
                    objUsuario.Estado = Convert.ToInt32(dr["usu_codigo_estado"].ToString());
                    objUsuario.Codigo_Perfil = Convert.ToInt32(dr["usu_perfil_codigo"].ToString());
                }
            }
            catch (Exception exc)
            {
                objUsuario = null;
                throw exc;
            }
            finally
            {
                conn.Close();
            }
            return objUsuario;
        }

        public int Register(Usuarios objUsuario)
        {
            int filasEditadas = 0;
            try
            {
                conn = conex.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spRegistroUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmDni", objUsuario.Dni);
                cmd.Parameters.AddWithValue("@prmUsername", objUsuario.Username);
                cmd.Parameters.AddWithValue("@prmPassword", objUsuario.Password);
                cmd.Parameters.AddWithValue("@prmNombre", objUsuario.Nombre);
                cmd.Parameters.AddWithValue("@prmApellido", objUsuario.Apellido);
                cmd.Parameters.AddWithValue("@prmTelefono", objUsuario.Telefono);
                cmd.Parameters.AddWithValue("@prmEmail", objUsuario.Email);
                cmd.Parameters.AddWithValue("@prmDireccion", objUsuario.Direccion);
                cmd.Parameters.AddWithValue("@prmCiudad", objUsuario.Ciudad);
                cmd.Parameters.AddWithValue("@prmProvincia", objUsuario.Provincia);
                cmd.Parameters.AddWithValue("@prmCodigo_Postal", objUsuario.Codigo_Postal);
                cmd.Parameters.AddWithValue("@prmRuta_Img", objUsuario.Ruta_Img);
                cmd.Parameters.AddWithValue("@prmEstado", objUsuario.Estado);
                cmd.Parameters.AddWithValue("@prmCodigo_Perfil", objUsuario.Codigo_Perfil);

                filasEditadas = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                conn.Close();
            }
            return filasEditadas;
        }
       
        // ELIMINAR CAMPOS

        public int EliminarUsuarioDni(String Dni)
        {
            try
            {
                conn = conex.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spEliminarUsuarioDni", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prm_dni", Dni.ToString());
                return conex.EjecutarProcedimientoAlmacenado(cmd, "spEliminarUsuarioDni");
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ObtenerUsuarios()
        {
            string strTabla = "Usuarios";
            string srtSQL = "SELECT usu_dni,usu_ruta_imagen, usu_username, usu_nombre,usu_apellido,usu_email,usu_ciudad,usu_provincia,est_codigo, est_nombre FROM Usuarios INNER JOIN Estados ON Usuarios.usu_codigo_estado = Estados.est_codigo";
            return conex.ObtenerTabla(strTabla, srtSQL);
        }
        public Usuarios LeerUsuario(String dni)
        {
            Usuarios objUsuario = null;
            try {
                conn = conex.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spLeerUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmDni", dni);

                SqlDataReader dr = cmd.ExecuteReader();

                // En caso de encontrar el usuario:
                if (dr.Read())
                {
                    objUsuario = new Usuarios();
                    objUsuario.Dni = dr["usu_dni"].ToString();
                    objUsuario.Username = dr["usu_username"].ToString();
                    objUsuario.Nombre = dr["usu_nombre"].ToString();
                    objUsuario.Apellido = dr["usu_apellido"].ToString();
                    objUsuario.Telefono = dr["usu_telefono"].ToString();
                    objUsuario.Email = dr["usu_email"].ToString();
                    objUsuario.Direccion = dr["usu_direccion"].ToString();
                    objUsuario.Ciudad = dr["usu_ciudad"].ToString();
                    objUsuario.Provincia = dr["usu_provincia"].ToString();
                    objUsuario.Codigo_Postal = dr["usu_codigo_postal"].ToString();
                    objUsuario.Ruta_Img = dr["usu_ruta_imagen"].ToString();
                    objUsuario.Estado = Convert.ToInt32(dr["usu_codigo_estado"].ToString());
                    objUsuario.Codigo_Perfil = Convert.ToInt32(dr["usu_perfil_codigo"].ToString());
                }
            }
            catch (Exception exc)
            {
                objUsuario = null;
                throw exc;
            }
            finally
            {
                conn.Close();
            }

            return objUsuario;
        }

        // LEER CAMPOS

        public Usuarios LeerUsername(String username)
        {
            Usuarios objUsuario = null;
            try
            {
                conn = conex.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spLeerUsername", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUsername ", username);

                SqlDataReader dr = cmd.ExecuteReader();

                // En caso de encontrar el usuario:
                if (dr.Read())
                {
                    objUsuario = new Usuarios();
                    objUsuario.Dni = dr["usu_dni"].ToString();
                    objUsuario.Username = dr["usu_username"].ToString();
                    objUsuario.Nombre = dr["usu_nombre"].ToString();
                    objUsuario.Apellido = dr["usu_apellido"].ToString();
                    objUsuario.Telefono = dr["usu_telefono"].ToString();
                    objUsuario.Email = dr["usu_email"].ToString();
                    objUsuario.Direccion = dr["usu_direccion"].ToString();
                    objUsuario.Ciudad = dr["usu_ciudad"].ToString();
                    objUsuario.Provincia = dr["usu_provincia"].ToString();
                    objUsuario.Codigo_Postal = dr["usu_codigo_postal"].ToString();
                    objUsuario.Ruta_Img = dr["usu_ruta_imagen"].ToString();
                    objUsuario.Estado = Convert.ToInt32(dr["usu_codigo_estado"].ToString());
                    objUsuario.Codigo_Perfil = Convert.ToInt32(dr["usu_perfil_codigo"].ToString());
                }
            }
            catch (Exception exc)
            {
                objUsuario = null;
                throw exc;
            }
            finally
            {
                conn.Close();
            }
            return objUsuario;
        }

        // EDITAR CAMPOS

        public int EditarEstadoUsuario(Usuarios objUsuario)
        {
            int filasEditadas = 0;
            try
            {
                // Edita la información del registro en la BD
                conn = conex.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spEditarEstadoUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmDni", objUsuario.Dni);
                cmd.Parameters.AddWithValue("@prmEstado", objUsuario.Estado);
                filasEditadas = cmd.ExecuteNonQuery();

            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                conn.Close();
            }
            return filasEditadas;
        }

        public bool EditUser(Usuarios objUsuario)
        {
            bool answ = false;
            try
            {
                // Edita la información del registro en la BD
                conn = conex.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spEditarUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmDni", objUsuario.Dni);
                cmd.Parameters.AddWithValue("@prmNombre", objUsuario.Nombre);
                cmd.Parameters.AddWithValue("@prmApellido", objUsuario.Apellido);
                cmd.Parameters.AddWithValue("@prmEmail", objUsuario.Email);
                cmd.Parameters.AddWithValue("@prmTelefono", objUsuario.Telefono);
                cmd.Parameters.AddWithValue("@prmDireccion", objUsuario.Direccion);
                cmd.Parameters.AddWithValue("@prmCodigo_Postal", objUsuario.Codigo_Postal);
                cmd.Parameters.AddWithValue("@prmCiudad", objUsuario.Ciudad);
                cmd.Parameters.AddWithValue("@prmProvincia", objUsuario.Provincia);

                int filasEditadas = cmd.ExecuteNonQuery();

                // Chekea si hubo modificaciones
                if (filasEditadas > 0)
                {
                    answ = true;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                conn.Close();
            }
            return answ;
        }

        public int EditPassword(String nuevaPassword, String Dni)
        {
            int filasEditadas;
            try
            {
                // Se modifica la contraseña
                conn = conex.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spEditarContraseña", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNuevaPassword", nuevaPassword);
                cmd.Parameters.AddWithValue("@prmDni", Dni);

                filasEditadas = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                conn.Close();
            }
            return filasEditadas;
        }

        // FILTROS

        public DataTable filtrarConsultaUsuarios(ref string Consulta)
        {
            string strTabla = "Usuarios";
            string srtSQL = "SELECT usu_dni,usu_ruta_imagen, usu_username, usu_nombre,usu_apellido,usu_email,usu_ciudad,usu_provincia, est_nombre, est_codigo FROM Usuarios INNER JOIN Estados ON Usuarios.usu_codigo_estado = Estados.est_codigo " + Consulta + " ORDER BY usu_dni ASC";
            return conex.ObtenerTabla(strTabla, srtSQL);
        }

        // VERIFICACIONES
        public Usuarios VerificarAntiguaPassword(String username, String antiguaPassword)
        {
            Usuarios objUsuario = null;
            try
            {
                // Se modifica la contraseña
                conn = conex.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spLoginUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUsername", username);
                cmd.Parameters.AddWithValue("@prmPassword", antiguaPassword);

                SqlDataReader dr = cmd.ExecuteReader();

                // En caso de encontrar el usuario y verificar la contraseña recolecta información:
                if (dr.Read())
                {
                    objUsuario = new Usuarios();
                    objUsuario.Dni = dr["usu_dni"].ToString();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                conn.Close();
            }
            return objUsuario ;
        }
    }
}