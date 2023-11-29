using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Web.SessionState;
using System.Configuration;

namespace ASP_NET_Framework
{
    public partial class ListaArticulos: System.Web.UI.Page
    {
        private const string sListArticulos = "listArticulos";
        private List<Marca> ListaMarcas = null;
        private List<Categoria> ListaCategorias = null;

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
            if(!IsPostBack)
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
            try
            {
                ddlCriterio.Items.Clear();
                txtFiltroAvanzado.Enabled = true;
                if (ddlCampos.Text == "Precio")
                {
                    ddlCriterio.Items.Add("Igual a");
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Menor a");
                }
                else if (ddlCampos.Text == "Marcas")
                {
                    MarcaNegocio negocioMarca = new MarcaNegocio();
                    txtFiltroAvanzado.Enabled = false;

                    ListaMarcas = ListaMarcas ?? negocioMarca.ListarMarcas();
                    ddlCriterio.DataSource = null;
                    ddlCriterio.DataSource = ListaMarcas;
                    ddlCriterio.DataBind();
                    ddlCriterio.DataMember = "Id";
                    ddlCriterio.DataTextField = "Descripcion";
                }
                else if (ddlCampos.Text == "Categorías")
                {
                    CategoriaNegocio negocioCat = new CategoriaNegocio();
                    txtFiltroAvanzado.Enabled = false;

                    ListaCategorias = ListaCategorias ?? negocioCat.ListarCategorias();

                    ddlCriterio.DataSource = null;
                    ddlCriterio.DataSource = ListaCategorias;
                    ddlCriterio.DataBind();
                    ddlCriterio.DataMember = "Id";
                    ddlCriterio.DataTextField = "Descripcion";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error",ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {
                List<Articulo> listaFiltrada = articuloNegocio.Filtrar(ddlCampos.Text, ddlCriterio.Text, txtFiltroAvanzado.Text);
                dgvArticulos.DataSource= null;
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
        private void SetFiltros()
        {
            ddlCampos.Items.Clear();
            ddlCampos.Items.Add("Precio");
            ddlCampos.Items.Add("Categorías");
            ddlCampos.Items.Add("Marcas");

            ddlCriterio.Items.Add("Igual a");
            ddlCriterio.Items.Add("Mayor a");
            ddlCriterio.Items.Add("Menor a");
        }
    }
}