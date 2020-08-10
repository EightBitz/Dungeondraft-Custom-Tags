Imports System.IO
Public Class AssetObject
    Public Property Name
    Public Property FilePath
    Public Property TagPath
End Class
Module AssetInfoModule
    Public Sub CreateAssetGridColumns()
        'Configure our columns for the data grid view.
        Dim SelectColumn As New DataGridViewCheckBoxColumn With {
            .HeaderText = "Select",
            .Name = "Select",
            .SortMode = DataGridViewColumnSortMode.Automatic,
            .Width = 70
        }
        CustomTagsForm.AssetDataGridView.Columns.Add(SelectColumn)
        CustomTagsForm.AssetDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        '
        ' 8/5/2020 - Added by Noral
        ' .ImageLayout is needed to make sure thumbnail fits area
        '
        Dim ThumbnailColumn As New DataGridViewImageColumn With {
            .HeaderText = "Thumbnail",
            .Name = "Thumbnail",
            .Visible = False,
            .ImageLayout = DataGridViewImageCellLayout.Zoom,
            .ReadOnly = True
        }
        CustomTagsForm.AssetDataGridView.Columns.Add(ThumbnailColumn)
        'CustomTagsForm.ThumbnailCheckBox.Checked = True

        Dim FileNameColumn As New DataGridViewTextBoxColumn With {
            .HeaderText = "File Name",
            .Name = "FileName",
            .SortMode = DataGridViewColumnSortMode.Automatic,
            .Width = 423,
            .ReadOnly = True
        }
        CustomTagsForm.AssetDataGridView.Columns.Add(FileNameColumn)

        Dim TagPathColumn As New DataGridViewTextBoxColumn With {
            .HeaderText = "Tag Path",
            .Name = "TagPath",
            .Visible = False,
            .ReadOnly = True
        }
        CustomTagsForm.AssetDataGridView.Columns.Add(TagPathColumn)

        Dim FilePathColumn As New DataGridViewTextBoxColumn With {
            .HeaderText = "File Path",
            .Name = "FilePath",
            .Visible = False,
            .ReadOnly = True
        }
        CustomTagsForm.AssetDataGridView.Columns.Add(FilePathColumn)
    End Sub

    Public Function ParseFileList(Source, FileList)
        If Not Source.EndsWith("\") Then Source &= "\"
        Dim AssetList As New List(Of AssetObject)
        For Each AssetFile As String In FileList
            Dim Asset As New AssetObject
            Asset.FilePath = AssetFile
            Asset.Name = Path.GetFileName(AssetFile)
            Asset.TagPath = AssetFile.Replace(Source, "").Replace("\", "/")
            AssetList.Add(Asset)
        Next
        Return AssetList
    End Function

    Public Function ParseTagList(Source As String, TagList As List(Of String))
        If Not Source.EndsWith("\") Then Source &= "\"
        Dim AssetList As New List(Of AssetObject)
        For Each AssetTag As String In TagList
            Dim Asset As New AssetObject
            Asset.FilePath = Source & AssetTag.Replace("/", "\")
            Asset.Name = Path.GetFileName(Asset.FilePath)
            Asset.TagPath = AssetTag

            Dim Duplicate As Boolean
            If File.Exists(Asset.FilePath) Then
                Duplicate = False
                For Each AddedAsset In AssetList
                    If Asset.Name = AddedAsset.Name Then
                        Duplicate = True
                        Exit For
                    End If
                Next
                If Duplicate = False Then AssetList.Add(Asset)
            End If
        Next
        Return AssetList
    End Function

    Public Function CheckForMissingFiles(Source As String, TagList As List(Of String))
        If Not Source.EndsWith("\") Then Source &= "\"
        Dim AssetList As New List(Of AssetObject)
        For Each AssetTag As String In TagList
            Dim Asset As New AssetObject
            Asset.FilePath = Source & AssetTag.Replace("/", "\")
            Asset.Name = Path.GetFileName(Asset.FilePath)
            Asset.TagPath = AssetTag

            Dim Duplicate As Boolean
            If Not File.Exists(Asset.FilePath) Then
                Duplicate = False
                For Each AddedAsset In AssetList
                    If Asset.Name = AddedAsset.Name Then
                        Duplicate = True
                        Exit For
                    End If
                Next
                If Duplicate = False Then AssetList.Add(Asset)
            End If
        Next
        Return AssetList
    End Function

    Public Function ImageCallBack() As Boolean
        Return True
    End Function

    Public Sub GetAssetInfo(Source As String, TagList As List(Of String))
        CreateAssetGridColumns()
        Dim FileTypes() As String = {".bmp", ".dds", ".exr", ".hdr", ".jpg", ".jpeg", ".png", ".tga", ".svg", ".svgz", ".webp"}
        Dim ObjectPath As String = Source & "\textures\objects"
        If Directory.Exists(ObjectPath) Then
            Dim FileList = From File In Directory.GetFiles(ObjectPath, "*.*", SearchOption.AllDirectories)
                           Where FileTypes.Contains(Path.GetExtension(File).ToLower)

            Dim FileAssets As New List(Of AssetObject)
            Dim TagAssets As New List(Of AssetObject)
            Dim MissingAssets As New List(Of AssetObject)
            Dim AllAssets As New List(Of AssetObject)

            '
            ' 8/5/2020 - Added by Noral
            ' Changed conditional from ">" to ">=" to take into account only a single file in the directory
            '
            If FileList.Count >= 1 Then FileAssets = ParseFileList(Source, FileList)

            If TagList.Count >= 1 Then
                TagAssets = ParseTagList(Source, TagList)
                MissingAssets = CheckForMissingFiles(Source, TagList)
            End If

            If TagAssets.Count >= 1 Then AllAssets.AddRange(TagAssets)
            If MissingAssets.Count >= 1 Then
                Dim MissingFilesMsg As String
                MissingFilesMsg = "The current tag file includes entries for assets that do not exist as files."
                MissingFilesMsg &= vbCrLf & "Do you want to keep these entries?"
                MissingFilesMsg &= vbCrLf & "(Recommended answer is No.)"
                Dim Response = MsgBox(MissingFilesMsg, MsgBoxStyle.YesNo)
                If Response = MsgBoxResult.Yes Then AllAssets.AddRange(MissingAssets)
            End If

            Dim Duplicate As Boolean
            If FileAssets.Count >= 1 Then
                For Each Asset In FileAssets
                    Duplicate = False
                    For Each AddedAsset In AllAssets
                        If Asset.Name = AddedAsset.Name Then
                            Duplicate = True
                            Exit For
                        End If
                    Next
                    If Duplicate = False Then AllAssets.Add(Asset)
                Next
            End If

            Dim RowIndex As Integer = 0
            For Each Asset In AllAssets
                Dim NewRow = {False, Nothing, Asset.Name, Asset.TagPath, Asset.FilePath}
                CustomTagsForm.AssetDataGridView.Rows.Add(NewRow)
                'CustomTagsForm.AssetDataGridView.Rows(RowIndex).Height = 60
                'CustomTagsForm.AssetDataGridView.Rows(RowIndex).Cells("FileName").ToolTipText = Asset.FilePath
                RowIndex += 1
            Next
            CustomTagsForm.AssetDataGridView.Sort(CustomTagsForm.AssetDataGridView.Columns("FileName"), System.ComponentModel.ListSortDirection.Ascending)
        Else
            Dim WarningMessage As String
            WarningMessage = "Cannot find path: " & vbCrLf & vbCrLf & ObjectPath & vbCrLf & vbCrLf
            WarningMessage &= "You may be in the wrong folder."
            MsgBox(WarningMessage)
        End If
    End Sub
End Module
