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
Imports bhattji.Modules.SalesPersons.Business
'Imports Microsoft.ScalableHosting.Security
'Imports AspNetSecurity = Microsoft.ScalableHosting.Security

#End Region

Namespace bhattji.Modules.SalesPersons

    Public MustInherit Class EditItem
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "
        Private itemId As Integer
        Private objOI As OptionsInfo
#End Region

#Region " Private Methods "

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
                If Not Users.UserController.GetCurrentUserInfo.IsInRole("acct_num_update") Then
                    txtDriverCode.ReadOnly = True
                    txtDriverCode.CssClass = "NormalBold"
                    txtDriverCode.Style.Add(HtmlTextWriterStyle.BorderWidth, "0")
                End If
                txtDLastName.Text = .DLastName
                txtDFirstName.Text = .DFirstName
                txtDriverName.Text = .DriverName


                lblDriverCode.Text = txtDriverCode.Text
                lblDriverName.Text = txtDriverName.Text

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
                txtCountryCode.Text = .CountryCode
                txtPhoneNo.Text = Phone.FormatPhoneNo(.PhoneNo)
                txtExt.Text = .Ext
                txtEmailAddress.Text = .EmailAddress
                If Not Null.IsNull(.CommRate) Then
                    txtCommRate.Text = .CommRate.ToString
                End If
                chkAdminExempt.Checked = (.AdminExempt.ToUpper = "Y")
                chkStatus.Checked = (.Status.ToUpper = "N")
                If (.Status.ToUpper = "N") Then
                    imgStatus.ImageUrl = ResolveUrl("~/images/icon_survey_32px.gif") 'FileManager/files/OK.gif
                Else
                    imgStatus.ImageUrl = ResolveUrl("~/images/delete.gif") 'unchecked.gif
                End If
                'txtSafetyAuth.Text = .SafetyAuth
                chkSafetyAuth.Checked = (.SafetyAuth.ToUpper = "HOLD")
                If chkSafetyAuth.Checked Then
                    imgSafetyAuth.ImageUrl = ResolveUrl("~/images/icon_survey_32px.gif") 'FileManager/files/OK.gif
                Else
                    imgSafetyAuth.ImageUrl = ResolveUrl("~/images/delete.gif") 'unchecked.gif
                End If

                txtDriverNotes.Text = .DriverNotes
                txtLoadType.Text = .LoadType
                If Not Null.IsNull(.LastLoad) Then
                    txtLastLoad.Text = .LastLoad.ToShortDateString
                End If
                txtCellPhone.Text = Phone.FormatPhoneNo(.CellPhone)
                txtPager.Text = Phone.FormatPhoneNo(.Pager)
                txtAccountNo.Text = .AccountNo
                ''Only the users with Role "acct_num_update" can change the AccountNo
                'If Not Users.UserController.GetCurrentUserInfo.IsInRole("acct_num_update") Then
                '    txtAccountNo.ReadOnly = True
                '    txtAccountNo.CssClass = "NormalBold"
                '    txtAccountNo.Style.Add(HtmlTextWriterStyle.BorderWidth, "0")
                'End If
                Try
                    ddlOfficeOwner.Items.FindByValue(.OfficeOwner).Selected = True
                Catch
                End Try
                txtFaxNo.Text = Phone.FormatPhoneNo(.FaxNo)
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
                If Not Null.IsNull(.InactivateDate) Then
                    txtInactivateDate.Text = .InactivateDate.ToShortDateString
                End If
                If Not Null.IsNull(.MedicalDate) Then
                    txtMedicalDate.Text = .MedicalDate.ToShortDateString
                End If
                chkLogBookOS.Checked = (.LogBookOS.ToUpper = "Y")

                If Not Null.IsNull(.MoMaint) Then txtMoMaint.Text = .MoMaint.ToShortDateString 'datetime
                If Not Null.IsNull(.DotInspec) Then txtDotInspec.Text = .DotInspec.ToShortDateString 'datetime
                If Not Null.IsNull(.TrailerMaint) Then txtTrailerMaint.Text = .TrailerMaint.ToShortDateString 'datetime
                If Not Null.IsNull(.RegRenew) Then txtRegRenew.Text = .RegRenew.ToShortDateString 'datetime
                If Not Null.IsNull(.OccIns) Then txtOccIns.Text = .OccIns.ToShortDateString 'datetime
                If Not Null.IsNull(.NtlIns) Then txtNtlIns.Text = .NtlIns.ToShortDateString 'datetime
                If Not Null.IsNull(.PhysDmg) Then txtPhysDmg.Text = .PhysDmg.ToShortDateString 'datetime
                If Not Null.IsNull(.SeaLink) Then txtSeaLink.Text = .SeaLink.ToShortDateString 'datetime
                If Not Null.IsNull(.AnnIns) Then txtAnnIns.Text = .AnnIns.ToShortDateString 'datetime
                chkProbDriver.Checked = .ProbDriver 'bit

                chkCalc87.Checked = (.Calc87.ToUpper = "Y")
                chkCalc85.Checked = (.Calc85.ToUpper = "Y")
                txtBrokerCodeD.Text = .BrokerCodeD
                If Not Null.IsNull(.DvrDedPct) Then
                    txtDvrDedPct.Text = .DvrDedPct.ToString
                End If
                txtDvrDedResn.Text = .DvrDedResn

                chkTerminated.Checked = .Terminated 'bit
                txtTerm_Staff.Text = .Term_Staff 'nvarchar
                If Not Null.IsNull(.Term_Date) Then txtTerm_Date.Text = .Term_Date.ToShortDateString 'datetime
                txtTerm_Reason.Text = .Term_Reason 'nvarchar

                If Not Null.IsNull(.ViewOrder) Then
                    txtViewOrder.Text = .ViewOrder.ToString
                End If

                If (New OptionsInfo(ModuleId)).ViewControl.ToUpper = "TERMINATION" Then
                    If .Terminated Then
                        chkTerminated.Enabled = False
                        'hypTerm_Date.ImageUrl = "~/images/1x1.gif"
                        hypTerm_Date.Visible = False
                        calTerm_Date.Enabled = False
                        txtTerm_Date.ReadOnly = True
                        txtTerm_Reason.ReadOnly = True
                    End If
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
            ddlOfficeOwner_SelectedIndexChanged(Nothing, Nothing)
            SetFuelTax()
        End Sub

        Private Sub SetFuelTax()
            Dim CommRate As Double = 0
            Try
                CommRate = Double.Parse(txtCommRate.Text)
            Catch
            End Try
            txtDvrDedPct.Enabled = (CommRate <= 85)
            If Not txtDvrDedPct.Enabled Then txtDvrDedPct.Text = "0"
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
                '.DriverName = txtDriverName.Text
                .DriverName = .DLastName & ", " & .DFirstName 'txtDriverName.Text
                .AddressLine1 = txtAddressLine1.Text
                .AddressLine2 = txtAddressLine2.Text
                .AddressLine3 = txtAddressLine3.Text
                .City = txtCity.Text
                '.State = txtState.Text
                .State = ddlStateCode.SelectedValue
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
                If chkStatus.Checked Then
                    .Status = "N"
                Else
                    .Status = "Y"
                End If
                '.SafetyAuth = txtSafetyAuth.Text
                If chkSafetyAuth.Checked Then .SafetyAuth = "HOLD" Else .SafetyAuth = ""
                .DriverNotes = txtDriverNotes.Text
                .LoadType = txtLoadType.Text
                Try
                    .LastLoad = Date.Parse(txtLastLoad.Text)
                Catch
                End Try
                .CellPhone = txtCellPhone.Text
                .Pager = txtPager.Text
                .AccountNo = txtAccountNo.Text
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
                    .InactivateDate = Date.Parse(txtInactivateDate.Text)
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

                Try
                    .MoMaint = Date.Parse(txtMoMaint.Text)
                Catch
                End Try
                Try
                    .DotInspec = Date.Parse(txtDotInspec.Text)
                Catch
                End Try
                Try
                    .TrailerMaint = Date.Parse(txtTrailerMaint.Text)
                Catch
                End Try
                Try
                    .RegRenew = Date.Parse(txtRegRenew.Text)
                Catch
                End Try
                Try
                    .OccIns = Date.Parse(txtOccIns.Text)
                Catch
                End Try
                Try
                    .NtlIns = Date.Parse(txtNtlIns.Text)
                Catch
                End Try
                Try
                    .PhysDmg = Date.Parse(txtPhysDmg.Text)
                Catch
                End Try
                Try
                    .SeaLink = Date.Parse(txtSeaLink.Text)
                Catch
                End Try
                Try
                    .AnnIns = Date.Parse(txtAnnIns.Text)
                Catch
                End Try
                .ProbDriver = chkProbDriver.Checked

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
                .BrokerCodeD = txtBrokerCodeD.Text
                Try
                    .DvrDedPct = Double.Parse(txtDvrDedPct.Text)
                Catch
                End Try
                .DvrDedResn = txtDvrDedResn.Text

                Try
                    .Terminated = chkTerminated.Checked
                Catch
                End Try
                If (New OptionsInfo(ModuleId)).ViewControl.ToUpper = "TERMINATION" Then
                    If .Terminated Then
                        .Term_Staff = Users.UserController.GetCurrentUserInfo().Username
                        Try
                            .Term_Date = Date.Parse(txtTerm_Date.Text)
                        Catch
                        End Try
                        .Term_Reason = txtTerm_Reason.Text

                        .Status = "Y"
                        .InactivateDate = .Term_Date
                        If Not .DriverNotes.Contains(.Term_Reason) Then
                            .DriverNotes = .DriverNotes & " " & .Term_Reason
                        End If
                    End If
                Else
                    .Term_Staff = txtTerm_Staff.Text
                    Try
                        .Term_Date = Date.Parse(txtTerm_Date.Text)
                    Catch
                    End Try
                    .Term_Reason = txtTerm_Reason.Text
                End If

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

            valTerm_Date1.ValueToCompare = Today.ToShortDateString

            Dim PersonsOnly As Boolean = (New OptionsInfo(ModuleId)).ViewControl.ToUpper = "PERSONAL"
            If PersonsOnly Then
                chkStatus.Style.Add("display", "none")
                chkSafetyAuth.Style.Add("display", "none")
                'txtSafetyNotes.Enabled = False
                txtSafetyNotes.ReadOnly = True

                ddlUpdateRedirection.SelectedValue = "ItemDetails"
            Else
                imgStatus.Style.Add("display", "none")
                imgSafetyAuth.Style.Add("display", "none")
            End If

            tdLastLoadID.Visible = Not PersonsOnly
            trAccountAdmin.Visible = Not PersonsOnly

            txtDriverName.ReadOnly = True
            txtDriverCode.ReadOnly = PersonsOnly
            txtDLastName.ReadOnly = PersonsOnly
            txtDFirstName.ReadOnly = PersonsOnly
            ddlOfficeOwner.Enabled = Not PersonsOnly
            txtAddressLine1.ReadOnly = PersonsOnly
            txtAddressLine2.ReadOnly = PersonsOnly
            txtAddressLine3.ReadOnly = PersonsOnly
            txtCity.ReadOnly = PersonsOnly
            'txtState.ReadOnly = PersonsOnly
            ddlStateCode.Enabled = Not PersonsOnly
            txtZipCode.ReadOnly = PersonsOnly
            txtCountryCode.ReadOnly = PersonsOnly
            'txtEmailAddress.ReadOnly = PersonsOnly


            Dim IsTermination As Boolean = (New OptionsInfo(ModuleId)).ViewControl.ToUpper = "TERMINATION"
            'trTermination.Visible = (Not PersonsOnly) 'OrElse IsTermination
            trTermination.Visible = (Not PersonsOnly) AndAlso (Not String.IsNullOrEmpty(Request.QueryString("ItemId"))) 'OrElse IsTermination
            trNormal.Visible = Not IsTermination

            If Not Page.IsPostBack Then
                BindStateCodes()
                BindOfficeOwner()

                SetIconBar()

            End If

        End Sub
        Sub BindStateCodes()
            With ddlStateCode
                '.DataValueField = "StateCode"
                '.DataTextField = "StateCode" '"State"
                .DataSource = (New SalesPersonsController).GetStateCodes
                .DataBind()

                .Items.Insert(0, New ListItem("", ""))
            End With 'ddlStateCode
        End Sub
        Sub BindOfficeOwner()
            With ddlOfficeOwner
                '.DataSource = (New Business.SalesPersonsController).GetAllInterOffices
                '.DataValueField = "JRCIOfficeCode" '"IOfficeCode"
                '.DataTextField = "IOName"
                '.DataBind()

                Dim valfld, txtfld As String
                Dim dr As IDataReader = (New Business.SalesPersonsController).GetAllInterOffices

                .Items.Clear()
                While dr.Read
                    valfld = dr("JRCIOfficeCode").ToString
                    'If valfld <> "000000000" Then
                    txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                    txtfld = Replace(txtfld, "JRC ", "")
                    .Items.Add(New ListItem(txtfld.ToUpper, valfld))
                    'End If
                End While
                'Try
                '    .Items.Remove(.Items.FindByValue("000000000"))
                '    '.Items.Remove(.Items.FindByValue(""))
                'Catch
                'End Try
            End With 'ddlOfficeOwner
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
            cmdUnterminate.ToolTip = "Unterminate this Driver ?"
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
            cmdUnterminate.Attributes.Add("onClick", "javascript:return confirm('Unterminate this Driver ?');")

        End Sub 'SetIconBar()

        Private Sub SendNotification(ByVal objDriver As SalesPersonInfo, Optional ByVal SendAction As String = "S")
            Try
                ' load all user emails based on roles selected
                Dim objRoleNames As New System.Collections.Generic.List(Of String)
                'objRoleNames.Add("Administrators")

                ''Create the List of Recipients
                Dim objRecipients As New ArrayList
                'If Name = "" Then
                '    objRecipients.Add(New System.Web.UI.WebControls.ListItem(eMail, eMail))
                'Else
                '    objRecipients.Add(New System.Web.UI.WebControls.ListItem(eMail, Name))
                'End If
                objRecipients.Add(New System.Web.UI.WebControls.ListItem(Users.UserController.GetCurrentUserInfo().Email, Users.UserController.GetCurrentUserInfo().DisplayName))
                objRecipients.Add(New System.Web.UI.WebControls.ListItem("jibhatt@gmail.com", "Jaydeep Bhatt"))
                objRecipients.Add(New System.Web.UI.WebControls.ListItem("eric@mediainfocus.com", "Eric Pontbriand"))
                objRecipients.Add(New System.Web.UI.WebControls.ListItem("gsmsoftware@snet.net", "Butch Hightower"))

                objRecipients.Add(New System.Web.UI.WebControls.ListItem("timb@jrctransportation.com", "Tim Bedard"))
                objRecipients.Add(New System.Web.UI.WebControls.ListItem("christinav@jrctransportation.com", "Christina Verdinez"))

                '' load emails specified in email distribution list
                Dim objUsers As New System.Collections.Generic.List(Of Users.UserInfo)
                For Each li As System.Web.UI.WebControls.ListItem In objRecipients
                    Dim objUser As New Users.UserInfo
                    objUser.UserID = Null.NullInteger
                    objUser.Email = li.Text
                    objUser.DisplayName = li.Value
                    objUsers.Add(objUser)
                Next
               

                'Dim objLoadSheetInfo As Business.LoadSheetInfo = (New Business.LoadSheetsController).GetLoadSheetByLoadId(hypLoadID.Text)
                'Dim ReportLink As String = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & Request.QueryString("ItemId"), "LoadType=" & Request.QueryString("LoadType").ToUpper)
                Dim ReportLink As String = "http://www.jrctransportation.com/deliveries/CLT_LEASE_TERMINATION.pdf"
                'If ReportLink.StartsWith("/") Then ReportLink = ApplicationPath & ReportLink

                Dim Disclaimer As String = "The information contained in this electronic message is private and confidential information of J.R.C. Transportation, Inc. and is intended only for the use of the individual and/or entity named above.  If the reader of this message is not the intended recipient, or the employee or agent responsible to deliver it to the intended recipient, you are hereby notified that reading, distributing, copying or making any other use of this communication is STRICTLY PROHIBITED.  In no event shall receipt of this message by an unintended party be construed as a waiver by J.R.C. Transportation, Inc. of any privilege or other privacy rights. If you have received this communication in error, please notify us at the above email address."

                Dim Subject As String = "JRC Driver Termination, " & objDriver.DriverName & ", " & objDriver.Term_Date.ToShortDateString
                'If objLoadSheetInfo.PUCityST <> "" Then Subject &= " First Pickup from " & objLoadSheetInfo.PUCityST
                'Dim Body As String = "Please see " & Subject & "<br/><br/>" & ReportLink & "<br/><br/><hr/>" & Disclaimer
                'Dim Body As String = "JRC driver, " & objDriver.DriverName & ", has been scheduled for termination on " & objDriver.Term_Date.ToShortDateString & " by " & objDriver.Term_Staff & " and will not be available for assignment after that date.<br/><br/>Reason: " & objDriver.Term_Reason & "<br/><br/>Please see the Termination Agreement at " & ReportLink & "<br/><br/><p style=""text-align: left;""><img width=""188"" height=""135"" src=""http://www.jrctransportation.com/Portals/jrctrans/LOGOS/LOGO.png"" /></p><hr/>" & Disclaimer
                Dim Body As String = "JRC driver, " & objDriver.DriverName & ", has been scheduled for termination on " & objDriver.Term_Date.ToShortDateString & " by " & Users.UserController.GetUserByName(PortalId, objDriver.Term_Staff).DisplayName & " and will not be available for assignment after that date.<br/><br/>Reason: " & objDriver.Term_Reason & "<br/><br/>Please see the Termination Agreement at " & ReportLink & "<br/><br/><p style=""text-align: left;""><img width=""188"" height=""135"" src=""http://www.jrctransportation.com/Portals/jrctrans/LOGOS/LOGO.png"" /></p><hr/>" & Disclaimer

                'Create object
                Dim objSendBulkEMail As New DotNetNuke.Services.Mail.SendTokenizedBulkEmail(objRoleNames, objUsers, True, Subject, Body)
                objSendBulkEMail.BodyFormat = DotNetNuke.Services.Mail.MailFormat.Html
                objSendBulkEMail.Priority = DotNetNuke.Services.Mail.MailPriority.High

                'Dim objSendingUser As Users.UserInfo = Users.UserController.GetCurrentUserInfo
                'objSendingUser.Username = objSendingUser.DisplayName
                'objSendBulkEMail.SendingUser = objSendingUser
                objSendBulkEMail.SendingUser = Users.UserController.GetCurrentUserInfo

                objSendBulkEMail.ReplyTo = objSendBulkEMail.SendingUser
                objSendBulkEMail.AddressMethod = DotNetNuke.Services.Mail.SendTokenizedBulkEmail.AddressMethods.Send_TO

                ' send mail
                'Dim SendAction As String = "S" '"A"
                Dim strResult As String
                Dim msgResult As DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType
                If SendAction = "S" Then
                    Dim intMailsSent As Integer = objSendBulkEMail.SendMails()
                    If intMailsSent > 0 Then
                        strResult = "eMails sent to " & intMailsSent.ToString & "Recipients" 'String.Format(DotNetNuke.Services.Localization.Localization.GetString("MessagesSentCount", Me.LocalResourceFile), intMailsSent)
                        msgResult = DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess
                    Else
                        strResult = "eMails could not be sent" 'DotNetNuke.Services.Localization.Localization.GetString("NoMessagesSent", Me.LocalResourceFile)
                        msgResult = DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning
                    End If
                Else    ' ansynchronous uses threading
                    Dim objThread As New Threading.Thread(AddressOf objSendBulkEMail.Send)
                    objThread.Start()
                    strResult = "eMails are scheduled to be sent Asynchornously" 'DotNetNuke.Services.Localization.Localization.GetString("MessageSent", Me.LocalResourceFile)
                    msgResult = DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess
                End If
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, strResult, msgResult)

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
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
                    Dim arrAvailable As ArrayList = (New Business.SalesPersonIOsController).GetIOsBySalesPerson
                    'Response.Write("arrAvailable.Count " & arrAvailable.Count.ToString)
                    'DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "arrAvailable.Count " & arrAvailable.Count.ToString, Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning)
                    ctlSalesPersonIOs.Available = arrAvailable


                    If Not Null.IsNull(itemId) Then
                        Dim objSalesPerson As SalesPersonInfo = (New SalesPersonsController).GetSalesPerson(itemId)

                        If Not objSalesPerson Is Nothing Then
                            'Load data
                            ItemToPage(objSalesPerson)

                            'Assign SalesPersons
                            With ctlSalesPersonIOs
                                Dim arrAssigned As ArrayList = (New Business.SalesPersonIOsController).GetIOsBySalesPerson(itemId)
                                For Each liAssigned As Business.SalesPersonIOInfo In arrAssigned
                                    For Each liAvailable As Business.SalesPersonIOInfo In arrAvailable
                                        If liAvailable.InterOfficeId = liAssigned.InterOfficeId Then
                                            arrAvailable.Remove(liAvailable)
                                            Exit For
                                        End If
                                    Next liAvailable 'As SalesPersonIOInfo In arrAssigned

                                Next liAssigned 'As SalesPersonIOInfo In arrAssigned

                                .Available = arrAvailable
                                .Assigned = arrAssigned
                            End With 'ctlSalesPersonIOs

                            chkStatus_CheckedChanged(Nothing, Nothing)
                            chkTerminated_CheckedChanged(Nothing, Nothing)

                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If

                    End If
                End If
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub chkStatus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
            valInactivateDate.Enabled = Not chkStatus.Checked
            If chkStatus.Checked Then
                imgActive.ImageUrl = "~/images/greendot.gif"
            Else
                imgActive.ImageUrl = "~/images/reddot.gif"
            End If
        End Sub
        Private Sub chkTerminated_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTerminated.CheckedChanged
            valTerm_Date.Enabled = chkTerminated.Checked
            valTerm_Reason.Enabled = chkTerminated.Checked
            If (New OptionsInfo(ModuleId)).ViewControl.ToUpper = "TERMINATION" Then
                cmdUnterminate.Visible = False
            Else
                cmdUnterminate.Visible = chkTerminated.Checked
            End If
            If chkTerminated.Checked Then
                If txtTerm_Staff.Text = "" Then
                    lblDriverTerminated.Text = "Driver " & txtDriverName.Text & " is terminated by " & Users.UserController.GetCurrentUserInfo.Username
                Else
                    lblDriverTerminated.Text = "Driver " & txtDriverName.Text & " is terminated by " & txtTerm_Staff.Text
                End If
            Else
                lblDriverTerminated.Text = ""
                txtTerm_Date.Text = ""
                txtTerm_Reason.Text = ""
                txtDriverNotes.Text = ""
            End If

            'Dispatchers cannot enter date other than Today
            If (New OptionsInfo(ModuleId)).ViewControl.ToUpper = "TERMINATION" Then
                If chkTerminated.Checked Then txtTerm_Date.Text = Today.ToShortDateString
                txtTerm_Date.ReadOnly = True
                hypTerm_Date.Visible = False
                calTerm_Date.Enabled = False
            ElseIf (New OptionsInfo(ModuleId)).ViewControl.ToUpper = "LIST" Then
                valTerm_Date1.Enabled = False
            End If
        End Sub

        Private Sub ddlOfficeOwner_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlOfficeOwner.SelectedIndexChanged
            Dim AllowCDed As Boolean = (New SalesPersonsController).GetAllowCDed(ddlOfficeOwner.SelectedValue)

            If Not AllowCDed Then txtDvrDedPct.Text = "0"

            trDvrDedPct.Visible = AllowCDed
            trDvrDedResn.Visible = AllowCDed

        End Sub

        Private Sub txtDFirstName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDFirstName.TextChanged, txtDLastName.TextChanged
            txtDriverName.Text = txtDLastName.Text & ", " & txtDFirstName.Text
        End Sub

        Private Sub txtCommRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCommRate.TextChanged
            SetFuelTax()
            If txtDvrDedPct.Enabled Then txtDvrDedPct.Focus() Else txtJRCTrailer.Focus()
        End Sub

        Private Sub imbAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAdd.Click
            cmdAdd_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            'If (New OptionsInfo(ModuleId)).Combined Then
            '    If (New Business.SalesPersonsController).IsUniqueCode(txtDriverCode.Text, ddlOfficeOwner.SelectedValue) Then
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





            'If (New Business.SalesPersonsController).IsUniqueAccountNo(txtAccountNo.Text) Then
            Select Case (New OptionsInfo(ModuleId)).Combined
                Case 1
                    If (New Business.SalesPersonsController).IsUniqueCode(txtDriverCode.Text) Then
                        cmdUpdate_Click(Nothing, Nothing)
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
                        cmdUpdate_Click(Nothing, Nothing)
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
                        cmdUpdate_Click(Nothing, Nothing)
                        'Controls.Add(objOI.Popup("Success", "New Driver with Driver Code " & txtDriverCode.Text & " added successfully", "New Driver with Driver Code " & txtDriverCode.Text & " added successfully in the Database.", 10, -350))
                        lblMsg.Text = "<font color='green'>Success<br/>New Driver with Driver Code " & txtDriverCode.Text & " added successfully in the Database</font>"
                    Else
                        'Controls.Add(objOI.Popup("Failure", "Driver with Driver Code " & txtDriverCode.Text & " already exists", "Driver with Driver Code " & txtDriverCode.Text & " already exists in the Database. Please choose another Driver Code", 10, -350))
                        lblMsg.Text = "<font color='red'>Failure<br/>Driver with Driver Code " & txtDriverCode.Text & " already exists in the Database. Please choose another Driver Code</font>"
                        DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                        DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "DriverCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                    End If
            End Select
            'Else
            'lblMsg.Text = "<font color='red'>Failure<br/>Driver with AccountNo " & txtAccountNo.Text & " already exists in the Database. Please choose another AccountNo</font>"
            'End If

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
                        objSalesPersonsController.UpdateLoadStatus4Driver(objSalesPerson)

                        If ((New OptionsInfo(ModuleId)).ViewControl.ToUpper = "TERMINATION") AndAlso (objSalesPerson.Terminated) Then
                            SendNotification(objSalesPerson)
                        End If

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

        Private Sub cmdUnterminate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUnterminate.Click
            chkTerminated.Checked = False
            chkTerminated_CheckedChanged(Nothing, Nothing)
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


#End Region

    End Class 'EditItem

End Namespace 'bhattji.Modules.SalesPersons
