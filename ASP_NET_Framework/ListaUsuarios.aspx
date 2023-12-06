<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="ASP_NET_Framework.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>USUARIOS</h1>
    <main>             
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="mt-md-4 mb-4">
                    <label for="txtFiltro"> Filtros</label>
                    <label for="cbxFiltroAvanzado">Filtro avanzado</label>
                </div>
               
                    <section class="row border border-2 border-primary-subtle rounded-4 p-4 mb-4">
                        <div class="col">
                            <label for="ddlCampos">Campo</label>
                            <asp:DropDownList runat="server" ID="ddlCampos" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlCampos_SelectedIndexChanged">                             
                            </asp:DropDownList>
                        </div>
                        <div class="col">
                            <label for="ddlCriterio">Criterio</label>
                            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"   >
                            </asp:DropDownList>
                        </div>     
                        <div class="col">
                            <label for="txtFiltroAvanzado">Filtro</label>
                            <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control  " data-cy="txtFiltroAvanzado"/>
                        </div>  

                        <div class="col"> 
                            <asp:Button Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary mt-4" data-cy="btnFiltrar"/>
                        </div>
                    </section>
            </ContentTemplate>
        </asp:UpdatePanel>       
        <asp:UpdatePanel runat="server" >
            <ContentTemplate>               
                <section class=" d-flex flex-column align-items-lg-center">
                 <%
                     if (dgvUsuarios.Rows.Count == 0)
                     {
                %>
                        <label class="text-center mb-3 fw-bold fs-2">No hay resultados!</label>        
                <%
                    }
                    else
                    {
                %>
                    <div class="col-9 mb-3">
                        <asp:GridView runat="server" ID="dgvUsuarios" DataKeyNames="Id" CssClass="table table-dark col-9" 
                            AutoGenerateColumns="false" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" 
                            OnPageIndexChanging="dgvUsuarios_PageIndexChanging" AllowPaging="true" PageSize="7">                   
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
            <asp:HyperLink runat="server" ID="btnAgregar" NavigateUrl="~/UsuarioForm.aspx" CssClass="btn btn-primary mb-3" Text="Agregar Usuario" data-cy="btnAgregarUsuario"/>            
        </section>
            </ContentTemplate>
        </asp:UpdatePanel>      
    </main>
</asp:Content>
