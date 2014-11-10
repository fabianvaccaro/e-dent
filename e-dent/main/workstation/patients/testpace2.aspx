<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testpace2.aspx.cs" Inherits="e_dent.main.workstation.patients.testpace2" %>
<%@ Register TagPrefix="CP" TagName="TestControl" Src="~/main/workstation/patients/testControl1.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    <br />
    <asp:HiddenField ID="hid_protocoloID" runat="server" />
    <br />
    <asp:Button ID="Button2" runat="server" Text="verificacion" OnClick="Button2_Click" />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <CP:TestControl runat="server" Descripcion =" hola" UID =" es el UID "/>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
