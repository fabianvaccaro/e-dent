<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PasoMedicionCtrl.ascx.cs" Inherits="e_dent.main.workstation.patients.controls.PasoMedicionCtrl" %>
<link rel="stylesheet" type="text/css" href="protocolDesigner.css" id="EstiloControles" runat="server"/>

<style type="text/css" media="screen">
    @import "./controls/protocolDesigner.css";
</style>

<asp:Table ID="organizador" runat="server" CssClass="organizador_interno">
    <asp:TableRow>
        <asp:TableCell>
            Variable:
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="txt_variableMedida"  Width="100%"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell>
            Valor:
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="txt_valor" Width="100%"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="3">
            <asp:Label ID="lbl_detalle" Width="40%" runat="server"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="btn_editarDetalle" runat="server" Text="Editar"  OnClick="btn_editarDetalle_Click"/>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
