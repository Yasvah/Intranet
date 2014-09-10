Imports System.Data.SqlClient
Imports System.Data

Public Class DALGroupeClient
    Public Function charger() As List(Of GroupeClient)
        Dim listClient As New List(Of GroupeClient)
        Dim Requete As String = "SELECT GCL_ID, GCL_NOM_GROUPE FROM VENTE.T_GROUPE_CLIENT_GCL ORDER BY GCL_NOM_GROUPE "
        Dim Commande As New SqlCommand(Requete, connexion)
        connexion.Open()
        Dim lesResultats As SqlDataReader = Commande.ExecuteReader()
        While lesResultats.Read
            Dim id As Integer
            Dim nom As String
            id = CInt(lesResultats.GetInt32(0))
            nom = lesResultats.GetString(1).ToString
            listClient.Add(New GroupeClient(id, nom))
        End While
        Return listClient
    End Function
    ''' <summary>
    ''' Permet d'ajouter un groupe client
    ''' </summary>
    ''' <param name="groupeClient"></param>
    ''' <remarks></remarks>
    Public Sub ajouter(groupeClient As GroupeClient)
        Try
            Dim commande As IDbCommand = Me.connexion.CreateCommand()
            commande.CommandText = "INSERT INTO VENTE.T_GROUPE_CLIENT_GCL (" &
                "GCL_NOM_GROUPE" &
                " )" &
                "VALUES ( @nomGroupe" &
                " )"
            creerParametre(commande, "nomGroupe", groupeClient.nomGroupe)
            connexion().Open()
            commande.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            If Me.connexion.State <> ConnectionState.Closed AndAlso
                   Me.connexion.State <> ConnectionState.Broken Then
                Me.connexion.Close()
            End If
        End Try

    End Sub
    ''' <summary>
    ''' Non implémenter
    ''' </summary>
    ''' <param name="GroupeClient"></param>
    ''' <remarks></remarks>
    Private Sub update(GroupeClient As GroupeClient)

    End Sub

    Private _ctn As IDbConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DWConnectionString").ConnectionString)

    Public ReadOnly Property connexion() As IDbConnection
        Get
            Return _ctn
        End Get
    End Property

    ''' <summary>
    ''' Permet de créer un parametre SQL
    ''' </summary>
    ''' <param name="commande">La commande de la requete SQL</param>
    ''' <param name="nom">Nom du parametre</param>
    ''' <param name="valeur">Sa valeur</param>
    ''' <param name="type">Le type SQL</param>
    ''' <param name="taille"></param>
    ''' <remarks></remarks>
    Private Sub creerParametre(ByVal commande As IDbCommand,
                                      ByVal nom As String,
                                      ByVal valeur As Object,
                                      Optional ByVal type As DbType = DbType.String,
                                      Optional ByVal taille As Integer = Nothing)
        Dim param As IDbDataParameter = commande.CreateParameter()
        param.ParameterName = "@" & nom
        param.Value = valeur
        param.DbType = type
        If taille <> Nothing Then
            param.Size = taille
        End If
        commande.Parameters.Add(param)
    End Sub
End Class

