using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dao;

namespace Negocio
{
    public class NegocioUsuario
    {
        DaoUsuarios user = new DaoUsuarios();
        public Usuario Login(String username, String password)
        {
            try
            {
                return user.Login(username, password);

            }catch(Exception exc)
            {
                throw exc;
            }
            
        }
    }
}
