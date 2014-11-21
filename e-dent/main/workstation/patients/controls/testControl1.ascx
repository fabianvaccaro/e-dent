<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="testControl1.ascx.cs" Inherits="e_dent.main.workstation.patients.testControl1" %>
<%-- Los controles deben colocarse dentro de un directorio llamado "controls" junto con el CSS para que puedan ser renderizados en el navegador --%>
<link rel="stylesheet" type="text/css" href="protocolDesigner.css" id="EstiloControles" runat="server"/>

<style type="text/css" media="screen">
    @import "./controls/protocolDesigner.css";
</style>

<asp:Table ID="Table1" runat="server" CssClass =" pasoSt">
    <asp:TableRow runat="server">
        <asp:TableCell  CssClass="lol1">
            <asp:Label ID="lbl_nombrePaso" runat="server" Text="Nombre" Font-Size="X-Small"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell  CssClass="lol2">
            <asp:TextBox ID="txt_descripcion" runat="server" CssClass="textoDescripcion"  TextMode="MultiLine"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Table ID="footBtn" runat="server"  CssClass="tbFoot">
    <asp:TableRow runat="server">
        <asp:TableCell runat="server" CssClass="tbCell">
            <asp:ImageButton runat="server" ImageUrl="~/Images/bt_nuevoPaso.png" ImageAlign="Top" BorderWidth="0px" Width="80px" Height="20px" CssClass="btnPuerco" OnClick="tclick"/>
            <%--<asp:Image runat="server" ImageUrl="~/Images/bt_nuevoPaso.png" ImageAlign="Top" />--%>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>


