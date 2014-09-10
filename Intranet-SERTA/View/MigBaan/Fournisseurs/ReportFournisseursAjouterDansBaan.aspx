<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" CodeBehind="ReportFournisseursAjouterDansBaan.aspx.vb" Inherits="IntranetSerta.ReportFournisseursAjouterDansBaan" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Themes/Theme/ReportViewer.css" rel="stylesheet" type="text/css" media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Liste des fournisseurs à ajouter dans Baan</h1>
    <p>Cette liste est extraite de Sage. Elle est filtré sur les fournisseurs actif et ou la mention "A CREER DS BAAN" est présente dans le champs code barre ou commentaire</p>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <rsweb:ReportViewer ID="ReportViewerControl" runat="server" ProcessingMode="Remote" SizeToReportContent="true" AsyncRendering="true">
        <ServerReport ReportPath="/Migration Baan/Fournisseur/FournisseurAAjouterBaan" ReportServerUrl="http://W08R2-EAGLE/ReportServer" />
    </rsweb:ReportViewer>
</asp:Content>
