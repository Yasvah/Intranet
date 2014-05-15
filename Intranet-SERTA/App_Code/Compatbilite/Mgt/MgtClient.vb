Public Class MgtClient
#Region "Attribut"
    Private _listClient As New List(Of Client)
#End Region
#Region "Propriété"
    Public Property listClient As List(Of Client)
        Get
            Return _listClient
        End Get
        Set(value As List(Of Client))
            _listClient = value
        End Set
    End Property
#End Region

#Region "Constructeur"
    Private Shared _instance As New MgtClient()

    Private Sub New()
        charger()
    End Sub

    Public Shared Function getInstance() As MgtClient
        Return _instance
    End Function
#End Region
#Region "Méthode"


    Public Sub charger()
        listClient.Clear()
        Dim dalClient As New DALClient
        listClient = dalClient.charger
    End Sub
    Public Sub update(client As Client)
        Dim DalClient As DALClient = New DALClient()
        DalClient.update(client)
    End Sub

    Public Function recherche(identificateur As Integer) As Client
        Dim ClientRecherche As Client
        ClientRecherche = listClient.Find(Function(unClient As Client) unClient.id = identificateur)
        Return ClientRecherche
    End Function
#End Region
End Class
