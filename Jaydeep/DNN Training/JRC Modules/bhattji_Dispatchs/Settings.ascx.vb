' Copyright (c) 2002-2005
' by Jaydeep Bhatt, Vision Consultants. ( http://www.bhattji.com )
'
' Permission is hereby granted, to the person obtaining a copy of this software legaly and associated 
' documentation files (the "Software"), to deal in the Software with restriction, including with limitation 
' the rights to use, copy, modify, merge, PublishDate, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DotNetNuke
Imports bhattji.Modules.Dispatchs.Business

Namespace bhattji.Modules.Dispatchs

    Public MustInherit Class Settings
        Inherits Entities.Modules.ModuleSettingsBase

#Region " Methods "

        Private Sub OptionsToPage(ByVal ModId As Integer)
            If ModId > 0 Then OptionsToPage(New OptionsInfo(ModId))
        End Sub

        Private Sub OptionsToPage(ByVal objOI As OptionsInfo)
            With objOI
                'Main Options
                Try
                    rblGetItems.SelectedIndex = .GetItems
                Catch
                    rblGetItems.SelectedIndex = 2
                End Try
                chkOnlyHostCanEdit.Checked = .OnlyHostCanEdit
                Try
                    rblViewControl.Items.FindByValue(.ViewControl).Selected = True
                Catch
                    rblViewControl.SelectedIndex = 0
                End Try
                txtPagerSize.Text = .PagerSize.ToString
                txtNoOfPages.Text = .NoOfPages.ToString
                chkDeleteFromGrid.Checked = .DeleteFromGrid

                Try
                    ddlUpdateRedirection.Items.FindByValue(.UpdateRedirection).Selected = True
                Catch
                End Try

                'Option1 Options
                chkAddDescription.Checked = .AddDescription
                Try
                    rblTabCss.Items.FindByValue(.TabCss).Selected = True
                Catch
                    rblTabCss.SelectedIndex = 0
                End Try
                Try
                    ddlTransition.Items.FindByValue(.Transition).Selected = True
                Catch
                    ddlTransition.Items.FindByValue("Pixelate").Selected = True
                End Try
                chkRattleImage.Checked = .RattleImage
                Try
                    ddlAddDate.Items.FindByValue(.AddDate).Selected = True
                Catch
                End Try
                Try
                    ddlImagePosition.Items.FindByValue(.ImagePosition).Selected = True
                Catch
                    ddlImagePosition.SelectedIndex = 1
                End Try

                chkDynamicThumb.Checked = .DynamicThumb
                chkShowRatings.Checked = .ShowRatings
                txtThumbWidth.Text = .ThumbWidth
                txtThumbHeight.Text = .ThumbHeight
                txtBackColor.Text = .BackColor
                txtAltColor.Text = .AltColor
                txtHeaderBackColor.Text = .HeaderBackColor
                txtPagerBackColor.Text = .PagerBackColor
                txtThumbColumns.Text = .ThumbColumns.ToString
                chkHideTextLink.Checked = .HideTextLink

                'Scroller Options
                Try
                    rblScrollBehavior.Items.FindByValue(.ScrollBehavior).Selected = True
                Catch
                    rblScrollBehavior.SelectedIndex = 0
                End Try
                Try
                    rblScrollDirection.Items.FindByValue(.ScrollDirection).Selected = True
                Catch
                    rblScrollDirection.SelectedIndex = 0
                End Try
                txtScrollAmount.Text = .ScrollAmount
                txtScrollDelay.Text = .ScrollDelay
                txtScrollWidth.Text = .ScrollWidth
                txtScrollHeight.Text = .ScrollHeight

                'Audit Control
                Try
                    'Dim objUC As New UserController
                    'Dim objUI As Users.UserInfo = Users.UserController.GetUser(PortalId, .UpdatedByUserId, True)
                    'ctlAudit.CreatedByUser = objUI.FirstName & " " & objUI.LastName
                    ctlAudit.CreatedByUser = .UpdatedByUser
                    ctlAudit.CreatedDate = .UpdatedDate.ToString
                    Dim objHostUser As Users.UserInfo = Users.UserController.GetUser(PortalId, UserId, True)
                    rblGetItems.Enabled = objHostUser.IsSuperUser
                    chkOnlyHostCanEdit.Enabled = objHostUser.IsSuperUser
                    If .OnlyHostCanEdit Then
                        'txtPayPalBusinessID.Enabled = objHostUser.IsSuperUser
                    End If
                Catch
                    ctlAudit.Visible = False
                End Try

            End With
        End Sub

        Private Sub PageToOptions(ByVal ModId As Integer)
            Dim objOI As New OptionsInfo
            With objOI
                'Main Options
                .GetItems = rblGetItems.SelectedIndex
                .OnlyHostCanEdit = chkOnlyHostCanEdit.Checked
                .ViewControl = rblViewControl.SelectedValue
                Try
                    .PagerSize = Integer.Parse(txtPagerSize.Text)
                Catch
                End Try
                Try
                    .NoOfPages = Integer.Parse(txtNoOfPages.Text)
                Catch
                End Try
                .DeleteFromGrid = chkDeleteFromGrid.Checked
                .UpdateRedirection = ddlUpdateRedirection.SelectedValue

                'Option1 Options
                .AddDescription = chkAddDescription.Checked
                .TabCss = rblTabCss.SelectedValue
                .Transition = ddlTransition.SelectedValue
                .RattleImage = chkRattleImage.Checked
                .AddDate = ddlAddDate.SelectedValue
                .ImagePosition = ddlImagePosition.SelectedValue
                .DynamicThumb = chkDynamicThumb.Checked
                .ShowRatings = chkShowRatings.Checked
                .ThumbWidth = txtThumbWidth.Text
                .ThumbHeight = txtThumbHeight.Text
                .BackColor = txtBackColor.Text
                .AltColor = txtAltColor.Text
                .HeaderBackColor = txtHeaderBackColor.Text
                .PagerBackColor = txtPagerBackColor.Text

                Try
                    .ThumbColumns = Integer.Parse(txtThumbColumns.Text)
                Catch
                End Try
                .HideTextLink = chkHideTextLink.Checked

                'Scroller Options
                .ScrollBehavior = rblScrollBehavior.SelectedValue
                .ScrollDirection = rblScrollDirection.SelectedValue
                .ScrollAmount = txtScrollAmount.Text
                .ScrollDelay = txtScrollDelay.Text
                .ScrollWidth = txtScrollWidth.Text
                .ScrollHeight = txtScrollHeight.Text

                'Audit Control
                .UpdatedByUserId = UserInfo.UserID
                .UpdatedByUser = UserInfo.DisplayName
                .UpdatedDate = Now

                '.Save Options Info Object
                .Update(ModId)
            End With
        End Sub

#End Region

#Region " Base Method Implementations "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' LoadSettings loads the settings from the Databas and displays them
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''		[bhattji]	10/20/2004	created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        ''' 
        Public Overrides Sub LoadSettings()
            LoadOptions(ModuleId)
        End Sub

        Public Sub LoadOptions(ByVal ModId As Integer)
            Try
                If Not Page.IsPostBack Then OptionsToPage(ModId)
            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' UpdateSettings saves the modified settings to the Database
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''		[bhattji]	10/20/2004	created
        '''		[bhattji]	10/25/2004	upated to use TabModuleId rather than TabId/ModuleId
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Overrides Sub UpdateSettings()
            UpdateOptions(ModuleId)
        End Sub

        Public Sub UpdateOptions(ByVal ModId As Integer)
            Try
                If Page.IsValid Then PageToOptions(ModId)
            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

#Region " Event Methods "
        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'Dim ModId As Integer = ModuleId
                'If Request.QueryString("SettingsModuleId") Is Nothing Then
                '    ModId = Convert.ToInt16(Request.QueryString("SettingsModuleId"))
                'End If

                'Dim objOI As New OptionsInfo(ModId)
                'If objOI.OnlyHostCanEdit Then
                '    Dim objUC As New UserController
                '    Dim objHostUser As UserInfo = objUC.GetUser(PortalId, UserId)
                '    If Not objHostUser.IsSuperUser Then
                '        ' security violation attempt to access item not related to this Module
                '        'DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "<a href=""" & NavigateURL() & """ title=""Click to go back"" onmouseover""window.status=this.title; return true"">Requires Host rights</a>", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                '        Response.Redirect(NavigateURL(), True)
                '    End If
                'End If

                If Not IsPostBack Then
                    cmdUpdate.Visible = Not Request.QueryString("SettingsModuleId") Is Nothing 'Request.QueryString("SettingsModuleId") <> String.Empty
                    imbUpdate.Visible = cmdUpdate.Visible
                    cmdCancel.Visible = cmdUpdate.Visible
                    imbCancel.Visible = cmdCancel.Visible

                    If cmdUpdate.Visible Then
                        LoadOptions(Convert.ToInt16(Request.QueryString("SettingsModuleId")))
                    End If
                End If
            Catch exc As Exception    'SettingsModule failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSort.Click
            Dim objDispatchController As New DispatchsController
            objDispatchController.SortDispatchs(ModuleId)
        End Sub

        Private Sub cmdFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFix.Click
            Dim objDispatchController As New DispatchsController
            objDispatchController.FixDispatchs(ModuleId, UserId)
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' cmdUpdate_Click runs when the update button is clicked
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[bhattji]	9/23/2004	Updated to reflect design changes for Help, 508 support
        '''                       and localisation
        ''' </history>
        ''' -----------------------------------------------------------------------------
        ''' 

        Private Sub imbUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdate.Click
            Dim cmdE As New EventArgs
            cmdUpdate_Click(sender, cmdE)
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try
                'If Page.IsValid Then
                UpdateOptions(Convert.ToInt16(Request.QueryString("SettingsModuleId")))
                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
                'End If
            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' cmdCancel_Click runs when the cancel button is clicked
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[bhattji]	9/23/2004	Updated to reflect design changes for Help, 508 support
        '''                       and localisation
        ''' </history>
        ''' -----------------------------------------------------------------------------

        Private Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
            Dim cmdE As New EventArgs
            cmdCancel_Click(sender, cmdE)
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

    End Class 'Settings

End Namespace 'bhattji.Modules.Dispatchs
