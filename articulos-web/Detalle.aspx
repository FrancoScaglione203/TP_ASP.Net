<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="articulos_web.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row my-5 justify-content-center">
        <div class="col-lg-1 col-md-1 col-sm-1 text-center">
            <%
                foreach (dominio.Imagen imagen in listaImagenes)
                {
            %>
            <div class="detail-img-container-mini">
                <img id="ImagenMini<%:imagen.Id %>" class="detail-img" src="<%:imagen.ImagenUrl %>" alt="producto"  />
            </div>
            <%
                }
            %>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-3 text-center">
            <div class="detail-img-container">
                <img id="ImagenDetalle" class="detail-img" src="<%:listaImagenes[0].ImagenUrl %>" alt="producto" onerror="this.src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSr3lojbtBPci4ZIOczT8VHnHr6X4Wj2zPUSrmMCRyCuGlEOYX3D-S7PiT07ImUMLuIm2M&usqp=CAU'" />
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-1">
            <div class="my-5 detail-info-container">
                <h2><%: articulo.Nombre %></h2>
                <h4>$<%: articulo.Precio %></h4>
                <h5 class="texto-azul">Marca:</h5>
                <p><%: articulo.Marca %></p>
                <h5 class="texto-azul">Descripción:</h5>
                <p><%: articulo.Descripcion %></p> 
                <asp:Button class="btn btn-primary w-100" ID="AddCart" runat="server" Text="Añadir al carrito" OnClick="AddCart_Click" />
            </div>
        </div>
        <div>
        </div>
    </div>
</asp:Content>
