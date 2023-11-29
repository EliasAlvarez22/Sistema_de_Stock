<%@ Page Title="Formulario de Artículo " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticuloForm.aspx.cs" Inherits="ASP_NET_Framework.ArticuloForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/ArticuloForm.css" rel="stylesheet" />
    <div class="row">
        <div class="col-md-5 me-md-auto">
            <div class="mb-3">
                <Label for="txtId" class="form-label">ID</Label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <Label for="txtNombre" class="form-label">Nombre</Label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <Label for="txtCodigo" class="form-label">Código</Label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control"/>
            </div>                                               
            <div class="mb-3">
                <Label for="ddlMarca" class="form-label me-3">Marca</Label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select pr-3"/>
            </div>
            <div class="mb-3">
                <Label for="ddlCategoria" class="form-label me-3">Categoria</Label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select pr-3"/>
            </div>            
        </div>
        <div class="col-md-5">
            <div class="mb-3">
                <Label for="txtDescripcion" class="form-label">Descripción</Label>
                <asp:TextBox runat="server" ID="txtDescripcion" textMode="MultiLine" CssClass="form-control"/>
            </div>
            <asp:UpdatePanel runat="server" ID="udpPanel">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtUrlImagen" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtUrlImagen" CssClass="form-control mb-3" OnTextChanged="txtUrlImagen_TextChanged"  
                            AutoPostBack="true"/>   
                        <asp:FileUpload runat="server" ID="FudImagen" CssClass="form-control mb-5" />
                    </div>
                    <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Pokebola-pokeball-png-0.png/800px-Pokebola-pokeball-png-0.png"
                        runat="server" ID="imgPokemon" Width="60%" CssClass="ms-lg-5" Height="250px"/>
                </ContentTemplate>
            </asp:UpdatePanel>            
        </div>
    </div>
    <div class="row">
        <div class="mb-5">
                <asp:Button runat="server" ID="btnAgregar"  Text="Agregar" CssClass="btn btn-success me-6 me-5" OnClick="btnAgregar_Click"/>
                <asp:HyperLink runat="server" ID="btnCancelar" CssClass="btn btn-danger" NavigateUrl="~/ListaArticulos.aspx" Text="Cancelar"/>
        </div>  
        <asp:UpdatePanel runat="server" ID="UdpEliminacion">
            <ContentTemplate>                
                    <asp:Button ID="BtnEliminar" Text="Eliminar" runat="server" CssClass="btn btn-danger d-block mb-3" OnClick="BtnEliminar_Click"/>

                    <% if (EliminarArticulo){%>
                    <label>¿Confirma eliminación del artículo?</label>
                    <asp:Button Text="Confirmar" runat="server" id="BtnConfirmar" CssClass="btn btn-danger" OnClick="BtnConfirmar_Click" data-bs-toggle="modal" data-bs-target="#miModal"/>               
                    <%} %>                                
            </ContentTemplate>
        </asp:UpdatePanel>   
        
        <!-- Modal -->
        <div class="modal fade" id="miModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
              <div class="modal-header text-bg-success">
                <h5 class="modal-title" id="exampleModalLabel">Articulo Eliminado correctamente!</h5>
              </div>
              <div class="modal-body text-center">
                <i class="bi bi-exclamation-circle-fill text-success icon_eliminado "></i>
              </div>
              <div class="modal-footer justify-content-center">
                  <a href="ListaArticulos.aspx" class="link-underline-light text-bg-success rounded-pill fs-5 btn">Volver a la lista de artículos</a
              </div>
            </div>
          </div>
        </div>
    </div>        
</asp:Content>
