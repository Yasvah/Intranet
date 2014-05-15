Public Class Redirection
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("nameFile") <> String.Empty Then
            Response.Redirect("~\App_Data\DownloadFile\" + Request.QueryString("nameFile"))
        End If
    End Sub

End Class