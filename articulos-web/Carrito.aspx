<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="articulos_web.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel runat="server">
        <ContentTemplate runat="server">

            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="card mb-3 " style="max-width: 1040px;">
                        <div class="row g-0">
                            <div class="col-md-4">
                                <img src="<%#Eval("Imagen") %>" class="img-fluid rounded-start" alt="..." style="max-height: 150px">
                            </div>
                            <div class="col-md-8">
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text"><%#Eval("Descripcion") %></p>
                                    <p class="card-text"><small class="text-body-secondary">$<%#Eval("Precio") %></small></p>
                                    <asp:Button  Text="Eliminar" AutoPostBack="true" cssClass="btn btn-primary w-25" runat="server" ID="btnEliminarCarrito" OnClick="btnEliminarCarrito_Click" Enabled="True"  />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div class="col-md-4" Cssclass="align-middle text-end">
                <h2 Cssclass="align-middle text-end" >TOTAL</h2>
                <asp:Label runat="server" ID="lblTotal" CssClass="align-middle text-end"></asp:Label>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>




</asp:Content>
