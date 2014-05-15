Public Class MgtGroupeClient

#Region "Attribut"
    Private _listGroupeClient As New List(Of GroupeClient)
#End Region
#Region "Propriété"
    Public Property listGroupeClient As List(Of GroupeClient)
        Get
            Return _listGroupeClient
        End Get
        Set(value As List(Of GroupeClient))
            _listGroupeClient = value
        End Set
    End Property
#End Region


#Region "Méthode"
    Public Sub charger()
        listGroupeClient.Clear()
        Dim dalGroupeClient As New DALGroupeClient
        listGroupeClient = dalGroupeClient.charger
    End Sub

    Public Sub ajouter(nomGroupe As String)
        Dim newGroupe As GroupeClient = New GroupeClient(nomGroupe)
        Dim dalGroupeClient As DALGroupeClient = New DALGroupeClient()
        listGroupeClient.Add(newGroupe)
        dalGroupeClient.ajouter(newGroupe)
        charger()
    End Sub

    Public Overloads Function rechercher(nomGroupe As String) As GroupeClient
        Dim GroupeClient As GroupeClient
        GroupeClient = listGroupeClient.Find(Function(unGroupe As GroupeClient) unGroupe.nomGroupe = nomGroupe)
        Return GroupeClient
    End Function
    Public Overloads Function rechercher(identificateur As Integer) As GroupeClient
        Dim GroupeClient As GroupeClient
        GroupeClient = listGroupeClient.Find(Function(unGroupe As GroupeClient) unGroupe.id = identificateur)
        Return GroupeClient
    End Function

#End Region
#Region "Constructeur"
    Private Shared _instance As New MgtGroupeClient()

    Private Sub New()
        charger()
    End Sub

    Public Shared Function getInstance() As MgtGroupeClient
        Return _instance
    End Function
#End Region

End Class

