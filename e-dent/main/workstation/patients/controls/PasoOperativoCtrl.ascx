<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PasoOperativoCtrl.ascx.cs" Inherits="e_dent.main.workstation.patients.controls.PasoOperativoCtrl" %>
<link rel="stylesheet" type="text/css" href="protocolDesigner.css" id="EstiloControles" runat="server"/>

<style type="text/css" media="screen">
    @import "./controls/protocolDesigner.css";
</style>

<asp:Table ID="organizador" runat="server" CssClass="organizador_interno">
    <asp:TableRow runat="server">
        <asp:TableCell CssClass="primera">
            Actividad:
        </asp:TableCell>
        <asp:TableCell runat="server" ColumnSpan="5">
            <asp:TextBox ID="txt_actividad" runat="server" TextMode="MultiLine" CssClass="actividad"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell CssClass="primera">
            Detalle:
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="lbl_detalle" runat="server" Text="" CssClass="lblDetalle"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="btn_editarDetalle" runat="server" Text="Editar"  OnClick="btn_editarDetalle_Click" CausesValidation="false"/>
        </asp:TableCell>
        <asp:TableCell>
            Espera:
        </asp:TableCell>
        <asp:TableCell CssClass="segunda">
            <asp:CheckBox ID="chk_espera" runat="server"  AutoPostBack="True" OnCheckedChanged="chk_espera_CheckedChanged"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txt_tiempoEspera" runat="server" TextMode="Time" CssClass="espera"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>


