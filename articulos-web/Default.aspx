<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="articulos_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="home">
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <div class="sidebar">
                        

                        <ul class="list-group">
                          <li class="list-group-item">
                        <h3>Filtrar por marca</h3>
                            <asp:RadioButtonList ID="rblMarcas" runat="server"></asp:RadioButtonList>
                          </li>
                          <li class="list-group-item">
                            <h3>Filtrar por categoria</h3>
                            <asp:RadioButtonList ID="rblCategorias" runat="server"></asp:RadioButtonList>
                          </li>
                          <li class="list-group-item">
                                <h3>Filtrar por nombre</h3>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                          </li>
                          <li class="list-group-item">
                              <h3>Filtrar por Precio</h3>
                              <asp:TextBox ID="txtPrecioMin" runat="server" CssClass="form-control" placeholder="Precio minimo"></asp:TextBox>
                          </li>
                          <li class="list-group-item">
                                <asp:TextBox ID="txtPrecioMax" runat="server" CssClass="form-control" placeholder="Precio maximo"></asp:TextBox>
                          </li >
                            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" style="margin: 10px;"/>
                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-primary" OnClick="btnLimpiar_Click" style="margin: 10px;" />
                        </ul>
                    </div>
                </div>
                <div class="col-md-9">
                    <div class="product-list">
                        <div class="row">
                            <%
                                foreach (dominio.Articulo articulo in ListaArticulos)
                                {
                            %>

                            <div class="col-md-4">
                                <div class="card">
                                    <a href="Detalle.aspx?id=<%: articulo.Id %>">
                                        <img class="card-img-top" src="<%:articulo.Imagen.ImagenUrl %>" alt="<%: articulo.Nombre %>"></a>
                                    <div class="card-body">
                                        <h5 class="card-title"><%: articulo.Marca.Descripcion %></h5>
                                        <h5 class="card-title"><%: articulo.Nombre %></h5>
                                        <p class="card-text precio">$<%: articulo.Precio %></p>
                                    </div>
                                </div>
                            </div>
                            <%
                                }
                            %>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
