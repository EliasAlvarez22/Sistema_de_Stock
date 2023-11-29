<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ASP_NET_Framework.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Mí Perfil</h1>
    <div class="row">
        <section class="col-md-5 me-lg-5 mb-5" >
            <label for="txtEmail">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" cssClass="mb-3 form-control"/> 

            <label for="txtNombre">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" cssClass="mb-3 form-control"/> 

            <label for="txtApellido">Apellido</label>
            <asp:TextBox ID="TextBox1" runat="server" cssClass="mb-3 form-control"/>          

            <div class="form-check form-switch">
                <input class="form-check-input btn btn-success" ID="cbxAdmin" type="checkbox" runat="server" disabled>
                <span>Admin</span>
            </div>
            <asp:Button runat="server" Text="Guardar Datos" ID="btnGuardarDatos" OnClick="btnGuardarDatos_Click" CssClass="btn btn-primary mt-5"/>

        </section>
        <div class="col-md-4">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <input type="file" name="txtImagen" runat="server" ID="txtImagen" class="form-control mb-3" onchange="txtImagen_onchange"/>
                    <asp:Image ID="imgPerfil" CssClass="img-fluid" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
       </div>    
     </div>
</asp:Content>
