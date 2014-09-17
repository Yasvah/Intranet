Partial Class T_SUP_ASSESSMENT_SUA_COMMON
    Implements ICloneable

    Private _PreCalcule As P_ASSESSMENT_VALUESResult
    ''' <summary>
    ''' Retourne les valeur precalcule pour cette assessment
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PreCalcule As P_ASSESSMENT_VALUESResult
        Get
            If _PreCalcule Is Nothing Then
                Dim BaseSupplierAssessment As dbSupplier_IndicatorDataContext = New dbSupplier_IndicatorDataContext()
                _PreCalcule = (From unPrecalcule In BaseSupplierAssessment.P_ASSESSMENT_VALUES(Me.SUP_ID, Me.SUA_QUARTER, "GROUP")
                    Select unPrecalcule).First
                Return _PreCalcule
            Else
                Return _PreCalcule
            End If
        End Get
    End Property

    Private _OrderHorizon As List(Of P_ASSESSMENT_ORDER_HORIZONResult)
    ''' <summary>
    ''' Retourne les valeurs des horizons de livraison
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property OrderHorizon As List(Of P_ASSESSMENT_ORDER_HORIZONResult)
        Get
            If _OrderHorizon Is Nothing Then
                Dim BaseSupplierAssessment As dbSupplier_IndicatorDataContext = New dbSupplier_IndicatorDataContext()
                _OrderHorizon = (From unOrderHorizon In BaseSupplierAssessment.P_ASSESSMENT_ORDER_HORIZON(Me.SUP_ID, Me.SUA_QUARTER, "GROUP")
                       Select unOrderHorizon).ToList
                Return _OrderHorizon
            Else
                Return _OrderHorizon
            End If
        End Get
    End Property

    Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function

    Public Sub New(SUP_ID As Integer, SUA_QUARTER As Integer)
        Me.SUP_ID = SUP_ID
        Me.SUA_QUARTER = SUA_QUARTER
        Me.SUA_ACTION_PLAN_REACTIVITY_POINT = 0
        Me.SUA_BONUS_500_PPM_POINT = 0
        Me.SUA_BUSINESS_RELATIONSHIP_POINT = 0
        Me.SUA_COMMENT = ""
        Me.SUA_COMMENT_CLASSIFICATION = ""
        Me.SUA_COMMENT_DETAIL = ""
        Me.SUA_COMMENT_GLOBAL = ""
        Me.SUA_CUSTOMER_CLAIM_NB_POINT = 0
        Me.SUA_CUSTOMER_CLAIM_NB_VALUE = 0
        Me.SUA_DELIVERY_DELAYS_LEVEL_POINT = 0
        Me.SUA_DELIVERY_QUALITY_POINT = 0
        Me.SUA_DELIVERY_QUALITY_VALUE = 0
        Me.SUA_DELIVERY_DELAYS_LEVEL_POINT = 0
        Me.SUA_DELIVERY_DELAYS_LEVEL_VALUE = 0
        Me.SUA_FINANCIAL_SITUATION_POINT = 0
        Me.SUA_FLEXIBILITY_POINT = 0
        Me.SUA_IMPROVMENT_PLAN_POINT = 0
        Me.SUA_INDICE_PPM_POINT = 0
        Me.SUA_INDICE_PPM_VALUE = 0
        Me.SUA_ISO_CERTFICATION_POINT = 0
        Me.SUA_LOGISTIC_RATE_TARGET_95_POINT = 0
        Me.SUA_LOGISTIC_RATE_TARGET_95_VALUE = 0
        Me.SUA_OFFERS_REACTIVITY_POINT = 0
        Me.SUA_SIN_NB_POINT = 0
        Me.SUA_SIN_NB_VALUE = 0
        Me.SUA_TECHNICAL_ANSWER_QUALITY_POINT = 0
        Me.SUA_TOTAL_POINT = 0
        Me.SUA_TREND = "1"
    End Sub
End Class

Partial Class T_SUP_ASSESSMENT_SUA_SERTA
    Implements ICloneable

    Private _PreCalcule As P_ASSESSMENT_VALUESResult
    ''' <summary>
    ''' Retourne les valeur precalcule pour cette assessment
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PreCalcule As P_ASSESSMENT_VALUESResult
        Get
            Dim BaseSupplierAssessment As dbSupplier_IndicatorDataContext = New dbSupplier_IndicatorDataContext()
            If _PreCalcule Is Nothing Then
                _PreCalcule = (From unPrecalcule In BaseSupplierAssessment.P_ASSESSMENT_VALUES(Me.SUP_ID, Me.SUA_QUARTER, "SERTA")
                    Select unPrecalcule).First
                Return _PreCalcule
            Else
                Return _PreCalcule
            End If
        End Get
    End Property

     Private _OrderHorizon As List(Of P_ASSESSMENT_ORDER_HORIZONResult)
    ''' <summary>
    ''' Retourne les valeurs des horizons de livraison
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property OrderHorizon As List(Of P_ASSESSMENT_ORDER_HORIZONResult)
        Get
            If _OrderHorizon Is Nothing Then
                Dim BaseSupplierAssessment As dbSupplier_IndicatorDataContext = New dbSupplier_IndicatorDataContext()
                _OrderHorizon = (From unOrderHorizon In BaseSupplierAssessment.P_ASSESSMENT_ORDER_HORIZON(Me.SUP_ID, Me.SUA_QUARTER, "SERTA")
                       Select unOrderHorizon).ToList
                Return _OrderHorizon
            Else
                Return _OrderHorizon
            End If
        End Get
    End Property

    Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function

    Public Sub New(SUP_ID As Integer, SUA_QUARTER As Integer)
        Me.SUP_ID = SUP_ID
        Me.SUA_QUARTER = SUA_QUARTER
        Me.SUA_ACTION_PLAN_REACTIVITY_POINT = 0
        Me.SUA_BONUS_500_PPM_POINT = 0
        Me.SUA_BUSINESS_RELATIONSHIP_POINT = 0
        Me.SUA_COMMENT = ""
        Me.SUA_COMMENT_CLASSIFICATION = ""
        Me.SUA_COMMENT_DETAIL = ""
        Me.SUA_COMMENT_GLOBAL = ""
        Me.SUA_CUSTOMER_CLAIM_NB_POINT = 0
        Me.SUA_CUSTOMER_CLAIM_NB_VALUE = 0
        Me.SUA_DELIVERY_DELAYS_LEVEL_POINT = 0
        Me.SUA_DELIVERY_QUALITY_POINT = 0
        Me.SUA_DELIVERY_QUALITY_VALUE = 0
        Me.SUA_DELIVERY_DELAYS_LEVEL_POINT = 0
        Me.SUA_DELIVERY_DELAYS_LEVEL_VALUE = 0
        Me.SUA_FINANCIAL_SITUATION_POINT = 0
        Me.SUA_FLEXIBILITY_POINT = 0
        Me.SUA_IMPROVMENT_PLAN_POINT = 0
        Me.SUA_INDICE_PPM_POINT = 0
        Me.SUA_INDICE_PPM_VALUE = 0
        Me.SUA_ISO_CERTFICATION_POINT = 0
        Me.SUA_LOGISTIC_RATE_TARGET_95_POINT = 0
        Me.SUA_LOGISTIC_RATE_TARGET_95_VALUE = 0
        Me.SUA_OFFERS_REACTIVITY_POINT = 0
        Me.SUA_SIN_NB_POINT = 0
        Me.SUA_SIN_NB_VALUE = 0
        Me.SUA_TECHNICAL_ANSWER_QUALITY_POINT = 0
        Me.SUA_TOTAL_POINT = 0
        Me.SUA_TREND = "1"
    End Sub
End Class

Partial Class T_SUP_ASSESSMENT_SUA_PNS
    Implements ICloneable

    Private _PreCalcule As P_ASSESSMENT_VALUESResult
    ''' <summary>
    ''' Retourne les valeur precalcule pour cette assessment
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PreCalcule As P_ASSESSMENT_VALUESResult
        Get
            Dim BaseSupplierAssessment As dbSupplier_IndicatorDataContext = New dbSupplier_IndicatorDataContext()
            If _PreCalcule Is Nothing Then
                _PreCalcule = (From unPrecalcule In BaseSupplierAssessment.P_ASSESSMENT_VALUES(Me.SUP_ID, Me.SUA_QUARTER, "PNS")
                    Select unPrecalcule).First
                Return _PreCalcule
            Else
                Return _PreCalcule
            End If
        End Get
    End Property
    Private _OrderHorizon As List(Of P_ASSESSMENT_ORDER_HORIZONResult)
    ''' <summary>
    ''' Retourne les valeurs des horizons de livraison
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property OrderHorizon As List(Of P_ASSESSMENT_ORDER_HORIZONResult)
        Get
            If _OrderHorizon Is Nothing Then
                Dim BaseSupplierAssessment As dbSupplier_IndicatorDataContext = New dbSupplier_IndicatorDataContext()
                _OrderHorizon = (From unOrderHorizon In BaseSupplierAssessment.P_ASSESSMENT_ORDER_HORIZON(Me.SUP_ID, Me.SUA_QUARTER, "PNS")
                       Select unOrderHorizon).ToList
                Return _OrderHorizon
            Else
                Return _OrderHorizon
            End If
        End Get
    End Property

    Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function

    Public Sub New(SUP_ID As Integer, SUA_QUARTER As Integer)
        Me.SUP_ID = SUP_ID
        Me.SUA_QUARTER = SUA_QUARTER
        Me.SUA_ACTION_PLAN_REACTIVITY_POINT = 0
        Me.SUA_BONUS_500_PPM_POINT = 0
        Me.SUA_BUSINESS_RELATIONSHIP_POINT = 0
        Me.SUA_COMMENT = ""
        Me.SUA_COMMENT_CLASSIFICATION = ""
        Me.SUA_COMMENT_DETAIL = ""
        Me.SUA_COMMENT_GLOBAL = ""
        Me.SUA_CUSTOMER_CLAIM_NB_POINT = 0
        Me.SUA_CUSTOMER_CLAIM_NB_VALUE = 0
        Me.SUA_DELIVERY_DELAYS_LEVEL_POINT = 0
        Me.SUA_DELIVERY_QUALITY_POINT = 0
        Me.SUA_DELIVERY_QUALITY_VALUE = 0
        Me.SUA_DELIVERY_DELAYS_LEVEL_POINT = 0
        Me.SUA_DELIVERY_DELAYS_LEVEL_VALUE = 0
        Me.SUA_FINANCIAL_SITUATION_POINT = 0
        Me.SUA_FLEXIBILITY_POINT = 0
        Me.SUA_IMPROVMENT_PLAN_POINT = 0
        Me.SUA_INDICE_PPM_POINT = 0
        Me.SUA_INDICE_PPM_VALUE = 0
        Me.SUA_ISO_CERTFICATION_POINT = 0
        Me.SUA_LOGISTIC_RATE_TARGET_95_POINT = 0
        Me.SUA_LOGISTIC_RATE_TARGET_95_VALUE = 0
        Me.SUA_OFFERS_REACTIVITY_POINT = 0
        Me.SUA_SIN_NB_POINT = 0
        Me.SUA_SIN_NB_VALUE = 0
        Me.SUA_TECHNICAL_ANSWER_QUALITY_POINT = 0
        Me.SUA_TOTAL_POINT = 0
        Me.SUA_TREND = "1"
    End Sub

End Class

