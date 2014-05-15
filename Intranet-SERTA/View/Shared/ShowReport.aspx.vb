Imports Microsoft.Reporting.WebForms

Public Class ShowReport
    Inherits System.Web.UI.Page

    Private serverReport As ServerReport
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " load form : " + Request.QueryString("reportPath") + " ", Me.ToString)
            serverReport = ReportViewerControle.ServerReport
            If Request.QueryString("reportPath") <> String.Empty Then
                serverReport.ReportPath = Request.QueryString("reportPath")
            End If
        End If
    End Sub

End Class