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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Articulo> listArticulos = new List<Articulo>();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                RptArticulos.DataSource = articuloNegocio.ListarArticulos();
                RptArticulos.DataBind();
            }
        }

        protected void RptArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void BtnAgregarFavorito_Click(object sender, EventArgs e)
        {

        }
    }
}