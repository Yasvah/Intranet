Public Class Client
#Region "Attribut"
    Private _id As Integer
    Private _code As Integer
    Private _nom As String
    Private _groupeClient As GroupeClient

#End Region
#Region "Propriété"
    Public ReadOnly Property id As Integer
        Get
            Return _id
        End Get
    End Property
    Public Property code As Integer
        Get
            Return _code
        End Get
        Set(value As Integer)
            _code = value
        End Set
    End Property
    Public Property nom As String
        Get
            Return _nom
        End Get
        Set(value As String)
            _nom = value
        End Set
    End Property
    Public Property groupeClient As GroupeClient
        Get
            Return _groupeClient
        End Get
        Set(value As GroupeClient)
            _groupeClient = value
        End Set
    End Property
#End Region
    Public ReadOnly Property nomGroupe As String
        Get
            If IsNothing(groupeClient) Then
                Return ""
            Else
                Return groupeClient.nomGroupe.ToString()
            End If
        End Get
    End Property

    Sub New(id As Integer, code As Integer, nom As String, Optional groupeClient As GroupeClient = Nothing)
        Me._id = id
        Me.code = code
        Me.nom = nom
        Me.groupeClient = groupeClient
    End Sub
End Class
