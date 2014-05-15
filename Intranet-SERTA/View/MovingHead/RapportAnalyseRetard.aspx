<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" CodeBehind="RapportAnalyseRetard.aspx.vb" Inherits="IntranetSerta.RapportAnalyseRetard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Themes/Theme/ModalPopup.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../App_Themes/Theme/ReportViewer.css" rel="stylesheet" type="text/css" media="all" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" SizeToReportContent="true" CssClass="reportViewer">
        <ServerReport ReportServerUrl="http://w08r2-update/ReportServer" ReportPath="/Supplier performance/GROUP/Moving ahead performance 1.9" />
    </rsweb:ReportViewer>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>


    <asp:HiddenField ID="hidForModel" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopErrorShowReport" runat="server" PopupControlID="pnlPopup" TargetControlID="hidForModel" DropShadow="true" OkControlID="btnOk"></asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
        <div class="header">
            Warning
        </div>
        <div class="body">
            Erreur : Impossible de charger le Rapport
        </div>
        <div class="footer">
            <asp:Button ID="btnOk" runat="server" Text="Ok" />
        </div>
    </asp:Panel>
</asp:Content>

