Imports System.IO
Imports Newtonsoft.Json

Public Class CustomTagsForm

    Private Sub CustomTagsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '
        ' 8/5/2020 - Added by Noral
        ' Show version number dynamically according to assememby version
        '
        Me.Text = "EightBitz's Custom Tags Tool - Version " + My.Application.Info.Version.ToString

        AddTagButton.Enabled = False
        TagCheckedListBox.Enabled = False
        AddTagSetButton.Enabled = False
        TagSetListBox.Enabled = False
        AssetDataGridView.Enabled = False
        SearchTextBox.Enabled = False
        ThumbnailCheckBox.Enabled = False
    End Sub

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
            AssetDataGridView.Invoke(New MethodInvoker(AddressOf LoadThumbnails))
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
            '
            ' 8/5/2020 - Added by Noral
            ' Uncheck Show Thumbnails when loading new directory
            '
            ThumbnailCheckBox.Checked = False
            RefreshLists()
            AddTagSetTextBox.Enabled = True
            AddTagSetButton.Enabled = True
            TagSetListBox.Enabled = True
            '
            ' 8/5/2020 - Added by Noral
            ' Background loading of Thumbnails
            '
            AssetDataGridView.Invoke(New MethodInvoker(AddressOf LoadThumbnails))
        Else
            MsgBox("Invalid folder name or folder does not exist.")
        End If
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
        '
        ' 8/5/2020 - Added by Noral
        ' Refresh of DataGridView 
        '
        AssetDataGridView.Refresh()

        For Each AssetTag In TagInfo("tags")
            TagCheckedListBox.Items.Add(AssetTag.Name)
            TagComboBox.Items.Add(AssetTag.Name)

            For Each Asset In TagInfo("tags")(AssetTag.Name)
                AssetList.Add(Asset.Value.ToString)
            Next
        Next
        '
        ' 8/5/2020 - Added by Noral
        ' Unneccessary
        '
        'AssetDataGridView.Rows.Clear()
        'AssetDataGridView.Columns.Clear()
        GetAssetInfo(AssetFolderTextBox.Text, AssetList)
        ThumbnailCheckBox.Enabled = True
        If TagSetListBox.Items.Count >= 1 Then TagSetListBox.SelectedIndex = 0
        If TagComboBox.Items.Count >= 1 Then TagComboBox.SelectedIndex = 0
        ShowAssetsComboBox.SelectedIndex = 0
        SortAssetsComboBox.SelectedIndex = 0
        SetColumnWidths()
        AssetDataGridView.Invoke(New MethodInvoker(AddressOf LoadThumbnails))
    End Sub

    Private Sub RevertChangesButton_Click(sender As Object, e As EventArgs) Handles RevertChangesButton.Click
        '
        ' 8/5/2020 - Added by Noral
        ' Adding prompt before changes are lost!
        '
        Dim MessageBoxResult As DialogResult = MessageBox.Show("Do you really want to revert?  Changes will be lost.", "Revert Changes", MessageBoxButtons.YesNo)

        If (MessageBoxResult = DialogResult.Yes) Then
            AddTagTextBox.Enabled = False
            AddTagButton.Enabled = False
            TagCheckedListBox.Enabled = False
            GlobalVariables.TagObject = GetTagInfo(AssetFolderTextBox.Text)
            Dim TagInfo = GlobalVariables.TagObject
            RefreshLists()
        End If
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
            DataFile = DataFolder & "\default.dungeondraft_tags"

            Dim MessageBoxResult As DialogResult = MessageBox.Show("Do you want to save changes to " & DataFile & "?", "Save Changes", MessageBoxButtons.YesNo)
            If (MessageBoxResult = DialogResult.Yes) Then
                If Not Directory.Exists(DataFolder) Then Directory.CreateDirectory(DataFolder)
                Dim TagObject = GlobalVariables.TagObject

                Dim SortedObject = SortTagInfo(TagObject)

                Dim SerialObject = JsonConvert.SerializeObject(SortedObject, Formatting.Indented)
                My.Computer.FileSystem.WriteAllText(DataFile, SerialObject, False, System.Text.Encoding.ASCII)
                MsgBox("File Saved to: " & DataFile)
                RefreshLists()
            End If
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
                AssetDataGridView.Rows(RowIndex).Cells("Select").Value = False
                AssetDataGridView.Rows(RowIndex).DefaultCellStyle.BackColor = GlobalVariables.UnselectedBackColor
                AssetDataGridView.Rows(RowIndex).DefaultCellStyle.ForeColor = GlobalVariables.UnselectedForeColor
            Next

            For RowIndex = 0 To AssetDataGridView.Rows.Count - 1
                AssetTagPath = AssetDataGridView.Rows(RowIndex).Cells("TagPath").Value

                For Each ContainedAsset In TagObject
                    If ContainedAsset = AssetTagPath Then
                        AssetDataGridView.Rows(RowIndex).Cells("Select").Value = True
                        AssetDataGridView.Rows(RowIndex).DefaultCellStyle.BackColor = GlobalVariables.SelectedBackColor
                        AssetDataGridView.Rows(RowIndex).DefaultCellStyle.ForeColor = GlobalVariables.SelectedForeColor
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

    '
    ' 8/5/2020 - Added by Noral
    ' Unneccessary
    '
    'Public Sub AssetGridView_CellContentDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles AssetDataGridView.CellContentDoubleClick
    '    If e.ColumnIndex <> AssetDataGridView.Columns("Select").Index And ThumbnailCheckBox.Checked Then
    '        GetThumbnails()
    '    End If
    'End Sub

    'Public Sub AssetDataGridView_Scroll() Handles AssetDataGridView.Scroll
    '    GetThumbnails()
    'End Sub

    'Public Sub AssetDataGridView_Sorted() Handles AssetDataGridView.Sorted
    '    GetThumbnails()
    'End Sub

    Private Sub ShowAssetsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ShowAssetsComboBox.SelectedIndexChanged
        Select Case ShowAssetsComboBox.SelectedItem
            Case "Show All"
                SearchTextBox.Text = ""
                SearchTextBox.Enabled = False
                For Each row As DataGridViewRow In AssetDataGridView.Rows
                    row.Visible = True
                Next
                '
                ' 8/5/2020 - Added by Noral
                ' Unneccessary
                '
                'GetThumbnails()
                SetColumnWidths()
            Case "Show Selected"
                SearchTextBox.Text = ""
                SearchTextBox.Enabled = False
                For Each row As DataGridViewRow In AssetDataGridView.Rows
                    If row.Cells("Select").Value Then
                        row.Visible = True
                    Else
                        row.Visible = False
                    End If
                Next
                '
                ' 8/5/2020 - Added by Noral
                ' Unneccessary
                '
                'GetThumbnails()
                SetColumnWidths()
            Case "Show Unselected"
                SearchTextBox.Text = ""
                SearchTextBox.Enabled = False
                For Each row As DataGridViewRow In AssetDataGridView.Rows
                    If row.Cells("Select").Value Then
                        row.Visible = False
                    Else
                        row.Visible = True
                    End If
                Next
                '
                ' 8/5/2020 - Added by Noral
                ' Unneccessary
                '
                'GetThumbnails()
                SetColumnWidths()
            Case "Search"
                SearchTextBox.Enabled = True
        End Select
    End Sub

    Private Sub SortAssetsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SortAssetsComboBox.SelectedIndexChanged
        Select Case SortAssetsComboBox.SelectedItem
            Case "Sort by Name (Ascending)"
                AssetDataGridView.Sort(AssetDataGridView.Columns("FileName"), System.ComponentModel.ListSortDirection.Ascending)
                '
                ' 8/5/2020 - Added by Noral
                ' Unneccessary
                '
                'GetThumbnails()
                SetColumnWidths()
            Case "Sort by Name (Descending)"
                AssetDataGridView.Sort(AssetDataGridView.Columns("FileName"), System.ComponentModel.ListSortDirection.Descending)
                '
                ' 8/5/2020 - Added by Noral
                ' Unneccessary
                '
                'GetThumbnails()
                SetColumnWidths()
            Case "Sort by Selected (Ascending)"
                AssetDataGridView.Sort(AssetDataGridView.Columns("Select"), System.ComponentModel.ListSortDirection.Ascending)
                '
                ' 8/5/2020 - Added by Noral
                ' Unneccessary
                '
                'GetThumbnails()
                SetColumnWidths()
            Case "Sort by Selected (Descending)"
                AssetDataGridView.Sort(AssetDataGridView.Columns("Select"), System.ComponentModel.ListSortDirection.Descending)
                '
                ' 8/5/2020 - Added by Noral
                ' Unneccessary
                '
                'GetThumbnails()
                SetColumnWidths()
        End Select
    End Sub

    Private Sub SearchTextBox_LostFocus(sender As Object, e As EventArgs) Handles SearchTextBox.LostFocus
        Dim search As String = SearchTextBox.Text
        If search <> "" Then
            For Each row As DataGridViewRow In AssetDataGridView.Rows
                If row.Cells("FileName").Value.ToString.ToLower.Contains(search.ToLower) Then
                    row.Visible = True
                Else
                    row.Visible = False
                End If
            Next
            '
            ' 8/5/2020 - Added by Noral
            ' Unneccessary
            '
            'GetThumbnails()
            SetColumnWidths()
        End If
    End Sub

    Private Sub ThumbnailCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ThumbnailCheckBox.CheckedChanged
        Dim Row As DataGridViewRow
        If ThumbnailCheckBox.Checked Then
            AssetDataGridView.Columns("Thumbnail").Visible = True
            For Each Row In AssetDataGridView.Rows
                Row.Height = 60
            Next
            '
            ' 8/5/2020 - Added by Noral
            ' Unneccessary
            '
            'GetThumbnails()
        Else
            AssetDataGridView.Columns("Thumbnail").Visible = False
            '
            ' 8/5/2020 - Added by Noral
            ' Unneccessary - Rows are already set and we do not want to remove the thumbnails
            '
            For Each Row In AssetDataGridView.Rows
                Row.Height = 22
                'Row.Cells("Thumbnail").Value = Nothing
            Next

            'NewHeight = Me.Size.Height
            'NewWidth = Me.Size.Width - AssetDataGridView.Columns("Thumbnail").Width
            'Me.Size = New Size(NewWidth, NewHeight)
        End If
        SetColumnWidths()
    End Sub

    Public Sub Me_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Dim WidthChange As Integer = Me.Size.Width - GlobalVariables.MinFormWidth
        Dim HeightChange As Integer = Me.Size.Height - GlobalVariables.MinFormHeight
        Dim DefaultButtonTop As Integer = GlobalVariables.DefaultButtonTop
        Dim NewX As Integer
        Dim NewY As Integer

        TagSetsAndTagsGroupBox.Height = TagSetsAndTagsGroupBox.MinimumSize.Height + HeightChange
        TagSetListBox.Height = TagSetListBox.MinimumSize.Height + HeightChange
        TagCheckedListBox.Height = TagCheckedListBox.MinimumSize.Height + HeightChange
        NewX = RevertChangesButton.Location.X
        NewY = DefaultButtonTop + HeightChange
        RevertChangesButton.Location = New Point(NewX, NewY)


        AssetsGroupBox.Width = AssetsGroupBox.MinimumSize.Width + WidthChange
        AssetsGroupBox.Height = AssetsGroupBox.MinimumSize.Height + HeightChange
        AssetDataGridView.Width = AssetDataGridView.MinimumSize.Width + WidthChange
        AssetDataGridView.Height = AssetDataGridView.MinimumSize.Height + HeightChange
        NewX = SaveChangesButton.Location.X
        NewY = DefaultButtonTop + HeightChange
        SaveChangesButton.Location = New Point(NewX, NewY)
        SaveChangesButton.Width = AssetsGroupBox.Width

        If AssetDataGridView.Rows.Count >= 1 Then
            SetColumnWidths()
        End If

    End Sub

    Private Sub SetColumnWidths()
        If AssetDataGridView.Rows.Count >= 1 Then
            Dim FileNameWidth As Integer
            FileNameWidth = AssetDataGridView.Width - 43

            FileNameWidth -= AssetDataGridView.Columns("Select").Width
            If AssetDataGridView.Columns("Thumbnail").Visible Then FileNameWidth -= AssetDataGridView.Columns("Thumbnail").Width
            If AssetDataGridView.Controls.OfType(Of VScrollBar).First.Visible Then FileNameWidth -= SystemInformation.VerticalScrollBarWidth

            AssetDataGridView.Columns("FileName").Width = FileNameWidth
        End If
    End Sub

    '
    ' 8/5/2020 - Added by Noral
    ' Unneccessary
    '
    'Public Sub GetThumbnails()
    '    GlobalVariables.TrackChanges = False
    '    If ThumbnailCheckBox.Checked Then
    '        Dim RowIndex As Integer
    '        Dim imgcallback As Image.GetThumbnailImageAbort = New Image.GetThumbnailImageAbort(AddressOf ImageCallBack)
    '        Dim Filename As String

    '        Dim totalHeight As Int16 = 0

    '        For RowIndex = 0 To AssetDataGridView.Rows.Count - 1
    '            If AssetDataGridView.Rows(RowIndex).Displayed Then
    '                Filename = AssetDataGridView.Rows(RowIndex).Cells("FilePath").Value
    '                Dim image As Image = New Bitmap(Filename)

    '                '
    '                ' Aspect Ratio
    '                'https://eikhart.com/blog/aspect-ratio-calculator#:~:text=There%20is%20a%20simple%20formula,%3D%20(%20newHeight%20*%20aspectRatio%20)%20.
    '                '

    '                Dim aspectRatio As Double = image.Width / image.Height
    '                Dim thumbHeight As Double = 60 / aspectRatio
    '                Dim thumbWidth As Double = thumbHeight * aspectRatio

    '                Dim imgThumbnail = image.GetThumbnailImage(CInt(thumbWidth), CInt(thumbHeight), imgcallback, New IntPtr)

    '                Dim RowHeight = thumbHeight + 10
    '                If RowHeight < 22 Then RowHeight = 22
    '                AssetDataGridView.Rows(RowIndex).Height = RowHeight
    '                AssetDataGridView.Rows(RowIndex).Cells("Thumbnail").Value = imgThumbnail
    '            Else
    '                AssetDataGridView.Rows(RowIndex).Cells("Thumbnail").Value = Nothing
    '            End If
    '        Next
    '    End If
    '    GlobalVariables.TrackChanges = True
    'End Sub

    Private Sub AssetDataGridViewCheckSelectedMenuItem_Click(sender As Object, e As EventArgs) Handles AssetDataGridViewCheckSelectedMenuItem.Click
        Dim Row As DataGridViewRow
        For Each Row In AssetDataGridView.Rows
            If Row.Selected And Row.Visible Then
                Row.Cells("Select").Value = True
                Row.DefaultCellStyle.BackColor = GlobalVariables.SelectedBackColor
                Row.DefaultCellStyle.ForeColor = GlobalVariables.SelectedForeColor
            End If
        Next
    End Sub

    Private Sub AssetDataGridViewUnheckSelectedMenuItem_Click(sender As Object, e As EventArgs) Handles AssetDataGridViewUncheckSelectedMenuItem.Click
        Dim Row As DataGridViewRow
        For Each Row In AssetDataGridView.Rows
            If Row.Selected And Row.Visible Then
                Row.Cells("Select").Value = False
                Row.DefaultCellStyle.BackColor = GlobalVariables.UnselectedBackColor
                Row.DefaultCellStyle.ForeColor = GlobalVariables.UnselectedForeColor
            End If
        Next
    End Sub

    '
    ' 8/5/2020 - Added by Noral
    ' Background loading of thumbnails
    '
    Private Sub LoadThumbnails()
        Dim RowIndex As Integer
        Dim imgcallback As Image.GetThumbnailImageAbort = New Image.GetThumbnailImageAbort(AddressOf ImageCallBack)
        Dim Filename As String

        For Each AssetDataGridRow In AssetDataGridView.Rows

            Filename = AssetDataGridRow.Cells("FilePath").Value
            Dim image As Image = New Bitmap(Filename)

            '
            ' Aspect Ratio
            'https://eikhart.com/blog/aspect-ratio-calculator#:~:text=There%20is%20a%20simple%20formula,%3D%20(%20newHeight%20*%20aspectRatio%20)%20.
            '

            Dim aspectRatio As Double = image.Width / image.Height
            Dim thumbHeight As Double = 60 / aspectRatio
            Dim thumbWidth As Double = thumbHeight * aspectRatio
            Dim imgThumbnail As Bitmap = New Bitmap(image.GetThumbnailImage(CInt(thumbWidth), CInt(thumbHeight), imgcallback, New IntPtr))

            'Dim RowHeight = thumbHeight + 10
            'If RowHeight <= 22 Then RowHeight = 22
            'AssetDataGridView.Rows(RowIndex).Height = RowHeight


            'Dim cell As New DataGridViewImageCell
            'cell = CType(AssetDataGridRow.Cells("Thumbnail"), DataGridViewImageCell)
            'cell.Value = imgThumbnail

            AssetDataGridRow.Cells("Thumbnail").Value = imgThumbnail

        Next
    End Sub
End Class

Public Class GlobalVariables
    Public Shared Property MinFormWidth = 1124
    Public Shared Property MinFormHeight = 700
    Public Shared Property DefaultButtonTop = 605
    Public Shared Property TagObject
    Public Shared Property TrackChanges As Boolean
    Public Shared Property SelectedBackColor As Color = Color.SlateGray
    Public Shared Property SelectedForeColor As Color = Color.White
    Public Shared Property UnselectedBackColor As Color = Color.White
    Public Shared Property UnselectedForeColor As Color = Color.Black
End Class