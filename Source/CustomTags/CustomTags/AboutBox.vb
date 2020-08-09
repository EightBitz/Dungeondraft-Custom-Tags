Public NotInheritable Class AboutBox

    Private Sub AboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright

        Me.TextBoxDescription.Text = My.Application.Info.Description
        Me.TextBoxDescription.Text = "Custom Tags for Dungeondraft."
        Me.TextBoxDescription.Text += vbCrLf + vbCrLf + "Quickly and easily tag your asset files without having to remember the rules."
        Me.TextBoxDescription.Text += vbCrLf + vbCrLf + "Documentation can be found in the GitHub repository."

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub LinkLabelCompanyName_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCompanyName.LinkClicked
        ' Navigate to a URL.
        System.Diagnostics.Process.Start(My.Application.Info.CompanyName)
    End Sub
End Class
