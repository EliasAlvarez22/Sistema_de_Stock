using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;


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
                    CargarDatosArticuloBasicos();

                    string rutaArchivo = "~/Images/Articulos/articulo-" + seleccionado.Id + ".jpg";
                    string rutaFisica = Server.MapPath(rutaArchivo);

                    //Si es null la imagen del articulo o la imagen de la carpeta se pone la imagen default
                    if (seleccionado.ImagenUrl == null)
                        imgArticulo.ImageUrl = "~/Images/Articulos/default.png";

                    //Si es != de vacio y valida la request de la imagen se pone la imagen
                    else if (txtUrlImagen.Text != "" && EsValidaImagen(txtUrlImagen.Text))
                        imgArticulo.ImageUrl = txtUrlImagen.Text;

                    if (File.Exists(rutaFisica))
                    {
                        imgArticulo.ImageUrl = rutaArchivo;
                        InpArchivo.Name = "articulo-" + seleccionado.Id + ".jpg";
                    }
                    else
                        imgArticulo.ImageUrl = "~/Images/Articulos/default.png";



                }
            }
            else
            {
                BtnEliminar.Visible = false;
                BtnEliminar.Enabled = false;
                txtId.Text = "Pendiente";
                imgArticulo.ImageUrl = "~/Images/Articulos/default.png";
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
                articulo.ImagenUrl = txtUrlImagen.Text;
                articulo.Marca = new Marca
                {
                    Id = int.Parse(ddlMarca.SelectedValue)
                };
                articulo.Categoria = new Categoria
                {
                    Id = int.Parse(ddlCategoria.SelectedValue)
                };


                if (InpArchivo.Name != "")
                {
                    //Se obtiene ruta de la carpeta de imagenes de Articulos
                    string ruta = Server.MapPath("./Images/Articulos/");

                    //Escribir img
                    articulo.ImagenUrl = "articulo-" + articulo.Id + ".jpg";
                    InpArchivo.PostedFile.SaveAs(ruta + articulo.ImagenUrl);


                    //borra el texto de la txtUrlImagen
                    txtUrlImagen.Text = "";
                }

                else if ((txtUrlImagen.Text != "") && EsValidaImagen(txtUrlImagen.Text))
                    articulo.ImagenUrl = txtDescripcion.Text;
              
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

        private bool EsValidaImagen (string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;
                    
                    if (response.IsSuccessStatusCode)
                        return true;
                }
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return false;                    
        }

        private void CargarDatosArticuloBasicos()
        {
            try
            {
                txtId.Text = articulo.Id.ToString();
                txtNombre.Text = articulo.Nombre;
                txtCodigo.Text = articulo.CodigoArticulo;
                txtDescripcion.Text = articulo.Descripcion;

                //Seleccion de elementos del pokemon
                ddlMarca.SelectedValue = articulo.Marca.Id.ToString();
                ddlCategoria.SelectedValue = articulo.Categoria.Id.ToString();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
            
        }
    }
}