<%@ Page Title="Lista de Artículos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="ASP_NET_Framework.ListaArticulos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>             
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="mt-md-4 mb-4">
                    <label> Filtros</label>
                    <asp:TextBox runat="server" ID="txtFiltro" placeholder="Nombre,código.."  AutoPostBack="true" CssClass="form-control d-inline-block" data-cy="txtFiltroRapido" OnTextChanged="txtFiltro_TextChanged" Width="300px"/>                            
                    <label>Filtro avanzado</label>
                    <asp:CheckBox runat="server" ID="cbxFiltroAvanzado" AutoPostBack="true" CssClass="ms-lg-2 " data-cy="cbxFiltroAvanzado"/>
                </div>
                <%if (cbxFiltroAvanzado.Checked)
                  {
                %>
                    <section class="row border border-2 border-primary-subtle rounded-4 p-4 mb-4">
                        <div class="col">
                            <label>Campo</label>
                            <asp:DropDownList runat="server" ID="ddlCampos" CssClass="form-control" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddlCampos_SelectedIndexChanged">                             
                            </asp:DropDownList>
                        </div>
                        <div class="col">
                            <label>Criterio</label>
                            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control" Width="300px" >
                            </asp:DropDownList>
                        </div>     
                        <div class="col">
                            <label>Filtro</label>
                            <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control  d-inline-block " Width="300px" data-cy="txtFiltroAvanzado"/>
                        </div>  
                        <div class="col"> 
                            <asp:Button Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary mt-4" data-cy="btnFiltrar"/>
                        </div>
                    </section>
                <%}%>
            </ContentTemplate>
        </asp:UpdatePanel>       
        <asp:UpdatePanel runat="server" >
            <ContentTemplate>               
                <section class=" d-flex flex-column align-items-lg-center">
                 <%
                     if (dgvArticulos.Rows.Count == 0)
                     {
                %>
                        <label class="text-center mb-3 fw-bold fs-2">No hay resultados!</label>        
                <%
                    }
                    else
                    {
                %>
                    <div class="col-9 mb-3">
                        <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="Id" CssClass="table table-dark col-9" 
                            AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" Width="860px" 
                            OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="7">                   
                           <columns>
                                <asp:boundfield  headertext="Codigo" datafield="CodigoArticulo"/>
                                <asp:boundfield  headertext="Nombre" datafield="Nombre"/>
                                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                                <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion"/>
                                <asp:commandfield headertext="Acción" showselectbutton="true" SelectText='<i class="bi bi-pencil-fill"></i>' ItemStyle-ForeColor="#0099ff"/> 
                            </columns>                    
                        </asp:GridView>
                    </div>                    
                    <%
                    }
                    %>                    
            <asp:HyperLink runat="server" ID="btnAgregar" NavigateUrl="~/ArticuloForm.aspx" CssClass="btn btn-primary mb-3" Text="Agregar Pokemon" data-cy="btnAgregarPokemon"/>            
        </section>
            </ContentTemplate>
        </asp:UpdatePanel>      
    </main>
</asp:Content>