<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" CodeBehind="ShowReport.aspx.vb" Inherits="IntranetSerta.ShowReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Themes/Theme/ReportViewer.css" rel="stylesheet" type="text/css" media="all" />
</asp:Content>

<%--Affiche un rapport en remote stocker sur un report service. en parametre GET "reportPath" le chemin du report --%>
<%--A utiliser pour afficher un simple report.--%>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <% If Request.QueryString("reportPath") = String.Empty Then%>
    <div style="text-align: center;">
        <h2>
            <asp:Label ID="ErrorMessage" runat="server"> Aucune parametre passé, le Get est vide</asp:Label>
        </h2>
    </div>
    <%Else%>
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <rsweb:ReportViewer ID="ReportViewerControle" runat="server" ProcessingMode="Remote" SizeToReportContent="true" CssClass="reportViewer">
        <ServerReport ReportServerUrl="http://w08r2-EAGLE/ReportServer/" />
    </rsweb:ReportViewer>
    
   <%End If%>
</asp:Content>
