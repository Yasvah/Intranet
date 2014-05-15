<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" CodeBehind="ReportFournisseurLastTransaction.aspx.vb" Inherits="IntranetSerta.ReportFournisseurLastTransaction" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Liste de la dernière transaction affectué sur un fournisseur</h1>
    <p>
        Cette liste donne la date de la dernière transation effectué avec un fournisseur.<br />
        Utilisier le paramètre pour filtrer les résultats.
    </p>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <rsweb:reportviewer id="ReportViewerControl" runat="server" processingmode="Remote" sizetoreportcontent="true" asyncrendering="true">
        <ServerReport ReportPath="/Migration Baan/FournisseurLastTransaction" ReportServerUrl="http://W08R2-UPDATE/ReportServer" />
    </rsweb:reportviewer>
</asp:Content>
