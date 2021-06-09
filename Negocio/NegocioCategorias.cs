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
    public class NegocioCategorias : System.Web.UI.Page
    {
        private readonly DaoCategorias daoCategorias = new DaoCategorias();
        public DataTable ObtenerCategorias()
        {
            return daoCategorias.ObtenerCategorias();
        }

        //USO SESION PARA EDITAR CATEGORIAS

        //SI NO EXISTE, CREA LA SESION
        public void CrearSesion()
        {
            if (Session["TablaSesionCategoria"] == null)
            {
                Session["TablaSesionCategoria"] = CrearTablaSesion();
            }
        }
        private DataTable CrearTablaSesion()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("cat_codigo", typeof(string));
            dt.Columns.Add("cat_nombre", typeof(string));
            dt.Columns.Add("cat_descripcion", typeof(string));
            dt.Columns.Add("cat_ruta_imagen", typeof(string));
            dt.Columns.Add("cat_codigo_estado", typeof(string));
            return dt;
        }

        // RETORNA UNA TABLA DE LA SESION.
        // EN CASO DE QUE LA SESION SEA NULL RETORNA UNA TABLA NULL
        public DataTable ObtenerTablaSesion()
        {
            DataTable dt = new DataTable();
            if (Session["TablaSesionCategoria"] != null)
            {
                dt = (DataTable)Session["TablaSesionCategoria"];
            }
            return dt;
        }

        // SI NO EXISTE CAT_CODIGO AGREGA LA CATEGORIA A LA SESION
        // RETORNA TRUE SI AGREGO
        // RETORNA FALSE SI NO AGREGO
        public bool AgregarCategoriaEnLaSesion(Categorias Categoria)
        {
            if (VerificarItem(Categoria.GetCodigo()))
            {
                AgregarCategoria(Categoria);
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
        private bool VerificarItem(int catCodigo)
        {
            DataTable dt = ObtenerTablaSesion();
            foreach (DataRow row in dt.Rows)
            {
                if (Int32.Parse(row["cat_codigo"].ToString()) == catCodigo)
                {
                    return false;
                }
            }
            return true;
        }
        private void AgregarCategoria(Categorias Categoria)
        {
            DataTable dt = ObtenerTablaSesion();
            DataRow dr = dt.NewRow();



            dr["cat_codigo"] = Categoria.GetCodigo();
            dr["cat_nombre"] = Categoria.GetNombre();
            dr["cat_descripcion"] = Categoria.GetDescripcion();
            dr["cat_ruta_imagen"] = Categoria.GetRutaImagen();
            dr["cat_codigo_estado"] = Categoria.GetEstado().GetCodigo();

            dt.Rows.Add(dr);
        }

        public bool EliminarSesion()
        {
            if (Session["TablaSesionCategoria"] != null)
            {
                Session["TablaSesionCategoria"] = null;
                return true;
            }
            return false;
        }
    }
}