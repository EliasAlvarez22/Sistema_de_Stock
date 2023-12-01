﻿<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ASP_NET_Framework.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="">
        <h1>Articulos</h1>
        <div class="row row-cols-1 row-cols-md-3 g-4">              
           <asp:Repeater runat="server" ID="RptArticulos" OnItemDataBound="RptArticulos_ItemDataBound">
               <ItemTemplate>
                   <div class="col d-flex ">
                    <article class="card" style="width:340px">
                        <asp:Image ID="imgArticulo" runat="server" ImageUrl='<%#Eval("ImagenUrl") %>' CssClass="card-img-top " alt='<%#Eval("Nombre") %>'  style="height:250px"  />
                        <div class="card-body"  >
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text" style="height:40px"><%#Eval("Descripcion") %></p>
                            <div class="d-flex align-items-center">
                                <a href="ArticuloForm.aspx?id=<%#Eval("Id") %>" class="btn btn-primary">Ver detalle</a>
                                <button runat="server" ID="BtnAgregarFavorito" CommandArgument='<%#Eval("Id") %>' OnClick="BtnAgregarFavorito_Click"
                                CommandName="IdArticulo" CssClass="">
                                <i id="agregarFav" class="bi bi-heart-fill"></i> 
                                </button>
                            </div>                           
                        </div>
                    </article>
                </div>
               </ItemTemplate>
           </asp:Repeater>
        </div>
    </main>
</asp:Content>
