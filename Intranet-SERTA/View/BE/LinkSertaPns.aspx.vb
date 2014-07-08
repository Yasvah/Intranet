Imports DataWareHouse
Public Class LinkSertaPns
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MgtLinkSERTAPNS.getInstance.refresh()
            DataGridViewUpdate = MgtLinkSERTAPNS.getInstance.ListLink
            loadGrid()
        End If
    End Sub

    Public Property DataGridViewUpdate() As List(Of T_J_ART_ARP_JAA)
        Get
            Return Session.Item("DataSourceGridViewUpdate")
        End Get
        Set(ByVal value As List(Of T_J_ART_ARP_JAA))
            Session.Item("DataSourceGridViewUpdate") = value
        End Set
    End Property

    ''' <summary>
    ''' Event sur le click du button Ok pour ajouter dans la base de donnee
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub lnkBtn_Command(sender As Object, e As CommandEventArgs)
        'Button ----------> GridView Cell ----------> GridView Row
        Dim gvRow As GridViewRow = CType(sender, Control).Parent.Parent
        Dim DropDownList As DropDownList = gvRow.FindControl("DropBoxStatut")
        Dim SelectedValues As String = DropDownList.SelectedValue


        Dim CommandArgument As String() = e.CommandArgument.Split(",")
        Dim CommandArgumentSERTA As String = CommandArgument(0)
        Dim CommandArgumentPNS As String = CommandArgument(1)
        Dim CommandArgumentSource As String = CommandArgument(2)

        MgtLinkSERTAPNS.getInstance.Add(CommandArgumentSERTA, CommandArgumentPNS, SelectedValues, CommandArgumentSource)
        loadGrid()
    End Sub

    'Gestion de la pagination.
    Protected Sub Table_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        sender.PageIndex = e.NewPageIndex
        loadGrid()
    End Sub

    ''' <summary>
    ''' Charge la gridView Table
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadGrid()
        MgtLinkSERTAPNS.getInstance.ListLinkSERTAPNS.OrderBy(Function(o) o.source)
        GridViewNew.DataSource = MgtLinkSERTAPNS.getInstance.ListLinkSERTAPNS
        GridViewNew.DataBind()
        If MgtLinkSERTAPNS.getInstance.ListLinkSERTAPNS.Count = 0 Then
            lblMessageNewLink.Visible = True
        Else
            lblMessageNewLink.Visible = False
        End If

        GridViewUpdate.DataSource = DataGridViewUpdate
        GridViewUpdate.DataBind()

        GridViewPurge.DataSource = MgtLinkSERTAPNS.getInstance.ListLinkPurge
        GridViewPurge.DataBind()
        If MgtLinkSERTAPNS.getInstance.ListLinkPurge.Count = 0 Then
            lblMessagePurge.Visible = True
        Else
            lblMessagePurge.Visible = False
        End If
    End Sub

    'Attribut la la value a dropListStatut
    Protected Sub Table_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewNew.RowDataBound
        Dim dropListStatut As DropDownList = e.Row.FindControl("DropBoxStatut")
        If Not IsNothing(dropListStatut) Then
            dropListStatut.SelectedValue = CType(e.Row.DataItem, MgtLinkSERTAPNS.LinkSERTAPNS).source
        End If
    End Sub


    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click
        DataGridViewUpdate = MgtLinkSERTAPNS.getInstance.Find(TextBoxFindRefSERTA.Text, TextBoxFindRefPNS.Text)
        GridViewUpdate.DataSource = DataGridViewUpdate
        GridViewUpdate.DataBind()
    End Sub

    Protected Sub EditGridViewUpdate(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles GridViewUpdate.RowEditing
        GridViewUpdate.EditIndex = e.NewEditIndex
        GridViewUpdate.DataSource = DataGridViewUpdate
        GridViewUpdate.DataBind()
    End Sub
    Protected Sub CancelEditGridViewUpdate(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs) Handles GridViewUpdate.RowCancelingEdit
        GridViewUpdate.EditIndex = -1
        GridViewUpdate.DataSource = DataGridViewUpdate
        GridViewUpdate.DataBind()
    End Sub

    Private Sub UpdateGridViewUpdate(sender As Object, e As GridViewUpdateEventArgs) Handles GridViewUpdate.RowUpdating
        Dim Statut As Integer = DirectCast(GridViewUpdate.Rows(e.RowIndex).FindControl("DropBoxStatut"), DropDownList).SelectedValue
        Dim RefSERTA As String = GridViewUpdate.Rows(e.RowIndex).Cells(0).Text
        Dim RefPNS As String = GridViewUpdate.Rows(e.RowIndex).Cells(1).Text

        MgtLinkSERTAPNS.getInstance.Update(RefSERTA, RefPNS, Statut)
        GridViewUpdate.EditIndex = -1
        GridViewUpdate.DataSource = MgtLinkSERTAPNS.getInstance.Find(TextBoxFindRefSERTA.Text, TextBoxFindRefPNS.Text)
        GridViewUpdate.DataBind()

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As CommandEventArgs)
        MgtLinkSERTAPNS.getInstance.Delete(e.CommandArgument)
        loadGrid()
    End Sub
End Class