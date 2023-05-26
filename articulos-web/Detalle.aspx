<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="articulos_web.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row my-5 justify-content-center">
        <div class="col-lg-1 col-md-1 col-sm-1 text-center">
            <div class="detail-img-container-mini">
                <asp:Image ID="ImagenMini1" class="detail-img" src="https://http2.mlstatic.com/D_NQ_NP_796892-MLA46114829828_052021-O.webp" alt="producto" runat="server" />
            </div>
            <div class="detail-img-container-mini">
                <asp:Image ID="ImagenMini2" class="detail-img" src="https://http2.mlstatic.com/D_NQ_NP_796892-MLA46114829828_052021-O.webp" alt="producto" runat="server" />
            </div>
            <div class="detail-img-container-mini">
                <asp:Image ID="ImagenMini3" class="detail-img" src="https://http2.mlstatic.com/D_NQ_NP_796892-MLA46114829828_052021-O.webp" alt="producto" runat="server" />
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-3 text-center">
            <div class="detail-img-container">
                <asp:Image ID="ImagenDetalle" class="detail-img" src="https://http2.mlstatic.com/D_NQ_NP_796892-MLA46114829828_052021-O.webp" alt="producto" runat="server" />
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-1">
            <div class="my-5 detail-info-container">
                <h2>Iphone 11</h2>
                <h4>$349.899</h4>
                <h5 class="texto-azul">Marca:</h5>
                <p>Apple</p>
                <h5 class="texto-azul">Descripción:</h5>
                <p>Graba videos 4K y captura retratos espectaculares y paisajes increíbles con el sistema de dos cámaras. Toma grandes fotos con poca luz gracias al modo Noche. Disfruta colores reales en las fotos, videos y juegos con la pantalla Liquid Retina de 6.1 pulgadas</p>
                <asp:Button class="btn btn-primary w-100" ID="AddCart" runat="server" Text="Añadir al carrito" />
            </div>
        </div>
        <div>
        </div>
    </div>
</asp:Content>
