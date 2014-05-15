<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" CodeBehind="Default.aspx.vb" Inherits="IntranetSerta._Default" Culture="auto:fr-FR" UICulture="auto:fr-FR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <asp:Label ID="TitrePrincipal" meta:resourceKey="TitrePrincipal" runat="server" Text="DefaultText"></asp:Label>
    </h2>
    <p>
        <asp:Label ID="TextPresentation" meta:resourceKey="TextPresentation" runat="server" Text="DefaultText"></asp:Label>
    </p>
    <br />
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
    <asp:Image ID="Image1" runat="server" Height="600" Width="900" />
    <ajaxToolkit:SlideShowExtender ID="SlideShowExtender1" runat="server"
        TargetControlID="Image1"
        SlideShowServiceMethod="GetSlides"
        AutoPlay="true"
        Loop="true"
        PlayInterval ="6000"
        SlideShowAnimationType="SlideRight" />
</asp:Content>
