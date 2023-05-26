<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="articulos_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        foreach (dominio.Articulo articulo in ListaArticulos)
        {
    %>
    <div class="card" style="width: 18rem;">
        <a href="Detalle.aspx?id=<%: articulo.Id %>">
            <img class="card-img-top" src="<%: articulo.Imagen.ImagenUrl %>" alt="<%: articulo.Nombre %>"></a>
        <div class="card-body">
            <h5 class="card-title"><%: articulo.Nombre %></h5>
            <p class="card-text"><%: articulo.Precio %></p>
        </div>
    </div>
    <%
        }
    %>
</asp:Content>
