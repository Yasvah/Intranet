Public Class CompabiliteFormulaire
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            fillGrid()
        End If

    End Sub


    'Charge les donnée dans la GridView
    Private Sub fillGrid()
        Tableau.DataSource = MgtClient.getInstance.listClient
        Tableau.DataBind()
    End Sub

    Protected Sub Tableau_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles Tableau.RowDataBound
        Dim droplistgroupeclient As DropDownList = e.Row.FindControl("NewGroupe")

        If Not IsNothing(droplistgroupeclient) Then

            droplistgroupeclient.DataSource = MgtGroupeClient.getInstance.listGroupeClient
            droplistgroupeclient.DataTextField = "nomGroupe"
            droplistgroupeclient.DataValueField = "id"
            droplistgroupeclient.DataBind()
            '  droplistgroupeclient.SelectedValue =  droplistgroupeclient.DataKeys[e.Row.RowIndex].Values[1].ToString();
        End If
    End Sub

    Protected Sub Tableau_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles Tableau.RowEditing
        Tableau.EditIndex = e.NewEditIndex
        fillGrid()
    End Sub

    Protected Sub Tableau_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles Tableau.RowCancelingEdit
        Tableau.EditIndex = -1
        fillGrid()
    End Sub

    Protected Sub Tableau_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles Tableau.RowUpdating
        Dim droplistgroupeclient As DropDownList = Tableau.Rows(e.RowIndex).FindControl("NewGroupe")
        Dim labelid As Label = Tableau.Rows(e.RowIndex).FindControl("Label1")
        Dim UpdateClient As Client = MgtClient.getInstance.recherche(CInt(labelid.Text))
        UpdateClient.groupeClient = MgtGroupeClient.getInstance.rechercher(CInt(droplistgroupeclient.SelectedItem.Value))
        MgtClient.getInstance.update(UpdateClient)
        Tableau.EditIndex = -1
        fillGrid()
    End Sub

    Protected Sub btnAjouterGroupe_Click(sender As Object, e As EventArgs)
        MgtGroupeClient.getInstance.ajouter(txtboxNomGroupe.Text)
        txtboxNomGroupe.Text = ""
    End Sub
End Class