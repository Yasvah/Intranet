Public Class MgtLinkSERTAPNS
#Region "Attribut"
    Friend db As New ReferenceBaanTechnoclassDataContext
#End Region

#Region "Property"
    ''' <summary>
    ''' List des nouvelle jointure à faire
    ''' </summary>
    ''' <remarks></remarks>
    Private _ListLinkSERTAPNS As List(Of LinkSERTAPNS)
    Public Property ListLinkSERTAPNS() As List(Of LinkSERTAPNS)
        Get
            Return _ListLinkSERTAPNS
        End Get
        Set(ByVal value As List(Of LinkSERTAPNS))
            _ListLinkSERTAPNS = value
        End Set
    End Property
    Private _ListLink As List(Of T_J_ART_ARP_JAA)
    Public Property ListLink() As List(Of T_J_ART_ARP_JAA)
        Get
            Return _ListLink
        End Get
        Set(ByVal value As List(Of T_J_ART_ARP_JAA))
            _ListLink = value
        End Set
    End Property
    Private _ListLinkPurge As List(Of T_J_ART_ARP_JAA)
    Public Property ListLinkPurge() As List(Of T_J_ART_ARP_JAA)
        Get
            Return _ListLinkPurge
        End Get
        Set(ByVal value As List(Of T_J_ART_ARP_JAA))
            _ListLinkPurge = value
        End Set
    End Property


#End Region

    ''' <summary>
    ''' Ajouter une correspondance dans la base de donnee
    ''' </summary>
    ''' <param name="RefSERTA"></param>
    ''' <param name="RefPNS"></param>
    ''' <param name="Statut"></param>
    ''' <param name="Source"></param>
    ''' <remarks></remarks>
    Sub Add(RefSERTA As String, RefPNS As String, Statut As Statut, Source As Source)
        Try
            Dim NewLink As New T_J_ART_ARP_JAA
            Dim SERTAItem As T_ARTICLE_ART = (From item In db.T_ARTICLE_ART
                                             Where item.ART_REFERENCE = RefSERTA
                                             Select item).First
            Dim PNSItem As T_ARTICLE_ARP = (From item In db.T_ARTICLE_ARP
                                           Where item.ARP_REFERENCE = RefPNS
                                           Select item).First

            With NewLink
                .T_ARTICLE_ART = SERTAItem
                .T_ARTICLE_ARP = PNSItem
                .JST_ID = Statut
                .JSR_ID = Source
                .JAA_DATE_CREATION = Now
                .JAA_DATE_MAJ = Now
            End With
            db.SubmitChanges()
            ListLinkSERTAPNS.Remove(Find(SERTAItem.ART_ID, PNSItem.ARP_ID))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Mettre à jour une correspondance
    ''' </summary>
    ''' <param name="Link"></param>
    ''' <remarks></remarks>
    Overloads Sub Update(Link As T_J_ART_ARP_JAA)
        Try
            Dim updateLink As T_J_ART_ARP_JAA = (From linkUpdate In db.T_J_ART_ARP_JAA
                                                 Where linkUpdate.ART_ID = Link.ART_ID And linkUpdate.ARP_ID = Link.ARP_ID
                                                 Select linkUpdate).First

            With updateLink
                .JST_ID = Link.JST_ID
                .JSR_ID = Link.JSR_ID
                .JAA_DATE_MAJ = Now
            End With
            db.SubmitChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Overloads Sub Update(RefSERTA As String, RefPNS As String, Statut As Integer)
        Try
            Dim updateLink As T_J_ART_ARP_JAA = (From linkUpdate In ListLink
                                                 Where linkUpdate.T_ARTICLE_ART.ART_REFERENCE = RefSERTA And linkUpdate.T_ARTICLE_ARP.ARP_REFERENCE = RefPNS
                                                 Select linkUpdate).First

            With updateLink
                'Il faut assignié l'entité et nom l'JST_ID directement
                .T_STATUT_JAA_JST = db.T_STATUT_JAA_JST.Single(Function(a) a.JST_ID = Statut)
                .JAA_DATE_MAJ = Now
            End With
            db.SubmitChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Supprimer une correspondance
    ''' </summary>
    ''' <param name="Link"></param>
    ''' <remarks></remarks>
    Overloads Sub Delete(Link As T_J_ART_ARP_JAA)
        Try
            Dim DeleteLink As List(Of T_J_ART_ARP_JAA) = (From linkUpdate In ListLinkPurge
                                         Where linkUpdate.ART_ID = Link.ART_ID And linkUpdate.ARP_ID = Link.ARP_ID
                                         Select linkUpdate).ToList
            db.T_J_ART_ARP_JAA.DeleteAllOnSubmit(DeleteLink)
            db.SubmitChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Overloads Sub Delete(JAA_ID As Integer)
        Try
            Dim DeleteLink As T_J_ART_ARP_JAA = (From linkUpdate In ListLinkPurge
                                         Where linkUpdate.JAA_ID = JAA_ID
                                         Select linkUpdate).First
            db.T_J_ART_ARP_JAA.DeleteOnSubmit(DeleteLink)
            ListLinkPurge.Remove(DeleteLink)
            db.SubmitChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Liste des nouvelle correspondance à valider
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function NewLinkList() As List(Of LinkSERTAPNS)
        Dim result As New List(Of LinkSERTAPNS)
        Dim query
        Try
            query = db.ExecuteQuery(Of Tmp)("SELECT T1.ART_ID, T3.ARP_ID, 1 AS Source " & _
                                            "FROM PRODUCTION.T_ARTICLE_ART T1 " & _
                                            "INNER JOIN ACHAT.T_REFERENCES_FOB_RFO T2 ON T1.ART_ID = T2.ART_ID AND T2.FOB_ID = 404 " & _
                                            "INNER JOIN PRODUCTION_PNS.T_ARTICLE_ARP T3 ON T3.ARP_REFERENCE = T2.RFO_REFERENCE " & _
                                            "LEFT JOIN PRODUCTION_PNS.T_J_ART_ARP_JAA T4 ON T4.ARP_ID = T3.ARP_ID AND T4.ART_ID =T1.ART_ID " & _
                                            "WHERE T4.JAA_ID Is NULL " & _
                                            "UNION " & _
                                            "SELECT T5.ART_ID, T4.ARP_ID, 2 AS Source " & _
                                            "FROM PRODUCTION_PNS.T_ARTICLE_ARP T4 " & _
                                            "INNER JOIN PRODUCTION.T_ARTICLE_ART T5 ON T4.ARP_REFERENCE_SERTA = T5.ART_REFERENCE " & _
                                            "LEFT JOIN PRODUCTION_PNS.T_J_ART_ARP_JAA T6 ON T6.ARP_ID = T4.ARP_ID AND T6.ART_ID = T5.ART_ID " & _
                                            "WHERE T6.JAA_ID IS NULL AND NOT EXISTS ( " & _
                                                                            "SELECT * " & _
                                                                            "FROM PRODUCTION.T_ARTICLE_ART T10 " & _
                                                                            "INNER JOIN ACHAT.T_REFERENCES_FOB_RFO T20 ON T10.ART_ID = T20.ART_ID AND T20.FOB_ID = 404 " & _
                                                                            "INNER JOIN PRODUCTION_PNS.T_ARTICLE_ARP T30 ON T30.ARP_REFERENCE = T20.RFO_REFERENCE " & _
                                                                            "LEFT JOIN PRODUCTION_PNS.T_J_ART_ARP_JAA T40 ON T40.ARP_ID = T30.ARP_ID AND T40.ART_ID =T10.ART_ID " & _
                                            "WHERE T40.JAA_ID Is NULL And T10.ART_ID = T5.ART_ID And T30.ARP_ID = T4.ARP_ID) ")


            For Each row In query
                result.Add(New LinkSERTAPNS(row.ART_ID, row.ARP_ID, row.Source, Statut.Secondiare))
            Next
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Overloads Function Find(ART_ID As Integer, ARP_ID As Integer) As LinkSERTAPNS
        Return ListLinkSERTAPNS.Find(Function(a) a.PNS = ARP_ID And a.SERTA = ART_ID)
    End Function
    ''' <summary>
    ''' Recherche une correspondance
    ''' </summary>
    ''' <param name="RefSERTA"></param>
    ''' <param name="RefPNS"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Find(RefSERTA As String, RefPNS As String) As List(Of T_J_ART_ARP_JAA)
        Dim ListFind As List(Of T_J_ART_ARP_JAA)
        Try
            ListFind = ListLink

            If RefSERTA IsNot Nothing And RefSERTA <> "" Then
                ListFind = (From Element In ListLink
                   Where Element.T_ARTICLE_ART.ART_REFERENCE = RefSERTA
                   Select Element).ToList
            End If

            If RefPNS IsNot Nothing And RefPNS <> "" Then
                ListFind = (From Element In ListFind
                   Where Element.T_ARTICLE_ARP.ARP_REFERENCE = RefPNS
                   Select Element).ToList
            End If

            Return ListFind
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function LoadListLink() As List(Of T_J_ART_ARP_JAA)
        Return (From Element In db.T_J_ART_ARP_JAA
               Select Element).ToList
    End Function
    Private Function LoadListLinkPurge() As List(Of T_J_ART_ARP_JAA)
        Dim result As New List(Of T_J_ART_ARP_JAA)
        Try
            result = (db.ExecuteQuery(Of T_J_ART_ARP_JAA)("SELECT JAA_ID, T1.ART_ID, T1.ARP_ID, T1.JST_ID, T1.JSR_ID, T1.JAA_DATE_CREATION, T1.JAA_DATE_MAJ " & _
                                            "FROM PRODUCTION_PNS.T_J_ART_ARP_JAA T1 " & _
                                            "INNER JOIN PRODUCTION.T_ARTICLE_ART T2 ON T1.ART_ID = T2.ART_ID " & _
                                            "INNER JOIN ACHAT.T_REFERENCES_FOB_RFO T3 ON T3.ART_ID = T2.ART_ID AND T3.FOB_ID = 404 " & _
                                            "INNER JOIN PRODUCTION_PNS.T_ARTICLE_ARP T4 ON T1.ARP_ID =T4.ARP_ID " & _
                                            "WHERE (T3.RFO_REFERENCE <> T4.ARP_REFERENCE AND JSR_ID = 1) OR (T4.ARP_REFERENCE_SERTA <> T2.ART_REFERENCE AND JSR_ID = 2)")).ToList
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Sub refresh()
        ListLinkSERTAPNS = NewLinkList()
        ListLink = LoadListLink()
        ListLinkPurge = LoadListLinkPurge()
    End Sub
#Region "Enumeration"
    Enum Statut
        Primaire = 1
        Secondiare = 2
    End Enum

    Enum Source
        SERTA = 1
        PNS = 2
    End Enum
#End Region

#Region "constructeur"
    Private Shared _instance As New MgtLinkSERTAPNS()

    Private Sub New()
        ListLinkSERTAPNS = NewLinkList()
        ListLink = LoadListLink()
        ListLinkPurge = LoadListLinkPurge()
    End Sub

    Public Shared Function getInstance() As MgtLinkSERTAPNS
        Return _instance
    End Function
#End Region
#Region "LinkSERTAPNS"
    Class LinkSERTAPNS
        Private db As New ReferenceBaanTechnoclassDataContext
        Private _source As Source
        Public Property source() As Source
            Get
                Return _source
            End Get
            Set(ByVal value As Source)
                _source = value
            End Set
        End Property
        Private _statut As Statut
        Public Property statut() As Statut
            Get
                Return _statut
            End Get
            Set(ByVal value As Statut)
                _statut = value
            End Set
        End Property

        Private _serta As Integer
        Public Property SERTA() As Integer
            Get
                Return _serta
            End Get
            Set(ByVal value As Integer)
                _T_ARTICLE_ART = (From item In db.T_ARTICLE_ART
                                 Where item.ART_ID = value
                                 Select item).First
                _serta = value
            End Set
        End Property
        Private _pns As Integer
        Public Property PNS() As Integer
            Get
                Return _pns
            End Get
            Set(ByVal value As Integer)
                _T_ARTICLE_ARP = (From item In db.T_ARTICLE_ARP
                                 Where item.ARP_ID = value
                                 Select item).First
                _pns = value
            End Set
        End Property

        Private _T_ARTICLE_ARP As T_ARTICLE_ARP
        Public ReadOnly Property T_ARTICLE_ARP() As T_ARTICLE_ARP
            Get
                Return _T_ARTICLE_ARP
            End Get
        End Property
        Private _T_ARTICLE_ART As T_ARTICLE_ART
        Public ReadOnly Property T_ARTICLE_ART() As T_ARTICLE_ART
            Get
                Return _T_ARTICLE_ART
            End Get
        End Property
        Sub New(SERTA As Integer, PNS As Integer, source As Source, statut As Statut)
            Me.PNS = PNS
            Me.SERTA = SERTA
            Me.source = source
        End Sub
    End Class
#End Region
    Private Class Tmp
        Private _ART_ID As Integer
        Public Property ART_ID() As Integer
            Get
                Return _ART_ID
            End Get
            Set(ByVal value As Integer)
                _ART_ID = value
            End Set
        End Property
        Private _ARP_ID As Integer
        Public Property ARP_ID() As Integer
            Get
                Return _ARP_ID
            End Get
            Set(ByVal value As Integer)
                _ARP_ID = value
            End Set
        End Property
        Private _source As Source
        Public Property Source() As Source
            Get
                Return _source
            End Get
            Set(ByVal value As Source)
                _source = value
            End Set
        End Property


    End Class
End Class

