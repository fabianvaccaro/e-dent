<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testpace2.aspx.cs" Inherits="e_dent.main.workstation.patients.testpace2" %>
<%@ Register tagPrefix="CP" tagName="TestControl" src="~/main/workstation/patients/controls/testControl1.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />
    <asp:Button ID="Button2" runat="server" Text="Iniciar Protocolos" OnClick="Button2_Click" />
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:HiddenField ID="hid_protocoloID" runat="server" />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">

            </asp:PlaceHolder>
            
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="145px"  OnRowUpdating="gridUpdate" OnRowUpdated="GridView1_RowUpdated" OnRowEditing="GridView1_RowEditing">
                <Columns >
                    <asp:TemplateField>
                        <ItemTemplate>
                            UID : 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UID" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="TextoUID" runat="server" Text='<%# Bind("UID") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="UpdateButton" runat="server" Text="Update" CommandName="Update"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
            
            
            <br />
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <%--<CP:TestControl ID="patito" runat="server" Descripcion =" hola" UID =" es el UID "/>--%>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
