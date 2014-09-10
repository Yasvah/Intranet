<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" CodeBehind="CasEmploiParComposant.aspx.vb" Inherits="IntranetSerta.CasEmploiParComposant" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <span>Ce Rapport donne la consommation (la quantité) d'un composant en fonction de chaque produit fini chez SERTA et PNS</span><br />
    <br />
    &nbsp;&nbsp;&nbsp;<span style="background-color: #FF8C00;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span> <span>: PNS </span>
    <br />
    &nbsp;&nbsp;&nbsp;<span style="background-color: #1E90FF;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span> <span>: SERTA </span>
    <br />
    <br />
    <rsweb:ReportViewer ID="ReportViewerControle" runat="server" ProcessingMode="Remote" SizeToReportContent="true" CssClass="reportViewer">
        <ServerReport ReportServerUrl="http://W08R2-EAGLE/ReportServer/" ReportPath="/BE/Cas_d_emploi_d_un_composant" />
    </rsweb:ReportViewer>
</asp:Content>

