<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="e_dent._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>. </h1>
            </hgroup>
            <p>
                AIdent es un sistema de apoyo al diagnóstico odontológico potenciado por herramientas de inteligencia computacional y análisis de imágenes digitales.
            </p>
            <p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/main/main.aspx">Ingresar al sistema</asp:HyperLink>
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Si usted visita por primera vez le recomendamos lo siguiente:</h3>
<p>&nbsp;</p>
<p></p>

    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />

    <ol class="round">
        <li class="one">
            <h5>Realizar los tutoriales</h5>
            ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245146">Learn more…</a>
        </li>
        <li class="two">
            <h5>Revisar la documentación</h5>
            NuGet makes it easy to install and update free libraries and tools.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Learn more…</a>
        </li>
        <li class="three">
            <h5>Ponerse en conctacto</h5>
            You can easily find a web hosting company that offers the right mix of features and price for your applications.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Learn more…</a>
        </li>
    </ol>
</asp:Content>
