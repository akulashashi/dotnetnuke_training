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

#Region " Namespaces "
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports bhattji.Modules.Dispatchs.Business
#End Region

Namespace bhattji.Modules.Dispatchs

    Public MustInherit Class Details
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "

        Private itemId As Integer
        Private objOI As OptionsInfo
        Private oldPassword As String = Null.NullString


#End Region

#Region " Private Methods "

        Private Function CreateDnnUser() As DotNetNuke.Security.Membership.UserCreateStatus
            Dim objUI As New Users.UserInfo
            With objUI
                .Profile.InitialiseProfile(PortalId)

                .PortalID = PortalId
                .Username = txtDispatchCode.Text
                .FirstName = txtDispatchName.Text
                .LastName = txtDispatchCode.Text
                '.FullName = txtDispatchName.Text
                .DisplayName = txtDispatchName.Text
                .Email = IIf(txtEmail.Text <> String.Empty, txtEmail.Text, txtDispatchCode.Text & "@jrctransportation.com").ToString

                .Profile.FirstName = .FirstName
                .Profile.LastName = .LastName

                .Membership.Username = .Username
                .Membership.Password = txtDispPassw.Text
                .Membership.CreatedDate = Now
                .Membership.Email = .Email

                '.Membership.Approved = True
            End With 'objUI

            Return Users.UserController.CreateUser(objUI)

            ''''Dim UserStatus As DotNetNuke.Security.Membership.UserCreateStatus '= (New UserController).CreateUser(objUI)

            ''''Dim objUC As UserController = New UserController
            ''''UserStatus = objUC.CreateUser(objUI)
            ''''Select Case UserStatus
            ''''    Case DotNetNuke.Security.Membership.UserCreateStatus.Success
            ''''        DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, UserStatus.ToString, DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)
            ''''    Case DotNetNuke.Security.Membership.UserCreateStatus.UserAlreadyRegistered
            ''''        DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, UserStatus.ToString, DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning)
            ''''    Case Else
            ''''        DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, UserStatus.ToString, DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            ''''End Select

        End Function 'CreateDnnUser

#End Region


#Region " Public Methods "

        Private Sub ItemToPage(ByVal ItemId As Integer)
            If Not Null.IsNull(ItemId) Then 'Check for the Not-Null ItemId
                Dim objDispatch As Business.DispatchInfo = (New Business.DispatchsController).GetDispatch(ItemId)
                'Check for the Not-Null objDispatch
                If Not objDispatch Is Nothing Then ItemToPage(objDispatch)
            End If
        End Sub

        Private Sub ItemToPage(ByVal objDispatch As Business.DispatchInfo)
            'Load objDispatch data to the Page
            With objDispatch
                txtDispatchCode.Text = .DispatchCode
                txtDispatchName.Text = .DispatchName
                'txtOffice.Text = .Office
                lblOffice.Text = .Office
                If Not Null.IsNull(.CommRate) Then
                    txtCommRate.Text = .CommRate.ToString
                End If
                txtDefDisp.Text = .DefDisp
                txtDispPassw.Text = .DispPassw
                'Store the Password in the Variable
                oldPassword = txtDispPassw.Text
                'chkStatus.Checked = (.Status.ToUpper = "A")
                txtOffLogNo.Text = .OffLogNo
                txtDOffLogNo.Text = .DOffLogNo
                chkAllowXM.Checked = (.AllowXM.ToUpper = "Y")
                txtLogonLink.Text = .LogonLink
                'If Not JrcUser Is Nothing Then txtLogonLink.Text = JrcUser.Email
                If Not Null.IsNull(.LogDate) Then
                    txtLogDate.Text = .LogDate.ToShortDateString
                End If
                txtLogTime.Text = .LogTime.ToShortTimeString
                If .ClearCode.ToUpper = "Y" Then
                    imgClearCode.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    imgClearCode.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If

                If .Status.ToUpper = "A" Then
                    imgStatus.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    imgStatus.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If

                txtWhatProcess.Text = .WhatProcess
                txtXMProc.Text = .XMProc

                If Not Null.IsNull(.ViewOrder) Then
                    txtViewOrder.Text = .ViewOrder.ToString
                End If

                'Audit Control
                ctlAudit.CreatedByUser = .UpdatedByUser
                ctlAudit.CreatedDate = .UpdatedDate.ToString

                'Tracking Control
                'ctlTracking.URL = .NavURL
                ctlTracking.ModuleID = .ModuleId
            End With 'objDispatch

        End Sub

        Private Sub SetIconBar()
            'Give the ImageUrl
            hypImgEdit.ImageUrl = ModulePath & "img/bhattji_Edit.jpg"

            'Give Tooltip
            hypEdit.ToolTip = hypEdit.Text

            'Close Authority
            With hypClose
                .Visible = True
                If .Visible Then
                    .NavigateUrl = NavigateURL()
                    .ToolTip = Localization.GetString("Close")
                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                End If
            End With  'hypClose
            With hypImgClose
                .Visible = True
                If .Visible Then
                    .ImageUrl = ModulePath & "img/bhattji_Close.jpg"
                    .NavigateUrl = NavigateURL()
                    .ToolTip = Localization.GetString("Close")
                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                End If
            End With  'hypImgClose

            'Print Authority
            With hypPrint
                .Visible = True
                If .Visible Then
                    .NavigateUrl = EditUrl("ItemID", itemId.ToString, "ItemDetails", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                    .Target = "_blank"
                    .ToolTip = Localization.GetString("Print", LocalResourceFile)
                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                End If
            End With  'hypPrint
            With hypImgPrint
                .Visible = True
                If .Visible Then
                    .ImageUrl = ModulePath & "img/bhattji_Print.jpg"
                    .NavigateUrl = hypPrint.NavigateUrl
                    .Target = "_blank"
                    .ToolTip = Localization.GetString("Print", LocalResourceFile)
                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                End If
            End With  'hypImgPrint
        End Sub 'SetIconBar()

#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                objOI = New OptionsInfo(ModuleId)

                'Put user code to initialize the page here
                Dim RattleImageJS As String = "<SCRIPT type=""text/javascript"" src=""" & ModulePath & "js/JbRattleImage.js""></SCRIPT>"
                If (Not Page.ClientScript.IsClientScriptBlockRegistered("RattleImageJS")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "RattleImageJS", RattleImageJS)
                End If
                Dim JB_ActiveContentJS As String = "<SCRIPT type=""text/javascript"" src=""" & ModulePath & "js/JB_ActiveContent.js""></SCRIPT>"
                If (Not Page.ClientScript.IsClientScriptBlockRegistered("JB_ActiveContentJS")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "JB_ActiveContentJS", JB_ActiveContentJS)
                End If

                ' Determine ItemId of Announcement to Display
                If Not (Request.QueryString("ItemId") Is Nothing) Then
                    itemId = Int32.Parse(Request.QueryString("ItemId"))
                Else
                    itemId = Convert.ToInt32(DotNetNuke.Common.Utilities.Null.NullInteger)
                End If

                If Not Page.IsPostBack Then
                    SetIconBar()

                    Dim arrAvailable As ArrayList = (New Business.DispatchIOsController).GetIOsByDispatcher()
                    ctlDispatchIOs.Available = arrAvailable

                    If Not Null.IsNull(itemId) Then
                        Dim objDispatch As DispatchInfo = (New DispatchsController).GetDispatch(itemId)

                        If Not objDispatch Is Nothing Then
                            ItemToPage(objDispatch)

                            'Edit Authority
                            With hypEdit
                                .Visible = IsEditable
                                If .Visible Then
                                    .NavigateUrl = EditUrl("ItemID", itemId.ToString)
                                    .ToolTip = Localization.GetString("Edit")
                                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                End If
                            End With  'hypEdit
                            With hypImgEdit
                                .Visible = IsEditable
                                If .Visible Then
                                    .NavigateUrl = EditUrl("ItemID", itemId.ToString)
                                    .ToolTip = Localization.GetString("Edit")
                                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                End If
                            End With  'hypImgEdit

                            'Audit Control
                            With ctlAudit
                                .CreatedByUser = objDispatch.UpdatedByUser
                                .CreatedDate = objDispatch.UpdatedDate.ToString
                            End With 'ctlAudit

                            'Tracking Control
                            With ctlTracking
                                ' .URL = objDispatch.NavURL
                                .ModuleID = objDispatch.ModuleId
                            End With 'ctlTracking

                            'Assign Offices to Dispatcher
                            With ctlDispatchIOs
                                Dim arrAssigned As ArrayList = (New Business.DispatchIOsController).GetIOsByDispatcher(itemId)
                                For Each liAssigned As Business.DispatchIOInfo In arrAssigned
                                    For Each liAvailable As Business.DispatchIOInfo In arrAvailable
                                        If liAvailable.InterOfficeId = liAssigned.InterOfficeId Then
                                            arrAvailable.Remove(liAvailable)
                                            Exit For
                                        End If
                                    Next liAvailable 'As DispatchIOInfo In arrAssigned

                                Next liAssigned 'As DispatchIOInfo In arrAssigned

                                .Available = arrAvailable
                                .Assigned = arrAssigned
                            End With 'ctlDispatchIOs

                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If

                    End If



                    'Close Authority
                    With hypClose
                        .Visible = True
                        If .Visible Then
                            .NavigateUrl = NavigateURL()
                            .ToolTip = Localization.GetString("Close")
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                        End If
                    End With  'hypClose
                    With hypImgClose
                        .Visible = True
                        If .Visible Then
                            .NavigateUrl = NavigateURL()
                            .ToolTip = Localization.GetString("Close")
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                        End If
                    End With  'hypImgClose
                    'With hypImgClose1
                    '    .NavigateUrl = NavigateURL()
                    '    .ToolTip = Localization.GetString("Close")
                    '    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                    'End With  'hypImgClose

                End If


            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

    End Class

End Namespace
