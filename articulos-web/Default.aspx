<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="articulos_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="home">
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <div class="sidebar">
                        <!-- Aquí van tus filtros -->
                        <h5>Filtros</h5>
                        <ul>
                            <li>Filtro 1</li>
                            <li>Filtro 2</li>
                            <li>Filtro 3</li>

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
