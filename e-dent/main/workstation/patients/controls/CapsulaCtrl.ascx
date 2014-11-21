<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CapsulaCtrl.ascx.cs" Inherits="e_dent.main.workstation.patients.controls.CapsulaCtrl" %>
<%@ Register TagPrefix="PS" TagName="PasoOperativo" Src="~/main/workstation/patients/controls/PasoOperativoCtrl.ascx" %>
<%@ Register TagPrefix="PS" TagName="DetalleCtrl" Src="~/main/workstation/patients/controls/DetalleCtrl.ascx" %>
<%@ Register TagPrefix="PS" TagName="MedicionCtrl" Src="~/main/workstation/patients/controls/PasoMedicionCtrl.ascx" %>


<link rel="stylesheet" type="text/css" href="protocolDesigner.css" id="EstiloControles" runat="server"/>

<style type="text/css" media="screen">
    @import "./controls/protocolDesigner.css";
</style>
<%--<asp:Label ID="lbl_indexador" runat="server" Text="XXXX"></asp:Label>--%>
        <asp:Table runat="server" ID="encapsulador" CssClass="organizador_externo">
            <asp:TableRow >
                <asp:TableCell ID="controlPrincipal">
                    <asp:Panel ID="panelCtrlPrincipal" runat="server"></asp:Panel>
                </asp:TableCell>
                <asp:TableCell CssClass="accesorios_derecha">
                    <asp:ImageButton ID="btn_anadir" runat="server" CssClass="btnAnadir" ImageUrl="~/Images/plusSignSmall.png"  OnClick="btn_anadir_Click" Width="30px" Height="30px"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell  ID="controlInferior" ColumnSpan="2">
                     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" Visible="false">
                        <asp:View ID="vista_detalle" runat="server">
                            <PS:DetalleCtrl ID="ct_detalle" runat="server" />
                        </asp:View>
                         <asp:View ID="vista_nuevo" runat="server">
                             <asp:Button ID="dummybtn" runat="server" Text="dummy"  OnClick="dummybtn_Click"/>
                             <asp:Button ID="btn_addPasoOperativo" runat="server" Text="Paso Operativo"  OnClick="btn_addPasoOperativo_Click"/>
                             <asp:Button ID="btn_addPasoMedicion" runat="server" Text="Medicion" OnClick="btn_addPasoMedicion_Click"/>
                         </asp:View>
                    </asp:MultiView>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
