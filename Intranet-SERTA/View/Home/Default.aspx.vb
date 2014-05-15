Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <System.Web.Services.WebMethodAttribute, System.Web.Script.Services.ScriptMethodAttribute> _
    Public Shared Function GetSlides() As AjaxControlToolkit.Slide()
        Dim slides As AjaxControlToolkit.Slide() = New AjaxControlToolkit.Slide(2) {}
        slides(0) = New AjaxControlToolkit.Slide("/img/SupplierIndicatorReport.png", "Supplier", "nice images")
        slides(1) = New AjaxControlToolkit.Slide("/img/QualityIndicatorReport.png", "Quality", "nice images")
        slides(2) = New AjaxControlToolkit.Slide("/img/CommercialIndicatorReport.png", "Commercial", "nice images")
        Return slides
    End Function
End Class