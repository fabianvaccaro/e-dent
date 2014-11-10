<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="testControl1.ascx.cs" Inherits="e_dent.main.workstation.patients.testControl1" %>
<style type="text/css">
    .auto-style1 {
        height: 23px;
    }
    </style>
<table style="border: thin solid #000000; width:240px;" border="0">
    <tr>
        <td colspan="2" class="auto-style1">
            <asp:Label ID="lbl_nombrePaso" runat="server" Text="Nombre"></asp:Label>
        </td>
        <td class="auto-style1"></td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:TextBox ID="txt_descripcion" runat="server" Width="219px" OnTextChanged="txt_descripcion_TextChanged"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 33%">
            <asp:CheckBox ID="PasoSeleccionado" runat="server" OnCheckedChanged="PasoSeleccionado_CheckedChanged" Text=" "  />
        </td>
        <td style="width: 33%; text-align: center; vertical-align: bottom;">
            <asp:ImageButton ID="btn_nuevoPaso" runat="server" Height="12px" ImageUrl="~/Images/plusSignSmall.png" Width="12px" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>