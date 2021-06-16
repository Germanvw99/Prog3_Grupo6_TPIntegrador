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
    public class DaoArticulos
    {
        private readonly AccesoDatos accDatos = new AccesoDatos();
        SqlConnection conn = null;
        public DataTable ObtenerArticulos()
        {
            string strTabla = "Categorias";
            
            
            string srtSQL = "SELECT art_codigo,art_nombre,art_descripcion,art_punto_pedido,art_precio_lista,art_ruta_imagen,est_nombre, mar_nombre, cat_nombre FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo";
           
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }

        public DataTable ObtenerArticulospormarca(string marca)
        {
            int marcaa = Convert.ToInt32(marca);
            string strTabla = "Categorias";
            string srtSQL = "SELECT art_codigo,art_nombre,art_descripcion,art_punto_pedido,art_precio_lista,art_ruta_imagen,est_nombre, mar_nombre, cat_nombre FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo  where art_marca_codigo = " + marcaa;
            
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }

        public DataTable ObtenerArticulosActivos()
        {
            string strTabla = "articulosAct";
            string srtSQL = "SELECT art_codigo,art_nombre,art_descripcion,art_punto_pedido,art_precio_lista,art_ruta_imagen,est_nombre, mar_nombre, cat_nombre FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo where est_nombre='Activo'";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }

        public DataTable ObtenerArticulosBus(string busquedad)
        {
            string strTabla = "ArticuloBus";
            string srtSQL = "SELECT art_codigo,art_nombre,art_descripcion,art_punto_pedido,art_precio_lista,art_ruta_imagen,est_nombre, mar_nombre, cat_nombre FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo where est_nombre='Activo' and art_nombre like '%"+busquedad+"%' ";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }

        public int AgregarArticulo(Articulos objArticulo)
        {
            int filasEditadas = 0;
            try
            {
                /*
                int marca_cod = objMarca.GetCodigo();
                int cat_cod = objCategoria.GetCodigo();
                int estado_cod = objEstado.GetCodigo();
                cmd.Parameters.AddWithValue("@prm_marca_codigo,", Convert.ToInt32(marca_cod));
                cmd.Parameters.AddWithValue("@prm_categoria_codigo,", Convert.ToInt32(cat_cod));
                cmd.Parameters.AddWithValue("@prm_nombre,", objArticulo.GetNombre());
                cmd.Parameters.AddWithValue("@prm_descripcion,", objArticulo.GetDescripcion());
                cmd.Parameters.AddWithValue("@prm_punto_pedido,", objArticulo.GetPuntoPedido());
                cmd.Parameters.AddWithValue("@prm_precio_lista,", objArticulo.GetPrecioLista());
                cmd.Parameters.AddWithValue("@prm_ruta_imagen,", objArticulo.GetRutaImagen());
                cmd.Parameters.AddWithValue("@prm_codigo_estado,", Convert.ToInt32(estado_cod));
                */
                // Recupero los codigos de Marca/Categoria/Estado
                conn = accDatos.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spAgregarArticulo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                Marcas objMarca = objArticulo.GetMarca();
                Categorias objCategoria = objArticulo.GetCategoria();
                Estados objEstado = objArticulo.GetEstado();

                cmd.Parameters.AddWithValue("@prmMarca", objMarca.GetCodigo());
                cmd.Parameters.AddWithValue("@prmCategoria", objCategoria.GetCodigo());
                cmd.Parameters.AddWithValue("@prmNombre", objArticulo.GetNombre());
                cmd.Parameters.AddWithValue("@prmDescripcion", objArticulo.GetDescripcion());
                cmd.Parameters.AddWithValue("@prmPunto_pedido", objArticulo.GetPuntoPedido());
                cmd.Parameters.AddWithValue("@prmPrecio_lista", objArticulo.GetPrecioLista());
                cmd.Parameters.AddWithValue("@prmRuta_imagen", objArticulo.GetRutaImagen());
                cmd.Parameters.AddWithValue("@prmEstado", objEstado.GetCodigo());

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
    }
}
