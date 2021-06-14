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
    public class NegocioArticulos : System.Web.UI.Page
    {
        private readonly DaoArticulos daoArticulos = new DaoArticulos();
        public DataTable ObtenerArticulos()
        {
            return daoArticulos.ObtenerArticulos();
        }

        public DataTable ObtenerArticulosdemarca(string marca)
        {
            return daoArticulos.ObtenerArticulospormarca(marca);
        }

        public DataTable ObtenerArticulosAct()
        {
            return daoArticulos.ObtenerArticulosActivos();
        }
        public DataTable ObtenerArticulosBuscados(string busquedad)
        {
            return daoArticulos.ObtenerArticulosBus(busquedad);
        }




        //USO SESION PARA EDITAR ARTICULOS

        //SI NO EXISTE, CREA LA SESION
        public void CrearSesion()
        {
            if (Session["TablaSesionArticulos"] == null)
            {
                Session["TablaSesionArticulos"] = CrearTablaSesion();
            }
        }
        private DataTable CrearTablaSesion()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("art_codigo", typeof(string));
            dt.Columns.Add("art_marca_codigo", typeof(string));
            dt.Columns.Add("art_categoria_codigo", typeof(string));
            dt.Columns.Add("art_nombre", typeof(string));
            dt.Columns.Add("art_descripcion", typeof(string));
            dt.Columns.Add("art_punto_pedido", typeof(string));
            dt.Columns.Add("art_precio_lista", typeof(string));
            dt.Columns.Add("art_ruta_imagen", typeof(string));
            dt.Columns.Add("art_codigo_estado", typeof(string));
            return dt;
        }

        // RETORNA UNA TABLA DE LA SESION.
        // EN CASO DE QUE LA SESION SEA NULL RETORNA UNA TABLA NULL
        public DataTable ObtenerTablaSesion()
        {
            DataTable dt = new DataTable();
            if (Session["TablaSesionArticulos"] != null)
            {
                dt = (DataTable)Session["TablaSesionArticulos"];
            }
            return dt;
        }

        // SI NO EXISTE ART_CODIGO AGREGA EL ARTICULO A LA SESION
        // RETORNA TRUE SI AGREGO
        // RETORNA FALSE SI NO AGREGO
        public bool AgregarArticuloEnLaSesion(Articulos Articulo)
        {
            if (VerificarItem(Articulo.GetCodigo()))
            {
                AgregarArticulo(Articulo);
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
        private bool VerificarItem(int artCodigo)
        {
            DataTable dt = ObtenerTablaSesion();
            foreach (DataRow row in dt.Rows)
            {
                if(Int32.Parse(row["art_codigo"].ToString()) == artCodigo)
                {
                    return false;
                }
            }
            return true;
        }
        private void AgregarArticulo(Articulos Articulo)
        {
            DataTable dt = ObtenerTablaSesion();
            DataRow dr = dt.NewRow();

            dr["art_codigo"] = Articulo.GetCodigo();
            dr["art_marca_codigo"] = Articulo.GetMarca().GetNombre();
            dr["art_categoria_codigo"] = Articulo.GetCategoria().GetNombre();
            dr["art_descripcion"] = Articulo.GetDescripcion();
            dr["art_punto_pedido"] = Articulo.GetPuntoPedido();
            dr["art_precio_lista"] = Articulo.GetPrecioLista();
            dr["art_ruta_imagen"] = Articulo.GetRutaImagen();
            dr["art_codigo_estado"] = Articulo.GetEstado().GetNombre();

            dt.Rows.Add(dr);
        }

        public bool EliminarSesion()
        {
            if (Session["TablaSesionArticulos"] != null)
            {
                Session["TablaSesionArticulos"] = null;
                return true;
            }
            return false;
        }


        public void agregarfilacarrito(Articulos Articulo, Int16 cantidad = 1)
        {
            DataTable dt = obtenercarritosesion();
            

            agregarfilacarrito(dt, Articulo, cantidad);




        }

        public DataTable obtenercarritosesion()
        {
            DataTable dt;

            if (Session["carrito"] == null)
            {

                Session["carrito"] = creartablacarrito();

                dt = (DataTable)Session["carrito"];

                return dt;
                    
                   

            }

            dt = (DataTable)Session["carrito"];

            return dt;



        }

        public DataTable creartablacarrito()
        {

            DataTable dt = new DataTable();

            DataColumn columna = new DataColumn("id",System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("nombre", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("descripcion", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("precio", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("Cantidad", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("Total", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            return dt;




        }

        public void agregarfilacarrito(DataTable dt , Articulos Articulo, Int16 cantidad)
        {

            DataRow dr = dt.NewRow();

            dr["nombre"] = Articulo.GetNombre();
            dr["id"] = Articulo.GetCodigo();
            dr["descripcion"] = Articulo.GetDescripcion();
            dr["precio"] = Articulo.GetPrecioLista();
            dr["Cantidad"] = cantidad;
            dr["Total"] = Convert.ToString(Articulo.GetPrecioLista() * cantidad);
            dt.Rows.Add(dr);

            Session["carrito"] = dt;





        }
    }
}
