Imports Newtonsoft.Json
Imports System.IO

Module PreferencesModule
    Public Sub SavePreferences(ConfigFile As String)
        Dim ConfigObject As New Newtonsoft.Json.Linq.JObject

        Dim Preferences() As String = {"asset_folder", "show_filter", "sort_option", "show_thumbnails", "location_x", "location_y", "size_width", "size_height"}
        For Each setting In Preferences
            If ConfigObject(setting) Is Nothing Then ConfigObject.Add(setting, "")
        Next

        ConfigObject("asset_folder") = CustomTagsForm.AssetFolderTextBox.Text
        If CustomTagsForm.ShowAssetsComboBox.Items.Count >= 1 Then ConfigObject("show_filter") = CustomTagsForm.ShowAssetsComboBox.SelectedItem.ToString
        If CustomTagsForm.SortAssetsComboBox.Items.Count >= 1 Then ConfigObject("sort_option") = CustomTagsForm.SortAssetsComboBox.SelectedItem.ToString
        ConfigObject("show_thumbnails") = CustomTagsForm.ThumbnailCheckBox.Checked
        ConfigObject("location_x") = CustomTagsForm.Location.X
        ConfigObject("location_y") = CustomTagsForm.Location.Y
        ConfigObject("size_width") = CustomTagsForm.Size.Width
        ConfigObject("size_height") = CustomTagsForm.Size.Height


        Dim SerialObject = JsonConvert.SerializeObject(ConfigObject, Formatting.Indented)
        My.Computer.FileSystem.WriteAllText(ConfigFile, SerialObject, False, System.Text.Encoding.ASCII)
    End Sub

    Public Function LoadPreferences(ConfigFile As String)
        'Dim ConfigObject As New Newtonsoft.Json.Linq.JObject
        If File.Exists(ConfigFile) Then
            Dim ConfigObject As Newtonsoft.Json.Linq.JObject
            Dim rawJson = File.ReadAllText(ConfigFile)
            ConfigObject = JsonConvert.DeserializeObject(rawJson)
            Return ConfigObject
        Else
            Return Nothing
        End If
    End Function

    Public Sub ApplyPreferences(ConfigFile As String, OverrideSource As Boolean)
        Dim ConfigObject As Newtonsoft.Json.Linq.JObject
        ConfigObject = LoadPreferences(ConfigFile)

        If Not ConfigObject Is Nothing Then
            Dim Preferences() As String = {"asset_folder", "show_filter", "sort_option", "show_thumbnails", "location_x", "location_y", "size_width", "size_height"}
            For Each setting In Preferences
                If ConfigObject(setting) Is Nothing Then
                    If setting = "show_thumbnails" Then ConfigObject.Add(setting, True) Else ConfigObject.Add(setting, "")
                End If
            Next

            If OverrideSource And Not ConfigObject("asset_folder") Is Nothing Then CustomTagsForm.AssetFolderTextBox.Text = ConfigObject("asset_folder")

            If Not ConfigObject("show_filter") Is Nothing Then
                If ConfigObject("show_filter") <> "" Then
                    Dim ShowFilter As String = ConfigObject("show_filter")
                    CustomTagsForm.ShowAssetsComboBox.SelectedIndex = CustomTagsForm.ShowAssetsComboBox.Items.IndexOf(ShowFilter)
                End If
            End If

            If Not ConfigObject("sort_option") Is Nothing Then
                If ConfigObject("sort_option") <> "" Then
                    Dim SortOption As String = ConfigObject("sort_option")
                    CustomTagsForm.SortAssetsComboBox.SelectedIndex = CustomTagsForm.SortAssetsComboBox.Items.IndexOf(SortOption)
                End If
            End If

            If Not ConfigObject("show_thumbnails") Is Nothing Then CustomTagsForm.ThumbnailCheckBox.Checked = ConfigObject("show_thumbnails")

            If (Not ConfigObject("location_x") Is Nothing) And (Not ConfigObject("location_y") Is Nothing) Then
                Dim PointX As Integer = ConfigObject("location_x")
                Dim PointY As Integer = ConfigObject("location_y")
                Dim FormLocation = New Point(PointX, PointY)
                CustomTagsForm.Location = FormLocation
            End If

            If (Not ConfigObject("size_width") Is Nothing) And (Not ConfigObject("size_height") Is Nothing) Then
                Dim FormWidth As Integer = ConfigObject("size_width")
                Dim FormHeight As Integer = ConfigObject("size_height")
                Dim FormSize = New Size(FormWidth, FormHeight)
                CustomTagsForm.Size = FormSize
            End If
        End If
    End Sub

    Public Sub RestoreDefaults(ConfigFile As String)
        Dim ConfigObject As New Newtonsoft.Json.Linq.JObject

        ConfigObject.Add("asset_folder", "")
        ConfigObject.Add("show_filter", "Show All")
        ConfigObject.Add("sort_option", "Sort by Name (Ascending)")
        ConfigObject.Add("show_thumbnails", False)
        ConfigObject.Add("location_x", 100)
        ConfigObject.Add("location_y", 100)
        ConfigObject.Add("size_width", 1124)
        ConfigObject.Add("size_height", 700)


        Dim SerialObject = JsonConvert.SerializeObject(ConfigObject, Formatting.Indented)
        My.Computer.FileSystem.WriteAllText(ConfigFile, SerialObject, False, System.Text.Encoding.ASCII)

        ApplyPreferences(ConfigFile, True)
    End Sub
End Module
