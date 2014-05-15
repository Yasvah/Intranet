Public Class MappageClientsBaanVP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Redirect("http://w08r2-update/ReportServer?%2fMigration+Baan%2fClients%2fMappageClientsBaanVP.xlsx&rs:Command=GetResourceContents")
    End Sub

End Class