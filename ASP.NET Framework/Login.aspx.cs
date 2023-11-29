using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace ASP_NET_Framework
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario user = new Usuario
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                };

                if (negocio.Login(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("Perfil.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false) ;
            }
        }
    }
}