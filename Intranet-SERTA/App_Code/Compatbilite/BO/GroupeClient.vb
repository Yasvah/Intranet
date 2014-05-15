Public Class GroupeClient

#Region "Attribut"
    Private _id As Integer
    Private _nomGroupe As String
#End Region

#Region "Propriété"
    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property
    Public Property nomGroupe As String
        Get
            Return _nomGroupe
        End Get
        Set(value As String)
            _nomGroupe = value
        End Set
    End Property
#End Region


    Sub New(id As Integer, nomGroupe As String)
        Me.id = id
        Me.nomGroupe = nomGroupe
    End Sub

    Sub New(nomGroup As String)
        Me._nomGroupe = nomGroup
    End Sub
End Class
