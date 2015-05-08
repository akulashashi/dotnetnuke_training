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
Imports System.Web.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports bhattji.Modules.Dispatchs.Business
'Imports Microsoft.ScalableHosting.Security
'Imports AspNetSecurity = Microsoft.ScalableHosting.Security

#End Region

Namespace bhattji.Modules.Dispatchs

    Public MustInherit Class EditItem
        Inherits Entities.Modules.PortalModuleBase


#Region " Private Members "
        Private itemId As Integer
        Private oldPassword As String = Null.NullString
        Private objOI As OptionsInfo
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
                .Email = IIf(txtEmail.Text <> String.Empty, txtEmail.Text, txtDispatchCode.Text & "@jrctransportation.com").ToString.ToLower

                .Profile.FirstName = .FirstName
                .Profile.LastName = .LastName

                .Membership.Username = .Username
                .Membership.Password = txtDispPassw.Text
                .Membership.CreatedDate = Now
                .Membership.Email = .Email

                .Membership.Approved = True
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

        Private Sub BindManagerOverride()
            With ddlManagerOverride
                .DataValueField = "DispatchCode"
                .DataTextField = "DispatchName"
                .DataSource = (New DispatchsController).GetAllDispatchs(200)
                .DataBind()

                .Items.Insert(0, New ListItem("<None>", ""))
            End With
        End Sub
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
                'Try to remove the Self as ManagerOverride
                Try
                    ddlManagerOverride.Items.Remove(New ListItem(.DispatchName, .DispatchCode))
                Catch
                End Try

                txtDispatchCode.Text = .DispatchCode
                valManagerOverride.InitialValue = .DispatchCode
                If Not Users.UserController.GetCurrentUserInfo.IsInRole("acct_num_update") Then
                    txtDispatchCode.ReadOnly = True
                    txtDispatchCode.CssClass = "NormalBold"
                    txtDispatchCode.Style.Add(HtmlTextWriterStyle.BorderWidth, "0")
                End If
                txtDispatchName.Text = .DispatchName
                'txtOffice.Text = .Office
                Try
                    ddlOfficeOwner.Items.FindByValue(.Office).Selected = True
                Catch
                End Try
                'Try
                '    ddlOfficeOverride.SelectedValue = .OfficeOverride
                'Catch
                'End Try
                txtOfficeOverride.Text = .OfficeOverride
                'Try to set the Manager as ManagerOverride
                Try
                    If .ManagerOverride <> "" Then ddlManagerOverride.SelectedValue = .ManagerOverride
                Catch
                End Try
                If Not Null.IsNull(.CommRate) Then
                    txtCommRate.Text = String.Format("{0:0.00}", .CommRate)
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
                chkClearCode.Checked = (.ClearCode.ToUpper = "Y")

                txtWhatProcess.Text = .WhatProcess
                txtXMProc.Text = .XMProc

                If Not Null.IsNull(.ViewOrder) Then
                    txtViewOrder.Text = .ViewOrder.ToString
                End If

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
                        .NavigateUrl = hypPrint.NavigateUrl
                        .Target = "_blank"
                        .ToolTip = Localization.GetString("Print", LocalResourceFile)
                        .Attributes.Add("onmouseover", "window.status=this.title; return true")
                    End If
                End With  'hypImgPrint

                'Audit Control
                ctlAudit.CreatedByUser = .UpdatedByUser
                ctlAudit.CreatedDate = .UpdatedDate.ToString

                'Tracking Control
                'ctlTracking.URL = .NavURL
                ctlTracking.ModuleID = .ModuleId

            End With 'objDispatch

        End Sub

        Private Function PageToItem() As DispatchInfo
            Dim objDispatch As New DispatchInfo
            'Initialise the ojbDispatch object
            objDispatch = CType(CBO.InitializeObject(objDispatch, GetType(Business.DispatchInfo)), DispatchInfo)

            'bind text values to object
            With objDispatch
                .ItemId = itemId
                .ModuleId = ModuleId

                .DispatchCode = txtDispatchCode.Text
                .DispatchName = txtDispatchName.Text
                '.Office = txtOffice.Text
                .Office = ddlOfficeOwner.SelectedValue
                .OfficeOverride = txtOfficeOverride.Text 'ddlOfficeOverride.SelectedValue
                .ManagerOverride = ddlManagerOverride.SelectedValue
                Try
                    If txtCommRate.Text <> "" Then .CommRate = Double.Parse(txtCommRate.Text)
                Catch
                End Try
                .DefDisp = txtDefDisp.Text
                .DispPassw = txtDispPassw.Text
                If chkStatus.Checked Then
                    .Status = "A"
                Else
                    .Status = "I"
                End If

                .OffLogNo = txtOffLogNo.Text
                .DOffLogNo = txtDOffLogNo.Text
                If chkAllowXM.Checked Then
                    .AllowXM = "Y"
                Else
                    .AllowXM = "N"
                End If

                If txtEmail.Text = String.Empty Then txtEmail.Text = txtDispatchCode.Text.ToLower & "@jrctransportation.com"
                .LogonLink = txtLogonLink.Text
                'If Not JrcUser Is Nothing Then
                '    JrcUser.Email = txtLogonLink.Text
                '    JrcUser.Membership.Email = JrcUser.Email
                'End If
                Try
                    .LogDate = Date.Parse(txtLogDate.Text)
                Catch
                End Try
                Try
                    .LogTime = DateTime.Parse(txtLogTime.Text)
                Catch
                End Try
                If chkClearCode.Checked Then
                    .ClearCode = "Y"
                Else
                    .ClearCode = "N"
                End If
                .WhatProcess = txtWhatProcess.Text
                .XMProc = txtXMProc.Text

                If txtViewOrder.Text <> String.Empty Then
                    Try
                        .ViewOrder = Integer.Parse(txtViewOrder.Text)
                    Catch
                    End Try
                End If

                'Audit Control
                .UpdatedByUserId = UserInfo.UserID
                .CreatedByUserId = .UpdatedByUserId

            End With 'objDispatch
            Return objDispatch
        End Function

        Private Sub InitControls()
            'cmdDelete.Visible = Not Null.IsNull(itemId)
            'imbDelete.Visible = cmdDelete.Visible
            'cmdUpdate.Visible = cmdDelete.Visible
            'imbUpdate.Visible = cmdUpdate.Visible
            'cmdAdd.Visible = Not cmdUpdate.Visible
            'imbAdd.Visible = cmdAdd.Visible

            'If Null.IsNull(itemId) Then
            '    trStatus.Visible = False
            '    tblJrcOffices.Visible = False
            '    tblUserRoles.Visible = False
            '    ddlUpdateRedirection.SelectedValue = "EditItem"
            'End If

            ''this needs to execute always to the client script code is registred in InvokePopupCal
            'cmdCalendarLogDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtLogDate)


        End Sub

        Private Sub SetIconBar()
            'Give the ImageUrl
            imbAdd.ImageUrl = ModulePath & "img/bhattji_Add.jpg"
            imbUpdate.ImageUrl = ModulePath & "img/bhattji_Update.jpg"
            imbDelete.ImageUrl = ModulePath & "img/bhattji_Delete.jpg"
            imbCancel.ImageUrl = ModulePath & "img/bhattji_Cancel.jpg"
            hypImgPrint.ImageUrl = ModulePath & "img/bhattji_Print.jpg"

            'Give the Tooltip
            cmdAdd.ToolTip = Localization.GetString("Add") 'cmdAdd.Text
            cmdUpdate.ToolTip = Localization.GetString("cmdUpdate") 'cmdUpdate.Text
            cmdDelete.ToolTip = Localization.GetString("cmdDelete") 'cmdDelete.Text
            cmdCancel.ToolTip = Localization.GetString("cmdCancel") 'cmdCancel.Text
            hypPrint.ToolTip = hypPrint.Text

            'Make the ControlButtons Visible
            tdDelete.Visible = Not Null.IsNull(itemId)
            tdUpdate.Visible = Not Null.IsNull(itemId) 'tdDelete.Visible '
            tdPrint.Visible = Not Null.IsNull(itemId) 'tdDelete.Visible
            tdAdd.Visible = Not tdUpdate.Visible


            If Null.IsNull(itemId) Then
                trStatus.Visible = False
                tblJrcOffices.Visible = False
                tblUserRoles.Visible = False
                ddlUpdateRedirection.SelectedValue = "EditItem"
            End If

            If tdDelete.Visible Then tdDelete.Visible = Users.UserController.GetCurrentUserInfo.IsInRole("Administrators") OrElse Users.UserController.GetCurrentUserInfo.IsInRole("Admin - JRC")
            If tdDelete.Visible Then
                cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                imbDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
            End If
        End Sub 'SetIconBar()

        'Private Sub BindOfficeOverride()
        '    With ddlOfficeOverride
        '        Dim valfld, txtfld As String
        '        Dim dr As IDataReader = (New Business.DispatchsController).GetAllInterOffices

        '        .Items.Clear()
        '        While dr.Read
        '            valfld = dr("JRCIOfficeCode").ToString
        '            If valfld <> "000000000" Then
        '                txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
        '                txtfld = Replace(txtfld, "JRC ", "")
        '                .Items.Add(New ListItem(txtfld.ToUpper, valfld))
        '            End If
        '        End While

        '        .Items.Insert(0, New ListItem("<Not Applicable>", ""))
        '    End With 'ddlOfficeOverride

        'End Sub
#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                objOI = New OptionsInfo(ModuleId)
                If objOI.OnlyHostCanEdit AndAlso (Not Users.UserController.GetCurrentUserInfo.IsSuperUser) Then
                    Response.Redirect(NavigateURL(), True)
                End If

                ' Determine ItemId
                If Request.Params("ItemId") Is Nothing Then
                    itemId = Null.NullInteger()
                Else
                    itemId = Int32.Parse(Request.Params("ItemId"))
                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                    imbDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                End If

                'Initilise the Controls and set its properties as well as Visiblity
                InitControls()

                If Not Page.IsPostBack Then
                    SetIconBar()

                    'BindOfficeOverride()
                    BindManagerOverride()

                    With ddlOfficeOwner
                        '.DataSource = (New Business.DispatchsController).GetAllInterOffices
                        '.DataValueField = "JRCIOfficeCode"
                        '.DataTextField = "IOName"
                        '.DataBind()
                        Dim valfld, txtfld As String
                        Dim dr As IDataReader = (New Business.DispatchsController).GetAllInterOffices

                        .Items.Clear()
                        While dr.Read
                            valfld = dr("JRCIOfficeCode").ToString
                            txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                            txtfld = Replace(txtfld, "JRC ", "")
                            .Items.Add(New ListItem(txtfld.ToUpper, valfld))
                        End While
                    End With 'ddlOfficeOwner

                    Dim arrAvailable As ArrayList = (New Business.DispatchIOsController).GetIOsByDispatcher()
                    Dim objNA_IO As Business.DispatchIOInfo = arrAvailable(0)
                    If objNA_IO.IOName.Contains("N/A") Then arrAvailable.Remove(objNA_IO)

                    'ctlDispatchIOs.Available = arrAvailable
                    ctlDispatchIOs.Available.Clear()
                    For Each liAvailable As Business.DispatchIOInfo In arrAvailable
                        If Not liAvailable.IOName.ToUpper.Contains("N/A") Then
                            ctlDispatchIOs.Available.Add(liAvailable)
                        End If
                    Next liAvailable 'As DispatchIOInfo In arrAssigned
                    'For Each liAvailable As Business.DispatchIOInfo In ctlDispatchIOs.Available
                    '    If liAvailable.IOName.Contains("N/A") Then
                    '        ctlDispatchIOs.Available.Remove(liAvailable)
                    '    End If
                    'Next liAvailable 'As DispatchIOInfo In arrAssigned

                    If Not Null.IsNull(itemId) Then
                        Dim objDispatch As DispatchInfo = (New DispatchsController).GetDispatch(itemId)

                        If Not objDispatch Is Nothing Then
                            'Load data
                            ItemToPage(objDispatch)

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

                            'Populate Portals ddl
                            Dim myPortals As ArrayList = (New DotNetNuke.Entities.Portals.PortalController).GetPortals
                            If Not myPortals Is Nothing Then
                                ddlPortals.Items.Clear()
                                For Each myPortal As DotNetNuke.Entities.Portals.PortalInfo In myPortals
                                    ddlPortals.Items.Add(New ListItem(myPortal.PortalName, myPortal.PortalID.ToString))
                                Next myPortal
                                Try
                                    ddlPortals.Items.FindByValue(PortalId.ToString).Selected = True
                                Catch
                                End Try
                            End If

                            btnRoles_Click(Nothing, Nothing)

                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If

                    End If
                End If
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub imbAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAdd.Click
            cmdAdd_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            'If (New Business.DispatchsController).IsUniqueCode(txtDispatchCode.Text) Then
            '    cmdUpdate_Click(sender, New EventArgs)
            'Else
            '    DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "DispatchCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            '    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "DispatchCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            'End If

            If (New Business.DispatchsController).IsUniqueCode(txtDispatchCode.Text) Then
                cmdUpdate_Click(Nothing, Nothing)
                'Controls.Add(objOI.Popup("Success", "New Dispatch with Dispatch Code " & txtDispatchCode.Text & " added successfully", "New Dispatch with Dispatch Code " & txtDispatchCode.Text & " added successfully in the Database."))
                lblMsg.Text = "<font color='green'>Success<br/>New Dispatch with Dispatch Code " & txtDispatchCode.Text & " added successfully</font>"
            Else
                'Controls.Add(objOI.Popup("Failure", "Dispatch with Dispatch Code " & txtDispatchCode.Text & " already exists", "Dispatch with Dispatch Code " & txtDispatchCode.Text & " already exists in the Database. Please choose another Dispatch Code"))
                lblMsg.Text = "<font color='red'>Failure<br/>Dispatch with Dispatch Code " & txtDispatchCode.Text & " already exists in the Database. Please choose another Dispatch Code</font>"
                DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "DispatchCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "DispatchCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If

        End Sub

        Private Sub imbUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdate.Click ', imbAdd.Click
            cmdUpdate_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click ', cmdAdd.Click
            Try
                ' Only Update if the Entered Data is Valid
                If Page.IsValid Then
                    'Dim objDispatch As New DispatchInfo
                    ''Initialise the ojbDispatch object
                    'objDispatch = CType(CBO.InitializeObject(objDispatch, GetType(Business.DispatchInfo)), DispatchInfo)

                    'bind text values to object
                    Dim objDispatch As DispatchInfo = PageToItem()


                    Dim objDispatchsController As New DispatchsController
                    If Null.IsNull(itemId) Then
                        itemId = objDispatchsController.AddDispatch(objDispatch)
                        cmdAddUser_Click(Nothing, Nothing)
                    Else
                        objDispatchsController.UpdateDispatch(objDispatch)
                        cmdUpdateUser_Click(Nothing, Nothing)
                    End If

                    If Not btnUpdateIOs.Visible Then btnUpdateIOs_Click(Nothing, Nothing)

                    ' url tracking
                    Dim objUrls As New UrlController
                    ' url tracking for MediaSrc
                    'With ctlMediaSrc
                    '    objUrls.UpdateUrl(PortalId, .Url, .UrlType, .Log, .Track, ModuleId, .NewWindow)
                    'End With 'ctlMediaSrc


                    'Redirect to the page as selected by the User in DropdownList
                    Select Case ddlUpdateRedirection.SelectedValue.ToUpper
                        Case "NEWITEM"
                            'Redirect back to the Edit Page of the Item for Add
                            Response.Redirect(EditUrl(), True)
                        Case "EDITITEM"
                            'Redirect back to this same Edit Page with same ItemId to Edit & Continue
                            Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
                        Case "ITEMDETAILS"
                            'Redirect to the Detail Page of this Item for Viewing the details of this Item
                            Response.Redirect(EditUrl("ItemId", itemId.ToString, "ItemDetails"), True)
                        Case Else '"LISTING"
                            'Redirect back to the portal home page
                            Response.Redirect(NavigateURL(), True)
                    End Select
                End If
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
            cmdCancel_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            'Redirect to the page as selected by the User in DropdownList
            Select Case ddlUpdateRedirection.SelectedValue.ToUpper
                Case "NEWITEM"
                    'Redirect back to the Edit Page of the Item for Add
                    Response.Redirect(EditUrl(), True)
                Case "EDITITEM"
                    If Not Null.IsNull(itemId) Then
                        'Redirect back to this same Edit Page with same ItemId to Edit & Continue
                        Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
                    Else
                        'Redirect back to the Edit Page of the Item for Add
                        Response.Redirect(EditUrl(), True)
                    End If
                Case "ITEMDETAILS"
                    If Not Null.IsNull(itemId) Then
                        'Redirect to the Detail Page of this Item for Viewing the details of this Item
                        Response.Redirect(EditUrl("ItemId", itemId.ToString, "ItemDetails"), True)
                    Else
                        'Redirect back to the portal home page
                        Response.Redirect(NavigateURL(), True)
                    End If
                Case Else '"LISTING"
                    'Redirect back to the portal home page
                    Response.Redirect(NavigateURL(), True)
            End Select
        End Sub

        Private Sub imbDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbDelete.Click
            cmdDelete_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
            Try
                If Not Null.IsNull(itemId) Then
                    Dim objDispatchsController As New DispatchsController
                    objDispatchsController.DeleteDispatch(itemId)
                End If

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub btnRoles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoles.Click
            Try
                'Dim Roles As Array
                'Dim Role As String
                'Dim User As UserInfo = (New UserController).GetUserByName(PortalId, txtDispatchCode.Text)
                'If Not User Is Nothing Then
                '    tdUserAndRoles.InnerHtml = "<b>" & User.DisplayName & "</b><br />[" & User.Username & " (" & User.UserID & ")]"
                '    Roles = (New DotNetNuke.Security.Roles.RoleController).GetRolesByUser(User.UserID, PortalId)
                '    If Not Roles Is Nothing Then
                '        tdUserAndRoles.InnerHtml &= "<ol>"
                '        For Each Role In Roles
                '            tdUserAndRoles.InnerHtml &= "<li>" & Role & "</li>"
                '        Next Role
                '        tdUserAndRoles.InnerHtml &= "</ol>"
                '    End If

                'End If

                'tdUserAndRoles.InnerHtml &= "<p><b>" & PortalSettings.PortalName & "</b> (" & PortalId & ")"
                'Dim pRole As DotNetNuke.Security.Roles.RoleInfo
                'Dim pRoles As ArrayList = (New DotNetNuke.Security.Roles.RoleController).GetPortalRoles(PortalId)

                'If Not pRoles Is Nothing Then
                '    tdUserAndRoles.InnerHtml &= "<ol>"
                '    For Each pRole In pRoles
                '        If (Roles.IndexOf(Roles, pRole.RoleName) > -1) Then
                '            tdUserAndRoles.InnerHtml &= "<li><font color=""green"">" & pRole.RoleName & "</font></li>"
                '        Else
                '            tdUserAndRoles.InnerHtml &= "<li><font color=""red"">" & pRole.RoleName & "</font></li>"
                '        End If
                '    Next pRole
                '    tdUserAndRoles.InnerHtml &= "</ol>"
                'End If

                'tdUserAndRoles.InnerHtml &= "</p>"

                'Dim myPortals As ArrayList = (New DotNetNuke.Entities.Portals.PortalController).GetPortals
                'If Not myPortals Is Nothing Then
                '    Dim myPortal As DotNetNuke.Entities.Portals.PortalInfo
                '    cblUserAndRoles.Items.Clear()
                '    For Each myPortal In myPortals

                'JrcUser = UserController.GetUserByName(Integer.Parse(ddlPortals.SelectedValue), txtDispatchCode.Text)

                Dim User As Users.UserInfo = Users.UserController.GetUserByName(Integer.Parse(ddlPortals.SelectedValue), txtDispatchCode.Text)
                cmdAddUser.Visible = User Is Nothing
                imbAddUser.Visible = cmdAddUser.Visible
                txtDispatchCode.ReadOnly = Not cmdAddUser.Visible
                trStatus.Visible = txtDispatchCode.ReadOnly
                'tblJrcOffices.Visible = txtDispatchCode.ReadOnly

                If Not User Is Nothing Then
                    'JrcUser = User
                    txtEmail.Text = User.Membership.Email.ToLower

                    chkStatus.Checked = User.Membership.Approved

                    tdUserAndRoles.InnerHtml = "<b>" & User.DisplayName & "</b><br />[" & User.Username & " (" & User.UserID & ")]<br />"
                    tdUserAndRoles.InnerHtml &= "<p><b>" & ddlPortals.SelectedItem.Text & "</b> (" & ddlPortals.SelectedValue & ")<br />"

                    Dim Roles As Array = (New DotNetNuke.Security.Roles.RoleController).GetRolesByUser(User.UserID, Integer.Parse(ddlPortals.SelectedValue))
                    Dim Role As String

                    Dim pRoles As ArrayList = (New DotNetNuke.Security.Roles.RoleController).GetPortalRoles(Integer.Parse(ddlPortals.SelectedValue))
                    Dim pRole As DotNetNuke.Security.Roles.RoleInfo
                    Dim eRoles As String() = New String() {"Administrators", "Registered Users", "Subscribers"}

                    'Dim cblUserAndRoles As New CheckBoxList
                    cblUserAndRoles.Items.Clear()
                    'Dim li As ListItem
                    If Not pRoles Is Nothing Then
                        For Each pRole In pRoles
                            If Array.IndexOf(eRoles, pRole.RoleName) < 0 Then
                                'cblUserAndRoles.Items.Add(pRole.RoleName)
                                cblUserAndRoles.Items.Add(New ListItem(pRole.RoleName, pRole.RoleID.ToString))
                            End If

                        Next pRole
                    End If

                    If Not Roles Is Nothing Then
                        For Each Role In Roles
                            Try
                                cblUserAndRoles.Items.FindByText(Role).Selected = True
                            Catch
                            End Try
                        Next Role
                    End If
                    'tdUserAndRoles.Controls.Add(cblUserAndRoles)
                Else
                    chkStatus.Checked = True
                    tdUserAndRoles.InnerHtml = "No such DNN User<br/>with Username<br/><b>" & txtDispatchCode.Text & "</b>"
                End If
                '    Next myPortal
                'End If 'Not myPortals is Nothing

                'Dim Roles As Array
                'Dim Role As String
                'Dim Users As ArrayList = (New UserController).GetUsers(PortalId)
                'Dim User As UserInfo
                'Dim myPortals As ArrayList = (New DotNetNuke.Entities.Portals.PortalController).GetPortals
                'Dim myPortal As DotNetNuke.Entities.Portals.PortalInfo
                'tdUserAndRoles.InnerHtml = String.Empty

                'If Not myPortals Is Nothing Then
                '    For Each myPortal In myPortals
                '        tdUserAndRoles.InnerHtml &= "<p><font color=""blue""><b>" & myPortal.PortalID & ": " & myPortal.PortalName & "</b></font></p>"

                '    Next myPortal
                'End If

                'If Not Users Is Nothing Then
                '    'tdUserAndRoles.InnerHtml = String.Empty
                '    For Each User In Users
                '        Roles = (New DotNetNuke.Security.Roles.RoleController).GetRolesByUser(User.UserID, PortalId)
                '        tdUserAndRoles.InnerHtml &= "<p><b>" & User.UserID & ": " & User.DisplayName & "</b>"
                '        If Not Roles Is Nothing Then
                '            For Each Role In Roles
                '                tdUserAndRoles.InnerHtml &= "<br>" & Role
                '            Next Role
                '        End If
                '        tdUserAndRoles.InnerHtml &= "</p>"
                '    Next User
                'End If
            Catch
                'Catch ex As Exception
                '    ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub chkSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
            For Each li As ListItem In cblUserAndRoles.Items
                li.Selected = chkSelectAll.Checked
            Next li
        End Sub

        Private Sub btnUpdateRoles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateRoles.Click
            Dim User As Users.UserInfo = Users.UserController.GetUserByName(Integer.Parse(ddlPortals.SelectedValue), txtDispatchCode.Text)
            Dim objRC As New DotNetNuke.Security.Roles.RoleController
            Dim Roles As Array = objRC.GetRolesByUser(User.UserID, Integer.Parse(ddlPortals.SelectedValue))
            'Dim Role As String

            For Each li As ListItem In cblUserAndRoles.Items
                If li.Selected Then
                    'If Not User.IsInRole(li.Text) Then
                    If Array.IndexOf(Roles, li.Text) < 0 Then
                        'Add this pRole to the UserRoles
                        objRC.AddUserRole(Integer.Parse(ddlPortals.SelectedValue), User.UserID, Integer.Parse(li.Value), #1/1/2039#)
                        tdUserAndRoles.InnerHtml &= "<br /><font color=""green""> Added " & li.Text & " to " & User.DisplayName & "</font>"
                    End If
                Else
                    'If User.IsInRole(li.Text) Then
                    If Array.IndexOf(Roles, li.Text) > -1 Then
                        'Remove this pRole from the UserRoles
                        objRC.DeleteUserRole(Integer.Parse(ddlPortals.SelectedValue), User.UserID, Integer.Parse(li.Value))
                        tdUserAndRoles.InnerHtml &= "<br /><font color=""red""> Removed " & li.Text & " from " & User.DisplayName & "</font>"
                    End If
                End If
            Next li

        End Sub

        Private Sub imbAddUser_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAddUser.Click
            cmdAddUser_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdAddUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddUser.Click
            Dim UserStatus As DotNetNuke.Security.Membership.UserCreateStatus = CreateDnnUser()
            btnRoles_Click(Nothing, Nothing)
            Select Case UserStatus
                Case DotNetNuke.Security.Membership.UserCreateStatus.Success
                    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, UserStatus.ToString, DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)
                Case DotNetNuke.Security.Membership.UserCreateStatus.UserAlreadyRegistered
                    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, UserStatus.ToString, DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning)
                Case Else
                    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, UserStatus.ToString, DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End Select
        End Sub

        Private Sub imbUpdateUser_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateUser.Click
            cmdUpdateUser_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdUpdateUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdateUser.Click
            Dim User As Users.UserInfo = Users.UserController.GetUserByName(Integer.Parse(ddlPortals.SelectedValue), txtDispatchCode.Text)
            If Not User Is Nothing Then
                With User
                    '.PortalID = PortalId
                    '.Username = txtDispatchCode.Text
                    .FirstName = txtDispatchName.Text
                    .LastName = txtDispatchCode.Text
                    '.FullName = txtDispatchName.Text
                    .DisplayName = txtDispatchName.Text
                    .Email = IIf(txtEmail.Text <> String.Empty, txtEmail.Text, txtDispatchCode.Text & "@jrctransportation.com").ToString.ToLower

                    .Profile.FirstName = .FirstName
                    .Profile.LastName = .LastName

                    .Membership.Username = .Username
                    '.Membership.Password = txtDispPassw.Text
                    '.Membership.CreatedDate = Now
                    .Membership.Email = .Email

                    .Membership.Approved = chkStatus.Checked
                End With 'objUI
                'Dim objUC As UserController = New UserController
                Users.UserController.UpdateUser(PortalId, User)
            End If

            cmdUpdatePassword_Click(Nothing, Nothing)
        End Sub

        Private Sub cmdUpdatePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdatePassword.Click

            ''1. Check New Password and Confirm are the same
            'If txtNewPassword.Text <> txtNewConfirm.Text Then
            '    OnPasswordUpdated(New PasswordUpdatedEventArgs(PasswordUpdateStatus.PasswordMismatch))
            '    Exit Sub
            'End If

            ''2. Check New Password is Valid
            'If Not UserController.ValidatePassword(txtNewPassword.Text) Then
            '    OnPasswordUpdated(New PasswordUpdatedEventArgs(PasswordUpdateStatus.PasswordInvalid))
            '    Exit Sub
            'End If

            ''3. Check old Password is Provided
            'If Not IsAdmin And txtOldPassword.Text = "" Then
            '    OnPasswordUpdated(New PasswordUpdatedEventArgs(PasswordUpdateStatus.PasswordMissing))
            '    Exit Sub
            'End If

            ''4. Check New Password is ddifferent
            'If Not IsAdmin And txtNewPassword.Text = txtOldPassword.Text Then
            '    OnPasswordUpdated(New PasswordUpdatedEventArgs(PasswordUpdateStatus.PasswordNotDifferent))
            '    Exit Sub
            'End If

            'Try and set password
            'If IsUser Then
            '    oldPassword = txtOldPassword.Text
            'End If
            Dim User As Users.UserInfo = Users.UserController.GetUserByName(Integer.Parse(ddlPortals.SelectedValue), txtDispatchCode.Text)
            If User Is Nothing Then
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "DNN User '" & txtDispatchCode.Text & "' not Found", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            Else
                If Users.UserController.ChangePassword(User, oldPassword, txtDispPassw.Text) Then
                    'Success
                    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Password for DNN User '" & txtDispatchCode.Text & "' updated Successfully", Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)
                Else
                    'Fail
                    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Error in updating Password for DNN User '" & txtDispatchCode.Text & "'", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                End If
            End If

        End Sub

        Private Sub chkStatus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
            Dim User As Users.UserInfo = Users.UserController.GetUserByName(Integer.Parse(ddlPortals.SelectedValue), txtDispatchCode.Text)
            If Not User Is Nothing Then
                User.Membership.Approved = chkStatus.Checked

                'Update User
                Users.UserController.UpdateUser(PortalId, User)
                If User.Membership.Approved Then
                    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Successfully updated the Status to 'Active'", Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)
                Else
                    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Successfully updated the Status to 'In-Active'", Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)
                End If
                'DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Successfully updated the Status as " & User.Membership.Approved.ToString, Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)

                'OnMembershipAuthorized(EventArgs.Empty)
            End If

        End Sub

        Private Sub btnUpdateIOs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateIOs.Click
            Dim objDispatchIOsController As New Business.DispatchIOsController
            Dim arrExisting As ArrayList = objDispatchIOsController.GetIOsByDispatcher
            Dim IO As Business.DispatchIOInfo

            'Delete the un-Assigned IOs
            For Each IO In arrExisting
                If ctlDispatchIOs.Assigned.IndexOf(IO) < 0 Then objDispatchIOsController.DeleteDispatchIO(itemId, IO.InterOfficeId)
            Next IO 'In arrExisting

            'Add the Assigned IOs
            For Each LI As ListItem In ctlDispatchIOs.Assigned
                objDispatchIOsController.AddDispatchIO(itemId, Integer.Parse(LI.Value))
            Next LI 'As ListItem In ctlDispatchIOs.Assigned

            'Add the default IO of the dispatcher
            Try
                Dim IOId As Integer = objDispatchIOsController.GetInterOfficeId(ddlOfficeOwner.SelectedValue)
                If IOId > 0 Then objDispatchIOsController.AddDispatchIO(itemId, IOId)
            Catch
            End Try

        End Sub


#End Region


    End Class 'EditItem

End Namespace 'bhattji.Modules.Dispatchs
