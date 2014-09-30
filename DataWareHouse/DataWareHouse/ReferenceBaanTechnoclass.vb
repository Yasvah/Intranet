Imports System.Configuration

Partial Class ReferenceBaanTechnoclassDataContext

    Public Sub New()
        'Configuration de la chaine de connexion sur le fichier web.config
        MyBase.New(System.Configuration.ConfigurationManager.ConnectionStrings("DWConnectionString").ConnectionString)
        OnCreated()
    End Sub
End Class

