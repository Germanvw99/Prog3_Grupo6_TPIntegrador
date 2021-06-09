using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;
using System.Web.SessionState;

namespace Negocio
{
    public class NegocioMarcas : System.Web.UI.Page
    {
        private readonly DaoMarcas daoMarcas = new Dao.DaoMarcas();
        public DataTable ObtenerMarcas() {
            return daoMarcas.ObtenerMarcas();
        }

        //USO SESION PARA EDITAR MARCAS

        //SI NO EXISTE, CREA LA SESION
        public void CrearSesion()
        {
            if (Session["TablaSesionMarcas"] == null)
            {
                Session["TablaSesionMarcas"] = CrearTablaSesion();
            }
        }
        private DataTable CrearTablaSesion()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("mar_codigo", typeof(string));
            dt.Columns.Add("mar_nombre", typeof(string));
            dt.Columns.Add("mar_descripcion", typeof(string));
            dt.Columns.Add("mar_ruta_imagen", typeof(string));
            dt.Columns.Add("mar_codigo_estado", typeof(string));
            return dt;
        }

        // RETORNA UNA TABLA DE LA SESION.
        // EN CASO DE QUE LA SESION SEA NULL RETORNA UNA TABLA NULL
        public DataTable ObtenerTablaSesion()
        {
            DataTable dt = new DataTable();
            if (Session["TablaSesionMarcas"] != null)
            {
                dt = (DataTable)Session["TablaSesionMarcas"];
            }
            return dt;
        }

        // SI NO EXISTE MAR_CODIGO AGREGA LA MARCA A LA SESION
        // RETORNA TRUE SI AGREGO
        // RETORNA FALSE SI NO AGREGO
        public bool AgregarMarcaEnLaSesion(Marcas Marca)
        {
            if (VerificarItem(Marca.GetCodigo()))
            {
                AgregarMarca(Marca);
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
        private bool VerificarItem(int marCodigo)
        {
            DataTable dt = ObtenerTablaSesion();
            foreach (DataRow row in dt.Rows)
            {
                if (Int32.Parse(row["mar_codigo"].ToString()) == marCodigo)
                {
                    return false;
                }
            }
            return true;
        }
        private void AgregarMarca(Marcas Marca)
        {
            DataTable dt = ObtenerTablaSesion();
            DataRow dr = dt.NewRow();
            dr["mar_codigo"] = Marca.GetCodigo();
            dr["mar_nombre"] = Marca.GetNombre();
            dr["mar_descripcion"] = Marca.GetDescripcion();
            dr["mar_ruta_imagen"] = Marca.GetRutaImagen();
            dr["mar_codigo_estado"] = Marca.GetEstado().GetCodigo(); 

            dt.Rows.Add(dr);
        }

        public bool EliminarSesion()
        {
            if (Session["TablaSesionMarcas"] != null)
            {
                Session["TablaSesionMarcas"] = null;
                return true;
            }
            return false;
        }
    }
}