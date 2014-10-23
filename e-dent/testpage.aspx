<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testpage.aspx.cs" Inherits="e_dent.testpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
    
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="NOMBRE"></asp:Label>
                <br />
                <asp:TextBox ID="txt_username" runat="server" OnTextChanged="txt_username_TextChanged"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lbl_info" runat="server" Text="INFO"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Crear" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                Ingrese ID de usuario:<br />
                <asp:TextBox ID="txt_getUsername" runat="server"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Buscar nombre de usuario" OnClick="Button2_Click" />
                <br />
                <asp:Label ID="lbl_retUserName" runat="server" Text="XXXXXX"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                ID de Paciente:<br />
                <asp:TextBox ID="txt_ptID" runat="server" Height="21px"></asp:TextBox>
                <asp:Button ID="Button4" runat="server" Text="Obtener Nombre" OnClick="Button4_Click" />
                <br />
                Nombre nuevo<br />
                <asp:TextBox ID="txt_ptNombre" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button3" runat="server" Text="Cambiar nombre" OnClick="Button3_Click" />
                <br />
                <asp:Label ID="lbl_perra" runat="server" Text="MOSTRAR"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
