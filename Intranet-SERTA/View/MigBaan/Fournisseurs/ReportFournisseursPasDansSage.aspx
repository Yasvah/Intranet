<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" CodeBehind="ReportFournisseursPasDansSage.aspx.vb" Inherits="IntranetSerta.ReportFournisseurPasDansSage" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Liste des fournisseurs qui ne sont pas dans Sage</h1>
    <p>Fournit la liste des fournisseurs qui sont créés dans Baan mais dans Sage.
        A supprimer?
    </p>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <rsweb:ReportViewer ID="ReportViewerControl" runat="server" ProcessingMode="Remote" SizeToReportContent="true" AsyncRendering="true">
        <ServerReport ReportPath="/Migration Baan/Fournisseur/FournisseurPasDansSage" ReportServerUrl="http://W08R2-EAGLE/ReportServer" />
    </rsweb:ReportViewer>
</asp:Content>