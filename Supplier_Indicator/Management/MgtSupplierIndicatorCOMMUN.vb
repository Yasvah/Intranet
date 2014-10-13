Public Class MgtSupplierIndicatorCOMMUN
#Region "Propriété"
    ''' <summary>
    ''' Variable utiliser pour le data context (Objet DAL)
    ''' </summary>
    ''' <remarks></remarks>
    Private BaseSupplierAssessment As dbSupplier_IndicatorDataContext = New dbSupplier_IndicatorDataContext()

    ''' <summary>
    ''' Retourne la liste des fournisseurs
    ''' </summary>
    ''' <remarks></remarks>
    Private _supplier_list As String
    Public ReadOnly Property Supplier_list() As System.Data.Linq.ISingleResult(Of P_SUPPLIER_LIST_COMMUNResult)
        Get
            Return BaseSupplierAssessment.P_SUPPLIER_LIST_COMMUN
        End Get
    End Property

    Dim _listAssessment As List(Of T_SUP_ASSESSMENT_SUA_COMMON)
    ''' <summary>
    ''' Liste des score enregistré dans la base de donnée
    ''' </summary>
    ''' <value></value>
    ''' <returns>Retourne une liste de type assessment</returns>
    ''' <remarks></remarks>
    ReadOnly Property ListAssessment As List(Of T_SUP_ASSESSMENT_SUA_COMMON)
        Get
            Try
                _listAssessment.Clear()
                Dim query = From listeAssessment In BaseSupplierAssessment.T_SUP_ASSESSMENT_SUA_COMMON
                       Select listeAssessment

                For Each item In query
                    _listAssessment.Add(item)
                Next
                Return _listAssessment
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property
#End Region
#Region "constructeur"
    Private Shared _instance As New MgtSupplierIndicatorCOMMUN()

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As MgtSupplierIndicatorCOMMUN
        Return _instance
    End Function
#End Region
#Region "Méthode"
    ''' <summary>
    ''' Function qui sauvegarde un assessment
    ''' </summary>
    ''' <param name="assessment"></param>
    ''' <remarks>Met à jour le score si il exist, sinon crée une insertion</remarks>
    Public Sub Save(assessment As T_SUP_ASSESSMENT_SUA_COMMON)
        If Not IsNothing(recherche(assessment.SUP_ID, assessment.SUA_QUARTER)) Then
            Update(assessment)
        Else
            Insert(assessment)
        End If
    End Sub
    ''' <summary>
    ''' Insertion d'un nouveau score dans la base de donnée
    ''' </summary>
    ''' <param name="Assessment"></param>
    ''' <remarks></remarks>
    Public Sub Insert(Assessment As T_SUP_ASSESSMENT_SUA_COMMON)
        Try
            BaseSupplierAssessment.T_SUP_ASSESSMENT_SUA_COMMON.InsertOnSubmit(Assessment)
            BaseSupplierAssessment.SubmitChanges()
            System.Diagnostics.Trace.WriteLine(Now + " | " + " Assessement INSERT : " + Assessment.ToString, Me.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Mise à jour d'un score dans la base de donnée
    ''' </summary>
    ''' <param name="Assessment"></param>
    ''' <remarks></remarks>
    Public Sub Update(Assessment As T_SUP_ASSESSMENT_SUA_COMMON)
        Try
            Dim modificationAssessment As T_SUP_ASSESSMENT_SUA_COMMON = (From unAssessment In BaseSupplierAssessment.T_SUP_ASSESSMENT_SUA_COMMON
                                                                Where unAssessment.SUP_ID = Assessment.SUP_ID And unAssessment.SUA_QUARTER = Assessment.SUA_QUARTER
                                                                Select unAssessment).First

            With modificationAssessment
                '.SUA_FORM = Assessment.SUA_FORM
                .SUA_INDICE_PPM_VALUE = Assessment.SUA_INDICE_PPM_VALUE
                .SUA_INDICE_PPM_POINT = Assessment.SUA_INDICE_PPM_POINT
                .SUA_SIN_NB_VALUE = Assessment.SUA_SIN_NB_VALUE
                .SUA_SIN_NB_POINT = Assessment.SUA_SIN_NB_POINT
                .SUA_CUSTOMER_CLAIM_NB_VALUE = Assessment.SUA_CUSTOMER_CLAIM_NB_VALUE
                .SUA_CUSTOMER_CLAIM_NB_POINT = Assessment.SUA_CUSTOMER_CLAIM_NB_POINT
                .SUA_ACTION_PLAN_REACTIVITY_POINT = Assessment.SUA_ACTION_PLAN_REACTIVITY_POINT
                .SUA_BONUS_500_PPM_POINT = Assessment.SUA_BONUS_500_PPM_POINT
                .SUA_LOGISTIC_RATE_TARGET_95_VALUE = Assessment.SUA_LOGISTIC_RATE_TARGET_95_VALUE
                .SUA_LOGISTIC_RATE_TARGET_95_POINT = Assessment.SUA_LOGISTIC_RATE_TARGET_95_POINT
                .SUA_FLEXIBILITY_POINT = Assessment.SUA_FLEXIBILITY_POINT
                .SUA_DELIVERY_DELAYS_LEVEL_VALUE = Assessment.SUA_DELIVERY_DELAYS_LEVEL_VALUE
                .SUA_DELIVERY_DELAYS_LEVEL_POINT = Assessment.SUA_DELIVERY_DELAYS_LEVEL_POINT
                .SUA_DELIVERY_QUALITY_VALUE = Assessment.SUA_DELIVERY_QUALITY_VALUE
                .SUA_DELIVERY_QUALITY_POINT = Assessment.SUA_DELIVERY_QUALITY_POINT
                .SUA_PRICE_COMPETITIVENESS_VALUE = Assessment.SUA_PRICE_COMPETITIVENESS_VALUE
                .SUA_PRICE_COMPETITIVENESS_POINT = Assessment.SUA_PRICE_COMPETITIVENESS_POINT
                .SUA_IMPROVMENT_PLAN_POINT = Assessment.SUA_IMPROVMENT_PLAN_POINT
                .SUA_BUSINESS_RELATIONSHIP_POINT = Assessment.SUA_BUSINESS_RELATIONSHIP_POINT
                .SUA_FINANCIAL_SITUATION_POINT = Assessment.SUA_FINANCIAL_SITUATION_POINT
                .SUA_OFFERS_REACTIVITY_POINT = Assessment.SUA_OFFERS_REACTIVITY_POINT
                .SUA_TECHNICAL_ANSWER_QUALITY_POINT = Assessment.SUA_TECHNICAL_ANSWER_QUALITY_POINT
                .SUA_ISO_CERTFICATION_POINT = Assessment.SUA_ISO_CERTFICATION_POINT
                .SUA_COMMENT = Assessment.SUA_COMMENT
                .SUA_COMMENT_CLASSIFICATION = Assessment.SUA_COMMENT_CLASSIFICATION
                .SUA_COMMENT_DETAIL = Assessment.SUA_COMMENT_DETAIL
                .SUA_COMMENT_GLOBAL = Assessment.SUA_COMMENT_GLOBAL
                .SUA_TOTAL_POINT = Assessment.SUA_TOTAL_POINT
                .SUA_TREND = Assessment.SUA_TREND
                .SUA_QUALITY_IMPROVEMENT_PLAN = Assessment.SUA_QUALITY_IMPROVEMENT_PLAN
                .SUA_LOGISTIC_IMPROVEMENT_PLAN = Assessment.SUA_LOGISTIC_IMPROVEMENT_PLAN
            End With
            BaseSupplierAssessment.SubmitChanges()

            System.Diagnostics.Trace.WriteLine(Now + " | " + " Assessement UPDATE : " + Assessment.ToString, Me.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Recherche un score dans la liste des scores
    ''' </summary>
    ''' <param name="Id">identifient du score</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function recherche(Id As Integer) As T_SUP_ASSESSMENT_SUA_COMMON
        Try
            Dim trouverAssessment = From unAssessment In BaseSupplierAssessment.T_SUP_ASSESSMENT_SUA_COMMON
            Where unAssessment.SUA_ID = Id
                              Select unAssessment
            If trouverAssessment.Any Then
                Return trouverAssessment.First
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Recherche un score dans la liste des scores
    ''' </summary>
    ''' <param name="IdSupplier">Identificateur du fournisseur</param>
    ''' <param name="quarter">Numéro du trimestre</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function recherche(IdSupplier As Integer, quarter As Integer) As T_SUP_ASSESSMENT_SUA_COMMON
        Try
            Dim trouverAssessment = From unAssessment In BaseSupplierAssessment.T_SUP_ASSESSMENT_SUA_COMMON
                                Where unAssessment.SUP_ID = IdSupplier And unAssessment.SUA_QUARTER = quarter
                               Select unAssessment
            If trouverAssessment.Any Then
                System.Diagnostics.Trace.WriteLine(trouverAssessment.First)
                Return trouverAssessment.First
            Else
                System.Diagnostics.Trace.WriteLine("Rien trouvé")
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
            System.Diagnostics.Trace.WriteLine(ex)
        End Try
    End Function
    ''' <summary>
    ''' Supprimer un assessment
    ''' </summary>
    ''' <param name="Assessment">Assessment à supprimer</param>
    ''' <remarks></remarks>
    Public Sub delete(Assessment As T_SUP_ASSESSMENT_SUA_COMMON)
        Try
            If Not IsNothing(Assessment) Then
                Dim SupprimerAssessment = From unAssessment In BaseSupplierAssessment.T_SUP_ASSESSMENT_SUA_COMMON
                                                                Where unAssessment.SUA_ID = Assessment.SUA_ID
                                                                Select unAssessment

                For Each unAssessment In SupprimerAssessment
                    BaseSupplierAssessment.T_SUP_ASSESSMENT_SUA_COMMON.DeleteOnSubmit(unAssessment)
                Next
                BaseSupplierAssessment.SubmitChanges()
                System.Diagnostics.Trace.WriteLine(Now + " | " + " Assessement DELETE : " + Assessment.ToString, Me.ToString)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
End Class
