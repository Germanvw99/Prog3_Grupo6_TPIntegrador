using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Dao;
using Entidades;
using System.Data;
using System.Web.SessionState;

namespace Negocio
{
    public class NegocioProveedores : System.Web.UI.Page
    {
        private readonly DaoProveedores daoProveedores = new DaoProveedores();

        public DataTable ObtenerProveedores()
        {
            return daoProveedores.ObtenerProveedores();
        }

        //USO SESION PARA EDITAR PROVEEDORES

        //SI NO EXISTE, CREA LA SESION
        public void CrearSesion()
        {
            if (Session["TablaSesionProveedor"] == null)
            {
                Session["TablaSesionProveedor"] = CrearTablaSesion();
            }
        }
        private DataTable CrearTablaSesion()
        {
            DataTable dt = new DataTable();
                    dt.Columns.Add("pro_dni", typeof(string));
                    dt.Columns.Add("pro_razon_social", typeof(string));
                    dt.Columns.Add("pro_direccion", typeof(string));
                    dt.Columns.Add("pro_email", typeof(string));
                    dt.Columns.Add("pro_telefono", typeof(string));
                    dt.Columns.Add("pro_nombre_contacto", typeof(string));
                    dt.Columns.Add("pro_ruta_imagen", typeof(string));
                    dt.Columns.Add("pro_codigo_estado", typeof(string));
            return dt;
        }

        // RETORNA UNA TABLA DE LA SESION.
        // EN CASO DE QUE LA SESION SEA NULL RETORNA UNA TABLA NULL
        public DataTable ObtenerTablaSesion()
        {
            DataTable dt = new DataTable();
            if (Session["TablaSesionProveedor"] != null)
            {
                dt = (DataTable)Session["TablaSesionProveedor"];
            }
            return dt;
        }

        // SI NO EXISTE PRO_DNI AGREGA EL PROVEEDOR A LA SESION
        // RETORNA TRUE SI AGREGO
        // RETORNA FALSE SI NO AGREGO
        public bool AgregarProveedorEnLaSesion(Proveedores Proveedor)
        {
            if (VerificarItem(Proveedor.GetDni()))
            {
                AgregarProveedor(Proveedor);
                return true;
            }
            else
            {
                return false;
            }
        }
        // VERIFICA LA EXISTENCIA DEL DNI EN LA SESION
        // SI EL DNI EXISTE RETORNA FALSE
        // SI EL DNI NO EXISTE RETORNA TRUE
        private bool VerificarItem(string Dni)
        {
            DataTable dt = ObtenerTablaSesion();
            foreach (DataRow row in dt.Rows)
            {
                if (row["pro_dni"].ToString().Equals(Dni)) {
                    return false;
                }
            }
            return true;
        }
        private void AgregarProveedor(Proveedores Proveedor)
        {
            DataTable dt = ObtenerTablaSesion();
            DataRow dr = dt.NewRow();

            dr["pro_dni"] = Proveedor.GetDni();
            dr["pro_razon_social"] = Proveedor.GetRazonSocial();
            dr["pro_direccion"] = Proveedor.GetDireccion();
            dr["pro_email"] = Proveedor.GetEmail();
            dr["pro_telefono"] = Proveedor.GetTelefono();
            dr["pro_nombre_contacto"] = Proveedor.GetNombreContacto();
            dr["pro_ruta_imagen"] = Proveedor.GetRutaImagen();
            dr["pro_codigo_estado"] = Proveedor.GetEstado().GetCodigo();

            dt.Rows.Add(dr);
        }

        public bool EliminarSesion()
        {
            if (Session["TablaSesionProveedor"] != null)
            {
                Session["TablaSesionProveedor"] = null;
                return true;
            }
            return false;
        }
    }
}