<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CustomTagsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.AssetsGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SearchTextBox = New System.Windows.Forms.TextBox()
        Me.SortAssetsComboBox = New System.Windows.Forms.ComboBox()
        Me.ShowAssetsComboBox = New System.Windows.Forms.ComboBox()
        Me.TagComboBox = New System.Windows.Forms.ComboBox()
        Me.AssetDataGridView = New System.Windows.Forms.DataGridView()
        Me.TagSetsAndTagsGroupBox = New System.Windows.Forms.GroupBox()
        Me.AddTagTextBox = New System.Windows.Forms.TextBox()
        Me.AddTagButton = New System.Windows.Forms.Button()
        Me.TagCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.TagContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveTagContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddTagSetButton = New System.Windows.Forms.Button()
        Me.AddTagSetTextBox = New System.Windows.Forms.TextBox()
        Me.TagSetListBox = New System.Windows.Forms.ListBox()
        Me.TagSetContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveTagSetContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssetFolderTextBox = New System.Windows.Forms.TextBox()
        Me.RevertChangesButton = New System.Windows.Forms.Button()
        Me.SaveChangesButton = New System.Windows.Forms.Button()
        Me.AssetFolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.AssetFolderBrowseButton = New System.Windows.Forms.Button()
        Me.AssetsGroupBox.SuspendLayout()
        CType(Me.AssetDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TagSetsAndTagsGroupBox.SuspendLayout()
        Me.TagContextMenu.SuspendLayout()
        Me.TagSetContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'AssetsGroupBox
        '
        Me.AssetsGroupBox.Controls.Add(Me.Label1)
        Me.AssetsGroupBox.Controls.Add(Me.SearchTextBox)
        Me.AssetsGroupBox.Controls.Add(Me.SortAssetsComboBox)
        Me.AssetsGroupBox.Controls.Add(Me.ShowAssetsComboBox)
        Me.AssetsGroupBox.Controls.Add(Me.TagComboBox)
        Me.AssetsGroupBox.Controls.Add(Me.AssetDataGridView)
        Me.AssetsGroupBox.Location = New System.Drawing.Point(523, 50)
        Me.AssetsGroupBox.Margin = New System.Windows.Forms.Padding(4)
        Me.AssetsGroupBox.Name = "AssetsGroupBox"
        Me.AssetsGroupBox.Padding = New System.Windows.Forms.Padding(4)
        Me.AssetsGroupBox.Size = New System.Drawing.Size(568, 548)
        Me.AssetsGroupBox.TabIndex = 3
        Me.AssetsGroupBox.TabStop = False
        Me.AssetsGroupBox.Text = "Assets"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Search for"
        '
        'SearchTextBox
        '
        Me.SearchTextBox.Location = New System.Drawing.Point(82, 52)
        Me.SearchTextBox.Name = "SearchTextBox"
        Me.SearchTextBox.Size = New System.Drawing.Size(479, 22)
        Me.SearchTextBox.TabIndex = 3
        '
        'SortAssetsComboBox
        '
        Me.SortAssetsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SortAssetsComboBox.FormattingEnabled = True
        Me.SortAssetsComboBox.Items.AddRange(New Object() {"Sort by Name (Ascending)", "Sort by Name (Descending)", "Sort by Selected (Ascending)", "Sort by Selected (Descending)"})
        Me.SortAssetsComboBox.Location = New System.Drawing.Point(350, 22)
        Me.SortAssetsComboBox.Name = "SortAssetsComboBox"
        Me.SortAssetsComboBox.Size = New System.Drawing.Size(211, 24)
        Me.SortAssetsComboBox.TabIndex = 2
        '
        'ShowAssetsComboBox
        '
        Me.ShowAssetsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ShowAssetsComboBox.FormattingEnabled = True
        Me.ShowAssetsComboBox.Items.AddRange(New Object() {"Show All", "Show Selected", "Show Unselected", "Search"})
        Me.ShowAssetsComboBox.Location = New System.Drawing.Point(202, 22)
        Me.ShowAssetsComboBox.Name = "ShowAssetsComboBox"
        Me.ShowAssetsComboBox.Size = New System.Drawing.Size(142, 24)
        Me.ShowAssetsComboBox.TabIndex = 1
        '
        'TagComboBox
        '
        Me.TagComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TagComboBox.FormattingEnabled = True
        Me.TagComboBox.Location = New System.Drawing.Point(7, 22)
        Me.TagComboBox.Name = "TagComboBox"
        Me.TagComboBox.Size = New System.Drawing.Size(189, 24)
        Me.TagComboBox.Sorted = True
        Me.TagComboBox.TabIndex = 0
        '
        'AssetDataGridView
        '
        Me.AssetDataGridView.AllowUserToAddRows = False
        Me.AssetDataGridView.AllowUserToDeleteRows = False
        Me.AssetDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AssetDataGridView.Location = New System.Drawing.Point(7, 80)
        Me.AssetDataGridView.Name = "AssetDataGridView"
        Me.AssetDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AssetDataGridView.Size = New System.Drawing.Size(554, 460)
        Me.AssetDataGridView.TabIndex = 4
        '
        'TagSetsAndTagsGroupBox
        '
        Me.TagSetsAndTagsGroupBox.Controls.Add(Me.AddTagTextBox)
        Me.TagSetsAndTagsGroupBox.Controls.Add(Me.AddTagButton)
        Me.TagSetsAndTagsGroupBox.Controls.Add(Me.TagCheckedListBox)
        Me.TagSetsAndTagsGroupBox.Controls.Add(Me.AddTagSetButton)
        Me.TagSetsAndTagsGroupBox.Controls.Add(Me.AddTagSetTextBox)
        Me.TagSetsAndTagsGroupBox.Controls.Add(Me.TagSetListBox)
        Me.TagSetsAndTagsGroupBox.Location = New System.Drawing.Point(12, 50)
        Me.TagSetsAndTagsGroupBox.Name = "TagSetsAndTagsGroupBox"
        Me.TagSetsAndTagsGroupBox.Size = New System.Drawing.Size(504, 548)
        Me.TagSetsAndTagsGroupBox.TabIndex = 2
        Me.TagSetsAndTagsGroupBox.TabStop = False
        Me.TagSetsAndTagsGroupBox.Text = "Tag Sets and Tags"
        '
        'AddTagTextBox
        '
        Me.AddTagTextBox.Location = New System.Drawing.Point(244, 21)
        Me.AddTagTextBox.Name = "AddTagTextBox"
        Me.AddTagTextBox.Size = New System.Drawing.Size(254, 22)
        Me.AddTagTextBox.TabIndex = 3
        '
        'AddTagButton
        '
        Me.AddTagButton.Location = New System.Drawing.Point(244, 49)
        Me.AddTagButton.Name = "AddTagButton"
        Me.AddTagButton.Size = New System.Drawing.Size(254, 26)
        Me.AddTagButton.TabIndex = 4
        Me.AddTagButton.Text = "Add Tag"
        Me.AddTagButton.UseVisualStyleBackColor = True
        '
        'TagCheckedListBox
        '
        Me.TagCheckedListBox.CheckOnClick = True
        Me.TagCheckedListBox.ContextMenuStrip = Me.TagContextMenu
        Me.TagCheckedListBox.FormattingEnabled = True
        Me.TagCheckedListBox.Location = New System.Drawing.Point(244, 81)
        Me.TagCheckedListBox.Name = "TagCheckedListBox"
        Me.TagCheckedListBox.Size = New System.Drawing.Size(254, 446)
        Me.TagCheckedListBox.Sorted = True
        Me.TagCheckedListBox.TabIndex = 5
        '
        'TagContextMenu
        '
        Me.TagContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveTagContextMenuItem})
        Me.TagContextMenu.Name = "TagContextMenu"
        Me.TagContextMenu.Size = New System.Drawing.Size(139, 26)
        Me.TagContextMenu.Text = "Context Menu"
        '
        'RemoveTagContextMenuItem
        '
        Me.RemoveTagContextMenuItem.Name = "RemoveTagContextMenuItem"
        Me.RemoveTagContextMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.RemoveTagContextMenuItem.Text = "Remove Tag"
        '
        'AddTagSetButton
        '
        Me.AddTagSetButton.Location = New System.Drawing.Point(6, 49)
        Me.AddTagSetButton.Name = "AddTagSetButton"
        Me.AddTagSetButton.Size = New System.Drawing.Size(232, 26)
        Me.AddTagSetButton.TabIndex = 1
        Me.AddTagSetButton.Text = "Add Tag Set"
        Me.AddTagSetButton.UseVisualStyleBackColor = True
        '
        'AddTagSetTextBox
        '
        Me.AddTagSetTextBox.Location = New System.Drawing.Point(6, 21)
        Me.AddTagSetTextBox.Name = "AddTagSetTextBox"
        Me.AddTagSetTextBox.Size = New System.Drawing.Size(232, 22)
        Me.AddTagSetTextBox.TabIndex = 0
        '
        'TagSetListBox
        '
        Me.TagSetListBox.ContextMenuStrip = Me.TagSetContextMenu
        Me.TagSetListBox.FormattingEnabled = True
        Me.TagSetListBox.ItemHeight = 16
        Me.TagSetListBox.Location = New System.Drawing.Point(6, 81)
        Me.TagSetListBox.Name = "TagSetListBox"
        Me.TagSetListBox.Size = New System.Drawing.Size(229, 436)
        Me.TagSetListBox.Sorted = True
        Me.TagSetListBox.TabIndex = 2
        '
        'TagSetContextMenu
        '
        Me.TagSetContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveTagSetContextMenuItem})
        Me.TagSetContextMenu.Name = "TagSetContextMenu"
        Me.TagSetContextMenu.Size = New System.Drawing.Size(158, 26)
        Me.TagSetContextMenu.Text = "Context Menu"
        '
        'RemoveTagSetContextMenuItem
        '
        Me.RemoveTagSetContextMenuItem.Name = "RemoveTagSetContextMenuItem"
        Me.RemoveTagSetContextMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.RemoveTagSetContextMenuItem.Text = "Remove Tag Set"
        '
        'AssetFolderTextBox
        '
        Me.AssetFolderTextBox.Location = New System.Drawing.Point(194, 18)
        Me.AssetFolderTextBox.Name = "AssetFolderTextBox"
        Me.AssetFolderTextBox.Size = New System.Drawing.Size(897, 22)
        Me.AssetFolderTextBox.TabIndex = 1
        '
        'RevertChangesButton
        '
        Me.RevertChangesButton.Location = New System.Drawing.Point(12, 605)
        Me.RevertChangesButton.Name = "RevertChangesButton"
        Me.RevertChangesButton.Size = New System.Drawing.Size(504, 40)
        Me.RevertChangesButton.TabIndex = 4
        Me.RevertChangesButton.Text = "Revert Changes"
        Me.RevertChangesButton.UseVisualStyleBackColor = True
        '
        'SaveChangesButton
        '
        Me.SaveChangesButton.Location = New System.Drawing.Point(530, 605)
        Me.SaveChangesButton.Name = "SaveChangesButton"
        Me.SaveChangesButton.Size = New System.Drawing.Size(568, 40)
        Me.SaveChangesButton.TabIndex = 5
        Me.SaveChangesButton.Text = "Save Changes"
        Me.SaveChangesButton.UseVisualStyleBackColor = True
        '
        'AssetFolderBrowseButton
        '
        Me.AssetFolderBrowseButton.Location = New System.Drawing.Point(18, 14)
        Me.AssetFolderBrowseButton.Name = "AssetFolderBrowseButton"
        Me.AssetFolderBrowseButton.Size = New System.Drawing.Size(170, 30)
        Me.AssetFolderBrowseButton.TabIndex = 0
        Me.AssetFolderBrowseButton.Text = "Browse for Asset Folder"
        Me.AssetFolderBrowseButton.UseVisualStyleBackColor = True
        '
        'CustomTagsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 657)
        Me.Controls.Add(Me.AssetFolderBrowseButton)
        Me.Controls.Add(Me.SaveChangesButton)
        Me.Controls.Add(Me.RevertChangesButton)
        Me.Controls.Add(Me.AssetFolderTextBox)
        Me.Controls.Add(Me.TagSetsAndTagsGroupBox)
        Me.Controls.Add(Me.AssetsGroupBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CustomTagsForm"
        Me.Text = "EightBitz's Custom Tags Tool - Version 0.7"
        Me.AssetsGroupBox.ResumeLayout(False)
        Me.AssetsGroupBox.PerformLayout()
        CType(Me.AssetDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TagSetsAndTagsGroupBox.ResumeLayout(False)
        Me.TagSetsAndTagsGroupBox.PerformLayout()
        Me.TagContextMenu.ResumeLayout(False)
        Me.TagSetContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AssetsGroupBox As GroupBox
    Friend WithEvents TagComboBox As ComboBox
    Friend WithEvents AssetDataGridView As DataGridView
    Friend WithEvents TagSetsAndTagsGroupBox As GroupBox
    Friend WithEvents TagCheckedListBox As CheckedListBox
    Friend WithEvents AssetFolderTextBox As TextBox
    Friend WithEvents AddTagTextBox As TextBox
    Friend WithEvents AddTagButton As Button
    Friend WithEvents AddTagSetButton As Button
    Friend WithEvents AddTagSetTextBox As TextBox
    Friend WithEvents TagSetListBox As ListBox
    Friend WithEvents RevertChangesButton As Button
    Friend WithEvents SaveChangesButton As Button
    Friend WithEvents TagSetContextMenu As ContextMenuStrip
    Friend WithEvents RemoveTagSetContextMenuItem As ToolStripMenuItem
    Friend WithEvents TagContextMenu As ContextMenuStrip
    Friend WithEvents RemoveTagContextMenuItem As ToolStripMenuItem
    Friend WithEvents SortAssetsComboBox As ComboBox
    Friend WithEvents ShowAssetsComboBox As ComboBox
    Friend WithEvents AssetFolderBrowserDialog As FolderBrowserDialog
    Friend WithEvents AssetFolderBrowseButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents SearchTextBox As TextBox
End Class
