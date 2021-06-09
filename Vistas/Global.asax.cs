using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Vistas
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Se ejecuta cuando la aplicación incia por PRIMERA VEZ.
            // Routing Handler.
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Home", "Home.aspx", "~/Home.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Register", "Register.aspx", "~/Register.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Login", "Login.aspx", "~/Login.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}