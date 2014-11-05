<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="unified_record.aspx.cs" Inherits="e_dent.main.workstation.patients.unified_record" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 503px;
        }
        .auto-style4 {
            width: 269px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    Introduzca el ID (Número identificador unificado) del paciente:<br />
                    <asp:TextBox ID="txt_pacid" runat="server"></asp:TextBox>
                <br />
                    <asp:Button ID="btn_continue" runat="server" OnClick="Button1_Click" Text="Continuar" />
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style3"><strong>Nombre del paciente:</strong><br />
                                <asp:Label ID="lbl_nmpac" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><strong>Documento de Identidad:</strong><br />
                                <asp:Label ID="lbl_dni" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><strong>Fecha de nacimiento:</strong><br />
                                <asp:Label ID="lbl_born" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><strong>Etnia:</strong><br />
                                <asp:Label ID="lbl_race" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><strong>Domicilio:</strong><br />
                                <asp:Label ID="lbl_address" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><strong>Teléfono fijo:</strong><br />
                                <asp:Label ID="lbl_phone1" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><strong>Telófono movil:</strong><br />
                                <asp:Label ID="lbl_phone2" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><strong>Trabajo:</strong><br />
                                <asp:Label ID="lbl_job" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><strong>Unidad educativa o centro social:</strong><br />
                                <asp:Label ID="lbl_school" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><strong>Seguro:</strong><br />
                                <asp:Label ID="lbl_ensur" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    Paciente no encontrado<br />
                    <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Volver" />
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        &nbsp;</p>
</asp:Content>
