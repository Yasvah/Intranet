Imports Microsoft.Reporting.WebForms
Imports Supplier_Indicator

Public Class RapportAnalyseRetard
    Inherits System.Web.UI.Page

   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not (IsPostBack) Then
                If Request.QueryString("Supplier") <> String.Empty And Request.QueryString("Quarter") <> String.Empty Then
                    ShowReport(Request.QueryString("Supplier"), "GROUP", Request.QueryString("Quarter"))
                Else
                    ReportViewer1.Visible = False
                    ModalPopErrorShowReport.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ShowReport(idSupplier As Integer, group As String, Trimestre As Integer)
        Try
            ReportViewer1.ShowParameterPrompts = True
            ' Gestion des droits
            'ReportViewer1.ServerReport.ReportServerCredentials = New ReportServerCredentials("UserName", "PassWORD", "doMain")
            'Passe les paramtres au rapport
            ReportViewer1.ServerReport.SetParameters(ShowReportWithParamter(idSupplier, group, convertQuarterToDate(Trimestre - 10), convertQuarterToDate(Trimestre))) 'DateFrom -10 pour un ecart de 1 an
            ReportViewer1.ShowParameterPrompts = False
            'Set Report Parameters
            ReportViewer1.ServerReport.Refresh()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ShowReportWithParamter(idSupplier As Integer, group As String, dateFrom As String, dateTo As String) As List(Of ReportParameter)
        Debug.Print(DateTo.ToString)

        Dim listSubCategory As String() = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13"}
        Dim listCategory As String() = {"1", "2", "3", "4"}

        Dim arrLstParam As List(Of ReportParameter) = New List(Of ReportParameter)
        arrLstParam.Add(New ReportParameter("LATE_ONLY", "TRUE"))
        arrLstParam.Add(New ReportParameter("DELIVERED_ONLY", "FALSE"))
        arrLstParam.Add(New ReportParameter("MONTH_FROM", dateFrom))
        arrLstParam.Add(New ReportParameter("MONTH_TO", dateTo))
        arrLstParam.Add(New ReportParameter("SSC_ID", listSubCategory))
        arrLstParam.Add(New ReportParameter("SCA_ID", listCategory))
        arrLstParam.Add(New ReportParameter("SUP_ID", idSupplier.ToString))
        arrLstParam.Add(New ReportParameter("DETAIL_LEVEL", group))
        arrLstParam.Add(New ReportParameter("LANGUAGE", "1"))
        Return arrLstParam
    End Function

    Private Function convertQuarterToDate(Quarter As Integer) As String
        If Quarter < 121 Then 'Pour évite bug hors limite du trimestre pour le rapport 
            Quarter = 121
        End If
        Return "01" + "/" + Right("0" + CInt(Right(Quarter, 1)) * 3, 2) + "/" + "20" + Left(Quarter, 2) + "  00:00:00"
    End Function

End Class