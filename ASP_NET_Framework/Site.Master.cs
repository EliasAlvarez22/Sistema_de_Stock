using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_NET_Framework
{
    public partial class SiteMaster : MasterPage
    {
        public Usuario Usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = (Usuario)Session["user"] ?? null;

            // Valida al User que no pueda acceder a las paginas de Login y Registro, redirige a su perfil.
            if ((Page is Login || Page is Register) && Usuario != null)
                Response.Redirect("Profile.aspx", false);


            /*if (!(Page is Contact || Page is Error || Page is _Default || Page is Pokemons.Login || Page is RegisterUser && Seguridad.SesionActiva(Usuario)))
            {
                Session.Add("error", "Sin acceso a esta pagina.");
                Response.Redirect("Error.aspx", false);
            }*/

            //Se carga la imagen del User en el imgAvatar del site
            if ((Usuario != null) && Usuario.ImagenPerfil != null)
                imgAvatar.ImageUrl = "~/Images/Perfil/" + Usuario.ImagenPerfil;
            else
                imgAvatar.ImageUrl = "~/Images/Perfil/sinPerfil.jpeg";
        }
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}