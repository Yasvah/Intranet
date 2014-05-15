Imports System.Data.SqlClient
Imports System.Data

Public Class DALClient
    Public Function charger() As List(Of Client)
        Dim listClient As New List(Of Client)
        Dim Requete As String = "SELECT CLI_ID, CLI_CODE, CLI_NOM , GCL_ID FROM VENTE.T_CLIENT_CLI"
        Dim Commande As New SqlCommand(Requete, connexion)
        connexion().Open()
        Dim lesResultats As SqlDataReader = Commande.ExecuteReader()
        While lesResultats.Read
            Dim id As Integer
            Dim code As Integer
            Dim nom As String
            Dim idGroupe As Integer
            id = CInt(lesResultats.GetInt16(0))
            code = CInt(lesResultats.GetString(1))
            nom = lesResultats.GetString(2).ToString
            If lesResultats.IsDBNull(3) Then
                idGroupe = Nothing
            Else
                idGroupe = lesResultats.GetInt32(3)
            End If
            listClient.Add(New Client(id, code, nom, MgtGroupeClient.getInstance.rechercher(idGroupe)))
        End While
        Return listClient
    End Function
    ''' <summary>
    ''' Fonction nom implémenter car les clients sont créer dans baan.
    ''' </summary>
    ''' <param name="client"></param>
    ''' <remarks></remarks>
    Public Sub ajouter(client As Client)

    End Sub
    ''' <summary>
    ''' Mettre à jour un client
    ''' </summary>
    ''' <param name="client">le client à jour</param>
    ''' <remarks></remarks>
    Public Sub update(client As Client)
        Try
            Dim commande As IDbCommand = Me.connexion.CreateCommand()
            commande.CommandText = "UPDATE VENTE.T_CLIENT_CLI SET " &
                "GCL_ID = @groupe_id" &
                " WHERE CLI_ID = @client_id"

            creerParametre(commande, "groupe_id", client.groupeClient.id)
            creerParametre(commande, "client_id", client.id)

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

    Private _ctn As IDbConnection = New SqlConnection("Data Source=W08R2-UPDATE\RYBACK;Initial Catalog=DW;User Id=sa;Password=casey;")

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

