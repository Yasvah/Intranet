Imports System.IO

Public Class FileLogin
    Public Shared Sub AjouterLog(UserName As String, Message As String)
        Dim TextMessage As String
        TextMessage = "*************" & Now.ToString & "*************" & vbNewLine
        TextMessage = TextMessage & "UserName : " & UserName & vbNewLine
        TextMessage = TextMessage & Message & vbNewLine
        EcrireFichier(TextMessage)

    End Sub

    Private Shared Sub EcrireFichier(Message As String)
        Try
            Dim monStreamWriter As StreamWriter = New StreamWriter("..\log.txt", True)
            monStreamWriter.WriteLine(Message)
            monStreamWriter.Close()
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

End Class
