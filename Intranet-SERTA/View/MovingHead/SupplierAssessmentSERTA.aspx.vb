Imports Supplier_Indicator
Imports System.Web.UI.DataVisualization.Charting

Public Class SupplierAssessmentSERTA
    Inherits System.Web.UI.Page

    ''Gestion de la base par Linq to SQL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            Try
                System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " load form", Me.ToString)
                ''Connexion de la source de donnée au listeBox Supplier(Fournisseur)
                DropDownListSupplier.DataSource = MgtSupplierIndicatorSERTA.getInstance.ListSupplier
                DropDownListSupplier.DataTextField = "SUP_NAME"
                DropDownListSupplier.DataValueField = "SUP_ID"
                DropDownListSupplier.DataBind()
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

#Region "Méthode"
    Private Sub chargeFormulaire(lAssessment As AssessmentSERTA)
        Try
            If (IsNothing(lAssessment)) Then
                Session("assessmentAfficher") = New AssessmentSERTA(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue)
            Else
                Session("assessmentAfficher") = lAssessment.Clone
            End If
            ''*****FieldSet Qualité ******
            Dim assessmentAfficher As AssessmentSERTA = CType(Session("assessmentAfficher"), AssessmentSERTA)
            textBoxIndicePPMvalue.Text = assessmentAfficher.indicePPMValue
            textBoxIndicePPMNote.Text = assessmentAfficher.indicePPMPoint
            textBoxSinNBValue.Text = assessmentAfficher.sinNBValue
            textBoxSinNBPoint.Text = assessmentAfficher.sinNBPoint
            textBoxCustomerClaimNBValue.Text = assessmentAfficher.customerClaimNBValue
            textBoxCustomerClaimNBPoint.Text = assessmentAfficher.customerClaimNBPoint
            textBoxActionPlanReactivity.Text = assessmentAfficher.actionPlanReactivityPoint
            textBoxBonusPPM.Text = assessmentAfficher.bonus500PPMPoint
            LabelTotalQualite.Text = assessmentAfficher.TotalQuality
            ''****** FieldSet Logistique ********
            textboxLogisticRateValue.Text = assessmentAfficher.logisticRateTarget95Value
            textboxLogisticRatePoint.Text = assessmentAfficher.logisticRateTarget95WithPenalty
            LabelTargetRatePenality.Text = assessmentAfficher.PenaltyPoint
            textboxFlexibilityPoint.Text = assessmentAfficher.flexibilityPoint
            textboxDeliveryDelaysLevelValue.Text = assessmentAfficher.deliveryDelaysLevelValue
            textboxDeliveryDelaysLevelPoint.Text = assessmentAfficher.deliveryDelaysLevelPoint
            textboxDeliveryQualityValue.Text = assessmentAfficher.deliveryQualityValue
            textboxDeliveryQualityPoint.Text = assessmentAfficher.deliveryQualityPoint
            labelTotalLogistique.Text = assessmentAfficher.TotalLogistic
            ''******** FielSet Compétitivité ********
            TextBoxImprovmentPlan.Text = assessmentAfficher.improvmentPlanPoint
            TextBoxBusinessRelationship.Text = assessmentAfficher.businessRelationshipPoint
            TextBoxFinancialSituation.Text = assessmentAfficher.financialSituationPoint
            TextBoxOffersReactivity.Text = assessmentAfficher.offersReactivityPoint
            TextBoxTechnicalAnswerQuality.Text = assessmentAfficher.technicalAnswerQualityPoint
            TextBoxIsoCertification.Text = assessmentAfficher.isoCertificationPoint
            LabelTatalCompetitiveness.Text = assessmentAfficher.TotalCompetitiveness
            ''************* FielSet Notation *************
            LabelTotal.Text = CInt(LabelTatalCompetitiveness.Text) + CInt(labelTotalLogistique.Text) + CInt(LabelTotalQualite.Text)
            RadioButtonListTrend.SelectedValue = assessmentAfficher.trend
            TextBoxCommentDetail.Text = assessmentAfficher.commentDetail
            TextBoxCommentClassification.Text = assessmentAfficher.commentClassification
            TextBoxCommentGlobal.Text = assessmentAfficher.commentGlobal
            '**************** Pré-calcule***************************
            LabelPPM.Text = IIf(IsNothing(assessmentAfficher.PrecalculedValue.PPM), 0, CInt(assessmentAfficher.PrecalculedValue.PPM))
            LabelQncCount.Text = IIf(IsNothing(assessmentAfficher.PrecalculedValue.QNC_COUNT), 0, assessmentAfficher.PrecalculedValue.QNC_COUNT)
            LabelCustomerClaimCount.Text = IIf(IsNothing(assessmentAfficher.PrecalculedValue.CUSTOMER_CLAIM_COUNT), 0, assessmentAfficher.PrecalculedValue.CUSTOMER_CLAIM_COUNT)
            LabelLNCCount.Text = IIf(IsNothing(assessmentAfficher.PrecalculedValue.LNC_COUNT), 0, CInt(assessmentAfficher.PrecalculedValue.LNC_COUNT))
            If (IsNothing(assessmentAfficher.PrecalculedValue.LOGISTIC_RATE)) Then
                LabelDelaysUpTo10DaysRate.Text = "0 %"
            Else
                LabelDelaysUpTo10DaysRate.Text = FormatPercent(assessmentAfficher.PrecalculedValue.LOGISTIC_RATE, 0)
            End If
            If IsNothing(assessmentAfficher.PrecalculedValue.DELAYS_UP_TO_DAYS_RATE) Then
                LabelLogisticRate.Text = "0 %"
            Else
                LabelLogisticRate.Text = FormatPercent(assessmentAfficher.PrecalculedValue.DELAYS_UP_TO_DAYS_RATE, 0)
            End If

            LabelFirmOrderRequest.Text = assessmentAfficher.PrecalculedValue.FIRM_ORDER_REQUEST
            LabelFirmOrderCurrent.Text = assessmentAfficher.PrecalculedValue.FIRM_ORDER_CURRENT
            LabelFirmOrderValues.Text = assessmentAfficher.PrecalculedValue.FirmOrderValues
            LabelFirmOrderPoint.Text = assessmentAfficher.PrecalculedValue.FirmOrderPoint

            ChartHorizonOrder.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("< 12 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_GREATER_THAN_12))
            ChartHorizonOrder.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("11 - 12 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_11_TO_12))
            ChartHorizonOrder.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("9 - 10 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_9_TO_10))
            ChartHorizonOrder.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("7 - 8 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_7_TO_8))
            ChartHorizonOrder.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("5 - 6 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_5_TO_6))
            ChartHorizonOrder.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("3 - 4 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_3_TO_4))
            ChartHorizonOrder.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("0 - 2 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_0_TO_2))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function nouveauPoint(name As String, ValuesY As Integer) As DataPoint
        Dim p As New DataPoint()
        p.AxisLabel = name
        p.YValues = {ValuesY}
        Return p
    End Function
    Private Sub sauvegardeFormulaire()
        Try
            Dim assessmentAfficher As AssessmentSERTA = (CType(Session("assessmentAfficher"), AssessmentSERTA))
            assessmentAfficher.indicePPMValue = textBoxIndicePPMvalue.Text
            assessmentAfficher.sinNBValue = textBoxSinNBValue.Text
            assessmentAfficher.customerClaimNBValue = textBoxCustomerClaimNBValue.Text
            assessmentAfficher.actionPlanReactivityPoint = textBoxActionPlanReactivity.Text
            assessmentAfficher.logisticRateTarget95Value = textboxLogisticRateValue.Text
            assessmentAfficher.flexibilityPoint = textboxFlexibilityPoint.Text
            assessmentAfficher.deliveryDelaysLevelValue = textboxDeliveryDelaysLevelValue.Text
            assessmentAfficher.deliveryQualityValue = textboxDeliveryQualityValue.Text
            ''******** FielSet Compétitivité ********
            assessmentAfficher.improvmentPlanPoint = TextBoxImprovmentPlan.Text
            assessmentAfficher.businessRelationshipPoint = TextBoxBusinessRelationship.Text
            assessmentAfficher.financialSituationPoint = TextBoxFinancialSituation.Text
            assessmentAfficher.offersReactivityPoint = TextBoxOffersReactivity.Text
            assessmentAfficher.technicalAnswerQualityPoint = TextBoxTechnicalAnswerQuality.Text
            assessmentAfficher.isoCertificationPoint = TextBoxIsoCertification.Text
            ''************* FielSet Notation *************
            assessmentAfficher.trend = RadioButtonListTrend.SelectedValue
            assessmentAfficher.commentDetail = TextBoxCommentDetail.Text
            assessmentAfficher.commentClassification = TextBoxCommentClassification.Text
            assessmentAfficher.commentGlobal = TextBoxCommentGlobal.Text
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "Evenement"
    ''Evenement si ListBox Fournisseur change
    Protected Sub ListBoxSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListSupplier.SelectedIndexChanged
        Try
            System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " show a assessment. ID : " + DropDownListSupplier.SelectedValue + " Quarter : " + DropDownListTrimestre.SelectedValue, Me.ToString)
            chargeFormulaire(MgtSupplierIndicatorSERTA.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''Evenement si ListBox Trimestre change
    Protected Sub DropDownListTrimestre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListTrimestre.SelectedIndexChanged
        Try
            System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " show a assessment. ID : " + DropDownListSupplier.SelectedValue + " Quarter : " + DropDownListTrimestre.SelectedValue, Me.ToString)
            chargeFormulaire(MgtSupplierIndicatorSERTA.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Save click
    Protected Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        Try
            System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " request save a assessment. ID : " + DropDownListSupplier.SelectedValue + " Quarter : " + DropDownListTrimestre.SelectedValue, Me.ToString)
            sauvegardeFormulaire()
            MgtSupplierIndicatorSERTA.getInstance.Save(CType(Session("assessmentAfficher"), AssessmentSERTA))
            chargeFormulaire(CType(Session("assessmentAfficher"), AssessmentSERTA))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''Evenement click bouton pour supprimer un Assessment
    Protected Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        Try
            System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " request delete a assessment. ID : " + DropDownListSupplier.SelectedValue + " Quarter : " + DropDownListTrimestre.SelectedValue, Me.ToString)
            MgtSupplierIndicatorSERTA.getInstance.delete(MgtSupplierIndicatorSERTA.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
            MgtSupplierIndicatorSERTA.getInstance.ListAssessment.Remove(MgtSupplierIndicatorSERTA.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
            chargeFormulaire(MgtSupplierIndicatorSERTA.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
End Class