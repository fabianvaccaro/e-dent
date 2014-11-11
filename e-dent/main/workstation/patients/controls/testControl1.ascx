<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="testControl1.ascx.cs" Inherits="e_dent.main.workstation.patients.testControl1" %>
<style type="text/css">
    .pasoSt
    {
        width : 200px;
        border : solid;
        border-color : black;
        border-style : solid;
        margin-bottom : 5px;
        padding-bottom : 5px;
    }
    .lol1
    {
        padding-bottom : 2px;
        padding-top : 2px;
        padding-left : 5px;
        padding-right: 5px;
        vertical-align : bottom;
        

    }
    .lol2
    {
        padding-bottom : 5px;
        padding-top : 0px;
        padding-left : 5px;
        padding-right: 5px;
        vertical-align : top;
        text-align : center;
        height : 100px;
    }
    .textoDescripcion
    {
        height : 80px;
        font-size: small;
        width : 95%;
        resize : none;
    }
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

