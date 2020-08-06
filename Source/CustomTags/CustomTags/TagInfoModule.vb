Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Public Class AssetFolderObject
    Public Property Path As String
    Public Property Name As String
    Public Property ObjectPath As String
    Public Property DataPath As String
    Public Property TagFile As String
End Class
Module TagInfoModule
    Public Function GetTagsFromJSON(TagFile As String)
        Dim rawJson = File.ReadAllText(TagFile)
        Dim TagObject = JsonConvert.DeserializeObject(rawJson)
        Return TagObject
    End Function
    Public Function GetTagsFromSubfolders(AssetFolderName As String, Source As String)
        Dim ObjectPath As String = Source
        '
        ' 8/5/2020 - Added by Noral
        ' Fixed initialization issue
        '
        Dim ColorablePath As String = ""

        'Get the exact, case-sensitive path name for the textures\objects\colorable folder.
        Dim ColorablePathArray = From subfolder In My.Computer.FileSystem.GetDirectories(ObjectPath.ToString())
                                 Where (My.Computer.FileSystem.GetDirectoryInfo(subfolder)).Name.ToLower() = "colorable"
        For Each path As String In ColorablePathArray
            ColorablePath = path
        Next

        'Set the values for the main keys that will appear in the JSON file.
        Dim tags As String = "tags"
        Dim colorable As String = "Colorable"
        Dim sets As String = "sets"

        'Set up ordered dictionaries that we can later serialize for later covnersion to JSON.
        Dim TagObject As New System.Collections.Specialized.OrderedDictionary
        Dim FolderObject As New System.Collections.Specialized.OrderedDictionary
        Dim ColorableObject As New System.Collections.Specialized.OrderedDictionary
        Dim SetObject As New System.Collections.Specialized.OrderedDictionary
        '
        ' 8/5/2020 - Added by Noral
        ' Commented out since not used
        '
        'Dim TagSetMembers() As String

        'Get the list of subfolders in textures\objects.
        Dim SubFolders As String() = Directory.GetDirectories(ObjectPath)

        'For each subfolder, truncate path from the string value so we're just left with the folder name.
        For i = 0 To SubFolders.Count - 1
            SubFolders(i) = SubFolders(i).Replace(ObjectPath & "\", "")
        Next

        'Get the list files from the root of textures\objects.
        Dim RootFiles As String() = Directory.GetFiles(ObjectPath)

        'For each file, truncate the path up to "textures" so we're left with "textures\objects\<filename>".
        'Then replace the backslashes with forward slashes so we're left with "textures/objects/<filename>".
        For i = 0 To RootFiles.Count - 1
            RootFiles(i) = RootFiles(i).Replace(Source & "\", "")
            RootFiles(i) = RootFiles(i).Replace("\", "/")
        Next

        'If a textures\objects\colorable folder exists, get the list of files from textures\objects\colorable.
        '
        ' 8/5/2020 - Added by Noral
        ' Fixed initialization issue
        '
        Dim RootColorableFiles As String() = {}
        If My.Computer.FileSystem.DirectoryExists(ColorablePath) Then
            RootColorableFiles = Directory.GetFiles(ColorablePath)

            'For each file, truncate the path up to "textures" so we're left with "textures\objects\colorable\<filename>".
            'Then replace the backslashes with forward slashes so we're left with "textures/objects/colorable/<filename>".
            For i = 0 To RootColorableFiles.Count - 1
                RootColorableFiles(i) = RootColorableFiles(i).Replace(Source & "\", "")
                RootColorableFiles(i) = RootColorableFiles(i).Replace("\", "/")
            Next
        End If

        Dim RootCount As Integer
        Dim RootObjects() As String
        RootCount = 0
        If RootFiles IsNot Nothing And RootColorableFiles IsNot Nothing Then
            'If there were files in both the root of textures\objects, and in textures\objects\colorable,
            'then combine both lists of files into the RootObjects array.
            RootCount = RootFiles.Count + RootColorableFiles.Count - 1
            ReDim RootObjects(RootCount)
            RootFiles.CopyTo(RootObjects, 0)
            RootColorableFiles.CopyTo(RootObjects, RootFiles.Count)
        ElseIf RootFiles IsNot Nothing Then
            'If there were files in the root of textures\objects, then copy that list into the RootObjects array.
            RootCount = RootFiles.Count
            ReDim RootObjects(RootCount - 1)
            RootFiles.CopyTo(RootObjects, 0)
        ElseIf RootColorableFiles IsNot Nothing Then
            'If there were files in textures\objects\colorable, then copy that list into the RootObjects array.
            RootCount = RootColorableFiles.Count
            ReDim RootObjects(RootCount)
            RootColorableFiles.CopyTo(RootObjects, 0)
        End If

        'Get a recursive list of all files in all subfolders under textures\objects.
        Dim AllObjects As String() = Directory.GetFiles(ObjectPath, "*.*", SearchOption.AllDirectories)

        'For each file, truncate the path up to "textures" so we're left with "textures\objects\<path>\<filename>".
        'Then replace the backslashes with forward slashes so we're left with "textures/objects/<path>/<filename>".
        For i = 0 To AllObjects.Count - 1
            AllObjects(i) = AllObjects(i).Replace(Source & "\", "")
            AllObjects(i) = AllObjects(i).Replace("\", "/")
        Next

        'Add the list of subfolders to the SetObject ordered dictionary.
        SetObject.Add(AssetFolderName, SubFolders)

        'For each subfolder, add the folder and its associated files to the FolderObject ordered dictionary.
        'Each subfolder name is what will be considered a Tag, and each file contained within that subfolder 
        'will be associated with its parent folder name as a tag.
        Dim SetCount As Integer
        Dim subset As String()
        For Each folder As String In SubFolders
            If folder.ToLower() <> "colorable" Then
                'We don't want to tag any files in textures\objects\colorable.
                'Those files, if they exist, have already been tagged with the default tag.
                Dim folderset As String() = Array.FindAll(AllObjects, Function(s) s.Contains("/" & folder & "/"))
                'If there is no conflict between the default tag value and this folder name,
                'then add the list of files from this subfolder to the FolderObject ordered dictionary,
                'using the folder name as the tag.

                SetCount = folderset.Count
                ReDim subset(SetCount - 1)
                folderset.CopyTo(subset, 0)
                FolderObject.Add(folder, subset)
            End If
        Next

        'Get a recursive list of all files in all "colorable" folders.
        'If any are found, add them to the FolderObject ordered dictionary under a "Colorable" tag.
        Dim AllColorableObjects As String() = Array.FindAll(AllObjects, Function(s) s.ToLower().Contains("/colorable/"))
        If AllColorableObjects.Count >= 1 Then
            FolderObject.Add(colorable, AllColorableObjects)
        End If

        'Add the FolderObject ordered dictionary to the TagObject ordered dictionary.
        TagObject.Add(tags, FolderObject)

        'Add the SetObject ordered dictionary to the TagObject ordered dictionary.
        TagObject.Add(sets, SetObject)

        'Convert the TagObject ordered dictionary to a JSON-formatted string.
        Dim JSONString As String = JsonConvert.SerializeObject(TagObject, Formatting.Indented)
        Dim TagJSON = JsonConvert.DeserializeObject(JSONString)

        Return TagJSON
    End Function

    Public Function BuildTagsFromScratch(AssetFolder As String)
        Dim tags As String = "tags"
        Dim sets As String = "sets"
        Dim colorable As String = "Colorable"
        Dim FolderTagSet As String = AssetFolder

        Dim NewTagInfo As New System.Collections.Specialized.OrderedDictionary
        Dim NewTagObject As New System.Collections.Specialized.OrderedDictionary
        Dim NewSetObject As New System.Collections.Specialized.OrderedDictionary
        Dim ColorableList As New List(Of String)
        Dim TagList As New List(Of String)

        NewTagObject.Add(colorable, ColorableList)
        NewSetObject.Add(FolderTagSet, TagList)

        NewTagInfo.Add(tags, NewTagObject)
        NewTagInfo.Add(sets, NewSetObject)

        Dim JSONString As String = JsonConvert.SerializeObject(NewTagInfo, Formatting.Indented)
        Dim TagJSON = JsonConvert.DeserializeObject(JSONString)
        Return TagJSON
    End Function

    Public Function SortTagInfo(TagObject As JObject)
        Dim SortedTagInfo As New System.Collections.Specialized.OrderedDictionary
        Dim SortedTagObject As New System.Collections.Specialized.OrderedDictionary
        Dim SortedSetObject As New System.Collections.Specialized.OrderedDictionary
        SortedTagInfo.Add("tags", SortedTagObject)
        SortedTagInfo.Add("sets", SortedSetObject)

        Dim UnsortedTagList As JObject = TagObject("tags")
        Dim SortedTagList As New List(Of String)
        For Each UnsortedTag In UnsortedTagList
            If UnsortedTag.Key.ToLower <> "colorable" Then SortedTagList.Add(UnsortedTag.Key)
        Next

        SortedTagList.Sort()

        For Each UnsortedTag In UnsortedTagList
            If UnsortedTag.Key.ToLower = "colorable" Then SortedTagList.Add(UnsortedTag.Key)
        Next

        For Each SortedTag In SortedTagList
            Dim SortedAssetList As New List(Of String)
            For Each UnsortedTag In UnsortedTagList
                If SortedTag = UnsortedTag.Key Then
                    For Each UnsortedAsset In UnsortedTag.Value
                        SortedAssetList.Add(UnsortedAsset)
                    Next
                    Exit For
                End If
            Next
            SortedAssetList.Sort()
            SortedTagObject.Add(SortedTag, SortedAssetList)
        Next

        Dim UnsortedSetList As JObject = TagObject("sets")
        Dim SortedSetList As New List(Of String)
        For Each UnsortedSet In UnsortedSetList
            SortedSetList.Add(UnsortedSet.Key)
        Next
        SortedSetList.Sort()

        For Each SortedSet In SortedSetList
            Dim SortedSetTags As New List(Of String)
            For Each UnsortedSet In UnsortedSetList
                If SortedSet = UnsortedSet.Key Then
                    For Each UnsortedSetTag In UnsortedSet.Value
                        SortedSetTags.Add(UnsortedSetTag)
                    Next
                    Exit For
                End If
            Next
            SortedSetTags.Sort()
            SortedSetObject.Add(SortedSet, SortedSetTags)
        Next

        Dim JSONString As String = JsonConvert.SerializeObject(SortedTagInfo, Formatting.Indented)
        Dim TagJSON = JsonConvert.DeserializeObject(JSONString)

        Return TagJSON
    End Function
    Public Function GetTagInfo(Source As String)
        Dim AssetFolder As New AssetFolderObject
        AssetFolder.Path = Source
        AssetFolder.Name = My.Computer.FileSystem.GetDirectoryInfo(Source).Name
        AssetFolder.ObjectPath = Source & "\textures\objects"
        AssetFolder.DataPath = Source & "\data"
        AssetFolder.TagFile = AssetFolder.DataPath & "\default.dungeondraft_tags"
        Dim TagObject

        If My.Computer.FileSystem.FileExists(AssetFolder.TagFile) Then
            TagObject = GetTagsFromJSON(AssetFolder.TagFile)
        ElseIf My.Computer.FileSystem.DirectoryExists(AssetFolder.ObjectPath) Then
            TagObject = GetTagsFromSubfolders(AssetFolder.Name, AssetFolder.ObjectPath)
        Else
            TagObject = BuildTagsFromScratch(AssetFolder.Name)
        End If

        Return TagObject
    End Function
End Module
