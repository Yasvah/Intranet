<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" CodeBehind="RapportClientCompta.aspx.vb" Inherits="IntranetSerta.RapportClientCompta" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="702px" Width="1303px">
            <ServerReport ReportPath="/Comptabilité/CA par Client" ReportServerUrl="http://w08r2-update/ReportServer" />
        </rsweb:ReportViewer>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </div>
</asp:Content>
