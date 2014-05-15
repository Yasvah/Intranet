Public Class AssessmentSERTA
    Inherits Assessment

    Public Sub New(idSupplier As Integer, quarter As Integer)
        MyBase.New(idSupplier, quarter)
    End Sub
    Public Sub New(id As Integer, supplier As Integer, quarter As String, form As Integer, indicePPMValue As Integer, _
                   indicePPMPoint As Integer, sinNBValue As Integer, sinNBPoint As Integer, customerClaimNBValue As Integer, customerClaimNBPoint As Integer, _
                   actionPlanReactivityPoint As Integer, bonus500PPMPoint As Integer, logisticRateTarget95Value As Integer, logisticRateTarget95Point As Integer, _
                   flexibilityPoint As Integer, deliveryDelaysLevelValue As Integer, deliveryDelaysLevelPoint As Integer, deliveryQualityValue As Integer, deliveryQualityPoint As Integer, _
                   priceCompetitivenessValue As Integer, priceCompetitivenessPoint As Integer, improvmentPlanPoint As Integer, businessRelationshipPoint As Integer, _
                   financialSituationPoint As Integer, OffersReactivityPoint As Integer, technicalAnswerQualityPoint As Integer, isoCertificationPoint As Integer, comment As String, _
                   commentDetail As String, commentClassification As String, commentGlobal As String, totalPoint As Integer, trend As Integer)
        MyBase.New(id, supplier, quarter, indicePPMValue, indicePPMPoint, sinNBValue, sinNBPoint, customerClaimNBValue, customerClaimNBPoint, _
                   actionPlanReactivityPoint, bonus500PPMPoint, logisticRateTarget95Value, logisticRateTarget95Point, _
                   flexibilityPoint, deliveryDelaysLevelValue, deliveryDelaysLevelPoint, deliveryQualityValue, deliveryQualityPoint, _
                   priceCompetitivenessValue, priceCompetitivenessPoint, improvmentPlanPoint, businessRelationshipPoint, _
                   financialSituationPoint, OffersReactivityPoint, technicalAnswerQualityPoint, isoCertificationPoint, comment, _
                   commentDetail, commentClassification, commentGlobal, totalPoint, trend)

    End Sub
    Private _PrecalculedValue As Precalculatedvalue
    Public ReadOnly Property PrecalculedValue As Precalculatedvalue
        Get
            Try
                If IsNothing(_PrecalculedValue) Then
                    Dim db As dbSupplierIndicatorDataContext = New dbSupplierIndicatorDataContext
                    For Each uneLigne In db.P_Assessment_Values_SERTA(Me.idSupplier, Me.quarter)
                        Dim PPM = If(IsNothing(uneLigne.PPM), 0, uneLigne.PPM)
                        Dim QNC_COUNT = uneLigne.QNC_COUNT
                        Dim CUSTOMER_CLAIN_COUNT = uneLigne.CUSTOMER_CLAIM_COUNT
                        Dim LNC_COUNT = uneLigne.LNC_COUNT
                        Dim LOGISTIC_RATE = IIf(IsNothing(uneLigne.LOGISTIC_RATE), 0, uneLigne.LOGISTIC_RATE)
                        Dim DELAY_UP_TO_DAYS_RATE = IIf(IsNothing(uneLigne.DELAYS_UPPER_TO_X_DAYS_RATE), 0, uneLigne.DELAYS_UPPER_TO_X_DAYS_RATE)
                        Dim _order_horizon_percentage_0_to_2 As Double = IIf(IsNothing(uneLigne.ORDER_HORIZON_0_TO_2_RATE), 0, uneLigne.ORDER_HORIZON_0_TO_2_RATE)
                        Dim _order_horizon_percentage_3_to_4 As Double = IIf(IsNothing(uneLigne.ORDER_HORIZON_3_TO_4_RATE), 0, uneLigne.ORDER_HORIZON_3_TO_4_RATE)
                        Dim _order_horizon_percentage_5_to_6 As Double = IIf(IsNothing(uneLigne.ORDER_HORIZON_5_TO_6_RATE), 0, uneLigne.ORDER_HORIZON_5_TO_6_RATE)
                        Dim _order_horizon_percentage_7_to_8 As Double = IIf(IsNothing(uneLigne.ORDER_HORIZON_7_TO_8_RATE), 0, uneLigne.ORDER_HORIZON_7_TO_8_RATE)
                        Dim _order_horizon_percentage_9_to_10 As Double = IIf(IsNothing(uneLigne.ORDER_HORIZON_9_TO_10_RATE), 0, uneLigne.ORDER_HORIZON_9_TO_10_RATE)
                        Dim _order_horizon_percentage_11_to_12 As Double = IIf(IsNothing(uneLigne.ORDER_HORIZON_11_TO_12_RATE), 0, uneLigne.ORDER_HORIZON_11_TO_12_RATE)
                        Dim _order_horizon_percentage_greather_than_12 As Double = IIf(IsNothing(uneLigne.ORDER_HORIZON_GREATER_THAN_12_RATE), 0, uneLigne.ORDER_HORIZON_GREATER_THAN_12_RATE)
                        Dim _firm_order_resquest As Integer = CInt(IIf(IsNothing(uneLigne.ORDER_HORIZON_REQUESTED), 0, uneLigne.ORDER_HORIZON_REQUESTED))
                        Dim _firm_order_current As Integer = CInt(IIf(IsNothing(uneLigne.ORDER_HORIZON_USUAL), 0, uneLigne.ORDER_HORIZON_USUAL))
                        _PrecalculedValue = New Precalculatedvalue(PPM, QNC_COUNT, CUSTOMER_CLAIN_COUNT, LNC_COUNT, LOGISTIC_RATE, DELAY_UP_TO_DAYS_RATE, _
                                                                   _order_horizon_percentage_0_to_2, _order_horizon_percentage_3_to_4, _order_horizon_percentage_5_to_6, _order_horizon_percentage_7_to_8, _
                                                                   _order_horizon_percentage_9_to_10, _order_horizon_percentage_11_to_12, _order_horizon_percentage_greather_than_12, _
                                                                   _firm_order_resquest, _firm_order_current)
                    Next
                End If
                Return _PrecalculedValue
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Calcule le nombre de point pour LogisticTarget avec la pénalité
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>
    ''' X = logisticRateTarget95Value
    ''' Y = (1 + PrecalculedValue.FirmOrderPoint / 100)
    ''' Z = logisticRateTarget95WithPenalty
    ''' 
    ''' Z =(5X(1-Y)) / 9
    ''' </remarks>
    Public ReadOnly Property logisticRateTarget95WithPenalty() As Integer
        Get
            Dim temp As Integer
            temp = IIf(logisticRateTarget95Value >= 95, 25, logisticRateTarget95Value * (1 - PrecalculedValue.FirmOrderPoint / 100) * 5 / 9 - 250 / 9) '95% -> 25 pts, 50% -> 0 pt
            temp = IIf(temp < 0, 0, temp)
            Return temp
        End Get
    End Property
    ''' <summary>
    ''' Calcule le nombre de point de pénality pour LogisticTarget
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>
    ''' X = logisticRateTarget95Value
    ''' Y = (PrecalculedValue.FirmOrderPoint / 100)
    ''' Z = PenaltyPoint
    ''' 
    ''' Z = 5XY/9
    ''' </remarks>
    Public ReadOnly Property PenaltyPoint As Integer
        Get
            Return (5 * logisticRateTarget95Value * (PrecalculedValue.FirmOrderPoint / 100)) / 9 * -1 'Pour avoir un chiffre négatif
        End Get
    End Property
End Class
