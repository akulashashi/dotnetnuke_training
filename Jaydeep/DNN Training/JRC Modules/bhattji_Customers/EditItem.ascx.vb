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
Imports bhattji.Modules.Customers.Business
'Imports Microsoft.ScalableHosting.Security
'Imports AspNetSecurity = Microsoft.ScalableHosting.Security

#End Region

Namespace bhattji.Modules.Customers

    Public MustInherit Class EditItem
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "
        Private itemId As Integer
        Private objOI As OptionsInfo
#End Region

#Region " Public Methods "
        Private Sub ItemToPage(ByVal ItemId As Integer)
            If Not Null.IsNull(ItemId) Then 'Check for the Not-Null ItemId
                Dim objCustomer As Business.CustomerInfo = (New Business.CustomersController).GetCustomer(ItemId)
                'Check for the Not-Null objCustomer
                If Not objCustomer Is Nothing Then ItemToPage(objCustomer)
            End If
        End Sub

        Private Sub ItemToPage(ByVal objCustomer As Business.CustomerInfo)
            'Load objCustomer data to the Page
            With objCustomer

                Dim I As Integer

                txtCustomerNumber.Text = .CustomerNumber
                If Not Users.UserController.GetCurrentUserInfo.IsInRole("acct_num_update") Then
                    txtCustomerNumber.ReadOnly = True
                    txtCustomerNumber.CssClass = "NormalBold"
                    txtCustomerNumber.Style.Add(HtmlTextWriterStyle.BorderWidth, "0")
                End If

                txtCustomerName.Text = .CustomerName
                txtAddressLine1.Text = .AddressLine1
                txtAddressLine2.Text = .AddressLine2
                txtAddressLine3.Text = .AddressLine3
                txtCity.Text = .City
                'txtState.Text = .State
                Try
                    ddlStateCode.SelectedValue = .State.ToUpper
                Catch
                End Try
                txtZipCode.Text = .ZipCode
                txtPhoneNumber.Text = .PhoneNumber
                txtExt.Text = .Extension
                txtFaxNumber.Text = .FaxNumber
                txtContactCode.Text = .ContactCode
                txtBillingInfo.Text = .BillingInfo
                txtFavor.Text = .Favor
                Try
                    ddlRepNo.Items.FindByValue(.RepNo).Selected = True
                Catch
                End Try
                txtRepName.Text = .RepName
                txtSortSeq.Text = .SortSeq

                If Not Null.IsNull(.RepDlr) AndAlso (.RepDlr > 0) Then
                    txtRepDlr.Text = .RepDlr.ToString
                End If
                If Not Null.IsNull(.RepPct) AndAlso (.RepPct > 0) Then
                    txtRepPct.Text = .RepPct.ToString
                End If
                Try
                    ddlCowner.Items.FindByValue(.Cowner).Selected = True
                Catch
                End Try
                'txtCowner.Text = .Cowner
                If Not Null.IsNull(.CorpUpd) Then
                    txtCorpUpd.Text = .CorpUpd.ToShortDateString
                End If
                txtDivision.Text = .Division
                txtOldCustNo.Text = .OldCustNo
                txtGSMStatus.Text = .GSMStatus
                I = ddlCustomerStatus.Items.IndexOf(ddlCustomerStatus.Items.FindByValue(.CustomerStatus.ToString))
                If I > -1 Then
                    ddlCustomerStatus.Items(I).Selected = True
                Else
                    ddlCustomerStatus.Items(0).Selected = True
                End If
                I = ddlCStatus.Items.IndexOf(ddlCStatus.Items.FindByValue(.CStatus.ToString))
                If I > -1 Then
                    ddlCStatus.Items(I).Selected = True
                Else
                    ddlCStatus.Items(0).Selected = True
                End If
                txtMCNO.Text = .MCNO
                txtWhoDoneIT.Text = .WhoDoneIT


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

                ctlTracking.ModuleID = .ModuleId
            End With 'objCustomer

        End Sub

        Private Function PageToItem() As CustomerInfo
            Dim objCustomer As New CustomerInfo
            'Initialise the ojbCustomer object
            objCustomer = CType(CBO.InitializeObject(objCustomer, GetType(Business.CustomerInfo)), CustomerInfo)

            'bind text values to object
            With objCustomer
                .ItemId = itemId
                .ModuleId = ModuleId

                .CustomerNumber = txtCustomerNumber.Text
                .CustomerName = txtCustomerName.Text
                .AddressLine1 = txtAddressLine1.Text
                .AddressLine2 = txtAddressLine2.Text
                .AddressLine3 = txtAddressLine3.Text
                .City = txtCity.Text
                '.State = txtState.Text
                .State = ddlStateCode.SelectedValue
                .ZipCode = txtZipCode.Text
                .PhoneNumber = txtPhoneNumber.Text
                .Extension = txtExt.Text
                .FaxNumber = txtFaxNumber.Text
                .ContactCode = txtContactCode.Text
                .BillingInfo = txtBillingInfo.Text
                .Favor = txtFavor.Text
                .RepNo = ddlRepNo.SelectedValue
                '.RepName = txtRepName.Text
                .RepName = ddlRepNo.SelectedItem.Text
                .SortSeq = txtSortSeq.Text

                If txtRepPct.Text <> String.Empty Then
                    Try
                        .RepPct = Decimal.Parse(txtRepPct.Text)
                    Catch
                        .RepPct = 0
                    End Try
                Else
                    .RepPct = 0
                End If

                If txtRepDlr.Text <> String.Empty Then
                    Try
                        .RepDlr = Decimal.Parse(txtRepDlr.Text)
                    Catch
                        .RepDlr = 0
                    End Try
                Else
                    .RepDlr = 0
                End If

                .Cowner = ddlCowner.SelectedValue 'txtCowner.Text
                Try
                    .CorpUpd = Date.Parse(txtCorpUpd.Text)
                Catch
                End Try
                .Division = txtDivision.Text
                .OldCustNo = txtOldCustNo.Text
                .GSMStatus = txtGSMStatus.Text
                .CustomerStatus = ddlCustomerStatus.SelectedValue
                .CStatus = ddlCStatus.SelectedValue
                .MCNO = txtMCNO.Text
                .WhoDoneIT = txtWhoDoneIT.Text

                If txtViewOrder.Text <> String.Empty Then
                    Try
                        .ViewOrder = Integer.Parse(txtViewOrder.Text)
                    Catch
                    End Try
                End If

                'Audit Control
                .UpdatedByUserId = UserInfo.UserID
                .CreatedByUserId = .UpdatedByUserId

            End With 'objCustomer
            Return objCustomer
        End Function

        Private Sub InitControls()

            'cmdDelete.Visible = Not Null.IsNull(itemId)
            'imbDelete.Visible = cmdDelete.Visible
            'cmdUpdate.Visible = cmdDelete.Visible
            'imbUpdate.Visible = cmdUpdate.Visible
            'cmdAdd.Visible = Not cmdUpdate.Visible
            'imbAdd.Visible = cmdAdd.Visible

            'cvCustomerNumber.Visible = cmdAdd.Visible


            ''this needs to execute always to the client script code is registred in InvokePopupCal
            'cmdCalendarCorpUpd.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtCorpUpd)
            If Not Page.IsPostBack Then
                BindRepNo()
                BindCowner()
                BindStateCodes()

                SetIconBar()
            End If

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

            cvCustomerNumber.Visible = cmdAdd.Visible

            If tdDelete.Visible Then tdDelete.Visible = Users.UserController.GetCurrentUserInfo.IsInRole("Administrators")
            If tdDelete.Visible Then 
                cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                imbDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
            End If
        End Sub 'SetIconBar()
        Sub BindRepNo()
            With ddlRepNo
                .DataSource = (New Business.CustomersController).GetAllSalesReps
                .DataValueField = "RepNo"
                .DataTextField = "RepName"
                .DataBind()
            End With
        End Sub
        Sub BindCowner()
            With ddlCowner
                Dim valfld, txtfld As String
                Dim dr As IDataReader = (New Business.CustomersController).GetAllInterOffices

                .Items.Clear()
                While dr.Read
                    valfld = dr("JRCIOfficeCode").ToString
                    txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                    txtfld = Replace(txtfld, "JRC ", "")
                    .Items.Add(New ListItem(txtfld.ToUpper, valfld))
                End While

            End With

        End Sub

        Sub BindStateCodes()
            With ddlStateCode
                '.DataValueField = "StateCode"
                '.DataTextField = "StateCode" '"State"
                .DataSource = (New CustomersController).GetStateCodes
                .DataBind()

                .Items.Insert(0, New ListItem("", ""))
            End With 'ddlStateCode
        End Sub

     
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
                    If Not Null.IsNull(itemId) Then
                        Dim objCustomer As CustomerInfo = (New CustomersController).GetCustomer(itemId)

                        If Not objCustomer Is Nothing Then
                            'Load data
                            ItemToPage(objCustomer)

                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If

                    End If
                End If
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub txtRepPct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRepPct.TextChanged, txtRepDlr.TextChanged
            If (txtRepPct.Text <> "") AndAlso (txtRepDlr.Text <> "") Then
                txtRepPct.Enabled = True
                txtRepDlr.Enabled = True
                'Controls.Add(objOI.Popup("Failure", "Enter either RepPct or RepDollar only"))
                lblMsg.Text = "<font color='red'>Failure<br/>Enter either RepPct or RepDollar only</font>"
            ElseIf (txtRepPct.Text = "") AndAlso (txtRepDlr.Text = "") Then
                txtRepPct.Enabled = True
                txtRepDlr.Enabled = True
                'Controls.Add(objOI.Popup("Warning", "You have neither selected RepPct nor RepDollar"))
                lblMsg.Text = "<font color='blue'>Warning<br/>You have neither selected RepPct nor RepDollar</font>"
            ElseIf (txtRepPct.Text <> "") Then
                txtRepDlr.Enabled = False
                'Controls.Add(objOI.Popup("Success", "You have selected SalesRepresentative Pct = " & txtRepPct.Text))
                lblMsg.Text = "<font color='green'>Success<br/>You have selected SalesRepresentative Pct = " & txtRepPct.Text & "</font>"
            ElseIf (txtRepDlr.Text <> "") Then
                txtRepPct.Enabled = False
                'Controls.Add(objOI.Popup("Success", "You have selected SalesRepresentative Dollar = " & txtRepDlr.Text))
                lblMsg.Text = "<font color='green'>Success<br/>You have selected SalesRepresentative Dollar = " & txtRepDlr.Text & "</font>"
            End If
        End Sub

        Private Sub ddlRepNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRepNo.SelectedIndexChanged
            Try
                Dim dr As IDataReader = (New CustomersController).GetSalesRep(ddlRepNo.SelectedValue)
                If Not dr Is Nothing Then
                    dr.Read()
                    txtRepPct.Text = dr("RepRate").ToString
                    txtRepDlr.Text = dr("RepDollar").ToString
                End If
            Catch
            End Try
        End Sub

        Private Sub imbAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAdd.Click
            cmdAdd_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            'If (New Business.CustomersController).IsUniqueCode(txtCustomerNumber.Text) Then
            '    cmdUpdate_Click(sender, New EventArgs)
            'Else
            '    DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "CustomerNumber must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            '    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "CustomerNumber must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            'End If


            If (New Business.CustomersController).IsUniqueCode(txtCustomerNumber.Text) Then
                cmdUpdate_Click(Nothing, Nothing)
                'Controls.Add(objOI.Popup("Success", "New Customer with Customer Code " & txtCustomerNumber.Text & " added successfully", "New Customer with Customer Code " & txtCustomerNumber.Text & " added successfully in the Database."))
                lblMsg.Text = "<font color='green'>Success<br/>New Customer with Customer Code " & txtCustomerNumber.Text & " added successfully</font>"
            Else
                'Controls.Add(objOI.Popup("Failure", "Customer with Customer Code " & txtCustomerNumber.Text & " already exists", "Customer with Customer Code " & txtCustomerNumber.Text & " already exists in the Database. Please choose another Customer Code"))
                lblMsg.Text = "<font color='red'>Failure<br/>Customer with Customer Code " & txtCustomerNumber.Text & " already exists in the Database. Please choose another Customer Code</font>"
                DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "CustomerCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "CustomerCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If

        End Sub


        Private Sub imbUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdate.Click ', imbAdd.Click
            cmdUpdate_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click ', cmdAdd.Click
            Try
                ' Only Update if the Entered Data is Valid
                If Page.IsValid Then
                    ' If (New Business.CustomersController).IsUniqueCode(txtCustomerNumber.Text) Then
                    'Dim objCustomer As New CustomerInfo
                    ''Initialise the ojbCustomer object
                    'objCustomer = CType(CBO.InitializeObject(objCustomer, GetType(Business.CustomerInfo)), CustomerInfo)

                    'bind text values to object
                    Dim objCustomer As CustomerInfo = PageToItem()


                    Dim objCustomersController As New CustomersController
                    If Null.IsNull(itemId) Then
                        itemId = objCustomersController.AddCustomer(objCustomer)
                    Else
                        objCustomersController.UpdateCustomer(objCustomer)
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
                    'Else
                    '    DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                    '    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                    'End If

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
                    Dim objCustomersController As New CustomersController
                    objCustomersController.DeleteCustomer(itemId)
                End If

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

    End Class 'EditItem

End Namespace 'bhattji.Modules.Customers
