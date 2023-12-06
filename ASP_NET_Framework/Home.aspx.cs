using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
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
                CargarArticulos();
            }
        }
        //Actualizar funciona tal que si es true, solicite a la DB la lista de articulos nuevamente, sino no
        private void CargarArticulos(bool actualizar = false)
        {
            try
            {
                List<Articulo> listFiltrada = null;

                //Quiero que se use la lista filtrada en esta pantalla solamente y no la lista normal.

                //
                if (!actualizar)
                {
                    if (Session["listFiltrada"] != null)
                    {
                        listFiltrada = (List<Articulo>)Session["listFiltrada"];
                        RptArticulos.DataSource = listFiltrada;
                        RptArticulos.DataBind();
                        return;
                    }
                    if (Session["listArticulos"] == null)
                    {
                        List<Articulo> listArticulos;
                        ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                        listArticulos = articuloNegocio.ListarArticulos();
                        Session.Add("listArticulos", listArticulos);
                        listFiltrada = listArticulos.ToList();

                        Session.Add("listFiltrada", listFiltrada);
                    }
                    else if (Session["listFiltrada"] == null)
                    {
                        listFiltrada = ((List<Articulo>)Session["listArticulos"]).ToList();
                        Session.Add("listFiltrada", listFiltrada);
                    }

                }
                else
                {
                    List<Articulo> listArticulos;
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                    listArticulos = articuloNegocio.ListarArticulos();
                    Session.Add("listArticulos", listArticulos);
                    
                    listFiltrada = listArticulos.ToList();
                    Session.Add("listFiltrada", listFiltrada);
                }

                //El ciclo recorre las urls de las imagenes, si son invalidas les agrega la imagen default, sino no.
                for (int art = 0; art < listFiltrada.Count; art++)
                {
                    try
                    {
                        if ((listFiltrada[art].ImagenUrl == null) || !listFiltrada[art].ImagenUrl.Contains("http"))                        
                           listFiltrada[art].ImagenUrl = "~/Images/Articulos/default.png";  
                                            
                        if (listFiltrada[art].ImagenUrl != null)
                        {
                            using (HttpClient httpClient = new HttpClient())
                            {
                                HttpResponseMessage response = httpClient.GetAsync(listFiltrada[art].ImagenUrl).Result;
                                if (!response.IsSuccessStatusCode)                                
                                    listFiltrada[art].ImagenUrl = "~/Images/Articulos/default.png";                                
                            }
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        //Si la URL obtenida es invalida, se coloca la imagen default
                        listFiltrada[art].ImagenUrl = "~/Images/Articulos/default.png";
                    }
                }
                RptArticulos.DataSource = listFiltrada;
                RptArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void RptArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void BtnAgregarFavorito_Click(object sender, EventArgs e)
        {

        }       
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarArticulos(true);
        }
    }
}