Imports Supplier_Indicator
Imports System.Web.UI.DataVisualization.Charting

Public Class SupplierAssessmentCOMMUN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Permet de bloquer l'écriture tout en perméttant la publication de la valeur
        textBoxIndicePPMNote.Attributes.Add("readonly", "readonly")
        textBoxSinNBPoint.Attributes.Add("readonly", "readonly")
        textBoxCustomerClaimNBPoint.Attributes.Add("readonly", "readonly")
        textboxLogisticRatePoint.Attributes.Add("readonly", "readonly")
        textboxDeliveryDelaysLevelPoint.Attributes.Add("readonly", "readonly")
        textBoxBonusPPM.Attributes.Add("readonly", "readonly")
        textboxDeliveryQualityPoint.Attributes.Add("readonly", "readonly")
        ' Au premier chargement de la page je remplies ma listbox de fournisseur.
        If Not (IsPostBack) Then
            Try
                ''Connexion de la source de donnée au listeBox Supplier(Fournisseur)
                System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " load form", Me.ToString)
                DropDownListSupplier.DataSource = MgtSupplierIndicatorCOMMUN.getInstance.Supplier_list
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

    Private Sub chargeFormulaireCommun(lAssessment As T_SUP_ASSESSMENT_SUA_COMMON)
        Try
            If (IsNothing(lAssessment)) Then
                Session("assessmentAfficherCOMMUN") = New T_SUP_ASSESSMENT_SUA_COMMON(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue)
            Else
                Session("assessmentAfficherCOMMUN") = lAssessment.Clone
            End If
            Dim assessmentAfficher As T_SUP_ASSESSMENT_SUA_COMMON = CType(Session("assessmentAfficherCOMMUN"), T_SUP_ASSESSMENT_SUA_COMMON)
            '------------------------------------Affichage Commun -----------------------
            ''*****FieldSet Qualité ******
            textBoxIndicePPMvalue.Text = assessmentAfficher.SUA_INDICE_PPM_VALUE
            textBoxIndicePPMNote.Text = assessmentAfficher.SUA_INDICE_PPM_POINT
            textBoxSinNBValue.Text = assessmentAfficher.SUA_SIN_NB_VALUE
            textBoxSinNBPoint.Text = assessmentAfficher.SUA_SIN_NB_POINT
            textBoxCustomerClaimNBValue.Text = assessmentAfficher.SUA_CUSTOMER_CLAIM_NB_VALUE
            textBoxCustomerClaimNBPoint.Text = assessmentAfficher.SUA_CUSTOMER_CLAIM_NB_POINT
            textBoxActionPlanReactivity.Text = assessmentAfficher.SUA_ACTION_PLAN_REACTIVITY_POINT
            textBoxBonusPPM.Text = assessmentAfficher.SUA_BONUS_500_PPM_POINT
            'LabelTotalQualite.Text = assessmentAfficher.SUA_
            ''****** FieldSet Logistique ********
            textboxLogisticRateValue.Text = assessmentAfficher.SUA_LOGISTIC_RATE_TARGET_95_VALUE
            textboxLogisticRatePoint.Text = assessmentAfficher.SUA_LOGISTIC_RATE_TARGET_95_POINT
            textboxFlexibilityPoint.Text = assessmentAfficher.SUA_FLEXIBILITY_POINT
            textboxDeliveryDelaysLevelValue.Text = assessmentAfficher.SUA_DELIVERY_DELAYS_LEVEL_VALUE
            textboxDeliveryDelaysLevelPoint.Text = assessmentAfficher.SUA_DELIVERY_DELAYS_LEVEL_POINT
            textboxDeliveryQualityValue.Text = assessmentAfficher.SUA_DELIVERY_QUALITY_VALUE
            textboxDeliveryQualityPoint.Text = assessmentAfficher.SUA_DELIVERY_QUALITY_POINT
            'labelTotalLogistique.Text = assessmentAfficher.SUA_
            ''******** FielSet Compétitivité ********
            TextBoxImprovmentPlan.Text = assessmentAfficher.SUA_IMPROVMENT_PLAN_POINT
            TextBoxBusinessRelationship.Text = assessmentAfficher.SUA_BUSINESS_RELATIONSHIP_POINT
            TextBoxFinancialSituation.Text = assessmentAfficher.SUA_FINANCIAL_SITUATION_POINT
            TextBoxOffersReactivity.Text = assessmentAfficher.SUA_OFFERS_REACTIVITY_POINT
            TextBoxTechnicalAnswerQuality.Text = assessmentAfficher.SUA_TECHNICAL_ANSWER_QUALITY_POINT
            TextBoxIsoCertification.Text = assessmentAfficher.SUA_ISO_CERTFICATION_POINT
            'LabelTatalCompetitiveness.Text = assessmentAfficher.SUA_
            ''************* FielSet Notation *************
            LabelTotal.Text = assessmentAfficher.SUA_TOTAL_POINT
            RadioButtonListTrend.SelectedValue = assessmentAfficher.SUA_TREND
            TextBoxCommentDetail.Text = assessmentAfficher.SUA_COMMENT_DETAIL
            TextBoxCommentClassification.Text = assessmentAfficher.SUA_COMMENT_CLASSIFICATION
            TextBoxCommentGlobal.Text = assessmentAfficher.SUA_COMMENT_GLOBAL
            '**************** Pré-calcule***************************
            If assessmentAfficher.PreCalcule.PPM Is Nothing Then
                LabelPPM.Text = "N/A"
            Else
                LabelPPM.Text = CInt(assessmentAfficher.PreCalcule.PPM)
            End If
            LabelQncCount.Text = IIf(IsNothing(assessmentAfficher.PreCalcule.QNC_COUNT), 0, assessmentAfficher.PreCalcule.QNC_COUNT)
            LabelCustomerClaimCount.Text = IIf(IsNothing(assessmentAfficher.PreCalcule.CUSTOMER_CLAIM_COUNT), 0, assessmentAfficher.PreCalcule.CUSTOMER_CLAIM_COUNT)
            LabelLNCCount.Text = IIf(IsNothing(assessmentAfficher.PreCalcule.LNC_COUNT), 0, assessmentAfficher.PreCalcule.LNC_COUNT)
            If (IsNothing(assessmentAfficher.PreCalcule.LOGISTIC_RATE)) Then
                LabelDelaysUpTo10DaysRate.Text = "N/A"
            Else
                LabelDelaysUpTo10DaysRate.Text = FormatPercent(assessmentAfficher.PreCalcule.LOGISTIC_RATE, 0)
            End If
            If IsNothing(assessmentAfficher.PreCalcule.DELAYS_UPPER_TO_X_DAYS_RATE) Then
                LabelLogisticRate.Text = "N/A"
            Else
                LabelLogisticRate.Text = FormatPercent(assessmentAfficher.PreCalcule.DELAYS_UPPER_TO_X_DAYS_RATE, 0)
            End If
            '*********************************** Graphique **********************************************************
            For Each uneLigne In assessmentAfficher.OrderHorizon
                ChartHorizonOrderCommun.Series("SeriesHorizonOrderOnTime").Points.Add(nouveauPoint(uneLigne.ORDER_HORIZON_LABEL, uneLigne.NB_ON_TIME))
                ChartHorizonOrderCommun.Series("SeriesHorizonOrderNotOnTime").Points.Add(nouveauPoint(uneLigne.ORDER_HORIZON_LABEL, uneLigne.NB_NOT_ON_TIME))
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chargeFormulairePNS(lAssessment As T_SUP_ASSESSMENT_SUA_PNS)
        Try
            If (IsNothing(lAssessment)) Then
                Session("assessmentAfficherPNS") = New T_SUP_ASSESSMENT_SUA_PNS(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue)
            Else
                Session("assessmentAfficherPNS") = lAssessment.Clone
            End If
            ''*****FieldSet Qualité ******
            Dim assessmentAfficher As T_SUP_ASSESSMENT_SUA_PNS = CType(Session("assessmentAfficherPNS"), T_SUP_ASSESSMENT_SUA_PNS)
            textBoxIndicePPMvaluePNS.Text = assessmentAfficher.SUA_INDICE_PPM_VALUE
            textBoxIndicePPMNotePNS.Text = assessmentAfficher.SUA_INDICE_PPM_POINT
            textBoxSinNBValuePNS.Text = assessmentAfficher.SUA_SIN_NB_VALUE
            textBoxSinNBPointPNS.Text = assessmentAfficher.SUA_SIN_NB_POINT
            textBoxCustomerClaimNBValuePNS.Text = assessmentAfficher.SUA_CUSTOMER_CLAIM_NB_VALUE
            textBoxCustomerClaimNBPointPNS.Text = assessmentAfficher.SUA_CUSTOMER_CLAIM_NB_POINT
            textBoxActionPlanReactivityPNS.Text = assessmentAfficher.SUA_ACTION_PLAN_REACTIVITY_POINT
            textBoxBonusPPMPNS.Text = assessmentAfficher.SUA_BONUS_500_PPM_POINT
            'LabelTotalQualite.Text = assessmentAfficher.SUA_
            ''****** FieldSet Logistique ********
            textboxLogisticRateValuePNS.Text = assessmentAfficher.SUA_LOGISTIC_RATE_TARGET_95_VALUE
            textboxLogisticRatePointPNS.Text = assessmentAfficher.SUA_LOGISTIC_RATE_TARGET_95_POINT
            textboxFlexibilityPointPNS.Text = assessmentAfficher.SUA_FLEXIBILITY_POINT
            textboxDeliveryDelaysLevelValuePNS.Text = assessmentAfficher.SUA_DELIVERY_DELAYS_LEVEL_VALUE
            textboxDeliveryDelaysLevelPointPNS.Text = assessmentAfficher.SUA_DELIVERY_DELAYS_LEVEL_POINT
            textboxDeliveryQualityValuePNS.Text = assessmentAfficher.SUA_DELIVERY_QUALITY_VALUE
            textboxDeliveryQualityPointPNS.Text = assessmentAfficher.SUA_DELIVERY_QUALITY_POINT
            'labelTotalLogistique.Text = assessmentAfficher.SUA_
            ''******** FielSet Compétitivité ********
            TextBoxImprovmentPlanPNS.Text = assessmentAfficher.SUA_IMPROVMENT_PLAN_POINT
            TextBoxBusinessRelationshipPNS.Text = assessmentAfficher.SUA_BUSINESS_RELATIONSHIP_POINT
            TextBoxFinancialSituationPNS.Text = assessmentAfficher.SUA_FINANCIAL_SITUATION_POINT
            TextBoxOffersReactivityPNS.Text = assessmentAfficher.SUA_OFFERS_REACTIVITY_POINT
            TextBoxTechnicalAnswerQualityPNS.Text = assessmentAfficher.SUA_TECHNICAL_ANSWER_QUALITY_POINT
            TextBoxIsoCertificationPNS.Text = assessmentAfficher.SUA_ISO_CERTFICATION_POINT
            'LabelTatalCompetitiveness.Text = assessmentAfficher.SUA_
            ''************* FielSet Notation *************
            LabelTotalPNS.Text = assessmentAfficher.SUA_TOTAL_POINT
            RadioButtonListTrendPNS.SelectedValue = assessmentAfficher.SUA_TREND
            TextBoxCommentDetailPNS.Text = assessmentAfficher.SUA_COMMENT_DETAIL
            TextBoxCommentClassificationPNS.Text = assessmentAfficher.SUA_COMMENT_CLASSIFICATION
            TextBoxCommentGlobalPNS.Text = assessmentAfficher.SUA_COMMENT_GLOBAL
            '**************** Pré-calcule***************************
            If assessmentAfficher.PreCalcule.PPM Is Nothing Then
                LabelPPMPNS.Text = "N/A"
            Else
                LabelPPMPNS.Text = CInt(assessmentAfficher.PreCalcule.PPM)
            End If
            LabelQncCountPNS.Text = IIf(IsNothing(assessmentAfficher.PreCalcule.QNC_COUNT), 0, assessmentAfficher.PreCalcule.QNC_COUNT)
            LabelCustomerClaimCountPNS.Text = IIf(IsNothing(assessmentAfficher.PreCalcule.CUSTOMER_CLAIM_COUNT), 0, assessmentAfficher.PreCalcule.CUSTOMER_CLAIM_COUNT)
            LabelLNCCountPNS.Text = IIf(IsNothing(assessmentAfficher.PreCalcule.LNC_COUNT), 0, assessmentAfficher.PreCalcule.LNC_COUNT)
            If (IsNothing(assessmentAfficher.PreCalcule.LOGISTIC_RATE)) Then
                LabelDelaysUpTo10DaysRatePNS.Text = "N/A"
            Else
                LabelDelaysUpTo10DaysRatePNS.Text = FormatPercent(assessmentAfficher.PreCalcule.LOGISTIC_RATE, 0)
            End If
            If IsNothing(assessmentAfficher.PreCalcule.DELAYS_UPPER_TO_X_DAYS_RATE) Then
                LabelLogisticRatePNS.Text = "N/A"
            Else
                LabelLogisticRatePNS.Text = FormatPercent(assessmentAfficher.PreCalcule.DELAYS_UPPER_TO_X_DAYS_RATE, 0)
            End If
            '*********************************** Graphique **********************************************************
            For Each uneLigne In assessmentAfficher.OrderHorizon
                ChartHorizonOrderPNS.Series("SeriesHorizonOrderOnTime").Points.Add(nouveauPoint(uneLigne.ORDER_HORIZON_LABEL, uneLigne.NB_ON_TIME))
                ChartHorizonOrderPNS.Series("SeriesHorizonOrderNotOnTime").Points.Add(nouveauPoint(uneLigne.ORDER_HORIZON_LABEL, uneLigne.NB_NOT_ON_TIME))
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chargeFormulaireSERTA(lAssessment As T_SUP_ASSESSMENT_SUA_SERTA)
        Try
            If (IsNothing(lAssessment)) Then
                Session("assessmentAfficherSERTA") = New T_SUP_ASSESSMENT_SUA_SERTA(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue)
            Else
                Session("assessmentAfficherSERTA") = lAssessment.Clone
            End If
            ''*****FieldSet Qualité ******
            Dim assessmentAfficher As T_SUP_ASSESSMENT_SUA_SERTA = CType(Session("assessmentAfficherSERTA"), T_SUP_ASSESSMENT_SUA_SERTA)
            textBoxIndicePPMvalueSERTA.Text = assessmentAfficher.SUA_INDICE_PPM_VALUE
            textBoxIndicePPMNoteSERTA.Text = assessmentAfficher.SUA_INDICE_PPM_POINT
            textBoxSinNBValueSERTA.Text = assessmentAfficher.SUA_SIN_NB_VALUE
            textBoxSinNBPointSERTA.Text = assessmentAfficher.SUA_SIN_NB_POINT
            textBoxCustomerClaimNBValueSERTA.Text = assessmentAfficher.SUA_CUSTOMER_CLAIM_NB_VALUE
            textBoxCustomerClaimNBPointSERTA.Text = assessmentAfficher.SUA_CUSTOMER_CLAIM_NB_POINT
            textBoxActionPlanReactivitySERTA.Text = assessmentAfficher.SUA_ACTION_PLAN_REACTIVITY_POINT
            textBoxBonusPPMSERTA.Text = assessmentAfficher.SUA_BONUS_500_PPM_POINT
            'LabelTotalQualite.Text = assessmentAfficher.SUA_
            ''****** FieldSet Logistique ********
            textboxLogisticRateValueSERTA.Text = assessmentAfficher.SUA_LOGISTIC_RATE_TARGET_95_VALUE
            textboxLogisticRatePointSERTA.Text = assessmentAfficher.SUA_LOGISTIC_RATE_TARGET_95_POINT
            textboxFlexibilityPointSERTA.Text = assessmentAfficher.SUA_FLEXIBILITY_POINT
            textboxDeliveryDelaysLevelValueSERTA.Text = assessmentAfficher.SUA_DELIVERY_DELAYS_LEVEL_VALUE
            textboxDeliveryDelaysLevelPointSERTA.Text = assessmentAfficher.SUA_DELIVERY_DELAYS_LEVEL_POINT
            textboxDeliveryQualityValueSERTA.Text = assessmentAfficher.SUA_DELIVERY_QUALITY_VALUE
            textboxDeliveryQualityPointSERTA.Text = assessmentAfficher.SUA_DELIVERY_QUALITY_POINT
            'labelTotalLogistique.Text = assessmentAfficher.SUA_
            ''******** FielSet Compétitivité ********
            TextBoxImprovmentPlanSERTA.Text = assessmentAfficher.SUA_IMPROVMENT_PLAN_POINT
            TextBoxBusinessRelationshipSERTA.Text = assessmentAfficher.SUA_BUSINESS_RELATIONSHIP_POINT
            TextBoxFinancialSituationSERTA.Text = assessmentAfficher.SUA_FINANCIAL_SITUATION_POINT
            TextBoxOffersReactivitySERTA.Text = assessmentAfficher.SUA_OFFERS_REACTIVITY_POINT
            TextBoxTechnicalAnswerQualitySERTA.Text = assessmentAfficher.SUA_TECHNICAL_ANSWER_QUALITY_POINT
            TextBoxIsoCertificationSERTA.Text = assessmentAfficher.SUA_ISO_CERTFICATION_POINT
            'LabelTatalCompetitiveness.Text = assessmentAfficher.SUA_
            ''************* FielSet Notation *************
            LabelTotalSERTA.Text = assessmentAfficher.SUA_TOTAL_POINT
            RadioButtonListTrendSERTA.SelectedValue = assessmentAfficher.SUA_TREND
            TextBoxCommentDetailSERTA.Text = assessmentAfficher.SUA_COMMENT_DETAIL
            TextBoxCommentClassificationSERTA.Text = assessmentAfficher.SUA_COMMENT_CLASSIFICATION
            TextBoxCommentGlobalSERTA.Text = assessmentAfficher.SUA_COMMENT_GLOBAL
            '**************** Pré-calcule***************************
            If assessmentAfficher.PreCalcule.PPM Is Nothing Then
                LabelPPMSERTA.Text = "N/A"
            Else
                LabelPPMSERTA.Text = CInt(assessmentAfficher.PreCalcule.PPM)
            End If
            LabelQncCountSERTA.Text = IIf(IsNothing(assessmentAfficher.PreCalcule.QNC_COUNT), 0, assessmentAfficher.PreCalcule.QNC_COUNT)
            LabelCustomerClaimCountSERTA.Text = IIf(IsNothing(assessmentAfficher.PreCalcule.CUSTOMER_CLAIM_COUNT), 0, assessmentAfficher.PreCalcule.CUSTOMER_CLAIM_COUNT)
            LabelLNCCountSERTA.Text = IIf(IsNothing(assessmentAfficher.PreCalcule.LNC_COUNT), 0, assessmentAfficher.PreCalcule.LNC_COUNT)
            If (IsNothing(assessmentAfficher.PreCalcule.LOGISTIC_RATE)) Then
                LabelDelaysUpTo10DaysRateSERTA.Text = "N/A"
            Else
                LabelDelaysUpTo10DaysRateSERTA.Text = FormatPercent(assessmentAfficher.PreCalcule.LOGISTIC_RATE, 0)
            End If
            If IsNothing(assessmentAfficher.PreCalcule.DELAYS_UPPER_TO_X_DAYS_RATE) Then
                LabelLogisticRateSERTA.Text = "N/A"
            Else
                LabelLogisticRateSERTA.Text = FormatPercent(assessmentAfficher.PreCalcule.DELAYS_UPPER_TO_X_DAYS_RATE, 0)
            End If
            '*********************************** Graphique **********************************************************
            For Each uneLigne In assessmentAfficher.OrderHorizon
                ChartHorizonOrderSERTA.Series("SeriesHorizonOrderOnTime").Points.Add(nouveauPoint(uneLigne.ORDER_HORIZON_LABEL, uneLigne.NB_ON_TIME))
                ChartHorizonOrderSERTA.Series("SeriesHorizonOrderNotOnTime").Points.Add(nouveauPoint(uneLigne.ORDER_HORIZON_LABEL, uneLigne.NB_NOT_ON_TIME))
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

   

    Private Sub sauvegardeFormulaire()
        Try
            Dim assessmentAfficher As T_SUP_ASSESSMENT_SUA_COMMON = (CType(Session("assessmentAfficherCOMMUN"), T_SUP_ASSESSMENT_SUA_COMMON))
            assessmentAfficher.SUP_ID = DropDownListSupplier.SelectedValue
            assessmentAfficher.SUA_QUARTER = DropDownListTrimestre.SelectedValue
            assessmentAfficher.SUA_ACTION_PLAN_REACTIVITY_POINT = textBoxActionPlanReactivity.Text
            assessmentAfficher.SUA_BONUS_500_PPM_POINT = textBoxBonusPPM.Text
            assessmentAfficher.SUA_BUSINESS_RELATIONSHIP_POINT = TextBoxBusinessRelationship.Text
            ' assessmentAfficher.SUA_COMMENT =
            assessmentAfficher.SUA_COMMENT_CLASSIFICATION = TextBoxCommentClassification.Text
            assessmentAfficher.SUA_COMMENT_DETAIL = TextBoxCommentDetail.Text
            assessmentAfficher.SUA_COMMENT_GLOBAL = TextBoxCommentGlobal.Text
            assessmentAfficher.SUA_CUSTOMER_CLAIM_NB_POINT = textBoxCustomerClaimNBPoint.Text
            assessmentAfficher.SUA_CUSTOMER_CLAIM_NB_VALUE = textBoxCustomerClaimNBValue.Text
            assessmentAfficher.SUA_DELIVERY_QUALITY_POINT = textboxDeliveryQualityPoint.Text
            assessmentAfficher.SUA_DELIVERY_QUALITY_VALUE = textboxDeliveryDelaysLevelValue.Text
            assessmentAfficher.SUA_DELIVERY_DELAYS_LEVEL_POINT = textboxDeliveryDelaysLevelPoint.Text
            assessmentAfficher.SUA_DELIVERY_DELAYS_LEVEL_VALUE = textboxDeliveryDelaysLevelValue.Text
            assessmentAfficher.SUA_FINANCIAL_SITUATION_POINT = TextBoxFinancialSituation.Text
            assessmentAfficher.SUA_FLEXIBILITY_POINT = textboxFlexibilityPoint.Text
            assessmentAfficher.SUA_IMPROVMENT_PLAN_POINT = TextBoxImprovmentPlan.Text
            assessmentAfficher.SUA_INDICE_PPM_POINT = textBoxIndicePPMNote.Text
            assessmentAfficher.SUA_INDICE_PPM_VALUE = textBoxIndicePPMvalue.Text
            assessmentAfficher.SUA_ISO_CERTFICATION_POINT = TextBoxIsoCertification.Text
            assessmentAfficher.SUA_LOGISTIC_RATE_TARGET_95_POINT = textboxLogisticRatePoint.Text
            assessmentAfficher.SUA_LOGISTIC_RATE_TARGET_95_VALUE = textboxLogisticRateValue.Text
            assessmentAfficher.SUA_OFFERS_REACTIVITY_POINT = TextBoxOffersReactivity.Text
            assessmentAfficher.SUA_SIN_NB_POINT = textBoxSinNBPoint.Text
            assessmentAfficher.SUA_SIN_NB_VALUE = textBoxSinNBValue.Text
            assessmentAfficher.SUA_TECHNICAL_ANSWER_QUALITY_POINT = TextBoxTechnicalAnswerQuality.Text
            assessmentAfficher.SUA_TOTAL_POINT = LabelTotal.Text
            assessmentAfficher.SUA_TREND = RadioButtonListTrend.SelectedValue

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
            If Not IsNothing(CType(Session("assessmentAfficherCOMMUN"), T_SUP_ASSESSMENT_SUA_COMMON)) Then
                System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " request save a assessement. ID : " + DropDownListSupplier.SelectedValue + " Quarter : " + DropDownListTrimestre.SelectedValue, Me.ToString)
                sauvegardeFormulaire()
                MgtSupplierIndicatorCOMMUN.getInstance.Save(CType(Session("assessmentAfficherCOMMUN"), T_SUP_ASSESSMENT_SUA_COMMON))
                chargeFormulaireCommun(CType(Session("assessmentAfficherCOMMUN"), T_SUP_ASSESSMENT_SUA_COMMON))
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