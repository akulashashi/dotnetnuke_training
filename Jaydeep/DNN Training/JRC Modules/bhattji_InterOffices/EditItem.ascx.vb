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
Imports bhattji.Modules.InterOffices.Business
'Imports Microsoft.ScalableHosting.Security
'Imports AspNetSecurity = Microsoft.ScalableHosting.Security

#End Region

Namespace bhattji.Modules.InterOffices

    Public MustInherit Class EditItem
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "
        Private itemId As Integer
        Private objOI As OptionsInfo
#End Region

#Region " Public Methods "

        Private Sub ItemToPage(ByVal ItemId As Integer)
            If Not Null.IsNull(ItemId) Then 'Check for the Not-Null ItemId
                Dim objInterOffice As Business.InterOfficeInfo = (New Business.InterOfficesController).GetInterOffice(ItemId)
                'Check for the Not-Null objInterOffice
                If Not objInterOffice Is Nothing Then ItemToPage(objInterOffice)
            End If
        End Sub

        Private Sub ItemToPage(ByVal objInterOffice As Business.InterOfficeInfo)
            'Load objInterOffice data to the Page
            With objInterOffice
                txtJRCIOfficeCode.Text = .JRCIOfficeCode
                txtIOfficeCode.Text = .IOfficeCode
                If Not Users.UserController.GetCurrentUserInfo.IsInRole("acct_num_update") Then
                    txtJRCIOfficeCode.ReadOnly = True
                    txtJRCIOfficeCode.CssClass = "NormalBold"
                    txtJRCIOfficeCode.Style.Add(HtmlTextWriterStyle.BorderWidth, "0")

                    txtIOfficeCode.ReadOnly = True
                    txtIOfficeCode.CssClass = "NormalBold"
                    txtIOfficeCode.Style.Add(HtmlTextWriterStyle.BorderWidth, "0")
                End If
                txtIOName.Text = .IOName
                txtAbvrName.Text = .AbvrName
                txtAddressLine1.Text = .AddressLine1
                txtAddressLine2.Text = .AddressLine2
                txtCity.Text = .City
                'txtState.Text = .State
                Try
                    If .State <> "" Then ddlStateCode.SelectedValue = .State.ToUpper
                Catch
                End Try
                txtZipCode.Text = .ZipCode
                txtCountryCode.Text = .CountryCode
                txtPhoneNo.Text = .PhoneNo
                txtExt.Text = .Ext
                txtEmailAddress.Text = .EmailAddress
                chkHasProbDrivers.Checked = .HasProbDrivers
                txtCommRate.Text = .CommRate
                chkAdminExempt.Checked = (.AdminExempt.ToUpper = "Y")
                chkStatus.Checked = (.Status.ToUpper = "Y")
                txtLoadType.Text = .LoadType
                If String.IsNullOrEmpty(.Division) Then .Division = "JRC"
                txtDivision.Text = .Division
                txtFaxNo.Text = .FaxNo
                chkOfficeOR.Checked = (.OfficeOR.ToUpper = "Y")
                txtOfficeORAcct.Text = .OfficeORAcct
                If Not Null.IsNull(.OfficeORPct) Then
                    txtOfficeORPct.Text = .OfficeORPct.ToString
                End If
                txtOfficeCodeNo.Text = .OfficeCodeNo
                txtLogOnPW.Text = .LogOnPW
                txtOfficName.Text = .OfficName
                txtOfficeAddr.Text = .OfficeAddr
                txtOfficeAbrv.Text = .OfficeAbrv
                If String.IsNullOrEmpty(.TempFile1) Then txtTempFile1.Text = "D:\FTP_ACCOUNTS\JRC\MASTXT" Else txtTempFile1.Text = .TempFile1
                'If .TempFile1 = "" Then
                '    txtTempFile1.Text = "D:\FTP_ACCOUNTS\JRC\MASTXT"
                'Else
                '    txtTempFile1.Text = .TempFile1
                'End If
                txtOONo.Text = .OONo
                txtBKNo.Text = .BKNo
                txtAVNo.Text = .AVNo
                chkUseDispatch.Checked = (.UseDispatch.ToUpper = "Y")
                If Not Null.IsNull(.OfficePct) Then
                    txtOfficePct.Text = .OfficePct.ToString
                End If
                If .LoadAcct.Length > 3 Then
                    txtGenCode.Text = .LoadAcct.Substring(3)
                End If
                txtLoadAcct.Text = .LoadAcct
                txtDiscAcct.Text = .DiscAcct
                txtDetenAcct.Text = .DetenAcct
                txtTollsAcct.Text = .TollsAcct
                txtFuelAcct.Text = .FuelAcct
                txtDropAcct.Text = .DropAcct
                txtReconAcct.Text = .ReconAcct
                txtTarpAcct.Text = .TarpAcct
                txtLumperAcct.Text = .LumperAcct
                txtUnloadAcct.Text = .UnloadAcct
                txtAdminMiscAcct.Text = .AdminMiscAcct
                If Not Null.IsNull(.BKOfficePct) Then
                    txtBKOfficePct.Text = .BKOfficePct.ToString
                End If
                If Not Null.IsNull(.LastXferDate) Then
                    txtLastXferDate.Text = .LastXferDate.ToShortDateString
                End If
                txtLastXmission.Text = .LastXmission
                If Not Null.IsNull(.Xfer) Then
                    txtXfer.Text = .Xfer.ToString
                End If
                If .NoOffChar > 2 Then
                    ddlNoOffChar.SelectedIndex = 1
                Else
                    ddlNoOffChar.SelectedIndex = 0
                End If
                chkAllowORide.Checked = (.AllowORide.ToUpper = "Y")
                If Not Null.IsNull(.JRCAdminP) Then
                    txtJRCAdminP.Text = .JRCAdminP.ToString
                End If
                txtReminder.Text = .Reminder
                txtDefDispNo.Text = .DefDispNo
                txtDefDispName.Text = .DefDispName
                txtLoadAcctB.Text = .LoadAcctB
                txtDiscAcctB.Text = .DiscAcctB
                txtDetenAcctB.Text = .DetenAcctB
                txtTollsAcctB.Text = .TollsAcctB
                txtFuelAcctB.Text = .FuelAcctB
                txtDropAcctB.Text = .DropAcctB
                txtReconAcctB.Text = .ReconAcctB
                txtTarpAcctB.Text = .TarpAcctB
                txtLumperAcctB.Text = .LumperAcctB
                txtUnloadAcctB.Text = .UnloadAcctB
                txtAdminMiscAcctB.Text = .AdminMiscAcctB

                chkCopyAddress.Checked = .CopyAddress
                chkShowOnWeb.Checked = .ShowOnWeb
                chkCorpOff.Checked = .CorpOff
                txtConfName.Text = .ConfName
                txtConfAddr.Text = .ConfAddr
                txtConfSTZ.Text = .ConfSTZ
                txtConfPNo.Text = .ConfPNo
                txtBWordsA.Text = .BWordsA
                txtBWordsB.Text = .BWordsB
                txtBWordsC.Text = .BWordsC
                chkPASplit.Checked = (.PASplit.ToUpper = "Y")

                chkCommAdj.Checked = (.CommAdj.ToUpper = "Y")
                chkMultiSing.Checked = (.MultiSing.ToUpper = "Y")
                chkBrokerOnly.Checked = (.BrokerOnly.ToUpper = "Y")
                chkAutoLoadSeq.Checked = (.AutoLoadSeq.ToUpper = "Y")
                Try
                    ddlWhatDivision.Items.FindByValue(.WhatDivision).Selected = True
                Catch
                End Try

                chkIntraOComm.Checked = (.IntraOComm.ToUpper = "Y")
                chkInitQForCust.Checked = (.InitQForCust.ToUpper = "Y")
                txtDay0.Text = .Day0.ToString
                txtDay7.Text = .Day7.ToString
                txtDay15.Text = .Day15.ToString
                txtDay30.Text = .Day30.ToString
                txtAlumaPct.Text = .AlumaPct.ToString
                If Not Null.IsNull(.Lastcorpbu) Then
                    txtLastcorpbu.Text = .Lastcorpbu.ToShortDateString
                End If

                chkXMissionSeq.Checked = (.XMissionSeq.ToUpper = "Y")
                txtCNOfficName.Text = .CNOfficName
                txtOffOrgin.Text = .OffOrgin
                chkDoABU.Checked = (.DoABU.ToUpper = "Y")
                txtTSL.Text = .TSL
                txtTPBCalc.Text = .TPBCalc
                If Not Null.IsNull(.LastCustUpd) Then
                    txtLastCustUpd.Text = .LastCustUpd.ToShortDateString
                End If
                If Not Null.IsNull(.LastUpdTime) Then
                    txtLastUpdTime.Text = .LastUpdTime.ToShortDateString
                End If
                txtAPCodeFM.Text = .APCodeFM
                txtAbvrNameFM.Text = .AbvrNameFM
                If Not Null.IsNull(.CommRateFM) Then
                    txtCommRateFM.Text = .CommRateFM.ToString
                End If
                If Not Null.IsNull(.BKCommRateFM) Then
                    txtBKCommRateFM.Text = .BKCommRateFM.ToString
                End If

                chkSubOffComm.Checked = (.SubOffComm.ToUpper = "Y")
                If Not Null.IsNull(.UserOn) Then
                    txtUserOn.Text = .UserOn.ToString
                End If
                txtMgrCode.Text = .MgrCode
                txtMgrName.Text = .MgrName
                If Not Null.IsNull(.CommRatex) Then
                    txtCommRatex.Text = .CommRatex.ToString
                End If
                If Not Null.IsNull(.BKCommRate) Then
                    txtBKCommRate.Text = .BKCommRate.ToString
                End If

                chkMGRSplit.Checked = (.MGRSplit.ToUpper = "Y")
                txtIODiv.Text = .IODiv
                txtLogDisp.Text = .LogDisp
                txtLogDispName.Text = .LogDispName
                txtLogonOffice.Text = .LogonOffice
                txtJRCOfficeNo.Text = .JRCOfficeNo
                chkAllowCDed.Checked = (.AllowCDed.ToUpper = "Y")
                txtDvrDAcct1.Text = .DvrDAcct1
                txtDvrDAcct2.Text = .DvrDAcct2
                If Not Null.IsNull(.OOLoadNo) Then
                    txtOOLoadNo.Text = .OOLoadNo.ToString
                End If
                If Not Null.IsNull(.BKLoadNo) Then
                    txtBKLoadNo.Text = .BKLoadNo.ToString
                End If
                If Not Null.IsNull(.AVLoadNo) Then
                    txtAVLoadNo.Text = .AVLoadNo.ToString
                End If


                chkJRCActive.Checked = (.JRCActive.ToUpper = "Y")

                If (.JRCActive.ToUpper = "Y") Then
                    imgJRCActive.ImageUrl = ResolveUrl("~/images/icon_survey_32px.gif") 'FileManager/files/OK.gif
                Else
                    imgJRCActive.ImageUrl = ResolveUrl("~/images/delete.gif") 'unchecked.gif
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
            End With 'objInterOffice

            chkCopyAddress_CheckedChanged(Nothing, Nothing)

        End Sub

        Private Function PageToItem() As InterOfficeInfo
            Dim objInterOffice As New InterOfficeInfo
            'Initialise the ojbInterOffice object
            objInterOffice = CType(CBO.InitializeObject(objInterOffice, GetType(Business.InterOfficeInfo)), InterOfficeInfo)

            CopyAddress()

            'bind text values to object
            With objInterOffice
                .ItemId = itemId
                .ModuleId = ModuleId

                .JRCIOfficeCode = txtJRCIOfficeCode.Text
                If txtIOfficeCode.Text = "" Then
                    .IOfficeCode = txtJRCIOfficeCode.Text.Substring(0, 7)
                Else
                    .IOfficeCode = txtIOfficeCode.Text
                End If
                .IOName = txtIOName.Text
                .AbvrName = txtAbvrName.Text
                .AddressLine1 = txtAddressLine1.Text
                .AddressLine2 = txtAddressLine2.Text
                .City = txtCity.Text
                '.State = txtState.Text
                .State = ddlStateCode.SelectedValue
                .ZipCode = txtZipCode.Text
                .CountryCode = txtCountryCode.Text
                .PhoneNo = txtPhoneNo.Text
                .Ext = txtExt.Text
                .EmailAddress = txtEmailAddress.Text
                .HasProbDrivers = chkHasProbDrivers.Checked
                .CommRate = txtCommRate.Text
                If chkAdminExempt.Checked Then
                    .AdminExempt = "Y"
                Else
                    .AdminExempt = "N"
                End If
                If chkStatus.Checked Then
                    .Status = "Y"
                Else
                    .Status = "N"
                End If
                .LoadType = txtLoadType.Text
                If String.IsNullOrEmpty(txtDivision.Text) Then txtDivision.Text = "JRC"
                .Division = txtDivision.Text
                .FaxNo = txtFaxNo.Text
                If chkOfficeOR.Checked Then
                    .OfficeOR = "Y"
                Else
                    .OfficeOR = "N"
                End If
                .OfficeORAcct = txtOfficeORAcct.Text
                Try
                    .OfficeORPct = Double.Parse(txtOfficeORPct.Text)
                Catch
                End Try
                .OfficeCodeNo = txtOfficeCodeNo.Text
                .LogOnPW = txtLogOnPW.Text
                .OfficName = txtOfficName.Text
                .OfficeAddr = txtOfficeAddr.Text
                .OfficeAbrv = txtOfficeAbrv.Text
                'If String.IsNullOrEmpty(txtTempFile1.Text) Then .TempFile1 = "JRC" Else .TempFile1 = txtTempFile1.Text
                .TempFile1 = txtTempFile1.Text
                .OONo = txtOONo.Text
                .BKNo = txtBKNo.Text
                .AVNo = txtAVNo.Text
                If chkUseDispatch.Checked Then
                    .UseDispatch = "Y"
                Else
                    .UseDispatch = "N"
                End If
                Try
                    .OfficePct = Double.Parse(txtOfficePct.Text)
                Catch
                End Try

                .LoadAcct = txtLoadAcct.Text
                .DiscAcct = txtDiscAcct.Text
                .DetenAcct = txtDetenAcct.Text
                .TollsAcct = txtTollsAcct.Text
                .FuelAcct = txtFuelAcct.Text
                .DropAcct = txtDropAcct.Text
                .ReconAcct = txtReconAcct.Text
                .TarpAcct = txtTarpAcct.Text
                .LumperAcct = txtLumperAcct.Text
                .UnloadAcct = txtUnloadAcct.Text
                .AdminMiscAcct = txtAdminMiscAcct.Text
                Try
                    .BKOfficePct = Double.Parse(txtBKOfficePct.Text)
                Catch
                End Try
                Try
                    .LastXferDate = Date.Parse(txtLastXferDate.Text)
                Catch
                End Try
                .LastXmission = txtLastXmission.Text
                Try
                    .Xfer = Decimal.Parse(txtXfer.Text)
                Catch
                End Try
                Try
                    .NoOffChar = Integer.Parse(ddlNoOffChar.SelectedValue)
                Catch
                    .NoOffChar = 2
                End Try
                If chkAllowORide.Checked Then
                    .AllowORide = "Y"
                Else
                    .AllowORide = "N"
                End If
                Try
                    .JRCAdminP = Double.Parse(txtJRCAdminP.Text)
                Catch
                End Try
                .Reminder = txtReminder.Text
                .DefDispNo = txtDefDispNo.Text
                .DefDispName = txtDefDispName.Text
                .LoadAcctB = txtLoadAcctB.Text
                .DiscAcctB = txtDiscAcctB.Text
                .DetenAcctB = txtDetenAcctB.Text
                .TollsAcctB = txtTollsAcctB.Text
                .FuelAcctB = txtFuelAcctB.Text
                .DropAcctB = txtDropAcctB.Text
                .ReconAcctB = txtReconAcctB.Text
                .TarpAcctB = txtTarpAcctB.Text
                .LumperAcctB = txtLumperAcctB.Text
                .UnloadAcctB = txtUnloadAcctB.Text
                .AdminMiscAcctB = txtAdminMiscAcctB.Text

                .CopyAddress = chkCopyAddress.Checked
                .ShowOnWeb = chkShowOnWeb.Checked
                .CorpOff = chkCorpOff.Checked
                .ConfName = txtConfName.Text
                .ConfAddr = txtConfAddr.Text
                .ConfSTZ = txtConfSTZ.Text
                .ConfPNo = txtConfPNo.Text
                .BWordsA = txtBWordsA.Text
                .BWordsB = txtBWordsB.Text
                .BWordsC = txtBWordsC.Text
                If chkPASplit.Checked Then
                    .PASplit = "Y"
                Else
                    .PASplit = "N"
                End If
                If chkCommAdj.Checked Then
                    .CommAdj = "Y"
                Else
                    .CommAdj = "N"
                End If
                If chkMultiSing.Checked Then
                    .MultiSing = "Y"
                Else
                    .MultiSing = "N"
                End If
                If chkBrokerOnly.Checked Then
                    .BrokerOnly = "Y"
                Else
                    .BrokerOnly = "N"
                End If
                If chkAutoLoadSeq.Checked Then
                    .AutoLoadSeq = "Y"
                Else
                    .AutoLoadSeq = "N"
                End If
                .WhatDivision = ddlWhatDivision.SelectedValue
                If chkIntraOComm.Checked Then
                    .IntraOComm = "Y"
                Else
                    .IntraOComm = "N"
                End If
                If chkInitQForCust.Checked Then
                    .InitQForCust = "Y"
                Else
                    .InitQForCust = "N"
                End If
                Try
                    .Day0 = Decimal.Parse(txtDay0.Text)
                Catch
                End Try
                Try
                    .Day7 = Decimal.Parse(txtDay7.Text)
                Catch
                End Try
                Try
                    .Day15 = Decimal.Parse(txtDay15.Text)
                Catch
                End Try
                Try
                    .Day30 = Decimal.Parse(txtDay30.Text)
                Catch
                End Try
                Try
                    .AlumaPct = Double.Parse(txtAlumaPct.Text)
                Catch
                End Try
                Try
                    .Lastcorpbu = Date.Parse(txtLastcorpbu.Text)
                Catch
                End Try
                If chkXMissionSeq.Checked Then
                    .XMissionSeq = "Y"
                Else
                    .XMissionSeq = "N"
                End If
                .CNOfficName = txtCNOfficName.Text
                .OffOrgin = txtOffOrgin.Text
                If chkDoABU.Checked Then
                    .DoABU = "Y"
                Else
                    .DoABU = "N"
                End If
                .TSL = txtTSL.Text
                .TPBCalc = txtTPBCalc.Text
                Try
                    .LastCustUpd = Date.Parse(txtLastCustUpd.Text)
                Catch
                End Try
                Try
                    .LastUpdTime = Date.Parse(txtLastUpdTime.Text)
                Catch
                End Try
                .APCodeFM = txtAPCodeFM.Text
                .AbvrNameFM = txtAbvrNameFM.Text
                Try
                    .CommRateFM = Double.Parse(txtCommRateFM.Text)
                Catch
                End Try
                Try
                    .BKCommRateFM = Double.Parse(txtBKCommRateFM.Text)
                Catch
                End Try
                If chkSubOffComm.Checked Then
                    .SubOffComm = "Y"
                Else
                    .SubOffComm = "N"
                End If
                Try
                    .UserOn = Integer.Parse(txtUserOn.Text)
                Catch
                End Try
                .MgrCode = txtMgrCode.Text
                .MgrName = txtMgrName.Text
                Try
                    .CommRatex = Double.Parse(txtCommRatex.Text)
                Catch
                End Try
                Try
                    .BKCommRate = Double.Parse(txtBKCommRate.Text)
                Catch
                End Try
                If chkMGRSplit.Checked Then
                    .MGRSplit = "Y"
                Else
                    .MGRSplit = "N"
                End If
                .IODiv = txtIODiv.Text
                .LogDisp = txtLogDisp.Text
                .LogDispName = txtLogDispName.Text
                .LogonOffice = txtLogonOffice.Text
                .JRCOfficeNo = txtJRCOfficeNo.Text
                If chkAllowCDed.Checked Then
                    .AllowCDed = "Y"
                Else
                    .AllowCDed = "N"
                End If
                .DvrDAcct1 = txtDvrDAcct1.Text
                .DvrDAcct2 = txtDvrDAcct2.Text
                Try
                    .OOLoadNo = Integer.Parse(txtOOLoadNo.Text)
                Catch
                End Try
                Try
                    .BKLoadNo = Integer.Parse(txtBKLoadNo.Text)
                Catch
                End Try
                Try
                    .AVLoadNo = Integer.Parse(txtAVLoadNo.Text)
                Catch
                End Try
                If chkJRCActive.Checked Then
                    .JRCActive = "Y"
                Else
                    .JRCActive = "N"
                End If

                If txtViewOrder.Text <> String.Empty Then
                    Try
                        .ViewOrder = Integer.Parse(txtViewOrder.Text)
                    Catch
                    End Try
                End If

                'Audit Control
                .UpdatedByUserId = UserInfo.UserID
                .CreatedByUserId = .UpdatedByUserId

            End With 'objInterOffice
            Return objInterOffice
        End Function

        Private Sub InitControls()
            'cmdDelete.Visible = Not Null.IsNull(itemId)
            'imbDelete.Visible = cmdDelete.Visible
            'cmdUpdate.Visible = cmdDelete.Visible
            'imbUpdate.Visible = cmdUpdate.Visible
            'cmdAdd.Visible = Not cmdUpdate.Visible
            'imbAdd.Visible = cmdAdd.Visible

            'cvJRCIOfficeCode.Visible = cmdAdd.Visible

            'this needs to execute always to the client script code is registred in InvokePopupCal
            'cmdCalendarLastXferDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtLastXferDate)
            'cmdCalendarLastcorpbu.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtLastcorpbu)
            'cmdCalendarLastCustUpd.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtLastCustUpd)
            'cmdCalendarLastUpdTime.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtLastUpdTime)


            'Dim OfficeAdmin As Boolean = Users.UserController.GetCurrentUserInfo.IsSuperUser OrElse Users.UserController.GetCurrentUserInfo.IsInRole("Administrators") OrElse Users.UserController.GetCurrentUserInfo.IsInRole("Admin - JRC") 'OrElse Users.UserController.GetCurrentUserInfo.IsInRole("Offices - Admin")
            Dim WordsOnly As Boolean = (New OptionsInfo(ModuleId)).ViewControl.ToUpper = "WORDS"
            If WordsOnly Then
                chkJRCActive.Style.Add("display", "none")
            Else
                imgJRCActive.Style.Add("display", "none")
            End If

            tblIODetails.Visible = Not WordsOnly
            tdConfirmation.Visible = Not WordsOnly
            If Not Null.IsNull(itemId) Then
                txtJRCIOfficeCode.ReadOnly = WordsOnly
                txtIOfficeCode.ReadOnly = WordsOnly
            End If
            txtIOName.ReadOnly = WordsOnly

            If Not Page.IsPostBack Then
                BindStateCodes()
                SetIconBar()
            End If
        End Sub
        Sub BindStateCodes()
            With ddlStateCode
                '.DataValueField = "StateCode"
                '.DataTextField = "StateCode" '"State"
                .DataSource = (New InterOfficesController).GetStateCodes
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

            cvJRCIOfficeCode.Visible = cmdAdd.Visible


            If tdDelete.Visible Then tdDelete.Visible = Users.UserController.GetCurrentUserInfo.IsInRole("Administrators")
            If tdDelete.Visible Then
                cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                imbDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
            End If
        End Sub 'SetIconBar()

    

#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
            Try
                objOI = New OptionsInfo(ModuleId)
                If objOI.OnlyHostCanEdit AndAlso (Not Users.UserController.GetCurrentUserInfo.IsSuperUser) Then
                    Response.Redirect(NavigateURL(), True)
                End If


                ' Determine ItemId
                If Request.Params("ItemId") Is Nothing Then
                    itemId = Null.NullInteger()
                    'Disable the IOfficeCode and get it only from JRCIOfficeCode
                    If Not Users.UserController.GetCurrentUserInfo.IsInRole("acct_num_update") Then
                        cvIOfficeCode.Visible = False
                        txtIOfficeCode.ReadOnly = True
                        txtIOfficeCode.CssClass = "NormalBold"
                        txtIOfficeCode.Style.Add(HtmlTextWriterStyle.BorderWidth, "0")
                    End If
                Else
                    itemId = Int32.Parse(Request.Params("ItemId"))
                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                    imbDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                End If

                'Initilise the Controls and set its properties as well as Visiblity
                InitControls()

                If Not Page.IsPostBack Then

                    If Not Null.IsNull(itemId) Then
                        Dim objInterOffice As InterOfficeInfo = (New InterOfficesController).GetInterOffice(itemId)

                        If Not objInterOffice Is Nothing Then
                            'Load data
                            ItemToPage(objInterOffice)

                            'set the NoOfChar Validators's ClientValidationFunction
                            ddlNoOffChar_SelectedIndexChanged(Nothing, Nothing)
                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If

                    End If
                End If
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Protected Sub ddlNoOffChar_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlNoOffChar.SelectedIndexChanged
            cvOONo.ClientValidationFunction = "ClientValidate" & ddlNoOffChar.SelectedValue & "char"
            cvBKNo.ClientValidationFunction = "ClientValidate" & ddlNoOffChar.SelectedValue & "char"
            cvAVNo.ClientValidationFunction = "ClientValidate" & ddlNoOffChar.SelectedValue & "char"

            cvOONo.ErrorMessage = "<b>Invalid PreFix</b><br/>The OONo must be of " & ddlNoOffChar.SelectedValue & " characters"
            cvBKNo.ErrorMessage = "<b>Invalid PreFix</b><br/>The BKNo must be of " & ddlNoOffChar.SelectedValue & " characters"
            cvAVNo.ErrorMessage = "<b>Invalid PreFix</b><br/>The AVNo must be of " & ddlNoOffChar.SelectedValue & " characters"

            If ddlNoOffChar.SelectedValue = "2" Then
                'valOOLoadNo0.MinimumValue = 10000
                valOOLoadNo0.MaximumValue = 99999
                'valBKLoadNo0.MinimumValue = 10000
                valBKLoadNo0.MaximumValue = 99999
                'valAVLoadNo0.MinimumValue = 10000
                valAVLoadNo0.MaximumValue = 99999
            Else
                'valOOLoadNo0.MinimumValue = 1000
                valOOLoadNo0.MaximumValue = 9999
                'valBKLoadNo0.MinimumValue = 1000
                valBKLoadNo0.MaximumValue = 9999
                'valAVLoadNo0.MinimumValue = 1000
                valAVLoadNo0.MaximumValue = 9999
            End If

            valOOLoadNo0.ErrorMessage = "<b>Out of Range</b><br/>The value of OOLoadNo must be within " & valOOLoadNo0.MinimumValue.ToString & " and " & valOOLoadNo0.MaximumValue.ToString
            valBKLoadNo0.ErrorMessage = "<b>Out of Range</b><br/>The value of BKLoadNo must be within " & valBKLoadNo0.MinimumValue.ToString & " and " & valBKLoadNo0.MaximumValue.ToString
            valAVLoadNo0.ErrorMessage = "<b>Out of Range</b><br/>The value of AVLoadNo must be within " & valAVLoadNo0.MinimumValue.ToString & " and " & valAVLoadNo0.MaximumValue.ToString

            txtOONo.MaxLength = CInt(ddlNoOffChar.SelectedValue)
            txtBKNo.MaxLength = CInt(ddlNoOffChar.SelectedValue)
            txtAVNo.MaxLength = CInt(ddlNoOffChar.SelectedValue)

            txtOOLoadNo.MaxLength = 7 - CInt(ddlNoOffChar.SelectedValue)
            txtBKLoadNo.MaxLength = 7 - CInt(ddlNoOffChar.SelectedValue)
            txtAVLoadNo.MaxLength = 7 - CInt(ddlNoOffChar.SelectedValue)

            If txtOONo.Text.Length > txtOONo.MaxLength Then txtOONo.Text = txtOONo.Text.Substring(0, txtOONo.MaxLength)
            If txtBKNo.Text.Length > txtBKNo.MaxLength Then txtBKNo.Text = txtBKNo.Text.Substring(0, txtBKNo.MaxLength)
            If txtAVNo.Text.Length > txtAVNo.MaxLength Then txtAVNo.Text = txtAVNo.Text.Substring(0, txtAVNo.MaxLength)
            If txtOOLoadNo.Text.Length > txtOOLoadNo.MaxLength Then txtOOLoadNo.Text = txtOOLoadNo.Text.Substring(0, txtOOLoadNo.MaxLength)
            If txtBKLoadNo.Text.Length > txtBKLoadNo.MaxLength Then txtBKLoadNo.Text = txtBKLoadNo.Text.Substring(0, txtBKLoadNo.MaxLength)
            If txtAVLoadNo.Text.Length > txtAVLoadNo.MaxLength Then txtAVLoadNo.Text = txtAVLoadNo.Text.Substring(0, txtAVLoadNo.MaxLength)
        End Sub

        Private Sub cmdGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGo.Click
            Dim Code As String = txtGenCode.Text
            txtLoadAcct.Text = "TRK" & Code
            txtDiscAcct.Text = "DSC" & Code
            txtDetenAcct.Text = "DTN" & Code
            txtTollsAcct.Text = "TOL" & Code
            txtFuelAcct.Text = "FUE" & Code
            txtDropAcct.Text = "DRP" & Code
            txtReconAcct.Text = "RCN" & Code
            txtTarpAcct.Text = "TRP" & Code
            txtLumperAcct.Text = "LMP" & Code
            txtUnloadAcct.Text = "SLF" & Code
            txtAdminMiscAcct.Text = "MSC" & Code


            txtLoadAcctB.Text = txtLoadAcct.Text & "B"
            txtDiscAcctB.Text = "DSC" & Code & "B"
            txtDetenAcctB.Text = "DTN" & Code & "B"
            txtTollsAcctB.Text = "TOL" & Code & "B"
            txtFuelAcctB.Text = "FUE" & Code & "B"
            txtDropAcctB.Text = "DRP" & Code & "B"
            txtReconAcctB.Text = "RCN" & Code & "B"
            txtTarpAcctB.Text = "TRP" & Code & "B"
            txtLumperAcctB.Text = "LMP" & Code & "B"
            txtUnloadAcctB.Text = "SLF" & Code & "B"
            txtAdminMiscAcctB.Text = "MSC" & Code & "B"
        End Sub

        Private Sub imbAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAdd.Click
            cmdAdd_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            'If (New Business.InterOfficesController).IsUniqueCode(txtJRCIOfficeCode.Text) Then
            '    cmdUpdate_Click(Nothing,Nothing)
            'Else
            '    DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "JRCIOfficeCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            '    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "JRCIOfficeCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            'End If

            If (New Business.InterOfficesController).IsUniqueCode(txtJRCIOfficeCode.Text) Then
                cmdUpdate_Click(Nothing, Nothing)
                'Controls.Add(objOI.Popup("Success", "New JRCIOffice with JRCIOffice Code " & txtJRCIOfficeCode.Text & " added successfully", "New JRCIOffice with JRCIOffice Code " & txtJRCIOfficeCode.Text & " added successfully in the Database."))
                lblMsg.Text = "<font color='green'>Success<br/>New JRCIOffice with JRCIOffice Code " & txtJRCIOfficeCode.Text & " added successfully in the Database.</font>"
            Else
                'Controls.Add(objOI.Popup("Failure", "JRCIOffice with JRCIOffice Code " & txtJRCIOfficeCode.Text & " already exists", "JRCIOffice with JRCIOffice Code " & txtJRCIOfficeCode.Text & " already exists in the Database. Please choose another JRCIOffice Code"))
                lblMsg.Text = "<font color='red'>Failure<br/>JRCIOffice with JRCIOffice Code " & txtJRCIOfficeCode.Text & " already exists in the Database. Please choose another JRCIOffice Code</font>"
                DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "JRCIOfficeCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "JRCIOfficeCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If
        End Sub

        Private Sub chkCopyAddress_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCopyAddress.CheckedChanged
            txtConfName.ReadOnly = chkCopyAddress.Checked
            txtConfAddr.ReadOnly = chkCopyAddress.Checked
            txtConfSTZ.ReadOnly = chkCopyAddress.Checked
            txtConfPNo.ReadOnly = chkCopyAddress.Checked

            CopyAddress()
        End Sub

        Private Sub CopyAddress()
            If chkCopyAddress.Checked Then
                txtConfName.Text = txtAbvrName.Text
                txtConfAddr.Text = txtAddressLine1.Text
                If txtAddressLine2.Text <> "" Then txtConfAddr.Text &= txtAddressLine2.Text
                txtConfSTZ.Text = txtCity.Text & ", " & ddlStateCode.SelectedValue & " - " & txtZipCode.Text
                If txtPhoneNo.Text <> "" Then txtConfPNo.Text = "Phone #: " & txtPhoneNo.Text
                If txtFaxNo.Text <> "" Then txtConfPNo.Text &= vbCrLf & "Fax #: " & txtFaxNo.Text
            End If
        End Sub

        Private Sub imbUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdate.Click ', imbAdd.Click
            cmdUpdate_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click ', cmdAdd.Click
            Try
                ' Only Update if the Entered Data is Valid
                If Page.IsValid Then
                    'Dim objInterOffice As New InterOfficeInfo
                    ''Initialise the ojbInterOffice object
                    'objInterOffice = CType(CBO.InitializeObject(objInterOffice, GetType(Business.InterOfficeInfo)), InterOfficeInfo)

                    'bind text values to object
                    Dim objInterOffice As InterOfficeInfo = PageToItem()


                    Dim objInterOfficesController As New InterOfficesController
                    If Null.IsNull(itemId) Then
                        itemId = objInterOfficesController.AddInterOffice(objInterOffice)
                    Else
                        objInterOfficesController.UpdateInterOffice(objInterOffice)
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
                    Dim objInterOfficesController As New InterOfficesController
                    objInterOfficesController.DeleteInterOffice(itemId)
                End If

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

    End Class 'EditItem

End Namespace 'bhattji.Modules.InterOffices
