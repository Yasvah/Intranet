<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" CodeBehind="ReportFournisseursMatch.aspx.vb" Inherits="IntranetSerta.ReportFournisseursMatch" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../App_Themes/Theme/ReportViewer.css" rel="stylesheet" type="text/css" media="all" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Correspondance entre les fournisseurs Baan et Sage</h1>
    <p>Correspondance entre les fournisseurs Baan et les fournisseurs de la comptabilité. <br /> <br />
        <span style="background-color:#DBE5F1;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span> : Liste des fournisseurs qui n'ont pas le même "code" <br />
        <span style="background-color:#EBB4B4;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span> : Liste des fournisseurs qui n'ont pas le même statut (Ex : Désactivé dans Sage et pas dans Baan)
    </p>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <rsweb:ReportViewer ID="ReportViewerControl" runat="server" ProcessingMode="Remote" SizeToReportContent="true" AsyncRendering="true">
        <ServerReport ReportPath="/Migration Baan/Fournisseur/FournisseurMatch" ReportServerUrl="http://W08R2-EAGLE/ReportServer" />
    </rsweb:ReportViewer>
</asp:Content>
