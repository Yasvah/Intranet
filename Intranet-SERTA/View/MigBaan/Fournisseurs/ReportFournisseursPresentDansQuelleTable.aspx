<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" CodeBehind="ReportFournisseursPresentDansQuelleTable.aspx.vb" Inherits="IntranetSerta.ReportFournisseursPresentDansQuelleTable" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Liste de la présence d'un fournisseur dans baan</h1>
    <p>
        Cette liste indique dans quelle table le fournisseur est présent dans BaaN
    </p>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <rsweb:ReportViewer ID="ReportViewerControle" runat="server" ProcessingMode="Remote" SizeToReportContent="true" AsyncRendering="true">
        <ServerReport ReportPath="/Migration Baan/Fournisseur/FournisseurPresencetableBaan" ReportServerUrl="http://W08R2-EAGLE/ReportServer" />
    </rsweb:ReportViewer>
</asp:Content>
