Imports System.IO
Imports Newtonsoft.Json

Public Class CustomTagsForm
    Private Sub AssetFolderTextBox_LostFocus(sender As Object, e As EventArgs) Handles AssetFolderTextBox.LostFocus
        Dim AssetFolder As String
        Dim IsFolderNameValid As Boolean
        Dim DoesFolderExist As Boolean

        AssetFolder = AssetFolderTextBox.Text
        AssetFolder = AssetFolder.TrimEnd("\")
        IsFolderNameValid = IsValidPathName(AssetFolder)
        DoesFolderExist = Directory.Exists(AssetFolder)

        If IsFolderNameValid And DoesFolderExist Then
            GlobalVariables.TagObject = GetTagInfo(AssetFolder)
            Dim TagInfo = GlobalVariables.TagObject
            RefreshLists()
            AddTagSetTextBox.Enabled = True
            AddTagSetButton.Enabled = True
            TagSetListBox.Enabled = True
        Else
            MsgBox("Invalid folder name or folder does not exist.")
        End If
    End Sub

    Private Sub AssetFolderBrowwseButton_Click(sender As Object, e As EventArgs) Handles AssetFolderBrowseButton.Click
        AssetFolderTextBox.Text = ""
        AssetFolderBrowserDialog.ShowDialog()
        AssetFolderTextBox.Text = AssetFolderBrowserDialog.SelectedPath

        Dim AssetFolder As String
        Dim IsFolderNameValid As Boolean
        Dim DoesFolderExist As Boolean

        AssetFolder = AssetFolderTextBox.Text
        AssetFolder = AssetFolder.TrimEnd("\")
        IsFolderNameValid = IsValidPathName(AssetFolder)
        DoesFolderExist = Directory.Exists(AssetFolder)

        If IsFolderNameValid And DoesFolderExist Then
            GlobalVariables.TagObject = GetTagInfo(AssetFolder)
            Dim TagInfo = GlobalVariables.TagObject
            RefreshLists()
            AddTagSetTextBox.Enabled = True
            AddTagSetButton.Enabled = True
            TagSetListBox.Enabled = True
        Else
            MsgBox("Invalid folder name or folder does not exist.")
        End If
    End Sub

    Private Sub TagSetListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TagSetListBox.SelectedIndexChanged
        If TagSetListBox.SelectedIndex >= 0 Then
            AddTagTextBox.Enabled = True
            AddTagButton.Enabled = True
            TagCheckedListBox.Enabled = True
        Else
            AddTagTextBox.Enabled = False
            AddTagButton.Enabled = False
            TagCheckedListBox.Enabled = False
        End If

        If Not TagSetListBox.SelectedItem Is Nothing Then
            GlobalVariables.TrackChanges = False

            Dim TagSetName As String
            TagSetName = TagSetListBox.SelectedItem.ToString
            Dim TagSetObject = GlobalVariables.TagObject("sets")(TagSetName)
            Dim AssetTag As String

            For TagCount = 0 To TagCheckedListBox.Items.Count - 1
                TagCheckedListBox.SetItemChecked(TagCount, False)
            Next

            For TagCount = 0 To TagCheckedListBox.Items.Count - 1
                AssetTag = TagCheckedListBox.Items(TagCount).ToString

                For Each ContainedTag In TagSetObject
                    If ContainedTag = AssetTag Then
                        TagCheckedListBox.SetItemChecked(TagCount, True)
                    End If
                Next
            Next
            GlobalVariables.TrackChanges = True
        End If
    End Sub

    Private Sub RefreshLists()
        Dim TagInfo = GlobalVariables.TagObject
        Dim AssetList As New List(Of String)
        TagSetListBox.Items.Clear()
        For Each TagSet In TagInfo("sets")
            TagSetListBox.Items.Add(TagSet.Name)
        Next

        TagCheckedListBox.Items.Clear()
        TagComboBox.Items.Clear()
        AssetDataGridView.Rows.Clear()
        For Each AssetTag In TagInfo("tags")
            TagCheckedListBox.Items.Add(AssetTag.Name)
            TagComboBox.Items.Add(AssetTag.Name)

            For Each Asset In TagInfo("tags")(AssetTag.Name)
                AssetList.Add(Asset.Value.ToString)
            Next
        Next
        AssetDataGridView.Rows.Clear()
        AssetDataGridView.Columns.Clear()
        GetAssetInfo(AssetFolderTextBox.Text, AssetList)
        If TagSetListBox.Items.Count >= 1 Then TagSetListBox.SelectedIndex = 0
        If TagComboBox.Items.Count >= 1 Then TagComboBox.SelectedIndex = 0
        ShowAssetsComboBox.SelectedIndex = 0
        SortAssetsComboBox.SelectedIndex = 0
    End Sub

    Private Sub TagCheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles TagCheckedListBox.ItemCheck
        If GlobalVariables.TrackChanges Then
            Dim TagName As String = TagCheckedListBox.Items(e.Index)
            Dim TagSetName As String = TagSetListBox.SelectedItem
            Dim TagSetObject = GlobalVariables.TagObject("sets")(TagSetName)
            If e.NewValue Then
                TagSetObject.Add(TagName)
            Else
                For TagIndex = 0 To TagSetObject.Count - 1
                    If TagSetObject(TagIndex) = TagName Then
                        TagSetObject(TagIndex).Remove
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub TagCheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TagCheckedListBox.SelectedIndexChanged
        TagComboBox.SelectedIndex = TagCheckedListBox.SelectedIndex
    End Sub

    Private Sub CustomTagsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddTagButton.Enabled = False
        TagCheckedListBox.Enabled = False

        AddTagSetButton.Enabled = False
        TagSetListBox.Enabled = False

        AssetDataGridView.Enabled = False
    End Sub

    Private Sub RevertChangesButton_Click(sender As Object, e As EventArgs) Handles RevertChangesButton.Click
        AddTagTextBox.Enabled = False
        AddTagButton.Enabled = False
        TagCheckedListBox.Enabled = False
        GlobalVariables.TagObject = GetTagInfo(AssetFolderTextBox.Text)
        Dim TagInfo = GlobalVariables.TagObject
        RefreshLists()
    End Sub

    Private Sub AddTagSetButton_Click(sender As Object, e As EventArgs) Handles AddTagSetButton.Click
        Dim NewTagSetName As String = AddTagSetTextBox.Text
        If NewTagSetName <> "" And Not TagSetListBox.Items.Contains(NewTagSetName) Then
            Dim NewTagSetValues As New Newtonsoft.Json.Linq.JArray
            TagSetListBox.Items.Add(NewTagSetName)
            GlobalVariables.TagObject("sets").Add(NewTagSetName, NewTagSetValues)
        End If
        AddTagSetTextBox.Text = ""
    End Sub

    Private Sub AddTagButton_Click(sender As Object, e As EventArgs) Handles AddTagButton.Click
        Dim NewTagName As String = AddTagTextBox.Text
        If NewTagName <> "" And Not TagCheckedListBox.Items.Contains(NewTagName) Then
            TagCheckedListBox.Items.Add(AddTagTextBox.Text)
            TagComboBox.Items.Add(AddTagTextBox.Text)
            Dim NewTagValues As New Newtonsoft.Json.Linq.JArray
            GlobalVariables.TagObject("tags").Add(NewTagName, NewTagValues)
        End If
        AddTagTextBox.Text = ""
    End Sub

    Private Sub RemoveTagSetContextMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveTagSetContextMenuItem.Click
        Dim TagSetName = TagSetListBox.SelectedItem
        TagSetListBox.Items.Remove(TagSetName)
        Dim TagSetObject = GlobalVariables.TagObject("sets")
        TagSetObject.Remove(TagSetName)
    End Sub

    Private Sub RemoveTagContextMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveTagContextMenuItem.Click
        Dim TagName = TagCheckedListBox.SelectedItem
        TagCheckedListBox.Items.Remove(TagName)
        TagComboBox.Items.Remove(TagName)

        Dim TagObject = GlobalVariables.TagObject("tags")
        TagObject.Remove(TagName)
    End Sub

    Private Sub SaveChanges_Click(sender As Object, e As EventArgs) Handles SaveChangesButton.Click
        Dim AssetFolder As String
        Dim DataFolder As String
        Dim DataFile As String
        Dim IsFolderNameValid As Boolean
        Dim DoesFolderExist As Boolean

        AssetFolder = AssetFolderTextBox.Text
        AssetFolder = AssetFolder.TrimEnd("\")
        IsFolderNameValid = IsValidPathName(AssetFolder)
        DoesFolderExist = Directory.Exists(AssetFolder)

        If IsFolderNameValid And DoesFolderExist Then
            DataFolder = AssetFolder & "\data"
            If Not Directory.Exists(DataFolder) Then Directory.CreateDirectory(DataFolder)
            DataFile = DataFolder & "\default.dungeondraft_tags"
            Dim TagObject = GlobalVariables.TagObject

            Dim SortedObject = SortTagInfo(TagObject)

            Dim SerialObject = JsonConvert.SerializeObject(SortedObject, Formatting.Indented)
            My.Computer.FileSystem.WriteAllText(DataFile, SerialObject, False, System.Text.Encoding.ASCII)
            MsgBox("File Saved to: " & DataFile)
            RefreshLists()
        Else
            MsgBox("Invalid folder name or folder does not exist.")
        End If
    End Sub

    Private Sub TagComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TagComboBox.SelectedIndexChanged
        TagCheckedListBox.SelectedIndex = TagComboBox.SelectedIndex
        If TagComboBox.SelectedIndex >= 0 Then
            AssetDataGridView.Enabled = True
        Else
            AssetDataGridView.Enabled = False
        End If

        If Not TagComboBox.SelectedItem Is Nothing Then
            GlobalVariables.TrackChanges = False

            Dim TagName As String
            TagName = TagComboBox.SelectedItem.ToString
            Dim TagObject = GlobalVariables.TagObject("tags")(TagName)
            Dim AssetTagPath As String

            For RowIndex = 0 To AssetDataGridView.Rows.Count - 1
                AssetDataGridView.Rows(RowIndex).Cells(0).Value = False
                AssetDataGridView.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                AssetDataGridView.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Next

            For RowIndex = 0 To AssetDataGridView.Rows.Count - 1
                AssetTagPath = AssetDataGridView.Rows(RowIndex).Cells(2).Value

                For Each ContainedAsset In TagObject
                    If ContainedAsset = AssetTagPath Then
                        AssetDataGridView.Rows(RowIndex).Cells(0).Value = True
                        AssetDataGridView.Rows(RowIndex).DefaultCellStyle.BackColor = Color.SlateGray
                        AssetDataGridView.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.White
                    End If
                Next
            Next
            GlobalVariables.TrackChanges = True
        End If
    End Sub

    Public Sub AssetDataGridView_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles AssetDataGridView.CellContentClick
        If GlobalVariables.TrackChanges Then
            If e.ColumnIndex = 0 Then
                Dim TagObject = GlobalVariables.TagObject("tags")(TagComboBox.SelectedItem)
                Dim TagPath As String
                Dim row As DataGridViewRow = AssetDataGridView.Rows(e.RowIndex)
                Dim checkbox As DataGridViewCheckBoxCell
                checkbox = row.Cells(e.ColumnIndex)
                checkbox.Value = Convert.ToBoolean(checkbox.EditedFormattedValue)

                TagPath = row.Cells("TagPath").Value
                If checkbox.Value Then
                    TagObject.Add(TagPath)
                    row.DefaultCellStyle.BackColor = Color.SlateGray
                    row.DefaultCellStyle.ForeColor = Color.White

                Else
                    row.DefaultCellStyle.BackColor = Color.White
                    row.DefaultCellStyle.ForeColor = Color.Black
                    For TagCount = 0 To TagObject.Count - 1
                        If TagObject(TagCount) = TagPath Then
                            TagObject(TagCount).Remove
                            Exit For
                        End If
                    Next
                End If
            End If
        End If

    End Sub

    Private Sub ShowAssetsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ShowAssetsComboBox.SelectedIndexChanged
        Select Case ShowAssetsComboBox.SelectedItem
            Case "Show All"
                For Each row As DataGridViewRow In AssetDataGridView.Rows
                    row.Visible = True
                Next
            Case "Show Selected"
                For Each row As DataGridViewRow In AssetDataGridView.Rows
                    If row.Cells("Select").Value Then
                        row.Visible = True
                    Else
                        row.Visible = False
                    End If
                Next
            Case "Show Unselected"
                For Each row As DataGridViewRow In AssetDataGridView.Rows
                    If row.Cells("Select").Value Then
                        row.Visible = False
                    Else
                        row.Visible = True
                    End If
                Next
        End Select

    End Sub

    Private Sub SortAssetsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SortAssetsComboBox.SelectedIndexChanged
        Select Case SortAssetsComboBox.SelectedItem
            Case "Sort by Name (Ascending)"
                AssetDataGridView.Sort(AssetDataGridView.Columns("FileName"), System.ComponentModel.ListSortDirection.Ascending)
            Case "Sort by Name (Descending)"
                AssetDataGridView.Sort(AssetDataGridView.Columns("FileName"), System.ComponentModel.ListSortDirection.Descending)
            Case "Sort by Selected (Ascending)"
                AssetDataGridView.Sort(AssetDataGridView.Columns("Select"), System.ComponentModel.ListSortDirection.Ascending)
            Case "Sort by Selected (Descending)"
                AssetDataGridView.Sort(AssetDataGridView.Columns("Select"), System.ComponentModel.ListSortDirection.Descending)
        End Select
    End Sub
End Class

Public Class GlobalVariables
    Public Shared Property TagObject
    Public Shared Property TrackChanges As Boolean
End Class