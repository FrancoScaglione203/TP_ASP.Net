<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="articulos_web.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-4"></div>
        <div class="col">
            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Usuario</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuario"/>
            </div>
            <div class="mb-3">
                <label for="txtClave" class="form-label">Clave</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtClave" type="password"/>
            </div>
            <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
            <asp:Button Text="Ingresar" CssClass="btn btn-primary" runat="server" ID="btnLogin" OnClick="btnLogin_Click" AutoPostBack="false"/>
        </div>
        <div class="col-4"></div>
    </div>



</asp:Content>
