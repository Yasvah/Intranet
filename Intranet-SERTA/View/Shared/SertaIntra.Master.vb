Imports System.Globalization
Imports System.Threading
Public Class SertaIntra
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Public Function Menu() As String
        Dim nodesitemap As SiteMapNodeCollection
        Dim label As String = "<ul> <li><a href='" + SiteMap.RootNode.Url + "'><span>" + SiteMap.RootNode.Title + "</span></a></li>"

        nodesitemap = SiteMap.RootNode.ChildNodes

        Dim position As Integer = 0
        For Each node As SiteMapNode In nodesitemap
            If position = nodesitemap.Count - 1 And Not node.HasChildNodes Then
                label = label + "<li class='last'> <a href='" + node.Url + "'><span> " + node.Title
                If node.HasChildNodes Then
                    label = label + unelisterenfant(node.ChildNodes)
                End If
            Else
                label = label + "<li " + quelClass(node) + "> <a href='" + node.Url + "'><span> " + node.Title + "</span></a>"
                If node.HasChildNodes Then
                    label = label + unelisterenfant(node.ChildNodes)
                End If
                label = label + "</li>"
            End If
            position = position + 1
        Next
        label = label + " </ul>"

        Return label

    End Function


    Function unelisterenfant(listEnfant As SiteMapNodeCollection) As String
        Dim label As String = "<ul>"
        Dim position As Integer = 0
        For Each node As SiteMapNode In listEnfant
            If position = listEnfant.Count - 1 And Not node.HasChildNodes Then
                label = label + "<li class='last'> <a href='" + node.Url + "'><span> " + node.Title + "</span></a>"
                If node.HasChildNodes Then
                    label = label + unelisterenfant(node.ChildNodes)
                End If
                label = label + "</li>"
            Else
                label = label + "<li " + quelClass(node) + "> <a href='" + node.Url + "'><span> " + node.Title + "</span></a>"
                If node.HasChildNodes Then
                    label = label + unelisterenfant(node.ChildNodes)
                End If
                label = label + "</li>"
            End If
            position = position + 1
        Next
        label = label + " </ul>"
        Return label
    End Function

    Private Function quelClass(node As SiteMapNode) As String
        If node.HasChildNodes Then
            Return "class='has-sub'"
        Else
            Return ""
        End If
    End Function



End Class