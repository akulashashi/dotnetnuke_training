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
Imports bhattji.Modules.BkrSalesPersons.Business
'Imports Microsoft.ScalableHosting.Security
'Imports AspNetSecurity = Microsoft.ScalableHosting.Security

#End Region

Namespace bhattji.Modules.BkrSalesPersons

    Public MustInherit Class EditItem
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "
        Private itemId As Integer
        Private objOI As OptionsInfo
#End Region

#Region " Public Methods "

        Private Sub BindUserIOs(Optional ByVal Username As String = "")
            Dim LoginName As String = Username
            If (LoginName = "") AndAlso Request.IsAuthenticated Then
                LoginName = Users.UserController.GetCurrentUserInfo.Username
            End If
            With ddlOfficeOwner
                '.DataTextField = "IOName"
                '.DataValueField = "IOfficeCode"
                'If LoginName = "" Then
                '    .DataSource = (New Business.LoadSheetsController).GetAllInterOffices
                'Else
                '    .DataSource = (New Business.LoadSheetsController).GetUserIOs(LoginName)
                'End If
                '.DataBind()

                Dim valfld, txtfld As String
                Dim dr As IDataReader '= objLoadSheetsController.GetAllInterOffices
                If (Users.UserController.GetCurrentUserInfo.IsSuperUser) OrElse (LoginName = "") Then
                    dr = (New Business.SalesPersonsController).GetAllInterOffices
                Else
                    dr = (New Business.SalesPersonsController).GetUserIOs(LoginName)
                End If
                .Items.Clear()

                While dr.Read
                    If dr("JRCActive").ToString.ToUpper = "Y" Then
                        valfld = dr("JRCIOfficeCode").ToString
                        txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                        txtfld = Replace(txtfld, "JRC ", "")
                        .Items.Add(New ListItem(txtfld.ToUpper, valfld))
                    End If
                End While

                Try
                    .Items.Remove(.Items.FindByValue("000000000"))
                    '.Items.Remove(.Items.FindByValue(""))
                Catch
                End Try

                Try
                    .Items.FindByValue((New Business.SalesPersonsController).GetUserDefaultIO(LoginName)).Selected = True
                Catch
                End Try

            End With
        End Sub

        Private Sub ItemToPage(ByVal ItemId As Integer)
            If Not Null.IsNull(ItemId) Then 'Check for the Not-Null ItemId
                Dim objSalesPerson As Business.SalesPersonInfo = (New Business.SalesPersonsController).GetSalesPerson(ItemId)
                'Check for the Not-Null objSalesPerson
                If Not objSalesPerson Is Nothing Then ItemToPage(objSalesPerson)
            End If
        End Sub

        Private Sub ItemToPage(ByVal objSalesPerson As Business.SalesPersonInfo)
            'Load objSalesPerson data to the Page
            With objSalesPerson
                txtDriverCode.Text = .DriverCode.ToUpper
                txtDriverCode.ReadOnly = True
                txtDriverCode.CssClass = "NormalBold"
                txtDriverCode.Style.Add(HtmlTextWriterStyle.BorderWidth, "0")
                txtDriverName.Text = .DLastName & ", " & .DFirstName '.DriverName
                txtDLastName.Text = .DLastName
                txtDFirstName.Text = .DFirstName
                txtAddressLine1.Text = .AddressLine1
                txtAddressLine2.Text = .AddressLine2
                txtAddressLine3.Text = .AddressLine3
                txtCity.Text = .City
                txtState.Text = .State
                txtZipCode.Text = .ZipCode
                txtCountryCode.Text = .CountryCode
                txtPhoneNo.Text = .PhoneNoF
                txtExt.Text = .Ext
                txtEmailAddress.Text = .EmailAddress
                If Not Null.IsNull(.CommRate) Then
                    txtCommRate.Text = .CommRate.ToString
                End If
                chkAdminExempt.Checked = (.AdminExempt.ToUpper = "Y")
                'chkStatus.Checked = (.Status.ToUpper = "N")
                Try
                    ddlStatus.SelectedValue = .Status.ToUpper
                Catch
                End Try
                If (.Status.ToUpper = "N") Then
                    imgStatus.ImageUrl = ResolveUrl("~/images/icon_survey_32px.gif") 'FileManager/files/OK.gif
                Else
                    imgStatus.ImageUrl = ResolveUrl("~/images/delete.gif") 'unchecked.gif
                End If
                txtDriverNotes.Text = .DriverNotes
                txtLoadType.Text = .LoadType
                If Not Null.IsNull(.LastLoad) Then
                    txtLastLoad.Text = .LastLoad.ToShortDateString
                End If
                txtSafetyAuth.Text = .SafetyAuth
                txtCellPhone.Text = .CellPhoneF
                txtPager.Text = .PagerF
                txtAccountNo.Text = .AccountNo
                Try
                    If ddlOfficeOwner.Items.IndexOf(ddlOfficeOwner.Items.FindByValue(.OfficeOwner)) < 0 Then
                        ddlOfficeOwner.Items.Add(.OfficeOwner)
                    End If
                    If ddlOfficeOwner.SelectedValue <> .OfficeOwner Then
                        ddlOfficeOwner.ClearSelection() 'This is clear previous selection if any
                        ddlOfficeOwner.SelectedValue = .OfficeOwner 'ddlOfficeOwner.Items.FindByValue(.OfficeOwner).Selected = True
                    End If
                Catch
                End Try
                txtFaxNo.Text = .FaxNoF
                txtJRCTrailer.Text = .JRCTrailer
                txtLastLoadID.Text = .LastLoadID
                txtLastPU.Text = .LastPU
                txtLastDP.Text = .LastDP
                txtSafetyNotes.Text = .SafetyNotes
                txtLastTrailerUsed.Text = .LastTrailerUsed
                If Not Null.IsNull(.LastLoadDeliv) Then
                    txtLastLoadDeliv.Text = .LastLoadDeliv.ToShortDateString
                End If
                If Not Null.IsNull(.DrugDate) Then
                    txtDrugDate.Text = .DrugDate.ToShortDateString
                End If
                If Not Null.IsNull(.LicenceDate) Then
                    txtLicenceDate.Text = .LicenceDate.ToShortDateString
                End If
                If Not Null.IsNull(.TruckInsDate) Then
                    txtTruckInsDate.Text = .TruckInsDate.ToShortDateString
                End If
                If Not Null.IsNull(.TrailerInsDate) Then
                    txtTrailerInsDate.Text = .TrailerInsDate.ToShortDateString
                End If
                If Not Null.IsNull(.RegRenewDate) Then
                    txtRegRenewDate.Text = .RegRenewDate.ToShortDateString
                End If
                If Not Null.IsNull(.NewLeaseDate) Then
                    txtNewLeaseDate.Text = .NewLeaseDate.ToShortDateString
                End If
                If Not Null.IsNull(.MedicalDate) Then
                    txtMedicalDate.Text = .MedicalDate.ToShortDateString
                End If
                chkLogBookOS.Checked = (.LogBookOS.ToUpper = "Y")
                chkCalc87.Checked = (.Calc87.ToUpper = "Y")
                chkCalc85.Checked = (.Calc85.ToUpper = "Y")

                If .BrokerCodeD = "" Then
                    txtBrokerCodeD.Text = "0000000"
                Else
                    txtBrokerCodeD.Text = .BrokerCodeD
                End If
                'Dim dr As IDataReader = (New SalesPersonsController).GetBrokerByCode(.BrokerCodeD)

                Try
                    With ddlBrokerCodeD
                        .DataValueField = "BrokerCode"
                        .DataTextField = "BrokerName"
                        .DataSource = (New SalesPersonsController).GetBrokerByCode(txtBrokerCodeD.Text)
                        .DataBind()
                        'ddlBrokerCodeD.Items.Insert(0, (New ListItem("To be assigned", "0000000")))

                        If .Items.Count < 1 Then
                            .Items.Add(New ListItem("<No Broker>", ""))
                        End If
                    End With
                Catch
                End Try

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
            End With 'objSalesPerson
            'ddlOfficeOwner_SelectedIndexChanged(Nothing, Nothing)
        End Sub

        Private Function PageToItem() As SalesPersonInfo
            Dim objSalesPerson As New SalesPersonInfo
            'Initialise the ojbSalesPerson object
            objSalesPerson = CType(CBO.InitializeObject(objSalesPerson, GetType(Business.SalesPersonInfo)), SalesPersonInfo)

            'bind text values to object
            With objSalesPerson
                .ItemId = itemId
                .ModuleId = ModuleId

                .DriverCode = txtDriverCode.Text.ToUpper
                .DLastName = txtDLastName.Text
                .DFirstName = txtDFirstName.Text
                .DriverName = .DLastName & ", " & .DFirstName 'txtDriverName.Text
                .AddressLine1 = txtAddressLine1.Text
                .AddressLine2 = txtAddressLine2.Text
                .AddressLine3 = txtAddressLine3.Text
                .City = txtCity.Text
                .State = txtState.Text
                .ZipCode = txtZipCode.Text
                .CountryCode = txtCountryCode.Text
                .PhoneNo = txtPhoneNo.Text
                .Ext = txtExt.Text
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
                'If chkStatus.Checked Then
                '    .Status = "N"
                'Else
                '    .Status = "Y"
                'End If
                .Status = ddlStatus.SelectedValue
                .DriverNotes = txtDriverNotes.Text
                .LoadType = txtLoadType.Text
                Try
                    .LastLoad = Date.Parse(txtLastLoad.Text)
                Catch
                End Try
                .SafetyAuth = txtSafetyAuth.Text
                .CellPhone = txtCellPhone.Text
                .Pager = txtPager.Text
                If String.IsNullOrEmpty(txtAccountNo.Text) Then
                    .AccountNo = txtBrokerCodeD.Text
                Else
                    .AccountNo = txtAccountNo.Text
                End If
                .OfficeOwner = ddlOfficeOwner.SelectedValue
                .FaxNo = txtFaxNo.Text
                .JRCTrailer = txtJRCTrailer.Text
                .LastLoadID = txtLastLoadID.Text
                .LastPU = txtLastPU.Text
                .LastDP = txtLastDP.Text
                .SafetyNotes = txtSafetyNotes.Text
                .LastTrailerUsed = txtLastTrailerUsed.Text
                Try
                    .LastLoadDeliv = Date.Parse(txtLastLoadDeliv.Text)
                Catch
                End Try
                Try
                    .DrugDate = Date.Parse(txtDrugDate.Text)
                Catch
                End Try
                Try
                    .LicenceDate = Date.Parse(txtLicenceDate.Text)
                Catch
                End Try
                Try
                    .TruckInsDate = Date.Parse(txtTruckInsDate.Text)
                Catch
                End Try
                Try
                    .TrailerInsDate = Date.Parse(txtTrailerInsDate.Text)
                Catch
                End Try
                Try
                    .RegRenewDate = Date.Parse(txtRegRenewDate.Text)
                Catch
                End Try
                Try
                    .NewLeaseDate = Date.Parse(txtNewLeaseDate.Text)
                Catch
                End Try
                Try
                    .MedicalDate = Date.Parse(txtMedicalDate.Text)
                Catch
                End Try
                If chkLogBookOS.Checked Then
                    .LogBookOS = "Y"
                Else
                    .LogBookOS = "N"
                End If
                If chkCalc87.Checked Then
                    .Calc87 = "Y"
                Else
                    .Calc87 = "N"
                End If
                If chkCalc85.Checked Then
                    .Calc85 = "Y"
                Else
                    .Calc85 = "N"
                End If
                '.BrokerCodeD = txtBrokerCodeD.Text
                .BrokerCodeD = ddlBrokerCodeD.SelectedValue

                'Audit Control
                .UpdatedByUserId = UserInfo.UserID
                .CreatedByUserId = .UpdatedByUserId

            End With 'objSalesPerson
            Return objSalesPerson
        End Function

        Private Sub InitControls()
            'cmdDelete.Visible = Not Null.IsNull(itemId)
            'imbDelete.Visible = cmdDelete.Visible
            'cmdUpdate.Visible = cmdDelete.Visible
            'imbUpdate.Visible = cmdUpdate.Visible
            'cmdAdd.Visible = Not cmdUpdate.Visible
            'imbAdd.Visible = cmdAdd.Visible

            'cvDriverCode.Visible = cmdAdd.Visible

            'this needs to execute always to the client script code is registred in InvokePopupCal
            'cmdCalendarLastLoad.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtLastLoad)
            'cmdCalendarLastLoadDeliv.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtLastLoadDeliv)
            'cmdCalendarDrugDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtDrugDate)
            'cmdCalendarLicenceDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtLicenceDate)
            'cmdCalendarTruckInsDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTruckInsDate)
            'cmdCalendarTrailerInsDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTrailerInsDate)
            'cmdCalendarRegRenewDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtRegRenewDate)
            'cmdCalendarNewLeaseDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtNewLeaseDate)
            'cmdCalendarMedicalDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtMedicalDate)

            Dim PersonsOnly As Boolean = (New OptionsInfo(ModuleId)).ViewControl.ToUpper = "PERSONAL"
            If PersonsOnly Then
                'chkStatus.Style.Add("display", "none")
                ddlStatus.Style.Add("display", "none")
            Else
                imgStatus.Style.Add("display", "none")
            End If

            tdLastLoadID.Visible = Not PersonsOnly
            trAccountAdmin.Visible = Not PersonsOnly

            txtDriverCode.ReadOnly = PersonsOnly
            txtDriverName.ReadOnly = True
            ddlOfficeOwner.Enabled = Not PersonsOnly


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

            cvDriverCode.Visible = cmdAdd.Visible

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
                    SetIconBar()

                    'With ddlOfficeOwner
                    '    '.DataSource = (New Business.SalesPersonsController).GetAllInterOffices
                    '    '.DataValueField = "JRCIOfficeCode" '"IOfficeCode"
                    '    '.DataTextField = "IOName"
                    '    '.DataBind()

                    '    Dim valfld, txtfld As String
                    '    Dim dr As IDataReader = (New Business.SalesPersonsController).GetAllInterOffices

                    '    .Items.Clear()
                    '    While dr.Read
                    '        valfld = dr("JRCIOfficeCode").ToString
                    '        txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                    '        txtfld = Replace(txtfld, "JRC ", "")
                    '        .Items.Add(New ListItem(txtfld.ToUpper, valfld))
                    '    End While

                    'End With 'ddlOfficeOwner
                    BindUserIOs()

                    'Dim arrAvailable As ArrayList = (New Business.SalesPersonIOsController).GetIOsBySalesPerson
                    ''Response.Write("arrAvailable.Count " & arrAvailable.Count.ToString)
                    ''DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "arrAvailable.Count " & arrAvailable.Count.ToString, Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning)
                    'ctlSalesPersonIOs.Available = arrAvailable


                    If Not Null.IsNull(itemId) Then
                        Dim objSalesPerson As SalesPersonInfo = (New SalesPersonsController).GetSalesPerson(itemId)

                        If Not objSalesPerson Is Nothing Then
                            'Load data
                            ItemToPage(objSalesPerson)

                            ''Assign SalesPersons
                            'With ctlSalesPersonIOs
                            '    Dim arrAssigned As ArrayList = (New Business.SalesPersonIOsController).GetIOsBySalesPerson(itemId)
                            '    'Dim arrAssigned As IDataReader = (New Business.SalesPersonIOsController).GetIOsBySalesPerson(itemId)
                            '    For Each liAssigned As Business.SalesPersonIOInfo In arrAssigned
                            '        For Each liAvailable As Business.SalesPersonIOInfo In arrAvailable
                            '            If liAvailable.InterOfficeId = liAssigned.InterOfficeId Then
                            '                arrAvailable.Remove(liAvailable)
                            '                Exit For
                            '            End If
                            '        Next liAvailable 'As SalesPersonIOInfo In arrAssigned

                            '    Next liAssigned 'As SalesPersonIOInfo In arrAssigned

                            '    .Available = arrAvailable
                            '    .Assigned = arrAssigned
                            'End With 'ctlSalesPersonIOs

                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If

                    End If
                End If
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub txtDFirstName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDFirstName.TextChanged, txtDLastName.TextChanged
            txtDriverName.Text = txtDLastName.Text & ", " & txtDFirstName.Text
        End Sub

        'Private Sub ddlOfficeOwner_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlOfficeOwner.SelectedIndexChanged
        '    Dim AllowCDed As Boolean = (New SalesPersonsController).GetAllowCDed(ddlOfficeOwner.SelectedValue)

        '    trDvrDedPct.Visible = AllowCDed
        '    trDvrDedResn.Visible = AllowCDed

        'End Sub

        'Private Function UpdateBroker(ByVal objSalesPerson As SalesPersonInfo) As Boolean

        '    Dim DriverId As Integer = (New SalesPersonsController).GetBrokerId(objSalesPerson.BrokerCodeD)
        '    Dim objSC As New bhattji.Modules.BkrSalesPersons.Business.SalesPersonsController
        '    Dim objSalePerson As bhattji.Modules.BkrSalesPersons.Business.SalesPersonInfo = objSC.GetBrokerByCode(objSalesPerson.BrokerCodeD)

        '    txtLastLoadID.Text = objSalePerson.LastLoadID
        '    txtLastLoad.Text = objSalePerson.LastLoad
        '    txtLastLoadDeliv.Text = objSalePerson.LastLoadDeliv
        '    txtLastPU.Text = objSalePerson.LastPU
        '    txtLastDP.Text = objSalePerson.LastDP
        '    txtLastTrailerUsed.Text = objSalePerson.LastTrailerUsed

        '    objSC.UpdateSalesPerson(objSalePerson)


        'End Function

        Private Sub imbAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAdd.Click
            cmdAdd_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            'If (New OptionsInfo(ModuleId)).Combined Then
            '    If (New Business.SalesPersonsController).IsUniqueCode(txtDriverCode.Text, ddlBrokerCodeD.SelectedValue) Then
            '        cmdUpdate_Click(sender, New EventArgs)
            '    Else
            '        DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            '        DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            '    End If
            'Else
            '    If (New Business.SalesPersonsController).IsUniqueCode(txtDriverCode.Text) Then
            '        cmdUpdate_Click(sender, New EventArgs)
            '    Else
            '        DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            '        DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            '    End If
            'End If

            Select Case (New OptionsInfo(ModuleId)).Combined
                Case 1
                    If (New Business.SalesPersonsController).IsUniqueCode(txtDriverCode.Text) Then
                        cmdUpdate_Click(sender, New EventArgs)
                        'Controls.Add(objOI.Popup("Success", "New Driver with Driver Code " & txtDriverCode.Text & " added successfully", "New Driver with Driver Code " & txtDriverCode.Text & " added successfully in the Database.", 10, -350))
                        lblMsg.Text = "<font color='green'>Success<br/>New Driver with Driver Code " & txtDriverCode.Text & " added successfully in the Database</font>"
                    Else
                        'Controls.Add(objOI.Popup("Failure", "Driver with Driver Code " & txtDriverCode.Text & " already exists", "Driver with Driver Code " & txtDriverCode.Text & " already exists in the Database. Please choose another Driver Code", 10, -350))
                        lblMsg.Text = "<font color='red'>Failure<br/>Driver with Driver Code " & txtDriverCode.Text & " already exists in the Database. Please choose another Driver Code</font>"
                        DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                        DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                    End If
                Case 2
                    If (New Business.SalesPersonsController).IsUniqueCode(txtDriverCode.Text, ddlOfficeOwner.SelectedValue) Then
                        cmdUpdate_Click(sender, New EventArgs)
                        'Controls.Add(objOI.Popup("Success", "New Driver with Driver Code " & txtDriverCode.Text & " added successfully", "New Driver with Driver Code " & txtDriverCode.Text & " added successfully in the Database.", 10, -350))
                        lblMsg.Text = "<font color='green'>Success<br/>New Driver with Driver Code " & txtDriverCode.Text & " added successfully in the Database</font>"
                    Else
                        'Controls.Add(objOI.Popup("Failure", "Driver with Driver Code " & txtDriverCode.Text & " already exists", "Driver with Driver Code " & txtDriverCode.Text & " already exists in the Database. Please choose another Driver Code", 10, -350))
                        lblMsg.Text = "<font color='red'>Failure<br/>Driver with Driver Code " & txtDriverCode.Text & " already exists in the Database. Please choose another Driver Code</font>"
                        DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                        DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                    End If
                Case Else '0
                    If (New Business.SalesPersonsController).IsTotalUniqueCode(txtDriverCode.Text) Then
                        cmdUpdate_Click(sender, New EventArgs)
                        'Controls.Add(objOI.Popup("Success", "New Driver with Driver Code " & txtDriverCode.Text & " added successfully", "New Driver with Driver Code " & txtDriverCode.Text & " added successfully in the Database.", 10, -350))
                        lblMsg.Text = "<font color='green'>Success<br/>New Driver with Driver Code " & txtDriverCode.Text & " added successfully in the Database</font>"
                    Else
                        'Controls.Add(objOI.Popup("Failure", "Driver with Driver Code " & txtDriverCode.Text & " already exists", "Driver with Driver Code " & txtDriverCode.Text & " already exists in the Database. Please choose another Driver Code", 10, -350))
                        lblMsg.Text = "<font color='red'>Failure<br/>Driver with Driver Code " & txtDriverCode.Text & " already exists in the Database. Please choose another Driver Code</font>"
                        DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                        DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                    End If
            End Select
        End Sub


        Private Sub imbUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdate.Click ', imbAdd.Click
            cmdUpdate_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click ', cmdAdd.Click
            Try
                ' Only Update if the Entered Data is Valid
                If Page.IsValid Then
                        'Dim objSalesPerson As New SalesPersonInfo
                    ''Initialise the ojbSalesPerson object
                    'objSalesPerson = CType(CBO.InitializeObject(objSalesPerson, GetType(Business.SalesPersonInfo)), SalesPersonInfo)

                    'bind text values to object
                    Dim objSalesPerson As SalesPersonInfo = PageToItem()


                    Dim objSalesPersonsController As New SalesPersonsController
                    If Null.IsNull(itemId) Then
                        itemId = objSalesPersonsController.AddSalesPerson(objSalesPerson)
                    Else
                        objSalesPersonsController.UpdateSalesPerson(objSalesPerson)
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
                    Dim objSalesPersonsController As New SalesPersonsController
                    objSalesPersonsController.DeleteSalesPerson(itemId)
                End If

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub btnUpdateIOs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateIOs.Click
            Dim objSalesPersonIOsController As New Business.SalesPersonIOsController
            Dim arrExisting As ArrayList = objSalesPersonIOsController.GetIOsBySalesPerson
            Dim IO As Business.SalesPersonIOInfo

            'Delete the un-Assigned IOs
            For Each IO In arrExisting
                If ctlSalesPersonIOs.Assigned.IndexOf(IO) < 0 Then objSalesPersonIOsController.DeleteSalesPersonIO(itemId, IO.InterOfficeId)
            Next IO 'In arrExisting

            'Add the Assigned IOs
            For Each LI As ListItem In ctlSalesPersonIOs.Assigned
                objSalesPersonIOsController.AddSalesPersonIO(itemId, Integer.Parse(LI.Value))
            Next LI 'As ListItem In ctlSalesPersonIOs.Assigned
        End Sub

        Private Sub btnBrokerSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBrokerSearch.Click
            With ddlBrokerCodeD
                'Dim txt As String '= .Items(0).Text '.SelectedItem.Text
                'Dim val As String '= .Items(0).Value '.SelectedValue
                'If .Items.Count > 0 Then
                '    txt = .Items(0).Text  '.SelectedItem.Text
                '    val = .Items(0).Value  '.SelectedValue
                'End If

                .DataValueField = "BrokerCode"
                .DataTextField = "BrokerName"
                '.DataSource = (New Business.LoadSheetsController).Getrpt2Broker(txtBrokerCode.Text, "BrokerName")
                .DataSource = (New Business.SalesPersonsController).GetBrokerSearch(txtBrokerCodeD.Text)
                .DataBind()

                If .Items.Count < 1 Then
                    .Items.Add(New ListItem("<No Broker>", ""))
                Else
                    txtBrokerCodeD.Text = .SelectedValue
                    txtBrokerCodeD_TextChanged(Nothing, Nothing)
                End If

            End With 'ddlBrokerCodeD


        End Sub

        Private Sub ddlBrokerCodeD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBrokerCodeD.SelectedIndexChanged
            txtBrokerCodeD.Text = ddlBrokerCodeD.SelectedValue
            txtBrokerCodeD_TextChanged(Nothing, Nothing)
        End Sub


        Private Sub txtBrokerCodeD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBrokerCodeD.TextChanged
            txtAccountNo.Text = txtBrokerCodeD.Text
        End Sub
#End Region

    End Class 'EditItem

End Namespace 'bhattji.Modules.BkrSalesPersons
