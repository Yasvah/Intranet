<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" CodeBehind="ComptabiliteFormulaire.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="IntranetSerta.CompabiliteFormulaire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Themes/Theme/Formulaire.css" rel="stylesheet" type="text/css" media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="container">
        <span>Add a company Group :</span>
        <asp:TextBox ID="txtboxNomGroupe" runat="server"></asp:TextBox>
        <asp:Button id="btnAjouterGroupe" runat="server" OnClick="btnAjouterGroupe_Click" Text="Add Groupe"/>
        <br />
        <asp:GridView ID="Tableau" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>

                <asp:TemplateField HeaderText="ID" InsertVisible="False">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Code Client">
                    <ItemTemplate>
                        <asp:Label ID="lblcode" runat="server" Text='<%# Eval("code")%>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate> 
                    <asp:TextBox ID="txt1" runat="server" ></asp:TextBox> 
                </FooterTemplate>
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Nom Client">
                     <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("nom")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nom Groupe">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("nomGroupe")%>'></asp:Label>
                    </ItemTemplate>
                   <EditItemTemplate>
                       <asp:DropDownList ID="NewGroupe" runat="server" DataTextField="nomGroupe" DataValueField="id" AutoPostBack ="true" CausesValidation ="true" >
                       </asp:DropDownList>
                    </EditItemTemplate> 
                    <FooterTemplate>
                        <asp:DropDownList ID="cmbNewType" runat="server" DataTextField="Typename" DataValueField="Id"></asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                    <EditItemTemplate>
                        <asp:LinkButton ID="lbkUpdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                        <asp:LinkButton ID="lnkCancel" runat="server"  CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Insert" Text="Insert"></asp:LinkButton>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server"  CommandName="Edit" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField> 

            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        <br />
</div>
</asp:Content>
