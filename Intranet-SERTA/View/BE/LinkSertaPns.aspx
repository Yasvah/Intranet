<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" CodeBehind="LinkSertaPns.aspx.vb" Inherits="IntranetSerta.LinkSertaPns" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Themes/Theme/TabContainer.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../App_Themes/Theme/ReportViewer.css" rel="stylesheet" type="text/css" media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ajaxscriptmanager" runat="server"></ajaxToolkit:ToolkitScriptManager>

    <ajaxToolkit:TabContainer
        ID="TabContainer"
        runat="server"
        ActiveTabIndex="0"
        CssClass="TabContainer_theme">

        <%--    ---------------------- ONGLET NOUVELLE CORRESPONDANCE ----------------------------
    Cette Onglet permet de valider et de corriger le statut si besoin des nouvelles 
    correspondances dans la base de donnée
    ------------------------------------------------------------------------------------%>


        <ajaxToolkit:TabPanel
            ID="TabPanelNewLink"
            runat="server"
            HeaderText="Nouvelle correspondance">

            <ContentTemplate>

                <asp:GridView
                    ID="GridViewNew"
                    runat="server"
                    CellPadding="4"
                    ForeColor="#333333"
                    GridLines="None"
                    AutoGenerateColumns="false"
                    AllowPaging="true"
                    OnPageIndexChanging="Table_PageIndexChanging"
                    PageSize="40"
                    Width="1200">

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="T_ARTICLE_ART.ART_REFERENCE" HeaderText="Réference SERTA" />
                        <asp:BoundField DataField="T_ARTICLE_ARP.ARP_REFERENCE" HeaderText="Réference PNS" />
                        <asp:BoundField DataField="Source" HeaderText="Source" />
                        <asp:TemplateField HeaderText="Statut">
                            <ItemTemplate>
                                <asp:DropDownList runat="server" ID="DropBoxStatut" CausesValidation="false" DataValueField="Source">
                                    <asp:ListItem Text="Principale" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Secondaire" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID='btn' runat="server" Text="Ok" OnCommand="lnkBtn_Command"
                                    CommandArgument='<%# CStr(Eval("T_ARTICLE_ART.ART_REFERENCE")) + "," + CStr(Eval("T_ARTICLE_ARP.ARP_REFERENCE")) + "," + CStr(Eval("source"))%>' CommandName="Ok" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <asp:Label ID="lblMessageNewLink" runat="server" Text="Il n'y a pas de nouvelle correspondance à importer"></asp:Label>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>


        <%--    ---------------------- ONGLET MODIFIER CORRESPONDANCE ----------------------------
        Cette Onglet permet de modifier le statut si besoin des nouvelles 
        correspondances dans la base de donnée
        ------------------------------------------------------------------------------------%>


        <ajaxToolkit:TabPanel ID="TabPanelUpdate" runat="server" HeaderText="Modifier les correspondances">
            <ContentTemplate>

                <br />
                <div id="ControlFilter" style="text-align: center;">
                    Référence SERTA :
                    <asp:TextBox ID="TextBoxFindRefSERTA" runat="server"></asp:TextBox>
                    Référence PNS :
                    <asp:TextBox ID="TextBoxFindRefPNS" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnFind" runat="server" Text="Rechercher" />
                </div>
                <br />


                <asp:GridView
                    ID="GridViewUpdate"
                    runat="server"
                    CellPadding="5"
                    ForeColor="#333333"
                    GridLines="None"
                    AutoGenerateColumns="false"
                    AllowPaging="true"
                    OnPageIndexChanging="Table_PageIndexChanging"
                    PageSize="40"
                    HorizontalAlign="Center"
                    Width="1200">

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="T_ARTICLE_ART.ART_REFERENCE" ReadOnly="true" HeaderText="Réference SERTA" />
                        <asp:BoundField DataField="T_ARTICLE_ARP.ARP_REFERENCE" ReadOnly="true" HeaderText="Réference PNS" />
                        <asp:BoundField DataField="T_SOURCE_JAA_JSR.JSR_LIBELLE" ReadOnly="true" HeaderText="Source" />
                        <asp:TemplateField HeaderText="Statut">
                            <ItemTemplate>
                                <asp:Label ID="LabelStatut" runat="server" Text='<%# Eval("T_STATUT_JAA_JST.JST_LIBELLE")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList runat="server" ID="DropBoxStatut" CausesValidation="false" DataValueField="Source">
                                    <asp:ListItem Text="Principale" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Secondaire" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                            <EditItemTemplate>
                                <asp:LinkButton ID="lbkUpdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        <%--    ---------------------- ONGLET SUPPRIMER PURGER CORRESPONDANCE ----------------------------
        Cette Onglet permet de purger les correspondances dans la base de donnée
        ------------------------------------------------------------------------------------%>


        <ajaxToolkit:TabPanel ID="TabPanelDelete" runat="server" HeaderText="Purger les correspondances">
            <ContentTemplate>

                <asp:GridView
                    ID="GridViewPurge"
                    runat="server"
                    CellPadding="4"
                    ForeColor="#333333"
                    GridLines="None"
                    AutoGenerateColumns="false"
                    AllowPaging="true"
                    OnPageIndexChanging="Table_PageIndexChanging"
                    PageSize="40"
                    HorizontalAlign="Center"
                    Width="1200">

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="T_ARTICLE_ART.ART_REFERENCE" HeaderText="Réference SERTA" />
                        <asp:BoundField DataField="T_ARTICLE_ARP.ARP_REFERENCE" HeaderText="Réference PNS" />
                        <asp:BoundField DataField="T_SOURCE_JAA_JSR.JSR_LIBELLE" HeaderText="Source" />
                        <asp:BoundField DataField="T_STATUT_JAA_JST.JST_LIBELLE" HeaderText="Statut" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID='btnDelete' runat="server" Text="Supprimer" OnCommand="btnDelete_Click"
                                    CommandArgument='<%# CStr(Eval("JAA_ID"))%>' CommandName="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <span style="align-content:center;">
                <asp:Label ID="lblMessagePurge" runat="server" Text="Il n'y a pas de correspondances à purger"></asp:Label>
                    </span>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

         <%--    ---------------------- ONGLET SUPPRIMER ANALYSE ANOMALIES ----------------------------
        Cette Onglet permet d'analyser tout les anomalies détecté par le rapport
        ------------------------------------------------------------------------------------%>

        <ajaxToolkit:TabPanel ID="TabPanelAnalyse" runat="server" HeaderText="Analyse des anomalies">
            <ContentTemplate>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" SizeToReportContent="true" CssClass="reportViewer">
                    <ServerReport ReportServerUrl="http://W08R2-EAGLE/ReportServer/" ReportPath="/BE/AnomalieSynchroArticleSERTAPNS" />
                </rsweb:ReportViewer>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
