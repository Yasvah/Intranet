Imports System.Net
Imports System.Security.Principal

Public Class RapportClientCompta
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            ReportViewer1.SizeToReportContent = True
        End If
    End Sub

End Class