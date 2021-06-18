using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{
    public class DaoProveedores
    {
        private readonly AccesoDatos accDatos = new AccesoDatos();
        public DataTable ObtenerProveedores()
        {
            string strTabla = "Proveedores";
            string srtSQL = "SELECT pro_dni,pro_razon_social,pro_direccion,pro_email,pro_telefono,pro_nombre_contacto,pro_ruta_imagen, est_codigo, est_nombre  FROM Proveedores INNER JOIN Estados ON Proveedores.pro_codigo_estado=Estados.est_codigo";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }

        #region AGREGAR PROVEEDOR
        //AGREGAR PROVEEDOR
        public int agregarProveedor(Proveedores proveedor)
        {
            SqlCommand comando = new SqlCommand();
            armarParametrosAgregarProveedor(ref comando, proveedor);
            return accDatos.EjecutarProcedimientoAlmacenado(comando, "spAgregarProveedor");
        }
        private void armarParametrosAgregarProveedor(ref SqlCommand Comando, Proveedores proveedor)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@pro_dni", SqlDbType.Char, 8);
            SqlParametros.Value = proveedor.GetDni();

            SqlParametros = Comando.Parameters.Add("@pro_razon_social", SqlDbType.VarChar, 255);
            SqlParametros.Value = proveedor.GetRazonSocial();

            SqlParametros = Comando.Parameters.Add("@pro_direccion", SqlDbType.VarChar, 255);
            SqlParametros.Value = proveedor.GetDireccion();

            SqlParametros = Comando.Parameters.Add("@pro_email", SqlDbType.VarChar, 255);
            SqlParametros.Value = proveedor.GetEmail();

            SqlParametros = Comando.Parameters.Add("@pro_telefono", SqlDbType.VarChar, 255);
            SqlParametros.Value = proveedor.GetTelefono();

            SqlParametros = Comando.Parameters.Add("@pro_nombre_contacto", SqlDbType.VarChar, 255);
            SqlParametros.Value = proveedor.GetNombreContacto();

            SqlParametros = Comando.Parameters.Add("@pro_ruta_imagen", SqlDbType.VarChar, 255);
            SqlParametros.Value = proveedor.GetRutaImagen();

            SqlParametros = Comando.Parameters.Add("@pro_codigo_estado", SqlDbType.Int);
            SqlParametros.Value = proveedor.GetEstado().GetCodigo();
        }

        //BUSCAR PROVEEDOR POR NOMBRE
        public int buscarProveedorPorDni(Proveedores proveedor)
        {
            string consultaSql = "SELECT COUNT(pro_dni) FROM Proveedores WHERE pro_dni LIKE '" + proveedor.GetDni() + "'";
            int cantidad = accDatos.cantidadFilasAfectadas(consultaSql);
            return cantidad;
        }
        #endregion

        #region MODIFICAR PROVEEDOR
        //BUSCAR PROVEEDOR POR NOMBRE Y CODIGO NO COINCIDENTE
        public int buscarProveedorPorNombreCodigoNoCoincidente(Proveedores proveedor)
        {
            string consultaSql = "SELECT COUNT(pro_dni) FROM Proveedores WHERE pro_razon_social LIKE '" + proveedor.GetRazonSocial() + "' AND pro_dni != '" + proveedor.GetDni() + "'";
            int cantidad = accDatos.cantidadFilasAfectadas(consultaSql);
            return cantidad;
        }

        public int modificarProveedor(Proveedores proveedor)
        {
            SqlCommand comando = new SqlCommand();
            armarParametrosAgregarProveedor(ref comando, proveedor);
            return accDatos.EjecutarProcedimientoAlmacenado(comando, "spModificarProveedor");
        }

        #endregion

        #region ELIMINAR PROVEEDOR
        public int eliminarProveedor(Proveedores proveedor)
        {
            SqlCommand comando = new SqlCommand();
            armarParametroEliminarProveedor(ref comando, proveedor);
            return accDatos.EjecutarProcedimientoAlmacenado(comando, "spEliminarProveedor");
        }

        private void armarParametroEliminarProveedor(ref SqlCommand Comando, Proveedores proveedor)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@pro_dni", SqlDbType.Char);
            SqlParametros.Value = proveedor.GetDni();
        }
        #endregion

        public DataTable filtrarConsultaProveedor(ref string ClausulaSQLConsultaProveedor)
        {
            string strTabla = "Proveedor";
            string srtSQL = "SELECT pro_dni,pro_razon_social,pro_direccion,pro_email,pro_telefono,pro_nombre_contacto,pro_ruta_imagen, est_codigo, est_nombre  FROM Proveedores INNER JOIN Estados ON Proveedores.pro_codigo_estado=Estados.est_codigo " + ClausulaSQLConsultaProveedor;
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }
    }
}