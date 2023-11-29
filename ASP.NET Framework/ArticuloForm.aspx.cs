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
    public partial class ArticuloForm : System.Web.UI.Page
    {
        public bool EliminarArticulo
        {
            get
            {
                if (ViewState["EliminarArticulo"] != null)
                {
                    return (bool)ViewState["EliminarArticulo"];
                }
                return false;
            }
            set
            {
                ViewState["EliminarArticulo"] = value;
            }
        }
        private Articulo articulo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetCamposElementos();
            txtId.ReadOnly = true;

            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                List<Articulo> temp = (List<Articulo>)Session["listArticulos"];
                Articulo seleccionado = temp.Find(x => x.Id == id);
                articulo = seleccionado;

                Page.Title = "Modificar Artículo";
                btnAgregar.Text = "Modificar";

                if (!IsPostBack)
                {
                    txtId.Text = seleccionado.Id.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtCodigo.Text = seleccionado.CodigoArticulo.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion.ToString();

                    //Seleccion de elementos del pokemon
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                }
            }
            else
            {
                BtnEliminar.Visible = false;
                txtId.Text = "Pendiente";
            }
        }
        private void SetCamposElementos()
        {          
            MarcaNegocio negMarca = new MarcaNegocio();
            List<Marca> listMarcas = negMarca.ListarMarcas();
                        
            ddlMarca.DataSource = listMarcas;
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataBind();

            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            List<Categoria> listaCategorias = negocioCategoria.ListarCategorias();

            ddlCategoria.DataSource = listaCategorias;
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {

                if (Request.QueryString["id"] == null)
                    articulo = new Articulo();

                articulo.Nombre = txtNombre.Text;
                articulo.CodigoArticulo = txtCodigo.Text;
                articulo.Descripcion = txtDescripcion.Text;

                if (txtUrlImagen.Text != "")
                    articulo.ImagenUrl = txtDescripcion.Text;



                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                
                if (Request.QueryString["id"] == null)
                    articuloNegocio.Agregar(articulo);
                else
                    articuloNegocio.ModificarArticulo(articulo);

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            EliminarArticulo = !EliminarArticulo;
            BtnEliminar.Text = BtnEliminar.Text == "Eliminar" ? "Cancelar eliminación" : "Eliminar";
        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                int id = int.Parse(Request.QueryString["id"]);
                //negocio.EliminarArticulo(id);
                BtnEliminar.Enabled = false;
                EliminarArticulo = false;
                btnAgregar.Enabled = false;
                btnCancelar.Text = "Volver";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
            
        }
    }
}