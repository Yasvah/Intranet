Imports Supplier_Indicator
Imports System.Web.UI.DataVisualization.Charting

Public Class SupplierAssessmentCOMMUN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Au premier chargement de la page je remplies ma listbox de fournisseur.
        If Not (IsPostBack) Then
            Try
                ''Connexion de la source de donnée au listeBox Supplier(Fournisseur)
                System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " load form", Me.ToString)
                DropDownListSupplier.DataSource = MgtSupplierIndicatorCOMMUN.getInstance.ListSupplier
                DropDownListSupplier.DataTextField = "SUP_NAME"
                DropDownListSupplier.DataValueField = "SUP_ID"
                DropDownListSupplier.DataBind()
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
#Region "Méthode"

    Private Function nouveauPoint(name As String, ValuesY As Integer) As DataPoint
        Dim p As New DataPoint()
        p.AxisLabel = name
        p.YValues = {ValuesY}
        Return p
    End Function

    Private Sub chargeFormulaireCommun(lAssessment As AssessmentCOMMUN)
        Try
            If (IsNothing(lAssessment)) Then
                Session("assessmentAfficherCOMMUN") = New AssessmentCOMMUN(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue)
            Else
                Session("assessmentAfficherCOMMUN") = lAssessment.Clone
            End If
            Dim assessmentAfficher As AssessmentCOMMUN = CType(Session("assessmentAfficherCOMMUN"), AssessmentCOMMUN)
            '------------------------------------Affichage Commun -----------------------
            ''*****FieldSet Qualité ******
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

    Private Sub chargeFormulairePNS(lAssessment As AssessmentPNS)
        Try
            If (IsNothing(lAssessment)) Then
                Session("assessmentAfficherPNS") = New AssessmentPNS(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue)
            Else
                Session("assessmentAfficherPNS") = lAssessment.Clone
            End If
            ''*****FieldSet Qualité ******
            Dim assessmentAfficher As AssessmentPNS = CType(Session("assessmentAfficherPNS"), AssessmentPNS)
            textBoxIndicePPMvaluePNS.Text = assessmentAfficher.indicePPMValue
            textBoxIndicePPMNotePNS.Text = assessmentAfficher.indicePPMPoint
            textBoxSinNBValuePNS.Text = assessmentAfficher.sinNBValue
            textBoxSinNBPointPNS.Text = assessmentAfficher.sinNBPoint
            textBoxCustomerClaimNBValuePNS.Text = assessmentAfficher.customerClaimNBValue
            textBoxCustomerClaimNBPointPNS.Text = assessmentAfficher.customerClaimNBPoint
            textBoxActionPlanReactivityPNS.Text = assessmentAfficher.actionPlanReactivityPoint
            textBoxBonusPPMPNS.Text = assessmentAfficher.bonus500PPMPoint
            LabelTotalQualitePNS.Text = assessmentAfficher.TotalQuality
            ''****** FieldSet Logistique ********
            textboxLogisticRateValuePNS.Text = assessmentAfficher.logisticRateTarget95Value
            textboxLogisticRatePointPNS.Text = assessmentAfficher.logisticRateTarget95WithPenalty
            textboxFlexibilityPointPNS.Text = assessmentAfficher.flexibilityPoint
            textboxDeliveryDelaysLevelValuePNS.Text = assessmentAfficher.deliveryDelaysLevelValue
            textboxDeliveryDelaysLevelPointPNS.Text = assessmentAfficher.deliveryDelaysLevelPoint
            textboxDeliveryQualityValuePNS.Text = assessmentAfficher.deliveryQualityValue
            textboxDeliveryQualityPointPNS.Text = assessmentAfficher.deliveryQualityPoint
            labelTotalLogistiquePNS.Text = assessmentAfficher.TotalLogistic
            ''******** FielSet Compétitivité ********
            TextBoxImprovmentPlanPNS.Text = assessmentAfficher.improvmentPlanPoint
            TextBoxBusinessRelationshipPNS.Text = assessmentAfficher.businessRelationshipPoint
            TextBoxFinancialSituationPNS.Text = assessmentAfficher.financialSituationPoint
            TextBoxOffersReactivityPNS.Text = assessmentAfficher.offersReactivityPoint
            TextBoxTechnicalAnswerQualityPNS.Text = assessmentAfficher.technicalAnswerQualityPoint
            TextBoxIsoCertificationPNS.Text = assessmentAfficher.isoCertificationPoint
            LabelTatalCompetitivenessPNS.Text = assessmentAfficher.TotalCompetitiveness
            ''************* FielSet Notation *************
            LabelTotalPNS.Text = CInt(LabelTatalCompetitiveness.Text) + CInt(labelTotalLogistique.Text) + CInt(LabelTotalQualite.Text)
            RadioButtonListTrendPNS.SelectedValue = assessmentAfficher.trend
            TextBoxCommentDetailPNS.Text = assessmentAfficher.commentDetail
            TextBoxCommentClassificationPNS.Text = assessmentAfficher.commentClassification
            TextBoxCommentGlobalPNS.Text = assessmentAfficher.commentGlobal
            '**************** Pré-calcule***************************
            LabelPPMPNS.Text = IIf(IsNothing(assessmentAfficher.PrecalculedValue.PPM), 0, CInt(assessmentAfficher.PrecalculedValue.PPM))
            LabelQncCountPNS.Text = IIf(IsNothing(assessmentAfficher.PrecalculedValue.QNC_COUNT), 0, assessmentAfficher.PrecalculedValue.QNC_COUNT)
            LabelCustomerClaimCountPNS.Text = IIf(IsNothing(assessmentAfficher.PrecalculedValue.CUSTOMER_CLAIM_COUNT), 0, assessmentAfficher.PrecalculedValue.CUSTOMER_CLAIM_COUNT)
            LabelLNCCountPNS.Text = IIf(IsNothing(assessmentAfficher.PrecalculedValue.LNC_COUNT), 0, CInt(assessmentAfficher.PrecalculedValue.LNC_COUNT))
            If (IsNothing(assessmentAfficher.PrecalculedValue.LOGISTIC_RATE)) Then
                LabelDelaysUpTo10DaysRatePNS.Text = "0 %"
            Else
                LabelDelaysUpTo10DaysRatePNS.Text = FormatPercent(assessmentAfficher.PrecalculedValue.LOGISTIC_RATE, 0)
            End If
            If IsNothing(assessmentAfficher.PrecalculedValue.DELAYS_UP_TO_DAYS_RATE) Then
                LabelLogisticRatePNS.Text = "0 %"
            Else
                LabelLogisticRatePNS.Text = FormatPercent(assessmentAfficher.PrecalculedValue.DELAYS_UP_TO_DAYS_RATE, 0)
            End If

            LabelTargetRatePenalityPNS.Text = assessmentAfficher.PenaltyPoint

            ChartHorizonOrderPNS.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("< 12 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_GREATER_THAN_12))
            ChartHorizonOrderPNS.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("11 - 12 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_11_TO_12))
            ChartHorizonOrderPNS.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("9 - 10 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_9_TO_10))
            ChartHorizonOrderPNS.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("7 - 8 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_7_TO_8))
            ChartHorizonOrderPNS.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("5 - 6 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_5_TO_6))
            ChartHorizonOrderPNS.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("3 - 4 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_3_TO_4))
            ChartHorizonOrderPNS.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("0 - 2 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_0_TO_2))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chargeFormulaireSERTA(lAssessment As AssessmentSERTA)
        Try
            If (IsNothing(lAssessment)) Then
                Session("assessmentAfficherSERTA") = New AssessmentSERTA(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue)
            Else
                Session("assessmentAfficherSERTA") = lAssessment.Clone
            End If
            ''*****FieldSet Qualité ******
            Dim assessmentAfficher As AssessmentSERTA = CType(Session("assessmentAfficherSERTA"), AssessmentSERTA)
            textBoxIndicePPMvalueSERTA.Text = assessmentAfficher.indicePPMValue
            textBoxIndicePPMNoteSERTA.Text = assessmentAfficher.indicePPMPoint
            textBoxSinNBValueSERTA.Text = assessmentAfficher.sinNBValue
            textBoxSinNBPointSERTA.Text = assessmentAfficher.sinNBPoint
            textBoxCustomerClaimNBValueSERTA.Text = assessmentAfficher.customerClaimNBValue
            textBoxCustomerClaimNBPointSERTA.Text = assessmentAfficher.customerClaimNBPoint
            textBoxActionPlanReactivitySERTA.Text = assessmentAfficher.actionPlanReactivityPoint
            textBoxBonusPPMSERTA.Text = assessmentAfficher.bonus500PPMPoint
            LabelTotalQualiteSERTA.Text = assessmentAfficher.TotalQuality
            ''****** FieldSet Logistique ********
            textboxLogisticRateValueSERTA.Text = assessmentAfficher.logisticRateTarget95Value
            textboxLogisticRatePointSERTA.Text = assessmentAfficher.logisticRateTarget95WithPenalty
            textboxFlexibilityPointSERTA.Text = assessmentAfficher.flexibilityPoint
            textboxDeliveryDelaysLevelValueSERTA.Text = assessmentAfficher.deliveryDelaysLevelValue
            textboxDeliveryDelaysLevelPointSERTA.Text = assessmentAfficher.deliveryDelaysLevelPoint
            textboxDeliveryQualityValueSERTA.Text = assessmentAfficher.deliveryQualityValue
            textboxDeliveryQualityPointSERTA.Text = assessmentAfficher.deliveryQualityPoint
            labelTotalLogistiqueSERTA.Text = assessmentAfficher.TotalLogistic
            ''******** FielSet Compétitivité ********
            TextBoxImprovmentPlanSERTA.Text = assessmentAfficher.improvmentPlanPoint
            TextBoxBusinessRelationshipSERTA.Text = assessmentAfficher.businessRelationshipPoint
            TextBoxFinancialSituationSERTA.Text = assessmentAfficher.financialSituationPoint
            TextBoxOffersReactivitySERTA.Text = assessmentAfficher.offersReactivityPoint
            TextBoxTechnicalAnswerQualitySERTA.Text = assessmentAfficher.technicalAnswerQualityPoint
            TextBoxIsoCertificationSERTA.Text = assessmentAfficher.isoCertificationPoint
            LabelTatalCompetitivenessSERTA.Text = assessmentAfficher.TotalCompetitiveness
            ''************* FielSet Notation *************
            RadioButtonListTrendSERTA.SelectedValue = assessmentAfficher.trend
            TextBoxCommentDetailSERTA.Text = assessmentAfficher.commentDetail
            TextBoxCommentClassificationSERTA.Text = assessmentAfficher.commentClassification
            TextBoxCommentGlobalSERTA.Text = assessmentAfficher.commentGlobal
            '**************** Pré-calcule***************************
            LabelPPMSERTA.Text = IIf(IsNothing(assessmentAfficher.PrecalculedValue.PPM), 0, CInt(assessmentAfficher.PrecalculedValue.PPM))
            LabelQncCountSERTA.Text = IIf(IsNothing(assessmentAfficher.PrecalculedValue.QNC_COUNT), 0, assessmentAfficher.PrecalculedValue.QNC_COUNT)
            LabelCustomerClaimCountSERTA.Text = IIf(IsNothing(assessmentAfficher.PrecalculedValue.CUSTOMER_CLAIM_COUNT), 0, assessmentAfficher.PrecalculedValue.CUSTOMER_CLAIM_COUNT)
            LabelLNCCountSERTA.Text = IIf(IsNothing(assessmentAfficher.PrecalculedValue.LNC_COUNT), 0, CInt(assessmentAfficher.PrecalculedValue.LNC_COUNT))
            If (IsNothing(assessmentAfficher.PrecalculedValue.LOGISTIC_RATE)) Then 'La fonction ToString("P") de la classe Double transforme et % le chiffre
                LabelDelaysUpTo10DaysRateSERTA.Text = "0 %"
            Else
                LabelDelaysUpTo10DaysRateSERTA.Text = FormatPercent(assessmentAfficher.PrecalculedValue.LOGISTIC_RATE, 0)
            End If
            If IsNothing(assessmentAfficher.PrecalculedValue.DELAYS_UP_TO_DAYS_RATE) Then
                LabelLogisticRateSERTA.Text = "0 %"
            Else
                LabelLogisticRateSERTA.Text = FormatPercent(assessmentAfficher.PrecalculedValue.DELAYS_UP_TO_DAYS_RATE, 0)
            End If
            LabelTargetRatePenalitySERTA.Text = assessmentAfficher.PenaltyPoint

            ChartHorizonOrderSERTA.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("< 12 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_GREATER_THAN_12))
            ChartHorizonOrderSERTA.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("11 - 12 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_11_TO_12))
            ChartHorizonOrderSERTA.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("9 - 10 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_9_TO_10))
            ChartHorizonOrderSERTA.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("7 - 8 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_7_TO_8))
            ChartHorizonOrderSERTA.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("5 - 6 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_5_TO_6))
            ChartHorizonOrderSERTA.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("3 - 4 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_3_TO_4))
            ChartHorizonOrderSERTA.Series("SeriesHorizonOrder").Points.Add(nouveauPoint("0 - 2 sem", assessmentAfficher.PrecalculedValue.ORDER_HORIZON_PERCENTAGE_0_TO_2))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

   

    Private Sub sauvegardeFormulaire()
        Try
            Dim assessmentAfficher As AssessmentCOMMUN = (CType(Session("assessmentAfficherCOMMUN"), AssessmentCOMMUN))
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
            System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " show a assessement. ID : " + DropDownListSupplier.SelectedValue + " Quarter : " + DropDownListTrimestre.SelectedValue, Me.ToString)
            chargeFormulaireCommun(MgtSupplierIndicatorCOMMUN.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
            chargeFormulairePNS(MgtSupplierIndicatorPNS.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
            chargeFormulaireSERTA(MgtSupplierIndicatorSERTA.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''Evenement si ListBox Trimestre change
    Protected Sub DropDownListTrimestre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListTrimestre.SelectedIndexChanged
        Try
            System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " request a assessement. ID : " + DropDownListSupplier.SelectedValue + " Quarter : " + DropDownListTrimestre.SelectedValue, Me.ToString)
            chargeFormulaireCommun(MgtSupplierIndicatorCOMMUN.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
            chargeFormulairePNS(MgtSupplierIndicatorPNS.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
            chargeFormulaireSERTA(MgtSupplierIndicatorSERTA.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Save click
    Protected Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        Try
            If Not IsNothing(CType(Session("assessmentAfficherCOMMUN"), AssessmentCOMMUN)) Then
                System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " request save a assessement. ID : " + DropDownListSupplier.SelectedValue + " Quarter : " + DropDownListTrimestre.SelectedValue, Me.ToString)
                sauvegardeFormulaire()
                MgtSupplierIndicatorCOMMUN.getInstance.Save(CType(Session("assessmentAfficherCOMMUN"), AssessmentCOMMUN))
                chargeFormulaireCommun(CType(Session("assessmentAfficherCOMMUN"), AssessmentCOMMUN))
                chargeFormulairePNS(MgtSupplierIndicatorPNS.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
                chargeFormulaireSERTA(MgtSupplierIndicatorSERTA.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Delete click
    Protected Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " request delete a supplier. ID : " + DropDownListSupplier.SelectedValue + " Quarter : " + DropDownListTrimestre.SelectedValue, Me.ToString)
        MgtSupplierIndicatorCOMMUN.getInstance.delete(MgtSupplierIndicatorCOMMUN.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
        MgtSupplierIndicatorCOMMUN.getInstance.ListAssessment.Remove(MgtSupplierIndicatorCOMMUN.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
        chargeFormulaireCommun(MgtSupplierIndicatorCOMMUN.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
        chargeFormulairePNS(MgtSupplierIndicatorPNS.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
        chargeFormulaireSERTA(MgtSupplierIndicatorSERTA.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))

    End Sub
    'show report click
    'Protected Sub btShowReport_Click(sender As Object, e As EventArgs) Handles btShowReport.Click
    '    Try
    '        System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " request show report assessment ID : " + DropDownListSupplier.SelectedValue + " Quarter : " + DropDownListTrimestre.SelectedValue, Me.ToString)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
#End Region

End Class