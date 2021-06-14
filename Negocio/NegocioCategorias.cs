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
        private readonly DaoCategorias daoCategoria = new DaoCategorias();
        private readonly Categorias categoria = new Categorias();
        public DataTable ObtenerCategorias()
        {
            return daoCategoria.ObtenerCategorias();
        }

        #region SESION CATEGORIAS


        public void AgregarCategoriaEliminar(Categorias categoria)
        {
            Session["SesionCategoriaEliminar"] = categoria;
        }

        public Categorias ObtenerCategoriaEliminar()
        {
            Categorias categoria = new Categorias();
            if (Session["SesionCategoriaEliminar"] != null)
            {
                categoria = (Categorias)Session["SesionCategoriaEliminar"];
            }
            return categoria;
        }


        //USO SESION PARA MODIFICAR CATEGORIAS. SI NO EXISTE, CREA LA SESION
        private void CrearSesionCategoria()
        {
            if (Session["SesionCategoria"] == null)
            {
                Categorias categoria = new Categorias();
                Session["SesionCategoria"] = categoria;
            }
        }

        // RETORNA LA SESION CATEGORIA. EN CASO DE QUE LA SESION SEA NULL RETORNA UNA CATEGORIA NULL
        public Categorias ObtenerSesionCategoria()
        {
            Categorias categoria = new Categorias();
            if (Session["SesionCategoria"] != null)
            {
                categoria = (Categorias)Session["SesionCategoria"];
            }
            return categoria;
        }
        // AGREGA UNA MARCA A LA SESION
        public void AgregarCategoriaEnLaSesion(Categorias categoria)
        {
            EliminarSesionCategoria();
            CrearSesionCategoria();
            Categorias categoriaSesion = ObtenerSesionCategoria();
            categoriaSesion.SetCodigo(categoria.GetCodigo());
            categoriaSesion.SetNombre(categoria.GetNombre());
            categoriaSesion.SetDescripcion(categoria.GetDescripcion());
            categoriaSesion.SetRutaImagen(categoria.GetRutaImagen());
            Estados estado = new Estados();
            estado.SetNombre(categoria.GetEstado().GetNombre());
            estado.SetCodigo(categoria.GetEstado().GetCodigo());
            categoriaSesion.SetEstado(estado);
        }

        // ELIMINA LA SESION CATEGORIA
        private void EliminarSesionCategoria()
        {
            if (Session["SesionCategoria"] != null)
            {
                Session["SesionCategoria"] = null;
            }
        }

        #endregion

        #region AGREGAR CATEGORIA
        // RETORNA 0 --> NO AGREGO LA CATEGORIA
        // RETORNA 1 --> AGREGO LA CATEGORIA
        // RETORNA 2 --> LA CATEGORIA YA EXISTE, NO FUE AGREGADA
        public int agregarMarca(Categorias categoria)
        {
            if (buscarMarcaPorCategoria(categoria) == 0)
            {
                int agregar = daoCategoria.agregarCategoria(categoria);
                if (agregar == 1) return 1;
                else return 0;
            }
            else
            {
                return 2;
            }
        }
        //BUSCAR MARCA POR NOMBRE
        private int buscarMarcaPorCategoria(Categorias categoria)
        {
            return daoCategoria.buscarCategoriaPorNombre(categoria);
        }

        #endregion

        #region MODIFICAR CATEGORIA

        //USADO PARA MODIFICAR CATEGORIA
        //BUSCAR CATEGORIA POR NOMBRE Y CODIGO DE CATEGORIA NO COINCIDENTE PARA EVITAR QUE EXISTAN CATEGORIAS CON EL MISMO NOMBRE
        private int buscarCategoriaPorNombreCodigoNoCoincidente(Categorias categoria)
        {
            return daoCategoria.buscarCategoriaPorNombreCodigoNoCoincidente(categoria);
        }

        //MODIFICAR MARCA
        public int modificarMarca(Categorias categoria)
        {
            if (buscarCategoriaPorNombreCodigoNoCoincidente(categoria) == 0)
            {
                int agregar = daoCategoria.modificarCategoria(categoria);
                if (agregar == 1) return 1;
                else return 0;
            }
            else
            {
                return 2;
            }
        }


        #endregion

        # region ELIMINAR CATEGORIA
        public bool eliminarCategoria(Categorias categoria)
        {
            int eliminar = daoCategoria.eliminarCategoria(categoria);
            if (eliminar == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        #endregion

    }
}