Imports Supplier_Indicator
Imports System.Web.UI.DataVisualization.Charting

Public Class SupplierAssessmentSERTA
    Inherits System.Web.UI.Page

    ''Gestion de la base par Linq to SQL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Permet de bloquer l'écriture tout en perméttant la publication de la valeur
        textBoxIndicePPMNote.Attributes.Add("readonly", "readonly")
        textBoxSinNBPoint.Attributes.Add("readonly", "readonly")
        textBoxCustomerClaimNBPoint.Attributes.Add("readonly", "readonly")
        textboxLogisticRatePoint.Attributes.Add("readonly", "readonly")
        textboxDeliveryDelaysLevelPoint.Attributes.Add("readonly", "readonly")
        textBoxBonusPPM.Attributes.Add("readonly", "readonly")
        textboxDeliveryQualityPoint.Attributes.Add("readonly", "readonly")
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
    Private Sub chargeFormulaire(lAssessment As T_SUP_ASSESSMENT_SUA_SERTA)
        Try
            If (IsNothing(lAssessment)) Then
                Session("assessmentAfficher") = New T_SUP_ASSESSMENT_SUA_SERTA(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue)
            Else
                Session("assessmentAfficher") = lAssessment.Clone
            End If
            Dim assessmentAfficher As T_SUP_ASSESSMENT_SUA_SERTA = CType(Session("assessmentAfficher"), T_SUP_ASSESSMENT_SUA_SERTA)
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
                ChartHorizonOrder.Series("SeriesHorizonOrderOnTime").Points.Add(nouveauPoint(uneLigne.ORDER_HORIZON_LABEL, uneLigne.NB_ON_TIME))
                ChartHorizonOrder.Series("SeriesHorizonOrderNotOnTime").Points.Add(nouveauPoint(uneLigne.ORDER_HORIZON_LABEL, uneLigne.NB_NOT_ON_TIME))
            Next
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
            Dim assessmentAfficher As T_SUP_ASSESSMENT_SUA_SERTA = (CType(Session("assessmentAfficher"), T_SUP_ASSESSMENT_SUA_SERTA))
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
            MgtSupplierIndicatorSERTA.getInstance.Save(CType(Session("assessmentAfficher"), T_SUP_ASSESSMENT_SUA_SERTA))
            chargeFormulaire(CType(Session("assessmentAfficher"), T_SUP_ASSESSMENT_SUA_SERTA))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''Evenement click bouton pour supprimer un Assessment
    Protected Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        Try
            System.Diagnostics.Trace.WriteLine(Now + " | " + User.Identity.Name + " request delete a assessment. ID : " + DropDownListSupplier.SelectedValue + " Quarter : " + DropDownListTrimestre.SelectedValue, Me.ToString)
            MgtSupplierIndicatorSERTA.getInstance.delete(MgtSupplierIndicatorSERTA.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
            chargeFormulaire(MgtSupplierIndicatorSERTA.getInstance.recherche(DropDownListSupplier.SelectedValue, DropDownListTrimestre.SelectedValue))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
End Class