<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ASP_NET_Framework.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <Main class="d-flex flex-column align-items-center row" >       
                
        <section class="d-flex flex-column col-sm-6 border border-primary align-items-center">
            <asp:Label ID="lblTitulo" runat="server" Text="Login" CssClass="  d-block text-primary text-center display-2 text-md mb-4"/>

            <asp:Label ID="lblEdad" runat="server" Text="Email" CssClass="mb-2"/>
            <asp:TextBox ID="txtEmail" runat="server" CssClass=" w-50 d-block mb-3 form-control border border-primary"></asp:TextBox>

            <asp:Label ID="lblNombre" runat="server" Text="Password" cssClass="mb-2"/>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass=" w-50 d-block mb-3 form-control border border-primary"/>

            <asp:Button runat="server" ID="BtnLogin" Text="Ingresar" CssClass="btn btn-primary w-50" OnClick="BtnLogin_Click"/>
        </section>        
    </Main>
</asp:Content>
