using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_NET_Framework
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }            
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocioUsuario = new UsuarioNegocio();
            try
            {
                Usuario user = new Usuario
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                };
                negocioUsuario.RegisterUser(user);
                Session.Add("user", user);
                Response.Redirect("Perfil.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
           
        }
    }
}