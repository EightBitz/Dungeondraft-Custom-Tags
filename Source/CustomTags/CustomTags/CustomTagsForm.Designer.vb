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
        Me.ThumbnailCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SearchTextBox = New System.Windows.Forms.TextBox()
        Me.SortAssetsComboBox = New System.Windows.Forms.ComboBox()
        Me.ShowAssetsComboBox = New System.Windows.Forms.ComboBox()
        Me.TagComboBox = New System.Windows.Forms.ComboBox()
        Me.AssetDataGridView = New System.Windows.Forms.DataGridView()
        Me.AssetDataGridViewContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AssetDataGridViewCheckSelectedMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssetDataGridViewUncheckSelectedMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveChangesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevertChangesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreferencesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadPreferencesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SavePreferencesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefaultPreferencesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TemplatesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadTemplateMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveTemplateMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefaultTemplateMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentationMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LicenseMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.READMEMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GitHubLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.CreativeCommonsLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.EmailLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplashPanel = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TemplateSaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.TemplateOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.BrowseMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssetDataGridViewCheckAllMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssetDataGridViewUncheckAllMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssetsGroupBox.SuspendLayout()
        CType(Me.AssetDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AssetDataGridViewContextMenu.SuspendLayout()
        Me.TagSetsAndTagsGroupBox.SuspendLayout()
        Me.TagContextMenu.SuspendLayout()
        Me.TagSetContextMenu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SplashPanel.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AssetsGroupBox
        '
        Me.AssetsGroupBox.Controls.Add(Me.ThumbnailCheckBox)
        Me.AssetsGroupBox.Controls.Add(Me.Label1)
        Me.AssetsGroupBox.Controls.Add(Me.SearchTextBox)
        Me.AssetsGroupBox.Controls.Add(Me.SortAssetsComboBox)
        Me.AssetsGroupBox.Controls.Add(Me.ShowAssetsComboBox)
        Me.AssetsGroupBox.Controls.Add(Me.TagComboBox)
        Me.AssetsGroupBox.Controls.Add(Me.AssetDataGridView)
        Me.AssetsGroupBox.Location = New System.Drawing.Point(523, 67)
        Me.AssetsGroupBox.Margin = New System.Windows.Forms.Padding(4)
        Me.AssetsGroupBox.MinimumSize = New System.Drawing.Size(568, 536)
        Me.AssetsGroupBox.Name = "AssetsGroupBox"
        Me.AssetsGroupBox.Padding = New System.Windows.Forms.Padding(4)
        Me.AssetsGroupBox.Size = New System.Drawing.Size(568, 536)
        Me.AssetsGroupBox.TabIndex = 3
        Me.AssetsGroupBox.TabStop = False
        Me.AssetsGroupBox.Text = "Assets"
        '
        'ThumbnailCheckBox
        '
        Me.ThumbnailCheckBox.AutoSize = True
        Me.ThumbnailCheckBox.Location = New System.Drawing.Point(428, 57)
        Me.ThumbnailCheckBox.Name = "ThumbnailCheckBox"
        Me.ThumbnailCheckBox.Size = New System.Drawing.Size(133, 20)
        Me.ThumbnailCheckBox.TabIndex = 4
        Me.ThumbnailCheckBox.Text = "Show Thumbnails"
        Me.ThumbnailCheckBox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Search for"
        '
        'SearchTextBox
        '
        Me.SearchTextBox.Location = New System.Drawing.Point(82, 54)
        Me.SearchTextBox.Name = "SearchTextBox"
        Me.SearchTextBox.Size = New System.Drawing.Size(262, 22)
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
        Me.AssetDataGridView.ContextMenuStrip = Me.AssetDataGridViewContextMenu
        Me.AssetDataGridView.Location = New System.Drawing.Point(7, 82)
        Me.AssetDataGridView.MinimumSize = New System.Drawing.Size(554, 447)
        Me.AssetDataGridView.Name = "AssetDataGridView"
        Me.AssetDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AssetDataGridView.Size = New System.Drawing.Size(554, 447)
        Me.AssetDataGridView.TabIndex = 5
        '
        'AssetDataGridViewContextMenu
        '
        Me.AssetDataGridViewContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssetDataGridViewCheckAllMenuItem, Me.AssetDataGridViewUncheckAllMenuItem, Me.AssetDataGridViewCheckSelectedMenuItem, Me.AssetDataGridViewUncheckSelectedMenuItem})
        Me.AssetDataGridViewContextMenu.Name = "AssetDataGridViewContextMenu"
        Me.AssetDataGridViewContextMenu.Size = New System.Drawing.Size(181, 114)
        '
        'AssetDataGridViewCheckSelectedMenuItem
        '
        Me.AssetDataGridViewCheckSelectedMenuItem.Name = "AssetDataGridViewCheckSelectedMenuItem"
        Me.AssetDataGridViewCheckSelectedMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AssetDataGridViewCheckSelectedMenuItem.Text = "Check Selected"
        '
        'AssetDataGridViewUncheckSelectedMenuItem
        '
        Me.AssetDataGridViewUncheckSelectedMenuItem.Name = "AssetDataGridViewUncheckSelectedMenuItem"
        Me.AssetDataGridViewUncheckSelectedMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AssetDataGridViewUncheckSelectedMenuItem.Text = "Uncheck Selected"
        '
        'TagSetsAndTagsGroupBox
        '
        Me.TagSetsAndTagsGroupBox.Controls.Add(Me.AddTagTextBox)
        Me.TagSetsAndTagsGroupBox.Controls.Add(Me.AddTagButton)
        Me.TagSetsAndTagsGroupBox.Controls.Add(Me.TagCheckedListBox)
        Me.TagSetsAndTagsGroupBox.Controls.Add(Me.AddTagSetButton)
        Me.TagSetsAndTagsGroupBox.Controls.Add(Me.AddTagSetTextBox)
        Me.TagSetsAndTagsGroupBox.Controls.Add(Me.TagSetListBox)
        Me.TagSetsAndTagsGroupBox.Location = New System.Drawing.Point(12, 67)
        Me.TagSetsAndTagsGroupBox.MinimumSize = New System.Drawing.Size(504, 536)
        Me.TagSetsAndTagsGroupBox.Name = "TagSetsAndTagsGroupBox"
        Me.TagSetsAndTagsGroupBox.Size = New System.Drawing.Size(504, 536)
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
        Me.TagCheckedListBox.ContextMenuStrip = Me.TagContextMenu
        Me.TagCheckedListBox.FormattingEnabled = True
        Me.TagCheckedListBox.Location = New System.Drawing.Point(244, 81)
        Me.TagCheckedListBox.MinimumSize = New System.Drawing.Size(254, 446)
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
        Me.TagSetListBox.MinimumSize = New System.Drawing.Size(229, 436)
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
        Me.AssetFolderTextBox.Location = New System.Drawing.Point(194, 35)
        Me.AssetFolderTextBox.Name = "AssetFolderTextBox"
        Me.AssetFolderTextBox.Size = New System.Drawing.Size(897, 22)
        Me.AssetFolderTextBox.TabIndex = 1
        '
        'RevertChangesButton
        '
        Me.RevertChangesButton.Location = New System.Drawing.Point(12, 609)
        Me.RevertChangesButton.Name = "RevertChangesButton"
        Me.RevertChangesButton.Size = New System.Drawing.Size(504, 40)
        Me.RevertChangesButton.TabIndex = 4
        Me.RevertChangesButton.Text = "Revert Changes"
        Me.RevertChangesButton.UseVisualStyleBackColor = True
        '
        'SaveChangesButton
        '
        Me.SaveChangesButton.Location = New System.Drawing.Point(523, 609)
        Me.SaveChangesButton.Name = "SaveChangesButton"
        Me.SaveChangesButton.Size = New System.Drawing.Size(568, 40)
        Me.SaveChangesButton.TabIndex = 5
        Me.SaveChangesButton.Text = "Save Changes"
        Me.SaveChangesButton.UseVisualStyleBackColor = True
        '
        'AssetFolderBrowseButton
        '
        Me.AssetFolderBrowseButton.Location = New System.Drawing.Point(18, 31)
        Me.AssetFolderBrowseButton.Name = "AssetFolderBrowseButton"
        Me.AssetFolderBrowseButton.Size = New System.Drawing.Size(170, 30)
        Me.AssetFolderBrowseButton.TabIndex = 0
        Me.AssetFolderBrowseButton.Text = "Browse for Asset Folder"
        Me.AssetFolderBrowseButton.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenuItem, Me.SettingsToolStripMenuItem, Me.HelpMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1108, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileMenuItem
        '
        Me.FileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BrowseMenuItem, Me.SaveChangesMenuItem, Me.RevertChangesMenuItem, Me.ExitMenuItem})
        Me.FileMenuItem.Name = "FileMenuItem"
        Me.FileMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileMenuItem.Text = "&File"
        '
        'SaveChangesMenuItem
        '
        Me.SaveChangesMenuItem.Name = "SaveChangesMenuItem"
        Me.SaveChangesMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveChangesMenuItem.Text = "&Save Changes"
        '
        'RevertChangesMenuItem
        '
        Me.RevertChangesMenuItem.Name = "RevertChangesMenuItem"
        Me.RevertChangesMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RevertChangesMenuItem.Text = "&Revert Changes"
        '
        'ExitMenuItem
        '
        Me.ExitMenuItem.Name = "ExitMenuItem"
        Me.ExitMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitMenuItem.Text = "E&xit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreferencesMenuItem, Me.TemplatesMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'PreferencesMenuItem
        '
        Me.PreferencesMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadPreferencesMenuItem, Me.SavePreferencesMenuItem, Me.DefaultPreferencesMenuItem})
        Me.PreferencesMenuItem.Name = "PreferencesMenuItem"
        Me.PreferencesMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PreferencesMenuItem.Text = "&Preferences"
        '
        'LoadPreferencesMenuItem
        '
        Me.LoadPreferencesMenuItem.Name = "LoadPreferencesMenuItem"
        Me.LoadPreferencesMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.LoadPreferencesMenuItem.Text = "Load Preferences"
        '
        'SavePreferencesMenuItem
        '
        Me.SavePreferencesMenuItem.Name = "SavePreferencesMenuItem"
        Me.SavePreferencesMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.SavePreferencesMenuItem.Text = "Save Preferences"
        '
        'DefaultPreferencesMenuItem
        '
        Me.DefaultPreferencesMenuItem.Name = "DefaultPreferencesMenuItem"
        Me.DefaultPreferencesMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.DefaultPreferencesMenuItem.Text = "Default Preferences"
        '
        'TemplatesMenuItem
        '
        Me.TemplatesMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadTemplateMenuItem, Me.SaveTemplateMenuItem, Me.DefaultTemplateMenuItem})
        Me.TemplatesMenuItem.Name = "TemplatesMenuItem"
        Me.TemplatesMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TemplatesMenuItem.Text = "&Templates"
        '
        'LoadTemplateMenuItem
        '
        Me.LoadTemplateMenuItem.Name = "LoadTemplateMenuItem"
        Me.LoadTemplateMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.LoadTemplateMenuItem.Text = "Load Template"
        '
        'SaveTemplateMenuItem
        '
        Me.SaveTemplateMenuItem.Name = "SaveTemplateMenuItem"
        Me.SaveTemplateMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.SaveTemplateMenuItem.Text = "Save Template"
        '
        'DefaultTemplateMenuItem
        '
        Me.DefaultTemplateMenuItem.Name = "DefaultTemplateMenuItem"
        Me.DefaultTemplateMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.DefaultTemplateMenuItem.Text = "Default Template"
        '
        'HelpMenuItem
        '
        Me.HelpMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutMenuItem, Me.DocumentationMenuItem, Me.LicenseMenuItem, Me.READMEMenuItem})
        Me.HelpMenuItem.Name = "HelpMenuItem"
        Me.HelpMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpMenuItem.Text = "&Help"
        '
        'AboutMenuItem
        '
        Me.AboutMenuItem.Name = "AboutMenuItem"
        Me.AboutMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AboutMenuItem.Text = "&About"
        '
        'DocumentationMenuItem
        '
        Me.DocumentationMenuItem.Name = "DocumentationMenuItem"
        Me.DocumentationMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DocumentationMenuItem.Text = "&Documentation"
        '
        'LicenseMenuItem
        '
        Me.LicenseMenuItem.Name = "LicenseMenuItem"
        Me.LicenseMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LicenseMenuItem.Text = "&License"
        '
        'READMEMenuItem
        '
        Me.READMEMenuItem.Name = "READMEMenuItem"
        Me.READMEMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.READMEMenuItem.Text = "&README"
        '
        'GitHubLinkLabel
        '
        Me.GitHubLinkLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GitHubLinkLabel.Location = New System.Drawing.Point(0, 270)
        Me.GitHubLinkLabel.Name = "GitHubLinkLabel"
        Me.GitHubLinkLabel.Size = New System.Drawing.Size(1079, 30)
        Me.GitHubLinkLabel.TabIndex = 5
        Me.GitHubLinkLabel.TabStop = True
        Me.GitHubLinkLabel.Text = "https://github.com/EightBitz/Dungeondraft-Custom-Tags"
        Me.GitHubLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cagliostro", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(447, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(416, 43)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Copyright © 2020 EightBitz,"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VersionLabel
        '
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.Font = New System.Drawing.Font("Cagliostro", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel.Location = New System.Drawing.Point(447, 86)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(122, 43)
        Me.VersionLabel.TabIndex = 8
        Me.VersionLabel.Text = "Version"
        Me.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CreativeCommonsLinkLabel
        '
        Me.CreativeCommonsLinkLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreativeCommonsLinkLabel.Location = New System.Drawing.Point(0, 300)
        Me.CreativeCommonsLinkLabel.Name = "CreativeCommonsLinkLabel"
        Me.CreativeCommonsLinkLabel.Size = New System.Drawing.Size(1079, 30)
        Me.CreativeCommonsLinkLabel.TabIndex = 7
        Me.CreativeCommonsLinkLabel.TabStop = True
        Me.CreativeCommonsLinkLabel.Text = "LinkLabel1"
        Me.CreativeCommonsLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EmailLinkLabel
        '
        Me.EmailLinkLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailLinkLabel.Location = New System.Drawing.Point(0, 240)
        Me.EmailLinkLabel.Name = "EmailLinkLabel"
        Me.EmailLinkLabel.Size = New System.Drawing.Size(1079, 30)
        Me.EmailLinkLabel.TabIndex = 12
        Me.EmailLinkLabel.TabStop = True
        Me.EmailLinkLabel.Text = "Email: eightbitz73@outlook.com"
        Me.EmailLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cagliostro", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(447, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(632, 65)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "EightBitz's Custom Tags Tool"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplashPanel
        '
        Me.SplashPanel.Controls.Add(Me.Label4)
        Me.SplashPanel.Controls.Add(Me.StartButton)
        Me.SplashPanel.Controls.Add(Me.PictureBox3)
        Me.SplashPanel.Controls.Add(Me.EmailLinkLabel)
        Me.SplashPanel.Controls.Add(Me.VersionLabel)
        Me.SplashPanel.Controls.Add(Me.CreativeCommonsLinkLabel)
        Me.SplashPanel.Controls.Add(Me.PictureBox1)
        Me.SplashPanel.Controls.Add(Me.GitHubLinkLabel)
        Me.SplashPanel.Controls.Add(Me.Label3)
        Me.SplashPanel.Controls.Add(Me.Label2)
        Me.SplashPanel.Location = New System.Drawing.Point(12, 27)
        Me.SplashPanel.Name = "SplashPanel"
        Me.SplashPanel.Size = New System.Drawing.Size(1084, 625)
        Me.SplashPanel.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cagliostro", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(447, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(446, 43)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Creative Commons CC-BY-NC"
        '
        'StartButton
        '
        Me.StartButton.Font = New System.Drawing.Font("Cagliostro", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartButton.Location = New System.Drawing.Point(459, 361)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(162, 80)
        Me.StartButton.TabIndex = 14
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Custom_Tags.My.Resources.Resources._8bitz
        Me.PictureBox3.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(437, 218)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 13
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Custom_Tags.My.Resources.Resources.by_nc
        Me.PictureBox1.Location = New System.Drawing.Point(910, 175)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(120, 43)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'TemplateOpenFileDialog
        '
        Me.TemplateOpenFileDialog.FileName = "OpenFileDialog1"
        '
        'BrowseMenuItem
        '
        Me.BrowseMenuItem.Name = "BrowseMenuItem"
        Me.BrowseMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BrowseMenuItem.Text = "&Browse"
        '
        'AssetDataGridViewCheckAllMenuItem
        '
        Me.AssetDataGridViewCheckAllMenuItem.Name = "AssetDataGridViewCheckAllMenuItem"
        Me.AssetDataGridViewCheckAllMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AssetDataGridViewCheckAllMenuItem.Text = "Check All"
        '
        'AssetDataGridViewUncheckAllMenuItem
        '
        Me.AssetDataGridViewUncheckAllMenuItem.Name = "AssetDataGridViewUncheckAllMenuItem"
        Me.AssetDataGridViewUncheckAllMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AssetDataGridViewUncheckAllMenuItem.Text = "Uncheck All"
        '
        'CustomTagsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1108, 661)
        Me.Controls.Add(Me.SplashPanel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.AssetFolderBrowseButton)
        Me.Controls.Add(Me.SaveChangesButton)
        Me.Controls.Add(Me.RevertChangesButton)
        Me.Controls.Add(Me.AssetFolderTextBox)
        Me.Controls.Add(Me.TagSetsAndTagsGroupBox)
        Me.Controls.Add(Me.AssetsGroupBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(1124, 700)
        Me.Name = "CustomTagsForm"
        Me.Text = "EightBitz's Custom Tags Tool - Version 0.8"
        Me.AssetsGroupBox.ResumeLayout(False)
        Me.AssetsGroupBox.PerformLayout()
        CType(Me.AssetDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AssetDataGridViewContextMenu.ResumeLayout(False)
        Me.TagSetsAndTagsGroupBox.ResumeLayout(False)
        Me.TagSetsAndTagsGroupBox.PerformLayout()
        Me.TagContextMenu.ResumeLayout(False)
        Me.TagSetContextMenu.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplashPanel.ResumeLayout(False)
        Me.SplashPanel.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ThumbnailCheckBox As CheckBox
    Friend WithEvents AssetDataGridViewContextMenu As ContextMenuStrip
    Friend WithEvents AssetDataGridViewCheckSelectedMenuItem As ToolStripMenuItem
    Friend WithEvents AssetDataGridViewUncheckSelectedMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileMenuItem As ToolStripMenuItem
    Friend WithEvents ExitMenuItem As ToolStripMenuItem
    Friend WithEvents HelpMenuItem As ToolStripMenuItem
    Friend WithEvents AboutMenuItem As ToolStripMenuItem
    Friend WithEvents GitHubLinkLabel As LinkLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents VersionLabel As Label
    Friend WithEvents CreativeCommonsLinkLabel As LinkLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents EmailLinkLabel As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents SplashPanel As Panel
    Friend WithEvents StartButton As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PreferencesMenuItem As ToolStripMenuItem
    Friend WithEvents LoadPreferencesMenuItem As ToolStripMenuItem
    Friend WithEvents SavePreferencesMenuItem As ToolStripMenuItem
    Friend WithEvents DefaultPreferencesMenuItem As ToolStripMenuItem
    Friend WithEvents TemplatesMenuItem As ToolStripMenuItem
    Friend WithEvents LoadTemplateMenuItem As ToolStripMenuItem
    Friend WithEvents SaveTemplateMenuItem As ToolStripMenuItem
    Friend WithEvents DefaultTemplateMenuItem As ToolStripMenuItem
    Friend WithEvents TemplateSaveFileDialog As SaveFileDialog
    Friend WithEvents TemplateOpenFileDialog As OpenFileDialog
    Friend WithEvents SaveChangesMenuItem As ToolStripMenuItem
    Friend WithEvents RevertChangesMenuItem As ToolStripMenuItem
    Friend WithEvents DocumentationMenuItem As ToolStripMenuItem
    Friend WithEvents LicenseMenuItem As ToolStripMenuItem
    Friend WithEvents READMEMenuItem As ToolStripMenuItem
    Friend WithEvents BrowseMenuItem As ToolStripMenuItem
    Friend WithEvents AssetDataGridViewCheckAllMenuItem As ToolStripMenuItem
    Friend WithEvents AssetDataGridViewUncheckAllMenuItem As ToolStripMenuItem
End Class
