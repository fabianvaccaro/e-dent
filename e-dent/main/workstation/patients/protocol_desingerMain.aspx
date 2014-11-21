<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="protocol_desingerMain.aspx.cs" Inherits="e_dent.main.workstation.patients.protocol_desingerMain" %>
<%@ Register tagPrefix="CP" tagName="PasoOperativoCtrl" src="~/main/workstation/patients/controls/PasoOperativoCtrl.ascx" %>
<%@ Register TagPrefix="PS" TagName="CapsulaCtrl" Src="~/main/workstation/patients/controls/CapsulaCtrl.ascx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="./controls/protocolDesigner.css" id="EstiloControles" runat="server"/>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="disenadorID" runat="server" />
    <h1>Protocol Designer</h1>
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>

            <asp:Button ID="btn_testPaso" runat="server" Text="nuevoPaso"  OnClick="btn_testPaso_Click"/>
            <asp:Table ID="designer_organizer" runat="server" CssClass="designer_organizer">
                <asp:TableRow>
                    <asp:TableCell CssClass="celdaMultivisor">
                        <asp:Panel ID="pnl_multivisor" runat="server"></asp:Panel>
                    </asp:TableCell>
                    <asp:TableCell CssClass="celdaControlesLaterales">
                        Informacion y controles laterales
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>



            <asp:Panel ID="Panel1" runat="server">
                
            </asp:Panel>
            <asp:PlaceHolder ID="MIPLACE" runat="server"></asp:PlaceHolder>

            
     <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--<PS:CapsulaCtrl ID="asdfas" runat="server"/>--%>
</asp:Content>
