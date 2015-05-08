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
Imports bhattji.Modules.Brokers.Business
'Imports Microsoft.ScalableHosting.Security
'Imports AspNetSecurity = Microsoft.ScalableHosting.Security

#End Region

Namespace bhattji.Modules.Brokers

    Public MustInherit Class EditItem
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "
        Private itemId As Integer
        Private objOI As OptionsInfo
#End Region

#Region " Public Methods "

        Private Sub ItemToPage(ByVal ItemId As Integer)
            If Not Null.IsNull(ItemId) Then 'Check for the Not-Null ItemId
                Dim objBroker As Business.BrokerInfo = (New Business.BrokersController).GetBroker(ItemId)
                'Check for the Not-Null objBroker
                If Not objBroker Is Nothing Then ItemToPage(objBroker)
            End If
        End Sub

        Private Sub ItemToPage(ByVal objBroker As Business.BrokerInfo)
            'Load objBroker data to the Page
            With objBroker
                txtBrokerCode.Text = .BrokerCode
                If Not Users.UserController.GetCurrentUserInfo.IsInRole("acct_num_update") Then
                    txtBrokerCode.ReadOnly = True
                    txtBrokerCode.CssClass = "NormalBold"
                    txtBrokerCode.Style.Add(HtmlTextWriterStyle.BorderWidth, "0")
                End If
                txtBrokerName.Text = .BrokerName
                txtAddressLine1.Text = .AddressLine1
                txtAddressLine2.Text = .AddressLine2
                txtCity.Text = .City
                'txtState.Text = .State
                Try
                    ddlStateCode.SelectedValue = .State.ToUpper
                Catch
                End Try
                txtZipCode.Text = .ZipCode
                txtPhoneNo.Text = .PhoneNo
                txtExt.Text = .Ext
                txtContactCode.Text = .ContactCode
                txtVendorRef.Text = .VendorRef.ToUpper
                If Not Users.UserController.GetCurrentUserInfo.IsInRole("acct_num_update") Then
                    txtVendorRef.ReadOnly = True
                    txtVendorRef.CssClass = "NormalBold"
                    txtVendorRef.Style.Add(HtmlTextWriterStyle.BorderWidth, "0")
                End If
                txtCountryCode.Text = .CountryCode
                txtEmailAddress.Text = .EmailAddress
                If Not Null.IsNull(.CommRate) Then
                    txtCommRate.Text = .CommRate.ToString
                End If

                chkStatus.Checked = (.Status.ToUpper = "Y")
                txtLoadType.Text = .LoadType
                txtFavorite.Text = .Favorite
                txtSortSeq.Text = .SortSeq
                txtBrokerNotes.Text = .BrokerNotes
                txtBkrType.Text = .BkrType
                If Not Null.IsNull(.CorpUpd) Then
                    txtCorpUpd.Text = .CorpUpd.ToShortDateString
                End If
                If .Division = "" Then
                    txtDivision.Text = "JRC"
                Else
                    txtDivision.Text = .Division
                End If
                txtFaxNo.Text = .FaxNo
                txtJRCTrailer.Text = .JRCTrailer

                chkAdminExempt.Checked = (.AdminExempt.ToUpper = "Y")
                'chkBStatus.Checked = (.BStatus.ToUpper = "ACTIVE")
                Try
                    If .BStatus <> "" Then ddlBStatus.SelectedValue = .BStatus
                Catch
                End Try
                chkThirdPartyOK.Checked = (.ThirdPartyOK.ToUpper = "Y")

                If Not Null.IsNull(.TPPct) Then
                    txtTPPct.Text = .TPPct.ToString
                End If
                If Not Null.IsNull(.TPAmt) Then
                    txtTPAmt.Text = .TPAmt.ToString
                End If

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
            End With 'objBroker

        End Sub

        Private Function PageToItem() As BrokerInfo
            Dim objBroker As New BrokerInfo
            'Initialise the ojbBroker object
            objBroker = CType(CBO.InitializeObject(objBroker, GetType(Business.BrokerInfo)), BrokerInfo)

            'bind text values to object
            With objBroker
                .ItemId = itemId
                .ModuleId = ModuleId

                .BrokerCode = txtBrokerCode.Text
                .BrokerName = txtBrokerName.Text
                .AddressLine1 = txtAddressLine1.Text
                .AddressLine2 = txtAddressLine2.Text
                .City = txtCity.Text
                '.State = txtState.Text
                .State = ddlStateCode.SelectedValue
                .ZipCode = txtZipCode.Text
                .PhoneNo = txtPhoneNo.Text
                .Ext = txtExt.Text
                .ContactCode = txtContactCode.Text
                .VendorRef = txtVendorRef.Text.ToUpper
                .CountryCode = txtCountryCode.Text
                .EmailAddress = txtEmailAddress.Text
                Try
                    .CommRate = Double.Parse(txtCommRate.Text)
                Catch
                End Try
                If chkAdminExempt.Checked Then
                    .AdminExempt = "Y"
                Else
                    .AdminExempt = "N"
                End If
                'If chkBStatus.Checked Then
                '    .BStatus = "ACTIVE"
                'Else
                '    .BStatus = "INACTIVE"
                'End If
                .BStatus = ddlBStatus.SelectedValue.ToUpper

                chkStatus.Checked = (.BStatus = "ACTIVE") 'chkBStatus.Checked 'Copy the Status since Status is Hidden
                If chkStatus.Checked Then
                    .Status = "Y"
                Else
                    .Status = "N"
                End If

                .LoadType = txtLoadType.Text
                .Favorite = txtFavorite.Text
                .SortSeq = txtSortSeq.Text
                .BrokerNotes = txtBrokerNotes.Text
                .BkrType = txtBkrType.Text
                Try
                    .CorpUpd = Date.Parse(txtCorpUpd.Text)
                Catch
                End Try
                If txtDivision.Text = "" Then txtDivision.Text = "JRC"
                .Division = txtDivision.Text
                .FaxNo = txtFaxNo.Text
                .JRCTrailer = txtJRCTrailer.Text
                If chkThirdPartyOK.Checked Then
                    .ThirdPartyOK = "Y"
                Else
                    .ThirdPartyOK = "N"
                End If
                Try
                    .TPPct = Double.Parse(txtTPPct.Text)
                Catch
                End Try
                Try
                    .TPAmt = Double.Parse(txtTPAmt.Text)
                Catch
                End Try

                If txtViewOrder.Text <> String.Empty Then
                    Try
                        .ViewOrder = Integer.Parse(txtViewOrder.Text)
                    Catch
                    End Try
                End If

                'Audit Control
                .UpdatedByUserId = UserInfo.UserID
                .CreatedByUserId = .UpdatedByUserId

            End With 'objBroker
            Return objBroker
        End Function

        Private Sub InitControls()

            'cmdDelete.Visible = Not Null.IsNull(itemId)
            'imbDelete.Visible = cmdDelete.Visible
            'cmdUpdate.Visible = cmdDelete.Visible
            'imbUpdate.Visible = cmdUpdate.Visible
            'cmdAdd.Visible = Not cmdUpdate.Visible
            'imbAdd.Visible = cmdAdd.Visible

            'cvBrokerCode.Visible = cmdAdd.Visible
            'cvVendorRef.Visible = cmdAdd.Visible

            'this needs to execute always to the client script code is registred in InvokePopupCal
            'cmdCalendarCorpUpd.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtCorpUpd)

            If Not Page.IsPostBack Then
                BindStateCodes()

                SetIconBar()
            End If
        End Sub
        Sub BindStateCodes()
            With ddlStateCode
                '.DataValueField = "StateCode"
                '.DataTextField = "StateCode" '"State"
                .DataSource = (New BrokersController).GetStateCodes
                .DataBind()

                .Items.Insert(0, New ListItem("", ""))
            End With 'ddlStateCode
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

            cvBrokerCode.Visible = cmdAdd.Visible
            cvVendorRef.Visible = cmdAdd.Visible

            If tdDelete.Visible Then tdDelete.Visible = Users.UserController.GetCurrentUserInfo.IsInRole("Administrators")
            If tdDelete.Visible Then
                cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                imbDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
            End If
        End Sub 'SetIconBar()

      
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
                    'SetIconBar()
                    'Bind the Categories
                    'BindCategories()

                    If Not Null.IsNull(itemId) Then
                        Dim objBroker As BrokerInfo = (New BrokersController).GetBroker(itemId)

                        If Not objBroker Is Nothing Then
                            'Load data
                            ItemToPage(objBroker)

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
            cmdAdd_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            'If (New Business.BrokersController).IsUniqueCode(txtBrokerCode.Text) Then
            '    cmdUpdate_Click(sender, New EventArgs)
            'Else
            '    DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "BrokerCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            '    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "BrokerCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            'End If

            If (New Business.BrokersController).IsUniqueVendorRef(txtVendorRef.Text) Then
                If (New Business.BrokersController).IsUniqueCode(txtBrokerCode.Text) Then
                    cmdUpdate_Click(Nothing, Nothing)
                    'Controls.Add(objOI.Popup("Success", "New Broker with Broker Code " & txtBrokerCode.Text & " added successfully", "New Broker with Broker Code " & txtBrokerCode.Text & " added successfully in the Database."))
                    lblMsg.Text = "<font color='green'>Success<br/>New Broker with Broker Code " & txtBrokerCode.Text & " & VendorRef " & txtVendorRef.Text & " added successfully in the Database</font>"
                Else
                    'Controls.Add(objOI.Popup("Failure", "Broker with Broker Code " & txtBrokerCode.Text & " already exists", "Broker with Broker Code " & txtBrokerCode.Text & " already exists in the Database. Please choose another Broker Code"))
                    lblMsg.Text = "<font color='red'>Failure<br/>Broker with Broker Code " & txtBrokerCode.Text & " already exists in the Database. Please choose another Broker Code</font>"
                    DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "BrokerCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "BrokerCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                End If
            Else
                'Controls.Add(objOI.Popup("Failure", "Broker with Broker Code " & txtBrokerCode.Text & " already exists", "Broker with Broker Code " & txtBrokerCode.Text & " already exists in the Database. Please choose another Broker Code"))
                lblMsg.Text = "<font color='red'>Failure<br/>Broker with VendorRef Code " & txtVendorRef.Text & " already exists in the Database. Please choose another VendorRef Code</font>"
                DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "VendorRef must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "VendorRef must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If

        End Sub

        Private Sub imbUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdate.Click ', imbAdd.Click
            cmdUpdate_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click ', cmdAdd.Click
            Try
                ' Only Update if the Entered Data is Valid
                If Page.IsValid Then
                    'Dim objBroker As New BrokerInfo
                    ''Initialise the ojbBroker object
                    'objBroker = CType(CBO.InitializeObject(objBroker, GetType(Business.BrokerInfo)), BrokerInfo)

                    'bind text values to object
                    Dim objBroker As BrokerInfo = PageToItem()


                    Dim objBrokersController As New BrokersController
                    If Null.IsNull(itemId) Then
                        itemId = objBrokersController.AddBroker(objBroker)
                    Else
                        objBrokersController.UpdateBroker(objBroker)
                    End If

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
           cmdCancel_Click(sender, New EventArgs)
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
            cmdDelete_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
            Try
                If Not Null.IsNull(itemId) Then
                    Dim objBrokersController As New BrokersController
                    objBrokersController.DeleteBroker(itemId)
                End If

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

    End Class 'EditItem

End Namespace 'bhattji.Modules.Brokers
