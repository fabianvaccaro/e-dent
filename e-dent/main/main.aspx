<%@ Page Title="Panel principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="e_dent.main.main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/main/workstation/main.aspx">Atención al público</asp:HyperLink>
    </p>
    <p>
        Administración</p>
</asp:Content>
