Public Class Assessment
    Implements System.ICloneable
#Region "Attribut et propiété"

    Private _id As Integer
    ''' <summary> 
    ''' Identificateur
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public _idSupplier As Integer
    ''' <summary>
    ''' Fournisseur
    ''' </summary>
    ''' <value></value>
    ''' <returns>Retourne la clé primaire du fournisseur</returns>
    ''' <remarks></remarks>
    Public Property idSupplier As Integer
        Get
            Return _idSupplier
        End Get
        Set(value As Integer)
            _idSupplier = value
        End Set
    End Property
    Private _quarter As Integer 'Trimestre
    ''' <summary>
    ''' trimestre
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property quarter As Integer
        Get
            Return _quarter
        End Get
        Set(value As Integer)
            _quarter = value
        End Set
    End Property
    Private _form As Integer
    ''' <summary>
    ''' version du formulaire
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property form As Integer
        Get
            Return _form
        End Get
        Set(value As Integer)
            _form = value
        End Set
    End Property
    Private _indicePPMValue As Integer
    Public Property indicePPMValue As Integer
        Get
            Return _indicePPMValue
        End Get
        Set(value As Integer)
            indicePPMPoint = value
            _indicePPMValue = value
        End Set
    End Property
    Private _indicePPMPoint As Integer
    Public Property indicePPMPoint As Integer
        Get
            Return _indicePPMPoint
        End Get
        Set(value As Integer)
            If (value <= 500) Then
                _indicePPMPoint = 20
            ElseIf (value >= 10000) Then
                _indicePPMPoint = 0
            Else
                _indicePPMPoint = 20 - value / 1000 * 2
            End If
        End Set
    End Property
    Private _sinNBValue As Integer
    Public Property sinNBValue As Integer
        Get
            Return _sinNBValue
        End Get
        Set(value As Integer)
            sinNBPoint = value
            _sinNBValue = value
        End Set
    End Property
    Private _sinNBPoint As Integer
    Public Property sinNBPoint() As Integer
        Get
            Return _sinNBPoint
        End Get
        Set(ByVal value As Integer)
            _sinNBPoint = IIf((20 - 5 * value) <= 0, 0, (20 - 5 * value))
        End Set
    End Property
    Private _customerClaimNBValue As Integer
    Public Property customerClaimNBValue() As Integer
        Get
            Return _customerClaimNBValue
        End Get
        Set(ByVal value As Integer)
            customerClaimNBPoint = value
            _customerClaimNBValue = value
        End Set
    End Property
    Private _customerClaimNBPoint As Integer
    Public Property customerClaimNBPoint() As Integer
        Get
            Return _customerClaimNBPoint
        End Get
        Set(ByVal value As Integer)
            _customerClaimNBPoint = value * -15
        End Set
    End Property
    Private _actionPlanReactivityPoint As Integer
    Public Property actionPlanReactivityPoint() As Integer
        Get
            Return _actionPlanReactivityPoint
        End Get
        Set(ByVal value As Integer)
            _actionPlanReactivityPoint = value
        End Set
    End Property
    Private _bonus500PPMPoint As Integer
    Public ReadOnly Property bonus500PPMPoint() As Integer
        Get
            Return IIf(Me.customerClaimNBValue > 0, 0, IIf(Me.indicePPMValue > 500, 0, (500 - Me.indicePPMValue) / 100 * 2))
        End Get
    End Property
    Private _logisticRateTarget95Value As Integer
    Public Property logisticRateTarget95Value() As Integer
        Get
            Return _logisticRateTarget95Value
        End Get
        Set(ByVal value As Integer)
            logisticRateTarget95Point = value
            _logisticRateTarget95Value = value
        End Set
    End Property
    Private _logisticRateTarget95Point As Integer
    Public Property logisticRateTarget95Point() As Integer
        Get
            Return _logisticRateTarget95Point
        End Get
        Set(ByVal value As Integer)
            Dim temp As Integer
            temp = IIf(value >= 95, 25, value * 5 / 9 - 250 / 9) '95% -> 25 pts, 50% -> 0 pt
            _logisticRateTarget95Point = IIf(temp < 0, 0, temp)
        End Set
    End Property
    Private _flexibilityPoint As Integer
    Public Property flexibilityPoint() As Integer
        Get
            Return _flexibilityPoint
        End Get
        Set(ByVal value As Integer)
            _flexibilityPoint = value
        End Set
    End Property
    Private _deliveryDelaysLevelValue As Integer
    Public Property deliveryDelaysLevelValue() As Integer
        Get
            Return _deliveryDelaysLevelValue
        End Get
        Set(ByVal value As Integer)
            deliveryDelaysLevelPoint = value
            _deliveryDelaysLevelValue = value
        End Set
    End Property
    Private _deliveryDelaysLevelPoint As Integer
    Public Property deliveryDelaysLevelPoint() As Integer
        Get
            Return _deliveryDelaysLevelPoint
        End Get
        Set(ByVal value As Integer)
            _deliveryDelaysLevelPoint = value * -2
        End Set
    End Property
    Private _deliveryQualityValue As Integer
    Public Property deliveryQualityValue() As Integer
        Get
            Return _deliveryQualityValue
        End Get
        Set(ByVal value As Integer)
            deliveryQualityPoint = value
            _deliveryQualityValue = value
        End Set
    End Property
    Private _deliveryQualityPoint As Integer
    Public Property deliveryQualityPoint() As Integer
        Get
            Return _deliveryQualityPoint
        End Get
        Set(ByVal value As Integer)

            _deliveryQualityPoint = IIf(value = 0, 2, 0)
        End Set
    End Property
    Private _priceCompetitivenessValue As Integer
    Public Property priceCompetitivenessValue() As Integer
        Get
            Return _priceCompetitivenessValue
        End Get
        Set(ByVal value As Integer)
            _priceCompetitivenessValue = value
        End Set
    End Property
    Private _priceCompetitivenessPoint As Integer
    Public Property priceCompetitivenessPoint() As Integer
        Get
            Return _priceCompetitivenessPoint
        End Get
        Set(ByVal value As Integer)
            _priceCompetitivenessPoint = value
        End Set
    End Property
    Private _improvmentPlanPoint As Integer
    Public Property improvmentPlanPoint() As Integer
        Get
            Return _improvmentPlanPoint
        End Get
        Set(ByVal value As Integer)
            _improvmentPlanPoint = value
        End Set
    End Property
    Private _businessRelationshipPoint As Integer
    Public Property businessRelationshipPoint() As Integer
        Get
            Return _businessRelationshipPoint
        End Get
        Set(ByVal value As Integer)
            _businessRelationshipPoint = value
        End Set
    End Property
    Private _financialSituationPoint As Integer
    Public Property financialSituationPoint() As Integer
        Get
            Return _financialSituationPoint
        End Get
        Set(ByVal value As Integer)
            _financialSituationPoint = value
        End Set
    End Property
    Private _offersReactivityPoint As Integer
    Public Property offersReactivityPoint() As Integer
        Get
            Return _offersReactivityPoint
        End Get
        Set(ByVal value As Integer)
            _offersReactivityPoint = value
        End Set
    End Property
    Private _technicalAnswerQualityPoint As Integer
    Public Property technicalAnswerQualityPoint() As Integer
        Get
            Return _technicalAnswerQualityPoint
        End Get
        Set(ByVal value As Integer)
            _technicalAnswerQualityPoint = value
        End Set
    End Property
    Private _isoCertificationPoint As Integer
    Public Property isoCertificationPoint() As Integer
        Get
            Return _isoCertificationPoint
        End Get
        Set(ByVal value As Integer)
            _isoCertificationPoint = value
        End Set
    End Property
    Private _comment As String
    Public Property comment() As String
        Get
            Return _comment
        End Get
        Set(ByVal value As String)
            _comment = value
        End Set
    End Property
    Private _commentDetail As String
    Public Property commentDetail() As String
        Get
            Return _commentDetail
        End Get
        Set(ByVal value As String)
            _commentDetail = value
        End Set
    End Property
    Private _commentClassification As String
    Public Property commentClassification() As String
        Get
            Return _commentClassification
        End Get
        Set(ByVal value As String)
            _commentClassification = value
        End Set
    End Property
    Private _commentGlobal As String
    Public Property commentGlobal() As String
        Get
            Return _commentGlobal
        End Get
        Set(ByVal value As String)
            _commentGlobal = value
        End Set
    End Property
    Private _totalPoint As Integer
    Public ReadOnly Property totalPoint() As Integer
        Get
            _totalPoint = Me.TotalQuality + Me.TotalLogistic + Me.TotalCompetitiveness
            Return _totalPoint
        End Get
    End Property
    Private _trend As Integer
    Public Property trend() As Integer
        Get
            Return _trend
        End Get
        Set(ByVal value As Integer)
            _trend = value
        End Set
    End Property
    ''' <summary>
    ''' Retourne l'année et le trimestre sous le fourmat "aaaa"
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property textQuarter As String
        Get
            Return "20" + quarter.ToString.Substring(0, 2) + " Trimestre " + quarter.ToString.Substring(2, 1)
        End Get
    End Property
    ''' <summary>
    ''' Retourne le total qualité.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TotalQuality As Integer
        Get
            Dim tmpTotalQuality As Integer
            tmpTotalQuality = Me.indicePPMPoint + Me.sinNBPoint + Me.actionPlanReactivityPoint + Me.customerClaimNBPoint + Me.bonus500PPMPoint
            If tmpTotalQuality < 0 Then
                Return 0
            ElseIf tmpTotalQuality > 55 Then 'Mis à 55 : Demande de Marc pour que le bonus de point puis se reporter sur le total.
                Return 55
            Else
                Return tmpTotalQuality
            End If
        End Get
    End Property
    ''' <summary>
    ''' Retourne le total logistique
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TotalLogistic As Integer
        Get
            Dim tmpTotalLogistic As Integer
            tmpTotalLogistic = Me.logisticRateTarget95Point + Me.deliveryDelaysLevelPoint + Me.deliveryQualityPoint + Me.flexibilityPoint
            If tmpTotalLogistic < 0 Then
                Return 0
            ElseIf tmpTotalLogistic > 35 Then
                Return 35
            Else
                Return tmpTotalLogistic
            End If
        End Get
    End Property
    ''' <summary>
    ''' retourne le total de compétivité
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TotalCompetitiveness As Integer
        Get
            Dim tmpTotalCompetitiveness As Integer
            tmpTotalCompetitiveness = Me.improvmentPlanPoint + Me.businessRelationshipPoint + Me.financialSituationPoint + Me.offersReactivityPoint + Me.technicalAnswerQualityPoint + Me.isoCertificationPoint
            If tmpTotalCompetitiveness < 0 Then
                Return 0
            ElseIf tmpTotalCompetitiveness > 20 Then
                Return 20
            Else
                Return tmpTotalCompetitiveness
            End If
        End Get
    End Property
#End Region
#Region "Constructeur"

    Public Sub New(idSupplier As Integer, quarter As String)
        Me.idSupplier = idSupplier
        Me.quarter = quarter
        Me.form = 1
        Me.indicePPMValue = 0
        Me.sinNBValue = 0
        Me.customerClaimNBValue = 0
        Me.actionPlanReactivityPoint = 0
        Me.logisticRateTarget95Value = 0
        Me.logisticRateTarget95Point = 0
        Me.flexibilityPoint = 0
        Me.deliveryDelaysLevelValue = 0
        Me.deliveryDelaysLevelPoint = 0
        Me.deliveryQualityValue = 0
        Me.deliveryQualityPoint = 0
        Me.priceCompetitivenessValue = 0
        Me.priceCompetitivenessPoint = 0
        Me.improvmentPlanPoint = 0
        Me.businessRelationshipPoint = 0
        Me.financialSituationPoint = 0
        Me.offersReactivityPoint = 0
        Me.technicalAnswerQualityPoint = 0
        Me.isoCertificationPoint = 0
        Me.comment = ""
        Me.commentDetail = ""
        Me.commentClassification = ""
        Me.commentGlobal = ""
        Me.trend = 1
    End Sub

    Public Sub New(id As Integer, supplier As Integer, quarter As String, indicePPMValue As Integer, _
                   indicePPMPoint As Integer, sinNBValue As Integer, sinNBPoint As Integer, customerClaimNBValue As Integer, customerClaimNBPoint As Integer, _
                   actionPlanReactivityPoint As Integer, bonus500PPMPoint As Integer, logisticRateTarget95Value As Integer, logisticRateTarget95Point As Integer, _
                   flexibilityPoint As Integer, deliveryDelaysLevelValue As Integer, deliveryDelaysLevelPoint As Integer, deliveryQualityValue As Integer, deliveryQualityPoint As Integer, _
                   priceCompetitivenessValue As Integer, priceCompetitivenessPoint As Integer, improvmentPlanPoint As Integer, businessRelationshipPoint As Integer, _
                   financialSituationPoint As Integer, OffersReactivityPoint As Integer, technicalAnswerQualityPoint As Integer, isoCertificationPoint As Integer, comment As String, _
                   commentDetail As String, commentClassification As String, commentGlobal As String, totalPoint As Integer, trend As Integer)
        Me.id = id
        Me.idSupplier = supplier
        Me.quarter = quarter
        Me.form = 1
        Me._indicePPMValue = indicePPMValue
        Me._indicePPMPoint = indicePPMPoint
        Me._sinNBValue = sinNBValue
        Me._sinNBPoint = sinNBPoint
        Me._customerClaimNBValue = customerClaimNBValue
        Me._customerClaimNBPoint = customerClaimNBPoint
        Me._actionPlanReactivityPoint = actionPlanReactivityPoint
        Me._bonus500PPMPoint = bonus500PPMPoint
        Me._logisticRateTarget95Value = logisticRateTarget95Value
        Me._logisticRateTarget95Point = logisticRateTarget95Point
        Me._flexibilityPoint = flexibilityPoint
        Me._deliveryDelaysLevelValue = deliveryDelaysLevelValue
        Me._deliveryDelaysLevelPoint = deliveryDelaysLevelPoint
        Me._deliveryQualityValue = deliveryQualityValue
        Me._deliveryQualityPoint = deliveryQualityPoint
        Me._priceCompetitivenessValue = priceCompetitivenessValue
        Me._priceCompetitivenessPoint = priceCompetitivenessPoint
        Me._improvmentPlanPoint = improvmentPlanPoint
        Me._businessRelationshipPoint = businessRelationshipPoint
        Me._financialSituationPoint = financialSituationPoint
        Me._offersReactivityPoint = OffersReactivityPoint
        Me._technicalAnswerQualityPoint = technicalAnswerQualityPoint
        Me._isoCertificationPoint = isoCertificationPoint
        Me._comment = comment
        Me._commentDetail = commentDetail
        Me._commentClassification = commentClassification
        Me._commentGlobal = commentGlobal
        Me._totalPoint = totalPoint
        Me._trend = trend

    End Sub

#End Region
#Region "méthode"

    Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function

    Public Overloads Function ToString() As String
        Dim txt As String
        txt = "id : " & id & vbNewLine
        txt &= "IdSupplier : " & idSupplier
        txt &= "quarter : " & quarter & vbNewLine
        txt &= "form : " & form & vbNewLine
        txt &= "indicePPMValue : " & indicePPMValue & vbNewLine
        txt &= "sinNBValue : " & sinNBValue & vbNewLine
        txt &= "customerClaimNBValue : " & customerClaimNBValue & vbNewLine
        txt &= "actionPlanReactivityPoint : " & actionPlanReactivityPoint & vbNewLine
        txt &= "logisticRateTarget95Value : " & logisticRateTarget95Value & vbNewLine
        txt &= "flexibilityPoint : " & flexibilityPoint & vbNewLine
        txt &= "deliveryDelaysLevelValue : " & deliveryDelaysLevelValue & vbNewLine
        txt &= "deliveryQualityValue : " & deliveryQualityValue & vbNewLine
        txt &= "priceCompetitivenessValue : " & priceCompetitivenessValue & vbNewLine
        txt &= "improvmentPlanPoint : " & improvmentPlanPoint & vbNewLine
        txt &= "businessRelationshipPoint : " & businessRelationshipPoint & vbNewLine
        txt &= "financialSituationPoint : " & financialSituationPoint & vbNewLine
        txt &= "offersReactivityPoint : " & offersReactivityPoint & vbNewLine
        txt &= "technicalAnswerQualityPoint : " & technicalAnswerQualityPoint & vbNewLine
        txt &= "isoCertificationPoint : " & isoCertificationPoint & vbNewLine
        Return txt
    End Function
#End Region
End Class
