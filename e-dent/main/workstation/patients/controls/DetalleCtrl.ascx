<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetalleCtrl.ascx.cs" Inherits="e_dent.main.workstation.patients.controls.DetalleCtrl" %>
<link rel="stylesheet" type="text/css" href="protocolDesigner.css" id="EstiloControles" runat="server"/>

<style type="text/css" media="screen">
    @import "./controls/protocolDesigner.css";
</style>

        <asp:Table ID="detalle_principal" runat="server" CssClass="detalle_principal">
            <asp:TableRow>
                <asp:TableCell CssClass="odontograma_titulo">
                    Odontograma
                </asp:TableCell>
                <asp:TableCell>
                    Otro contenido
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="odontograma_principal">
                    Introducir aqui odontograma
                </asp:TableCell>
                <asp:TableCell>
                    Introducir aquí otro contenido
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
