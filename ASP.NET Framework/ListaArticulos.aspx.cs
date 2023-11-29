using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Web.SessionState;

namespace ASP_NET_Framework
{
    public partial class ListaArticulos: System.Web.UI.Page
    {
        private const string sListArticulos = "listArticulos";

        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();

            if (Session[sListArticulos] == null)            
                Session.Add(sListArticulos, negocio.ListarArticulos());            
            else            
                Session[sListArticulos] = negocio.ListarArticulos();

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = Session[sListArticulos];
            dgvArticulos.DataBind();

            SetFiltros();
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("ArticuloForm?id="+id, false);
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCampos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void SetFiltros()
        {
            ddlCampos.Items.Clear();
            ddlCampos.Items.Add("Precio");
            ddlCampos.Items.Add("Código");
            ddlCampos.Items.Add("Categorías");
            ddlCampos.Items.Add("Marcas");

            ddlCriterio.Items.Clear();
            ddlCriterio.Items.Add("Mayor a");
            ddlCriterio.Items.Add("Menor a");
            ddlCriterio.Items.Add("Igual que");

        }
    }
}