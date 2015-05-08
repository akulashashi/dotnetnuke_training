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
Imports bhattji.Modules.LoadSheets.Business
'Imports Microsoft.ScalableHosting.Security
'Imports AspNetSecurity = Microsoft.ScalableHosting.Security

#End Region

Namespace bhattji.Modules.LoadSheets

    Public MustInherit Class EditItem
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "
        Private itemId As Integer
        Private objOI As OptionsInfo
        Private PickupDate As Date
        Private loadId As String

        'Shared IsCopiedLoad As Boolean

        'Shared IsNeverUpdated As Boolean
#End Region

#Region " Public Methods "
        Private Sub BindReps()
            With ddlRepNo
                .DataValueField = "RepNo"
                .DataTextField = "RepName"
                .DataSource = (New Business.LoadSheetsController).GetAllSalesReps
                .DataBind()
            End With
        End Sub

        Private Sub ItemToPage(ByVal ItemId As Integer)
            If Not Null.IsNull(ItemId) Then 'Check for the Not-Null ItemId
                Dim objLoadSheet As LoadSheetInfo = (New LoadSheetsController).GetLoadSheet(ItemId)
                'Check for the Not-Null objLoadSheet
                If Not objLoadSheet Is Nothing Then ItemToPage(objLoadSheet)
            End If
        End Sub

        Private Sub DisableCopyLoadIcon(ByVal Disable As Boolean)
            imbCopyLoad.Enabled = Not Disable
            lnbCopyLoad.Enabled = Not Disable
            If imbCopyLoad.Enabled Then
                imbCopyLoad.ImageUrl = ResolveUrl("~/images/icon_lists_32px.gif")
                imbCopyLoad.ToolTip = "Copy, Convert or Template this Load"
            Else
                imbCopyLoad.ImageUrl = ResolveUrl("~/images/icon_lists_32px-disabled.gif")
                imbCopyLoad.ToolTip = "Cannot Copy, Convert or Template the IORecovered Load"
            End If
            lnbCopyLoad.ToolTip = imbCopyLoad.ToolTip
        End Sub
        Private Sub ItemToPage(ByVal objLoadSheet As LoadSheetInfo)
            With objLoadSheet
                Dim I As Integer 'Variable defined for the finding out the Index Value
                hypLoadAccounting.NavigateUrl = EditUrl("LoadID", .LoadID, "EditAcct")
                hypLoadAccounting.ToolTip = "Go to Load Accounting for Load '" & .LoadID & "'"
                hypLoadAccounting.Attributes.Add("onmouseover", "window.status=this.title; return true")

                'IsNeverUpdated = (.CreatedDate = .UpdatedDate)
                'IsCopiedLoad = .IsCopiedLoad
                txtLoadID.Text = .LoadID
                txtOfficeVendorNO.Text = .OfficeVendorNO
                txtJRCIOfficeCode.Text = .JRCIOfficeCode
                If Not Null.IsNull(.LoadDate) Then
                    txtLoadDate.Text = .LoadDate.ToShortDateString
                    'calLoadDate.SelectedDate = .LoadDate
                End If
                If Not Null.IsNull(.DeliveryDate) Then
                    txtDeliveryDate.Text = .DeliveryDate.ToShortDateString
                End If
                chkCompletedLoad.Checked = .CompletedLoad

                If Not Null.IsNull(.CompletedDate) Then
                    txtCompletedDate.Text = .CompletedDate.ToShortDateString
                End If
                txtOfficeCode.Text = .OfficeCode

                Try
                    ddlCustomerNumber.Items.Insert(0, (New ListItem("To be assigned", "0000000")))
                    'CN = .CustomerName
                    'CC = .CustomerNumber
                    'ddlCustomerNumber.Items.Add(New ListItem(CN, CC))
                    ddlCustomerNumber.Items.Add(New ListItem(.CustomerName, .CustomerNumber))
                    ddlCustomerNumber.Items.FindByValue(.CustomerNumber).Selected = True
                Catch
                End Try
                ViewState("CustomerNumber") = ddlCustomerNumber.SelectedValue

                'txtCustomerNumber.Text = .CustomerNumber
                'txtCustomerName.Text = .CustomerName
                txtCustomerNumber.Text = "" 'ddlCustomerNumber.SelectedValue
                txtCustomerName.Text = "" 'ddlCustomerNumber.SelectedItem.Text

                txtCustPO.Text = .CustPO
                txtTrailerNumber.Text = .TrailerNumber
                If Not Null.IsNull(.TrailerDue) Then
                    txtTrailerDue.Text = .TrailerDue.ToShortDateString
                End If

                txtContainer1.Text = .Container1 'nvarchar
                If Not Null.IsNull(.Container1Due) Then txtContainer1Due.Text = .Container1Due.ToShortDateString 'datetime
                txtContainer2.Text = .Container2 'nvarchar
                If Not Null.IsNull(.Container2Due) Then txtContainer2Due.Text = .Container2Due.ToShortDateString 'datetime

                ViewState("DriverCode") = .DriverCode '"ZXZX"
                ViewState("DriverName") = .DriverName '"N/A"

                Try
                    ddlBkrDriverNo.Items.Insert(0, New ListItem("To be assigned", "ZXZX"))
                    ddlDriverCode.Items.Add(New ListItem(.DriverName, .DriverCode))
                    ddlDriverCode.Items.FindByValue(.DriverCode).Selected = True
                Catch
                End Try
                'txtDriverName.Text = .DriverName
                txtDriverName.Text = ddlDriverCode.SelectedItem.Text

                Try
                    ddlBrokerCode.Items.Insert(0, (New ListItem("To be assigned", "0000000")))
                    'BN = .BrokerName
                    'BC = .BrokerCode
                    'ddlBrokerCode.Items.Add(New ListItem(BN, BC))
                    ddlBrokerCode.Items.Add(New ListItem(.BrokerName, .BrokerCode))
                    ddlBrokerCode.Items.FindByValue(.BrokerCode).Selected = True
                Catch
                End Try
                'txtBrokerName.Text = .BrokerName
                txtBrokerCode.Text = "" 'ddlBrokerCode.SelectedValue
                txtBrokerName.Text = "" 'ddlBrokerCode.SelectedItem.Text
                ViewState("BrokerCode") = ddlBrokerCode.SelectedValue

                txtJRCIOCode.Text = .JRCIOCode
                Try
                    ddlIOCode.Items.Add(New ListItem(.IOName, .JRCIOCode))
                    ddlIOCode.Items.FindByValue(.JRCIOCode).Selected = True
                Catch
                End Try
                txtIOName.Text = .IOName
                ViewState("CanRecover") = .CanRecover
                SetCanRecover()
                SeteMailTo()

                If Not Null.IsNull(.OverrideComm) Then
                    txtOverrideComm.Text = .OverrideComm.ToString
                End If
                If Not Null.IsNull(.DriverPct) Then
                    txtDriverPct.Text = .DriverPct.ToString
                End If
                txtFOB.Text = .FOB
                txtLoadNotes.Text = .LoadNotes.ToUpper
                txtComCheckSeq.Text = .ComCheckSeq
                If Not Null.IsNull(.ComCheckAmt) Then
                    txtComCheckAmt.Text = String.Format("{0:0.00}", .ComCheckAmt)
                End If
                txtCodCheckSeq.Text = .CodCheckSeq
                If Not Null.IsNull(.CodCheckAmt) Then
                    txtCodCheckAmt.Text = String.Format("{0:0.00}", .CodCheckAmt)
                End If

                chkTarpLoad.Checked = (.TarpLoad.ToUpper = "Y")
                trTarpMessage.Visible = chkTarpLoad.Checked
                'txtTarpMessage.Enabled = chkTarpLoad.Checked
                If chkTarpLoad.Checked Then
                    txtTarpMessage.Text = .TarpMessage
                    'If .TarpMessage = "" Then
                    '    txtTarpMessage.Text = "THIS LOAD MUST BE TARPED"
                    'Else
                    '    txtTarpMessage.Text = .TarpMessage
                    'End If
                End If

                txtDispatchCode.Text = .DispatchCode
                txtDispName.Text = .DispName
                'txtLoadStatus.Text = .LoadStatus
                Try
                    'ddlLoadStatus.ClearSelection()
                    'ddlLoadStatus.Items.FindByValue(.LoadStatus.ToUpper).Selected = True
                    ddlLoadStatus.SelectedValue = .LoadStatus.ToUpper
                Catch
                End Try
                SetLoadStatusText(ddlLoadStatus.SelectedItem.Text)
                If Not Null.IsNull(.DispOverride) Then
                    txtDispOverride.Text = .DispOverride.ToString
                End If
                Try
                    'ddlRepNo.Items.FindByValue(.RepNo).Selected = True
                    ddlRepNo.SelectedValue = .RepNo
                Catch
                End Try
                'txtRepNo.Text = ddlRepNo.SelectedValue '.RepNo
                txtRepName.Text = ddlRepNo.SelectedItem.Text '.RepName
                If Not Null.IsNull(.LastUpdate) Then
                    txtLastUpdate.Text = .LastUpdate.ToShortDateString
                End If
                If Not Null.IsNull(.XmissionSeq) Then
                    txtXmissionSeq.Text = .XmissionSeq.ToString
                End If

                I = ddlLoadType.Items.IndexOf(ddlLoadType.Items.FindByValue(.LoadType.ToString.ToUpper))
                If I > -1 Then
                    ddlLoadType.Items(I).Selected = True
                Else
                    ddlLoadType.Items(0).Selected = True
                End If
                txtLoadType.Text = ddlLoadType.SelectedItem.Text
                'Try
                '    ddlLoadType.Items.FindByValue(.LoadType).Selected = True
                'Catch
                'End Try

                If Not Null.IsNull(.DriverComm) Then
                    txtDriverComm.Text = .DriverComm.ToString
                End If
                If Not Null.IsNull(.BrokerComm) Then
                    txtBrokerComm.Text = .BrokerComm.ToString
                End If
                txtLoadWeight.Text = .LoadWeight
                txtLoadPieces.Text = .LoadPieces
                If Not Null.IsNull(.LoadMileage) Then
                    txtLoadMileage.Text = .LoadMileage.ToString
                End If
                'chkAdminExempt.Checked = .AdminExempt
                chkAdminExempt.Checked = (.AdminExempt.ToUpper = "Y")
                txtProNox.Text = .ProNox
                txtXMissionFile.Text = .XMissionFile
                If Not Null.IsNull(.XMissionDate) Then
                    txtXMissionDate.Text = .XMissionDate.ToShortDateString
                End If
                If Not Null.IsNull(.EntryDate) Then
                    txtEntryDate.Text = .EntryDate.ToShortDateString
                End If
                If Not Null.IsNull(.RepDlrM) Then
                    txtRepDlrM.Text = .RepDlrM.ToString
                End If
                If Not Null.IsNull(.RepPctM) Then
                    txtRepPctM.Text = .RepPctM.ToString
                End If
                txtRepOverride.Text = .RepOverride
                If Not Null.IsNull(.RepDlrStd) Then
                    txtRepDlrStd.Text = .RepDlrStd.ToString
                End If
                If Not Null.IsNull(.RepPctStd) Then
                    txtRepPctStd.Text = .RepPctStd.ToString
                End If
                txtCorpTo.Text = .CorpTo
                'txtTrailerType.Text = .TrailerType
                Try
                    ddlTrailerType.SelectedValue = .TrailerType.ToUpper
                Catch
                End Try
                I = ddlBrokerType.Items.IndexOf(ddlBrokerType.Items.FindByValue(.BrokerType.ToString))
                If I > -1 Then
                    ddlBrokerType.Items(I).Selected = True
                Else
                    ddlBrokerType.Items(0).Selected = True
                End If
                chkOfficePaid.Checked = (.OfficePaid.ToUpper = "Y")

                txtPDCkNo.Text = .PDCkNo
                If Not Null.IsNull(.PDDate) Then
                    txtPDDate.Text = .PDDate.ToShortDateString
                End If
                If Not Null.IsNull(.PDAmt) Then
                    txtPDAmt.Text = .PDAmt.ToString
                End If
                txtProJob.Text = .ProJob
                txtInvCommentA.Text = .InvCommentA
                txtInvCommentB.Text = .InvCommentB
                txtInvCommentC.Text = .InvCommentC
                txtInvCommentD.Text = .InvCommentD
                txtBkrInvNo.Text = .BkrInvNo
                txtReasonFor.Text = .ReasonFor
                If Not Null.IsNull(.BkrInvDate) Then
                    txtBkrInvDate.Text = .BkrInvDate.ToShortDateString
                End If
                chkIOAvail.Checked = (.IOAvail.ToUpper = "Y")
                chkIsPrinted.Checked = (.IsPrinted.ToUpper = "Y") OrElse (.IsPrinted.ToUpper = "PRINTED")
                If (.IsPrinted.ToUpper = "Y") OrElse (.IsPrinted.ToUpper = "PRINTED") Then
                    imgIsPrinted.ImageUrl = ResolveUrl("~/images/icon_survey_32px.gif") 'FileManager/files/OK.gif
                Else
                    imgIsPrinted.ImageUrl = ResolveUrl("~/images/NotPrinted.gif") 'unchecked.gif
                End If
                txtAcctNull.Text = .AcctNull
                chkBkrFunds.Checked = (.BkrFunds.ToUpper = "US")
                chkOffFunds.Checked = (.OffFunds.ToUpper = "US")
                chkOffOrgin.Checked = (.OffOrgin.ToUpper = "US")
                txtCNOfficeVendorNO.Text = .CNOfficeVendorNO
                If Not Null.IsNull(.PUSEQ) Then
                    txtPUSEQ.Text = .PUSEQ.ToString
                End If
                chkShowPUInfo.Checked = .ShowPUInfo
                txtPUCityST.Text = .PUCityST
                txtDPCityST.Text = .DPCityST
                If Not Null.IsNull(.DPSEQ) Then
                    txtDPSEQ.Text = .DPSEQ.ToString
                End If
                chkIsIODiv.Checked = (.IsIODiv.ToUpper = "Y")
                If Not Null.IsNull(.OLPUDate) Then
                    txtOLPUDate.Text = .OLPUDate.ToShortDateString
                End If
                txtOLNoStops.Text = .OLNoStops
                txtCarrierName.Text = .CarrierName
                txtBkrIOName.Text = .BkrIOName
                txtBkrDriverNo.Text = .BkrDriverNo
                txtBKDriver.Text = .BKDriver
                chkCommPaid.Checked = .CommPaid
                txtLDNotesA.Text = .LDNotesA
                txtLDNotesB.Text = .LDNotesB
                txtLDNotesC.Text = .LDNotesC
                txtLDNotesD.Text = .LDNotesD
                'Try
                '    ddlLoadMo.Items.FindByValue(.LoadMo.ToString).Selected = True
                'Catch
                'End Try

                I = ddlLoadMo.Items.IndexOf(ddlLoadMo.Items.FindByValue(.LoadMo.ToString))
                If I > -1 Then
                    ddlLoadMo.Items(I).Selected = True
                Else
                    ddlLoadMo.Items(0).Selected = True
                End If
                I = ddlLoadYR.Items.IndexOf(ddlLoadYR.Items.FindByValue(.LoadYR.ToString))
                If I > -1 Then
                    ddlLoadYR.Items(I).Selected = True
                Else
                    ddlLoadYR.Items(0).Selected = True
                End If
                chkCalc85.Checked = (.Calc85.ToUpper = "Y")
                If Not Null.IsNull(.DvrDedPct) Then
                    txtDvrDedPct.Text = .DvrDedPct.ToString
                End If
                txtDvrDedResn.Text = .DvrDedResn

                'With ddlBkrDriverNo
                '    .DataValueField = "DriverCode"
                '    .DataTextField = "DriverName"
                '    .DataSource = (New LoadSheetsController).GetBrokerByCode(objLoadSheet.BrokerCode)
                '    .DataBind()
                'End With
                BindBkrDrivers(.BkrDriverNo)
                If .BkrDriverNo <> "" Then
                    Try
                        ddlBkrDriverNo.ClearSelection()
                        ddlBkrDriverNo.Items.Insert(0, New ListItem("To be assigned", "ZXZX"))
                        ddlBkrDriverNo.Items.FindByValue(.BkrDriverNo).Selected = True
                    Catch
                    End Try
                End If

                If Not Null.IsNull(.ViewOrder) Then
                    txtViewOrder.Text = .ViewOrder.ToString
                End If

                'Audit Control
                ctlAudit.CreatedByUser = .CreatedByUser
                ctlAudit.CreatedDate = .CreatedDate.ToString

                'Tracking Control
                'ctlTracking.URL = .NavURL
                ctlTracking.ModuleID = .ModuleId
            End With 'objLoadSheet

        End Sub

        Private Sub ItemToPage(ByVal objLoadPU As LoadPUInfo)
            With objLoadPU

                If Not Null.IsNull(.Seq) Then
                    txtSeq.Text = .Seq.ToString
                End If
                txtPUName.Text = .PUName
                txtPUAdd1.Text = .PUAdd1
                txtPRONo.Text = .PRONo
                txtPUCity.Text = .PUCity
                txtPUState.Text = .PUState
                txtPUTel.Text = .PUTel
                txtPUContact.Text = .PUContact
                If Not Null.IsNull(.PUTime) Then
                    txtPUDate.Text = .PUDate.ToShortDateString
                End If
                If Not Null.IsNull(.PUTime) Then
                    txtPUTime.Text = .PUTime.ToShortTimeString
                End If
                txtPieces.Text = .Pieces
                txtWeight.Text = .Weight
                If Not Null.IsNull(.Miles) Then
                    txtMiles.Text = .Miles.ToString
                End If

            End With 'objLoadPU
        End Sub

        Private Sub ItemToPage(ByVal objLoadDrop As LoadDropInfo)
            With objLoadDrop

                If Not Null.IsNull(.Seq) Then
                    txtSeq.Text = .Seq.ToString
                End If
                txtDPName.Text = .DPName
                txtDPAddr.Text = .DPAddr
                txtDPCity.Text = .DPCity
                txtDPState.Text = .DPState
                txtDPPhone.Text = .DPPhone
                If Not Null.IsNull(.DPDate) Then
                    txtDPDate.Text = .DPDate.ToShortDateString
                End If
                txtDPContact.Text = .DPContact
                txtJobno.Text = .Jobno
                txtBillOLay.Text = .BillOLay
                txtBOLSeq.Text = .BOLSeq
                If Not Null.IsNull(.Stime) Then
                    txtStime.Text = .Stime.ToShortDateString
                End If
                If Not Null.IsNull(.Etime) Then
                    txtEtime.Text = .Etime.ToShortDateString
                End If

            End With 'objLoadDrop
        End Sub

        Private Function PageToItem() As LoadSheetInfo
            Dim objLoadSheet As New LoadSheetInfo
            'Initialise the ojbLoadSheet object
            objLoadSheet = CType(CBO.InitializeObject(objLoadSheet, GetType(LoadSheetInfo)), LoadSheetInfo)

            'bind text values to object
            With objLoadSheet
                .ItemId = itemId
                .ModuleId = ModuleId

                .LoadID = txtLoadID.Text


                .OfficeVendorNO = txtOfficeVendorNO.Text
                .JRCIOfficeCode = txtJRCIOfficeCode.Text
                Try
                    .LoadDate = Date.Parse(txtLoadDate.Text)
                    '.LoadDate = calLoadDate.OnClientShown
                Catch
                End Try
                Try
                    .DeliveryDate = Date.Parse(txtDeliveryDate.Text)
                Catch
                End Try
                .CompletedLoad = chkCompletedLoad.Checked
                Try
                    .CompletedDate = Date.Parse(txtCompletedDate.Text)
                Catch
                End Try
                .OfficeCode = txtOfficeCode.Text
                .CustomerNumber = ddlCustomerNumber.SelectedValue
                .CustomerName = GetCustomerName(ddlCustomerNumber.SelectedItem.Text) 'ddlCustomerNumber.SelectedItem.Text 'txtCustomerName.Text
                .CustPO = txtCustPO.Text
                .TrailerNumber = txtTrailerNumber.Text
                Try
                    .TrailerDue = Date.Parse(txtTrailerDue.Text)
                Catch
                End Try

                .Container1 = txtContainer1.Text
                Try
                    .Container1Due = Date.Parse(txtContainer1Due.Text)
                Catch
                End Try
                .Container2 = txtContainer2.Text
                Try
                    .Container2Due = Date.Parse(txtContainer2Due.Text)
                Catch
                End Try

                .DriverCode = ddlDriverCode.SelectedValue
                .DriverName = ddlDriverCode.SelectedItem.Text 'txtDriverName.Text
                .BrokerCode = ddlBrokerCode.SelectedValue
                .BrokerName = ddlBrokerCode.SelectedItem.Text 'txtBrokerName.Text
                .JRCIOCode = ddlIOCode.SelectedValue 'txtJRCIOCode.Text
                .IOCode = ddlIOCode.SelectedValue
                .IOName = ddlIOCode.SelectedItem.Text 'txtIOName.Text
                .CanRecover = ddlCanRecover.SelectedValue
                Try
                    .OverrideComm = Double.Parse(txtOverrideComm.Text)
                Catch
                End Try
                Try
                    .DriverPct = Double.Parse(txtDriverPct.Text)
                Catch
                End Try
                .FOB = txtFOB.Text
                .LoadNotes = txtLoadNotes.Text.ToUpper
                .ComCheckSeq = txtComCheckSeq.Text
                Try
                    .ComCheckAmt = Decimal.Parse(txtComCheckAmt.Text)
                Catch
                End Try
                .CodCheckSeq = txtCodCheckSeq.Text
                Try
                    .CodCheckAmt = Decimal.Parse(txtCodCheckAmt.Text)
                Catch
                End Try
                If txtDispatchCode.Text = "" Then
                    .DispatchCode = Users.UserController.GetCurrentUserInfo.Username
                Else
                    .DispatchCode = txtDispatchCode.Text
                End If
                .DispName = txtDispName.Text
                'If txtLoadStatus.Text Is String.Empty Then txtLoadStatus.Text = "WIP"
                '.LoadStatus = txtLoadStatus.Text
                .LoadStatus = GetLoadStatus() 'ddlLoadStatus.SelectedValue
                Try
                    .DispOverride = Double.Parse(txtDispOverride.Text)
                Catch
                End Try
                .RepNo = ddlRepNo.SelectedValue
                '.RepName = txtRepName.Text
                .RepName = ddlRepNo.SelectedItem.Text
                Try
                    .LastUpdate = Date.Parse(txtLastUpdate.Text)
                Catch
                End Try
                Try
                    .XmissionSeq = Double.Parse(txtXmissionSeq.Text)
                Catch
                End Try
                Try
                    .LoadType = ddlLoadType.SelectedValue
                Catch
                End Try
                Try
                    .DriverComm = Double.Parse(txtDriverComm.Text)
                Catch
                End Try
                Try
                    .BrokerComm = Double.Parse(txtBrokerComm.Text)
                Catch
                End Try
                .LoadWeight = txtLoadWeight.Text
                .LoadPieces = txtLoadPieces.Text
                Try
                    .LoadMileage = Double.Parse(txtLoadMileage.Text)
                Catch
                End Try
                If chkAdminExempt.Checked Then
                    .AdminExempt = "Y"
                Else
                    .AdminExempt = "N"
                End If
                If chkTarpLoad.Checked Then
                    .TarpLoad = "Y"
                    .TarpMessage = txtTarpMessage.Text
                Else
                    .TarpLoad = "N"
                End If
                .ProNox = txtProNox.Text
                .XMissionFile = txtXMissionFile.Text
                Try
                    .XMissionDate = Date.Parse(txtXMissionDate.Text)
                Catch
                End Try
                Try
                    .EntryDate = Date.Parse(txtEntryDate.Text)
                Catch
                End Try
                Try
                    .RepDlrM = Double.Parse(txtRepDlrM.Text)
                Catch

                End Try
                Try
                    .RepPctM = Double.Parse(txtRepPctM.Text)
                Catch
                End Try
                .RepOverride = txtRepOverride.Text
                Try
                    .RepDlrStd = Double.Parse(txtRepDlrStd.Text)
                Catch
                End Try
                Try
                    .RepPctStd = Double.Parse(txtRepPctStd.Text)
                Catch
                End Try
                .CorpTo = txtCorpTo.Text
                '.TrailerType = txtTrailerType.Text
                .TrailerType = ddlTrailerType.SelectedValue
                Try
                    .BrokerType = ddlBrokerType.SelectedValue
                Catch
                End Try
                If chkOfficePaid.Checked Then
                    .OfficePaid = "Y"
                Else
                    .OfficePaid = "N"
                End If
                .PDCkNo = txtPDCkNo.Text
                Try
                    .PDDate = Date.Parse(txtPDDate.Text)
                Catch
                End Try
                Try
                    .PDAmt = Double.Parse(txtPDAmt.Text)
                Catch
                End Try
                .ProJob = txtProJob.Text
                .InvCommentA = txtInvCommentA.Text
                .InvCommentB = txtInvCommentB.Text
                .InvCommentC = txtInvCommentC.Text
                .InvCommentD = txtInvCommentD.Text

                If txtBkrInvNo.Text = "" Then
                    .BkrInvNo = txtLoadID.Text
                Else
                    .BkrInvNo = txtBkrInvNo.Text
                End If
                .ReasonFor = txtReasonFor.Text
                Try
                    .BkrInvDate = Date.Parse(txtBkrInvDate.Text)
                Catch
                End Try
                If chkIOAvail.Checked Then
                    .IOAvail = "Y"
                Else
                    .IOAvail = "N"
                End If
                If chkIsPrinted.Checked Then
                    .IsPrinted = "Y"
                Else
                    .IsPrinted = "N"
                End If
                .AcctNull = txtAcctNull.Text
                If chkBkrFunds.Checked Then
                    .BkrFunds = "US"
                Else
                    .BkrFunds = "N"
                End If
                If chkOffFunds.Checked Then
                    .OffFunds = "US"
                Else
                    .OffFunds = "N"
                End If
                If chkOffOrgin.Checked Then
                    .OffOrgin = "US"
                Else
                    .OffOrgin = "N"
                End If

                .CNOfficeVendorNO = txtCNOfficeVendorNO.Text
                Try
                    .PUSEQ = Decimal.Parse(txtPUSEQ.Text)
                Catch
                End Try
                .ShowPUInfo = chkShowPUInfo.Checked
                .PUCityST = (New LoadPUsController).GetPUCitySTByLoadId(.LoadID) 'txtPUCityST.Text
                .DPCityST = (New LoadDropsController).GetDPCitySTByLoadId(.LoadID) 'txtDPCityST.Text
                Try
                    .DPSEQ = Decimal.Parse(txtDPSEQ.Text)
                Catch
                End Try
                If chkIsIODiv.Checked Then
                    .IsIODiv = "Y"
                Else
                    .IsIODiv = "N"
                End If
                Try
                    .OLPUDate = Date.Parse(txtOLPUDate.Text)
                Catch
                End Try
                .OLNoStops = txtOLNoStops.Text
                .CarrierName = txtCarrierName.Text
                .BkrIOName = txtBkrIOName.Text

                '.BkrDriverNo = txtBkrDriverNo.Text
                '.BKDriver = txtBKDriver.Text
                Try
                    .BkrDriverNo = ddlBkrDriverNo.SelectedValue
                    .BKDriver = ddlBkrDriverNo.SelectedItem.Text
                Catch
                    .BkrDriverNo = "ZXZX"
                    .BKDriver = "N/A"
                End Try

                .CommPaid = chkCommPaid.Checked
                .LDNotesA = txtLDNotesA.Text
                .LDNotesB = txtLDNotesB.Text
                .LDNotesC = txtLDNotesC.Text
                .LDNotesD = txtLDNotesD.Text
                Try
                    .LoadMo = Double.Parse(ddlLoadMo.SelectedValue)
                Catch
                End Try
                Try
                    .LoadYR = Double.Parse(ddlLoadYR.SelectedValue)
                Catch
                End Try
                If chkCalc85.Checked Then
                    .Calc85 = "Y"
                Else
                    .Calc85 = "N"
                End If
                Try
                    .DvrDedPct = Double.Parse(txtDvrDedPct.Text)
                Catch
                End Try
                .DvrDedResn = txtDvrDedResn.Text

                Try
                    .ViewOrder = Integer.Parse(txtViewOrder.Text)
                Catch
                End Try

                'Audit Control
                .CreatedByUser = UserInfo.UserID.ToString
            End With 'objLoadSheet

            Return objLoadSheet

        End Function

        'Private Sub SendNotification(ByVal eMail As String, Optional ByVal Name As String = "")
        '    Try
        '        If eMail <> "" Then
        '            Dim objRecipients As New ArrayList
        '            objRecipients.Add(New ListItem(eMail, Name))
        '            objRecipients.Add(New ListItem("jibhatt@gmail.com", "Jaydeep Bhatt"))
        '            objRecipients.Add(New ListItem("eric@mediainfocus.com", "Eric Pontbriand"))
        '            objRecipients.Add(New ListItem("john@mediainfocus.com", "John Hubbard"))
        '            ' create object
        '            'Dim objSendBulkEMail As New DotNetNuke.Services.Mail.SendBulkEmail(objRecipients, "2", "HTML", PortalSettings.PortalAlias.HTTPAlias)
        '            'Dim objSendBulkEMail As  DotNetNuke.Services.Mail.SendTokenizedBulkEmail(objRecipients, "2", "HTML", PortalSettings.PortalAlias.HTTPAlias)

        '            Dim objLoadSheetsController As New Business.LoadSheetsController
        '            Dim objLoadSheetInfo As Business.LoadSheetInfo = objLoadSheetsController.GetLoadSheet(itemId)
        '            ''Redirect back to this same Edit Page with same ItemId to Edit & Continue
        '            'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"), True)
        '            'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper), True)
        '            Dim ReportLink As String = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper)
        '            Dim Disclaimer As String = "The information contained in this electronic message is private and confidential information of J.R.C. Transportation, Inc. and is intended only for the use of the individual and/or entity named above.  If the reader of this message is not the intended recipient, or the employee or agent responsible to deliver it to the intended recipient, you are hereby notified that reading, distributing, copying or making any other use of this communication is STRICTLY PROHIBITED.  In no event shall receipt of this message by an unintended party be construed as a waiver by J.R.C. Transportation, Inc. of any privilege or other privacy rights. If you have received this communication in error, please notify us at the above email address."

        '            'With objSendBulkEMail
        '            '    .Subject = "Load Report for the Load " & objLoadSheetInfo.LoadID
        '            '    .Body &= "Please see " & .Subject & "<br/><br/>" & ReportLink & "<br/><br/><hr/>" & Disclaimer

        '            '    .SendMethod = "BCC"
        '            '    .SMTPServer = Convert.ToString(PortalSettings.HostSettings("SMTPServer"))
        '            '    .SMTPAuthentication = Convert.ToString(PortalSettings.HostSettings("SMTPAuthentication"))
        '            '    .SMTPUsername = Convert.ToString(PortalSettings.HostSettings("SMTPUsername"))
        '            '    .SMTPPassword = Convert.ToString(PortalSettings.HostSettings("SMTPPassword"))
        '            '    .Administrator = PortalSettings.Email
        '            '    .Heading = Localization.GetString("Heading", Me.LocalResourceFile)
        '            'End With
        '            '' send mail
        '            'If optSendAction.SelectedItem.Value = "S" Then
        '            '    objSendBulkEMail.Send()
        '            'Else    ' ansynchronous uses threading
        '            'Dim objThread As New Threading.Thread(AddressOf objSendBulkEMail.Send)
        '            'objThread.Start()
        '            'End If

        '            ' completed
        '            DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, Localization.GetString("MessageSent", Me.LocalResourceFile), DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)
        '        Else
        '            DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, Localization.GetString("MessageNotSent", Me.LocalResourceFile), DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
        '        End If

        '    Catch exc As Exception    'Module failed to load
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Sub
        Private Sub SendNotification(ByVal eMail As String, Optional ByVal Name As String = "", Optional ByVal SendAction As String = "S")
            Try
                ' load all user emails based on roles selected
                Dim objRoleNames As New System.Collections.Generic.List(Of String)
                'objRoleNames.Add("Administrators")

                ''Create the List of Recipients
                'Dim objRecipients As New ArrayList
                'If Name = "" Then
                '    objRecipients.Add(New System.Web.UI.WebControls.ListItem(eMail, eMail))
                'Else
                '    objRecipients.Add(New System.Web.UI.WebControls.ListItem(eMail, Name))
                'End If
                'objRecipients.Add(New System.Web.UI.WebControls.ListItem("jibhatt@gmail.com", "Jaydeep Bhatt"))
                'objRecipients.Add(New System.Web.UI.WebControls.ListItem("eric@mediainfocus.com", "Eric Pontbriand"))
                'objRecipients.Add(New System.Web.UI.WebControls.ListItem("john@mediainfocus.com", "John Hubbard"))

                '' load emails specified in email distribution list
                'Dim objUsers As New System.Collections.Generic.List(Of Users.UserInfo)
                'For Each li As System.Web.UI.WebControls.ListItem In objRecipients
                '    Dim objUser As New Users.UserInfo
                '    objUser.UserID = Null.NullInteger
                '    objUser.Email = li.Text
                '    objUser.DisplayName = li.Value
                '    objUsers.Add(objUser)
                'Next                
                Dim objUsers As New System.Collections.Generic.List(Of Users.UserInfo)
                Dim objUser As New Users.UserInfo
                objUser.UserID = Null.NullInteger
                objUser.Email = eMail
                If Name = "" Then Name = eMail
                objUser.DisplayName = Name
                objUsers.Add(objUser)

                Dim objLoadSheetInfo As Business.LoadSheetInfo = (New LoadSheetsController).GetLoadSheet(itemId)
                'Dim ReportLink As String = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & Request.QueryString("ItemId"), "LoadType=" & Request.QueryString("LoadType").ToUpper)
                Dim ReportLink As String = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper)
                If ReportLink.StartsWith("/") Then ReportLink = ApplicationPath & ReportLink

                Dim Disclaimer As String = "The information contained in this electronic message is private and confidential information of J.R.C. Transportation, Inc. and is intended only for the use of the individual and/or entity named above.  If the reader of this message is not the intended recipient, or the employee or agent responsible to deliver it to the intended recipient, you are hereby notified that reading, distributing, copying or making any other use of this communication is STRICTLY PROHIBITED.  In no event shall receipt of this message by an unintended party be construed as a waiver by J.R.C. Transportation, Inc. of any privilege or other privacy rights. If you have received this communication in error, please notify us at the above email address."

                Dim Subject As String = "Load Report for the Load " & objLoadSheetInfo.LoadID & " from " & objLoadSheetInfo.JRCIOfficeCode
                If objLoadSheetInfo.PUCityST <> "" Then Subject &= " First Pickup from " & objLoadSheetInfo.PUCityST
                Dim Body As String = "Please see " & Subject & "<br/><br/>" & ReportLink & "<br/><br/><hr/>" & Disclaimer

                'Create object
                Dim objSendBulkEMail As New DotNetNuke.Services.Mail.SendTokenizedBulkEmail(objRoleNames, objUsers, True, Subject, Body)
                objSendBulkEMail.BodyFormat = DotNetNuke.Services.Mail.MailFormat.Html
                objSendBulkEMail.Priority = DotNetNuke.Services.Mail.MailPriority.High
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

        Private Sub InitControls()

            cmdDelete.Visible = Not Null.IsNull(itemId)
            imbDelete.Visible = cmdDelete.Visible
            cmdUpdate.Visible = cmdDelete.Visible
            imbUpdate.Visible = cmdUpdate.Visible
            cmdAdd.Visible = Not cmdUpdate.Visible
            imbAdd.Visible = cmdAdd.Visible

            hypLoadAccounting.Visible = cmdDelete.Visible

            'this needs to execute always to the client script code is registred in InvokePopupCal
            'cmdCalendarDeliveryDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtDeliveryDate)
            ''cmdCalandarLoadDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtLoadDate)
            'cmdCalendarCompletedDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtCompletedDate)
            'cmdCalenderLastUpdate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtLastUpdate)
            'cmdCalendarXMissionDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtXMissionDate)
            'cmdCalendarEntryDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtEntryDate)
            'cmdCalendarPDDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtPDDate)
            'cmdCalendarBkrInvDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtBkrInvDate)
            'cmdCalendarOLPUDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtOLPUDate)
            'cmdCalendarDPDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtDPDate)
            'cmdCalendarPUDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtPUDate)
            'cmdCalendarTrailerDue.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTrailerDue)

            If Not Page.IsPostBack Then
                ViewState.Add("CustomerNumber", "0000000")
                'Try
                '    ViewState.Add("CustomerNumber", "0000000")
                '    lblCustomerChanged.Text = "Customer Set to " & CType(ViewState("CustomerNumber"), String)
                'Catch
                'End Try

                BindReps()
            End If
        End Sub

        Private Sub HideWhenLoadIsVoid(Optional ByVal Show As Boolean = False)
            trLoadDetails.Visible = Show
            trLoadDelivery.Visible = Show

            tdVoid.Visible = Show
            tdUnVoid.Visible = Not Show
        End Sub

        Private Sub SetBrokerPrintIcons(ByVal Enable As Boolean)
            With imbPrint
                .Enabled = Enable
                If .Enabled Then
                    .ImageUrl = ResolveUrl("~/images/print_this.png")
                Else
                    .ImageUrl = ResolveUrl("~/images/print_this-disabled.png")
                End If
                lnbPrint.Enabled = Enable
            End With

            With imbPrintConfirm
                .Enabled = Enable
                If .Enabled Then
                    .ImageUrl = ResolveUrl("~/images/print_this.png")
                    'lblBrokerNotes.Text = ""
                Else
                    .ImageUrl = ResolveUrl("~/images/print_this-disabled.png")
                    'lblBrokerNotes.Text = "<br/>" & Convert.ToString(Null.SetNull(ViewState("BrokerNotes"), Null.NullString))
                End If
                lnbPrintConfirm.Enabled = Enable
            End With
        End Sub

        Private Function GetLoadStatus() As String
            Dim LS As String = ddlLoadStatus.SelectedValue.ToUpper '"SUSPENSE"
            Dim bLS As Boolean = (txtLoadDate.Text <> "") AndAlso (CType(ViewState("BBaseLoad"), Decimal) > 0) AndAlso (CType(ViewState("BCustBill"), Decimal) > 0) AndAlso (CType(ViewState("DRTotDue"), Double) > 0) AndAlso ((ViewState("CustomerStatus").ToString = "A") OrElse (ViewState("CustomerStatus").ToString = "C"))

            If (LS = "SUSPENSE") OrElse (LS = "WIP") Then
                Select Case ddlLoadType.SelectedValue.ToUpper
                    Case "BK"
                        If bLS AndAlso (CType(ViewState("GPPct"), Decimal) >= 4.85) AndAlso (ViewState("BrokerStatus") = "ACTIVE") Then 'AndAlso (ddlCustomerNumber.SelectedValue <> "000000000")
                            LS = "WIP"
                        Else
                            LS = "SUSPENSE"
                        End If

                        'SetBrokerPrintIcons(ViewState("BrokerStatus") = "ACTIVE")
                        SetBrokerPrintIcons(ViewState("BrokerStatus") <> "HOLD")

                    Case "IO"
                        If bLS AndAlso (ddlIOCode.SelectedValue <> "000000000") AndAlso (ddlIOCode.SelectedValue <> "") Then 'AndAlso (ddlCustomerNumber.SelectedValue <> "000000000")
                            LS = "WIP"
                        Else
                            LS = "SUSPENSE"
                        End If
                    Case Else '"OO"
                        Dim DriverStatus As String = ViewState("DriverStatus")
                        If (DriverStatus = "Y") AndAlso (Convert.ToDateTime(ViewState("InactivateDate")) >= Convert.ToDateTime(txtLoadDate.Text)) Then
                            DriverStatus = "N"
                        End If
                        'If bLS AndAlso (CType(ViewState("GPPct"), Decimal) >= 4.85) AndAlso (ViewState("DriverStatus") = "N") AndAlso (ViewState("SafetyAuth") <> "HOLD") Then 'AndAlso (ddlCustomerNumber.SelectedValue <> "000000000")
                        If bLS AndAlso (CType(ViewState("GPPct"), Decimal) >= 4.85) AndAlso (DriverStatus = "N") AndAlso (ViewState("SafetyAuth") <> "HOLD") Then 'AndAlso (ddlCustomerNumber.SelectedValue <> "000000000")
                            LS = "WIP"
                        Else
                            LS = "SUSPENSE"
                        End If
                End Select
            End If

            Return LS
        End Function
        Private Sub SetCanRecover()
            ddlCanRecover.DataSource = (New Business.LoadAcctsController).GetDispatchersByJRCIOfficeCode9(ddlIOCode.SelectedValue)
            ddlCanRecover.DataBind()
            ddlCanRecover.Items.Insert(0, New ListItem("<Any One>", ""))
            Try
                ddlCanRecover.SelectedValue = ViewState("CanRecover").ToString
            Catch
            End Try
        End Sub
        Private Sub SeteMailTo()
            ddleMailTo.DataSource = (New Business.LoadAcctsController).GetDispatchersByJRCIOfficeCode9(ddlIOCode.SelectedValue)
            ddleMailTo.DataBind()
            ddleMailTo.Items.Insert(0, New ListItem("<Type eMail>", ""))
            Try
                ddleMailTo.SelectedValue = ViewState("CanRecover").ToString
            Catch
            End Try
            ddleMailTo_SelectedIndexChanged(Nothing, Nothing)
        End Sub
        Private Sub SetLoadStatusText(ByVal strLoadStatus As String)
            Select Case strLoadStatus.ToUpper
                Case "SUSPENSE", "VOIDED"
                    txtLoadStatus.ForeColor = Drawing.Color.Red
                Case "WIP"
                    txtLoadStatus.ForeColor = Drawing.Color.Blue
                Case Else '"COMPLETE"
                    txtLoadStatus.ForeColor = Drawing.Color.Navy
            End Select
            txtLoadStatus.Text = strLoadStatus

            ddlCustomerNumber.Enabled = (strLoadStatus = "WIP") OrElse (strLoadStatus = "SUSPENSE")
            ddlDriverCode.Enabled = ddlCustomerNumber.Enabled
            ddlBrokerCode.Enabled = ddlCustomerNumber.Enabled

            Dim upnlLoadStatus As UpdatePanel = CType(tdLoadStatus.FindControl("upnlLoadStatus"), UpdatePanel)
            If Not upnlLoadStatus Is Nothing Then upnlLoadStatus.Update()
        End Sub
        Private Sub SetLoadStatus()
            With ddlLoadStatus
                '.ClearSelection()
                .SelectedValue = GetLoadStatus()
                SetLoadStatusText(.SelectedItem.Text)
            End With
        End Sub
        Private Sub BindBkrDrivers(Optional ByVal DriverCode As String = "")
            If ddlLoadType.SelectedValue.ToUpper = "BK" Then
                With ddlBkrDriverNo
                    'If (DriverCode = "") AndAlso (.Items.Count > 1) Then
                    '    DriverCode = .SelectedValue
                    'End If
                    .DataValueField = "DriverCode"
                    .DataTextField = "DriverName"
                    .DataSource = (New Business.LoadSheetsController).GetBkrDrivers(txtJRCIOfficeCode.Text, ddlBrokerCode.SelectedValue, "N")
                    .DataBind()

                    .Items.Insert(0, New ListItem("To be assigned", "ZXZX"))
                    'If .Items.Count > 1 Then
                    '    .SelectedIndex = 1
                    '    If (DriverCode <> "") Then
                    '        Try
                    '            .Items.FindByValue(DriverCode).Selected = True
                    '        Catch
                    '        End Try
                    '    End If

                    'End If
                End With
            End If
        End Sub


        Private Function GetCustomerName(ByVal CustomerName As String) As String
            Try
                Dim s() As String = CustomerName.Split(" | ")
                Return s(0)
            Catch
                Return CustomerName
            End Try
        End Function


        'Private Sub BindCategories()
        '    With ddlCategoryId
        '        .DataValueField = "ItemId"
        '        .DataTextField = "Category"
        '        .DataSource = (New Business.CategoriesController).GetAllCategories
        '        .DataBind()
        '    End With 'ddlCategoryId
        'End Sub
#End Region

#Region " Event Handlers "

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            If AJAX.IsInstalled Then
                AJAX.WrapUpdatePanelControl(tblCustomer, True)
                AJAX.WrapUpdatePanelControl(tblDriver, True)
                AJAX.WrapUpdatePanelControl(tblInterOffice, True)
                AJAX.WrapUpdatePanelControl(tblBroker, True)

                AJAX.WrapUpdatePanelControl(tblLoadPUs, True)
                AJAX.WrapUpdatePanelControl(tblLoadDrops, True)
            End If
        End Sub

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

                    Dim MyViewLoadPUs As ViewLoadPUs = CType(LoadControl(ModulePath & "ViewLoadPUs.ascx"), ViewLoadPUs)
                    With MyViewLoadPUs
                        '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewLoadPUs.ascx")
                        .ModuleConfiguration = ModuleConfiguration
                        .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewLoadPUs.ascx")
                        .itemId = itemId
                        .Embeded = True
                    End With 'MyViewLoadPUs
                    phtLoadPUs.Controls.Add(MyViewLoadPUs)

                    Dim MyViewLoadDrops As ViewLoadDrops = CType(LoadControl(ModulePath & "ViewLoadDrops.ascx"), ViewLoadDrops)
                    With MyViewLoadDrops
                        '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewLoadDrops.ascx")
                        .ModuleConfiguration = ModuleConfiguration
                        .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewLoadDrops.ascx")
                        .itemId = itemId
                        .Embeded = True
                    End With 'MyViewLoadDrops
                    phtLoadDrops.Controls.Add(MyViewLoadDrops)


                End If

                'Initilise the Controls and set its properties as well as Visiblity
                InitControls()

                ddlLoadType.Enabled = Null.IsNull(itemId)

                If Not Page.IsPostBack Then

                    With valLoadDate
                        .MaximumValue = Now.AddDays(90).ToShortDateString
                        .MinimumValue = Now.AddDays(-90).ToShortDateString
                        .ErrorMessage = "<b>Out Of Range</b><br/>Load Date must be within " & .MinimumValue & " & " & .MaximumValue
                    End With

                    ViewState.Add("DriverCode", "ZXZX")
                    ViewState.Add("DriverName", "N/A")
                    'ViewState.Add("CustomerNumber", "C0000000")

                    If Not Null.IsNull(itemId) Then
                        Dim objLoadSheet As LoadSheetInfo = (New LoadSheetsController).GetLoadSheet(itemId)

                        If Not objLoadSheet Is Nothing Then
                            'Load data
                            ItemToPage(objLoadSheet)
                            ViewState("BBaseLoad") = objLoadSheet.BBaseLoad
                            ViewState("BCustBill") = objLoadSheet.BCustBill
                            ViewState("DRTotDue") = objLoadSheet.DRTotDue
                            ViewState("GPPct") = objLoadSheet.GPPct

                            lblLoadType.Text = "Load " & objLoadSheet.LoadID.ToUpper
                            Dim strLoadType As String = objLoadSheet.LoadType.ToUpper
                            Select Case strLoadType
                                Case "OO"
                                    lblLoadType.Text &= " (Driver)"
                                Case "IO"
                                    lblLoadType.Text &= " (Inter Office)"

                                    imbPrintConfirm.Style.Add("display", "none")
                                    lnbPrintConfirm.Style.Add("display", "none")
                                Case "BK"
                                    lblLoadType.Text &= " (Broker)"
                            End Select
                            trIOeMail.Visible = (strLoadType = "IO")

                            'lnbVoid.Visible = ddlLoadStatus.SelectedValue.ToUpper <> "VOIDED"
                            If ddlLoadStatus.SelectedValue = "VOIDED" Then
                                lnbVoid.Text = "<br/><font size='+1' color='red'>VOIDED LOAD</font>"
                                HideWhenLoadIsVoid()
                            End If

                            ''Hide CopyLoad for IORecoved Loads
                            'imbCopyLoad.Visible = (objLoadSheet.IORecovery < 1)
                            'lnbCopyLoad.Visible = imbCopyLoad.Visible
                            'Disable CopyLoad for IORecoved Loads
                            'imbCopyLoad.Enabled = (objLoadSheet.IORecovery < 1)
                            'lnbCopyLoad.Enabled = imbCopyLoad.Enabled
                            DisableCopyLoadIcon(objLoadSheet.IsIORecoveredLoad)

                            ''LoadPU
                            'Dim objLoadPU As New LoadPUInfo

                            'objLoadPU = (New LoadPUsController).GetLoadPU(objLoadSheet.ItemId)
                            'If Not objLoadPU Is Nothing Then
                            '    'Load data
                            '    ItemToPage(objLoadPU)
                            'Else ' security violation attempt to access item not related to this Module
                            '    'Response.Redirect(NavigateURL(), True)
                            'End If

                            ''LoadDrop
                            'Dim objLoadDrop As New LoadDropInfo
                            'objLoadDrop = (New LoadDropsController).GetLoadDrop(objLoadSheet.ItemId)

                            'If Not objLoadDrop Is Nothing Then
                            '    'Load data
                            '    ItemToPage(objLoadDrop)
                            'Else ' security violation attempt to access item not related to this Module
                            '    'Response.Redirect(NavigateURL(), True)
                            'End If

                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If

                    Else
                        'Set the default LoadType as Driver(0)
                        Try
                            Dim lt As String = Request.QueryString("EditLoadType").ToUpper
                            If lt <> String.Empty Then
                                ddlLoadType.Items.FindByValue(lt).Selected = True
                            Else
                                ddlLoadType.SelectedIndex = 0
                            End If
                        Catch
                            ddlLoadType.SelectedIndex = 0
                        End Try
                        txtLoadType.Text = ddlLoadType.SelectedItem.Text
                        txtJRCIOfficeCode.Text = Request.QueryString("IOCode")
                        txtOfficeVendorNO.Text = txtJRCIOfficeCode.Text.Substring(1, 7) '& "10"

                    End If

                    If (Not Request.QueryString("Customer") Is Nothing) AndAlso (Request.QueryString("Customer") <> String.Empty) Then
                        txtCustomerName.Text = Request.QueryString("Customer")
                        With ddlCustomerNumber
                            .DataSource = (New Business.LoadSheetsController).GetSearchedCustomers(txtCustomerName.Text)
                            .DataValueField = "CustomerNumber"
                            .DataTextField = "CustomerName"
                            .DataBind()
                        End With 'ddlCustomerNumber
                    End If
                    If (Not Request.QueryString("Broker") Is Nothing) AndAlso (Request.QueryString("Broker") <> String.Empty) Then
                        txtBrokerName.Text = Request.QueryString("Broker")
                        With ddlBrokerCode
                            .DataSource = (New Business.LoadSheetsController).GetSearchedBrokers(txtBrokerName.Text)
                            .DataValueField = "BrokerCode"
                            .DataTextField = "BrokerName"
                            .DataBind()
                        End With 'ddlBrokerNumber
                    End If
                    ddlCustomerNumber_SelectedIndexChanged(Nothing, Nothing)
                    ddlLoadType_SelectedIndexChanged(Nothing, Nothing)
                End If

            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub chkTarpLoad_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTarpLoad.CheckedChanged
            'txtTarpMessage.Enabled = chkTarpLoad.Checked
            trTarpMessage.Visible = chkTarpLoad.Checked
            'txtTarpMessage.Enabled = chkTarpLoad.Checked
            If chkTarpLoad.Checked Then
                If txtTarpMessage.Text = "" Then txtTarpMessage.Text = "THIS LOAD MUST BE TARPED"
            Else
                txtTarpMessage.Text = ""
            End If
        End Sub

        Private Sub txtDeliveryDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeliveryDate.TextChanged
            Dim objLoadSheetsController As New LoadSheetsController
            Dim objLoadSheetInfo As LoadSheetInfo = objLoadSheetsController.GetLoadSheet(itemId)
            If Not objLoadSheetInfo Is Nothing Then
                Try
                    objLoadSheetInfo.DeliveryDate = Date.Parse(txtDeliveryDate.Text)
                    objLoadSheetsController.UpdateLoadSheet(objLoadSheetInfo)
                Catch
                End Try
            End If
        End Sub


        'Private Sub ddlLoadType_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLoadType.SelectedIndexChanged
        Private Sub ddlLoadType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLoadType.SelectedIndexChanged
            'Show only one of the Three options
            txtLoadType.Text = ddlLoadType.SelectedItem.Text
            Dim objLoadSheetsController As New Business.LoadSheetsController
            With ddlDriverCode
                .Enabled = ddlLoadType.SelectedValue.ToUpper = "OO"
                tblDriver.Visible = .Enabled
                If .Enabled Then
                    Dim txt As String '= .Items(0).Text '.SelectedItem.Text
                    Dim val As String '= .Items(0).Value '.SelectedValue
                    If .Items.Count > 0 Then
                        txt = .Items(0).Text  '.SelectedItem.Text
                        val = .Items(0).Value  '.SelectedValue
                    End If

                    '.DataSource = objLoadSheetsController.GetAllSalesPersons
                    '.DataSource = objLoadSheetsController.GetAllSalesPersonsByJRCIOCode(txtJRCIOfficeCode.Text)
                    .DataSource = objLoadSheetsController.GetDriverSearchByIO(String.Empty, txtJRCIOfficeCode.Text, "Any", False, 1000)
                    .DataValueField = "DriverCode"
                    .DataTextField = "DriverName"
                    .DataBind()

                    '.Items.Insert(0, (New ListItem("N/A", "ZXZX")))

                    'If val <> String.Empty Then
                    '    If .Items.IndexOf(New ListItem(txt, val)) > -1 Then
                    '        .Items.FindByValue(val).Selected = True
                    '    Else
                    '        .Items.Insert(0, (New ListItem(txt, val)))
                    '    End If
                    'Else
                    '    If .Items.IndexOf(New ListItem("N/A", "ZXZX")) > -1 Then
                    '        .Items.FindByValue(val).Selected = True
                    '    Else
                    '        .Items.Insert(0, (New ListItem("N/A", "ZXZX")))
                    '    End If
                    'End If

                    If .Items.IndexOf(.Items.FindByValue(ViewState("DriverCode").ToString)) < 0 Then
                        .Items.Insert(0, (New ListItem(ViewState("DriverName").ToString, ViewState("DriverCode").ToString)))
                    Else
                        .Items.FindByValue(ViewState("DriverCode").ToString).Selected = True
                    End If

                    'If ddlDriverCode.SelectedValue.ToUpper <> "ZXZX" Then ddlDriverCode_SelectedIndexChanged(Nothing, Nothing)
                    If ddlDriverCode.SelectedValue.ToUpper <> "" Then ddlDriverCode_SelectedIndexChanged(Nothing, Nothing)
                End If
            End With 'DriverCode

            With ddlBrokerCode
                .Enabled = ddlLoadType.SelectedValue.ToUpper = "BK"
                tblBroker.Visible = .Enabled
                If .Enabled Then
                    '    .DataSource = objLoadSheetsController.GetAllBrokers
                    '    .DataValueField = "BrokerCode"
                    '    .DataTextField = "BrokerName"
                    '    .DataBind()

                    '    .Items.Insert(0, (New ListItem("N/A", "0000000")))

                    'If ddlBrokerCode.SelectedValue <> "0000000" Then ddlBrokerCode_SelectedIndexChanged(Nothing, Nothing)
                    If ddlBrokerCode.SelectedValue <> "" Then ddlBrokerCode_SelectedIndexChanged(Nothing, Nothing)
                End If
            End With 'BrokerCode


            With ddlIOCode
                .Enabled = ddlLoadType.SelectedValue.ToUpper = "IO"
                tblInterOffice.Visible = .Enabled
                If .Enabled Then
                    Dim txt As String '= .Items(0).Text '.SelectedItem.Text
                    Dim val As String = String.Empty '.Items(0).Value '.SelectedValue
                    If .Items.Count > 0 Then
                        txt = .Items(0).Text  '.SelectedItem.Text
                        val = .Items(0).Value  '.SelectedValue
                    End If

                    '.DataSource = objLoadSheetsController.GetAllInterOffices
                    '.DataValueField = "IOfficeCode"
                    '.DataTextField = "IOName"
                    '.DataBind()

                    Dim valfld, txtfld As String
                    Dim dr As IDataReader = objLoadSheetsController.GetAllInterOffices
                    .Items.Clear()
                    While dr.Read
                        valfld = dr("JRCIOfficeCode").ToString
                        txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                        txtfld = Replace(txtfld, "JRC ", "")
                        .Items.Add(New ListItem(txtfld, valfld))
                    End While

                    .Items.Insert(0, (New ListItem("N/A", "000000000")))
                    If val <> String.Empty Then
                        'If .Items.IndexOf(New ListItem(txt, val)) > -1 Then
                        '    .Items.FindByValue(val).Selected = True
                        'End If
                        .Items.FindByValue(val).Selected = True
                    End If

                End If
            End With

            If Null.IsNull(itemId) Then
                'Set the default LoadType as Driver(0)
                'ddlLoadType.SelectedIndex = 0

                Dim strLoadType As String
                Select Case ddlLoadType.SelectedValue.ToUpper
                    Case "BK"
                        strLoadType = "BK"
                    Case "IO"
                        strLoadType = "AV" '"BK"
                    Case Else '"OO"
                        strLoadType = "OO"
                End Select
                txtLoadID.Text = objLoadSheetsController.GetLoadId(Request.QueryString("IOCode"), strLoadType)

            End If

        End Sub


        Private Sub txtCustomerName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomerName.TextChanged
            If Not String.IsNullOrEmpty(txtCustomerName.Text) Then
                'Dim CityStateZip As String() = Strings.Split(txtCustomerName.Text, "|")
                Dim CityStateZip() As String = Split(txtCustomerName.Text, " | ")
                If CityStateZip.Length > 0 Then
                    txtCustomerName.Text = CityStateZip(0)
                    If CityStateZip.Length > 1 Then
                        txtCustomerNumber.Text = CityStateZip(1)
                        txtCustomerNumber_TextChanged(Nothing, Nothing)
                    Else
                        btnCustomerSearch_Click(Nothing, Nothing)
                    End If

                    Dim sm As ScriptManager = AJAX.ScriptManagerControl(Me.Page)
                    sm.SetFocus(ddlCustomerNumber)
                End If
            End If
        End Sub

        Private Sub txtCustomerNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerNumber.TextChanged
            With ddlCustomerNumber
                Dim txt As String '= .Items(0).Text '.SelectedItem.Text
                Dim val As String '= .Items(0).Value '.SelectedValue
                If .Items.Count > 0 Then
                    txt = .Items(0).Text  '.SelectedItem.Text
                    val = .Items(0).Value  '.SelectedValue
                End If

                '.DataSource = (New Business.LoadSheetsController).GetCustomerSearch(txtCustomerNumber.Text, "CustomerNumber", (rblCustomerSearchType.SelectedIndex < 1))
                .DataSource = (New Business.LoadSheetsController).GetCustomerSearch(txtCustomerNumber.Text, "CustomerNumber")
                .DataValueField = "CustomerNumber"
                .DataTextField = "CustomerNameNumber"
                .DataBind()

                ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
                'If val <> String.Empty Then .Items.Insert(0, (New ListItem(txt, val)))
                ''.Items.Insert(0, (New ListItem("", "0000000")))

                If .Items.Count > 0 Then
                    ddlCustomerNumber_SelectedIndexChanged(Nothing, Nothing)
                Else
                    .Items.Add(New ListItem("No Customer", ""))
                    lblCustomer.Text = ""
                    ViewState("CustomerStatus") = "I"
                    SetLoadStatus()
                End If
            End With 'ddlCustomerName

        End Sub
        Private Sub ddlCustomerNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCustomerNumber.SelectedIndexChanged
            If ddlCustomerNumber.SelectedValue <> String.Empty Then
                Dim dr As IDataReader = (New Business.LoadSheetsController).GetCustomerByNumber(ddlCustomerNumber.SelectedValue)
                If Not dr Is Nothing Then
                    dr.Read()

                    lblCustomer.Text = "Number: " & dr("CustomerNumber").ToString
                    'lblCustomer.Text &= "<br />Status: "
                    Dim CS As String = dr("CustomerStatus").ToString.ToUpper
                    ViewState("CustomerStatus") = CS
                    SetLoadStatus()
                    lblCStatus.Visible = (CS = "H") OrElse (CS = "C")
                    tblCodCheck.Visible = (CS = "C")

                    Select Case CS
                        Case "A"
                            'lblCustomer.Text &= "<font color='green'>ACTIVE</font><br />"
                            lblCustomerStatus.Text = "<font color='green'>ACTIVE</font>"
                        Case "I"
                            'lblCustomer.Text &= "<font color='red'>INACTIVE</font><br />"
                            lblCustomerStatus.Text = "<font color='red'>INACTIVE</font>"
                        Case "H"
                            'lblCustomer.Text &= "<font color='red'>CREDIT HOLD</font><br />"
                            lblCustomerStatus.Text = "<font color='red'>CREDIT HOLD</font>"
                            lblCStatus.Text = "<font size='+1' color='red'>CREDIT HOLD</font><br />"
                        Case Else '"COD"
                            'lblCustomer.Text &= "<font color='blue'>CASH ON DELIVERY</font><br />"
                            lblCustomerStatus.Text = "<font color='blue'>CASH ON DELIVERY</font>"
                            lblCStatus.Text = "<font size='+1' color='red'>COD</font><br />"
                    End Select

                    lblCustomer.Text &= "<br />"
                    If dr("ContactCode").ToString <> String.Empty Then lblCustomer.Text &= dr("ContactCode").ToString & ", "
                    lblCustomer.Text &= "Phone: " & Phone.FormatPhoneNo(dr("PhoneNumber").ToString)
                    If dr("Extension").ToString <> String.Empty Then lblCustomer.Text &= " - " & dr("Extension").ToString
                    lblCustomer.Text &= "<br />"
                    If dr("FaxNumber").ToString <> String.Empty Then lblCustomer.Text &= "Fax: " & Phone.FormatPhoneNo(dr("FaxNumber").ToString) & "<br />"
                    If dr("AddressLine1").ToString <> String.Empty Then lblCustomer.Text &= dr("AddressLine1").ToString & "<br />"
                    If dr("AddressLine2").ToString <> String.Empty Then lblCustomer.Text &= dr("AddressLine2").ToString & "<br />"
                    If dr("AddressLine3").ToString <> String.Empty Then lblCustomer.Text &= dr("AddressLine3").ToString & "<br />"
                    lblCustomer.Text &= dr("City").ToString & ", "
                    lblCustomer.Text &= dr("State").ToString & " "
                    lblCustomer.Text &= dr("ZipCode").ToString

                    'Reset the SalesRep in LoadAcct
                    'If IsPostBack AndAlso (ddlRepNo.SelectedValue <> dr("RepNo").ToString) Then
                    'If Not IsCopiedLoad Then 'SalesRep is to be maintained if the Load is an copied load
                    'If IsNeverUpdated Then
                    If IsPostBack Then

                        Try
                            ddlRepNo.SelectedValue = dr("RepNo").ToString
                        Catch exc As Exception
                            lblCustomer.Text &= "<br/>" & exc.ToString
                            ProcessModuleLoadException(Me, exc)
                        End Try
                        txtRepDlrStd.Text = dr("RepDlr").ToString
                        txtRepDlrM.Text = txtRepDlrStd.Text
                        txtRepPctStd.Text = dr("RepPct").ToString
                        txtRepPctM.Text = txtRepPctStd.Text

                    End If

                    'Try
                    '    lblCustomerChanged.Text = "ViewState(CustomerNumber)" & CType(ViewState("CustomerNumber"), String)
                    'Catch
                    '    lblCustomerChanged.Text = "ViewState(CustomerNumber) is Null"
                    'End Try
                    'Try
                    '    If (ddlCustomerNumber.SelectedValue = ViewState("CustomerNumber").ToString()) Then
                    '        lblCustomerChanged.Text &= ""
                    '    Else
                    '        lblCustomerChanged.Text &= "<br/>Customer Changed. Ensure to update the LoadAccounting."
                    '    End If
                    'Catch
                    'End Try
                    If ddlCustomerNumber.SelectedValue = ViewState("CustomerNumber").ToString() Then
                        lblCustomerChanged.Text = ""
                    Else
                        lblCustomerChanged.Text = "<br/>Customer changed.  Be sure to re-calculate Accounting."
                    End If

                    'Update the Search TextBoxes
                    txtCustomerNumber.Text = "" 'ddlCustomerNumber.SelectedValue
                    txtCustomerName.Text = "" 'ddlCustomerNumber.SelectedItem.Text

                    ''Remarked Follwing Sectioned on 8 Oct 2008 because while moving from Edit to Acct, the SalesRep gets resetted
                    '=================================================
                    'If dr("RepNo").ToString <> String.Empty Then
                    '    Try
                    '        'ViewState("ddlRepNo.SelectedValue") = dr("RepNo").ToString
                    '        'ViewState.Remove("ddlRepNo")
                    '        ddlRepNo.ClearSelection()
                    '        'ViewState.Item("ddlRepNo") = dr("RepNo").ToString
                    '        'ddlRepNo.Items.FindByValue(dr("RepNo").ToString).Selected = True
                    '        ddlRepNo.SelectedValue = dr("RepNo").ToString

                    '        txtRepDlrStd.Text = dr("RepDlr").ToString
                    '        txtRepDlrM.Text = txtRepDlrStd.Text
                    '        txtRepPctStd.Text = dr("RepPct").ToString
                    '        txtRepPctM.Text = txtRepPctStd.Text
                    '    Catch
                    '    End Try

                    '    'This fields is being locked now
                    '    ddlRepNo.Enabled = False '(ddlRepNo.SelectedValue = "0000000") OrElse (ddlRepNo.SelectedIndex < 0)
                    '    'txtRepDlrStd.Enabled = False
                    '    'txtRepDlrM.Enabled = False
                    '    'txtRepPctStd.Enabled = False
                    '    'txtRepPctM.Enabled = False
                    'End If
                    '=================================================

                    'If (ddlLoadStatus.SelectedValue.ToUpper <> "COMPLETE") AndAlso (ddlLoadStatus.SelectedValue.ToUpper <> "VOIDED") AndAlso (CS <> String.Empty) AndAlso (CS.ToUpper <> "A") Then
                    '    Try
                    '        'ViewState("ddlLoadStatus.SelectedValue") = "SUSPENSE"
                    '        ViewState.Remove("ddlLoadStatus")
                    '        ddlLoadStatus.ClearSelection()
                    '        ddlLoadStatus.Items.FindByValue("SUSPENSE").Selected = True
                    '        'ddlLoadStatus.Enabled = False
                    '        'ViewState.Remove("ddlRepNo")
                    '        'ddlRepNo.ClearSelection()
                    '        'ViewState.Item("ddlRepNo") = dr("RepNo").ToString
                    '        'ddlRepNo.Items.FindByValue(dr("RepNo").ToString).Selected = True
                    '    Catch
                    '    End Try
                    'End If


                End If
            End If

        End Sub

        Private Sub btnCustomerSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCustomerSearch.Click
            With ddlCustomerNumber
                Dim txt As String = "" '= .Items(0).Text '.SelectedItem.Text
                Dim val As String = "" '= .Items(0).Value '.SelectedValue
                If .Items.Count > 0 Then
                    txt = .Items(0).Text  '.SelectedItem.Text
                    val = .Items(0).Value  '.SelectedValue
                End If

                '.DataSource = (New Business.LoadSheetsController).GetSearchedCustomers(txtCustomerName.Text)
                .DataSource = (New Business.LoadSheetsController).GetCustomerSearch(txtCustomerName.Text, "Any", True)
                .DataValueField = "CustomerNumber"
                .DataTextField = "CustomerNameNumber"
                .DataBind()

                'If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
                '               If val <> "" Then .Items.Insert(0, (New ListItem(txt, val)))
                .Items.Insert(0, (New ListItem("To be assigned", "0000000")))
                If .Items.Count > 1 Then
                    .SelectedIndex = 1
                    ddlCustomerNumber_SelectedIndexChanged(Nothing, Nothing)
                Else
                    '.Items.Add(New ListItem("No Customer", ""))
                    lblCustomer.Text = ""
                    ViewState("CustomerStatus") = "I"
                    SetLoadStatus()
                End If
            End With 'ddlCustomerNumber
        End Sub

        Private Sub ddlDriverCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDriverCode.SelectedIndexChanged
            Dim dr As IDataReader = (New Business.LoadSheetsController).GetDriverByCode(ddlDriverCode.SelectedValue)
            If Not dr Is Nothing Then
                dr.Read()

                lblDriver.Text = "<br />Account No: " & dr("AccountNo").ToString
                ddlDriverCode.Items.Insert(0, (New ListItem("To be assigned", "zxzx")))
                ViewState("DriverStatus") = dr("Status").ToString.ToUpper
                ViewState("InactivateDate") = Convert.ToDateTime(Null.SetNull(dr("InactivateDate"), Null.NullDate)) 'Convert.ToDateTime(dr("InactivateDate"))
                'If (dr("Status").ToString.ToUpper = "Y") AndAlso (Convert.ToDateTime(dr("InactivateDate")) >= Today()) Then
                '    ViewState("DriverStatus") = "N"
                'End If

                ViewState("SafetyAuth") = dr("SafetyAuth").ToString.ToUpper
                SetLoadStatus()

                'lblDriver.Text &= "<br />Status: "
                If dr("Status").ToString.ToUpper = "N" Then
                    'lblDriver.Text &= "<font color='green'>ACTIVE</font>"
                    'lblDriverStatus.Text = "<font color='green'>ACTIVE</font>"
                    lblDriverStatus.Text = "<font color='yellow'>ACTIVE</font>"
                    ''===========================================================
                    ''Check that the BCustBill is > 0
                    'Dim CustBill As Decimal = 0

                    'Dim objLoadAcctsController As New Business.LoadAcctsController
                    'Dim LoadAcctId As Integer = objLoadAcctsController.GetLoadAcctId(txtLoadID.Text)
                    'If LoadAcctId > 0 Then
                    '    CustBill = objLoadAcctsController.GetLoadAcct(LoadAcctId).BCustBill
                    'End If
                    ''===========================================================


                    'If (ddlLoadStatus.SelectedValue.ToUpper <> "VOIDED") AndAlso (ddlLoadStatus.SelectedValue.ToUpper = "SUSPENSE") AndAlso (CustBill > 0) Then
                    '    ddlLoadStatus.ClearSelection()
                    '    ddlLoadStatus.Items.FindByValue("WIP").Selected = True
                    'End If
                Else
                    'lblDriver.Text &= "<font color='red'>INACTIVE</font>"
                    lblDriverStatus.Text = "<font color='red'>INACTIVE</font>"
                    'If ddlLoadStatus.SelectedValue.ToUpper <> "VOIDED" Then
                    '    ddlLoadStatus.ClearSelection()
                    '    ddlLoadStatus.Items.FindByValue("SUSPENSE").Selected = True
                    'End If
                End If

                If dr("SafetyAuth").ToString <> "" Then
                    'lblDriver.Text &= "<font color='red'>" & dr("SafetyAuth").ToString & "</font><br />"
                    lblDriver.Text &= "(<font color='red'>Safety Hold</font>)<br />"
                    lblSafetyAuth.Visible = True
                    lblSafetyAuth.Text = "<font size='+1' color='red'>Safety Hold</font><br/><font color='red'>" & dr("SafetyNotes").ToString & "</font>"
                Else
                    lblDriver.Text &= "<br />"
                    lblSafetyAuth.Visible = False
                End If

                'If dr("OfficeOwner").ToString <> String.Empty Then lblDriver.Text &= "Office: " & dr("OfficeOwner").ToString & "<br />"
                ' If dr("ContactCode").ToString <> String.Empty Then lblDriver.Text &= dr("ContactCode").ToString & ", "
                lblDriver.Text &= "Phone: " & Phone.FormatPhoneNo(dr("PhoneNo").ToString)
                If dr("Ext").ToString <> String.Empty Then lblDriver.Text &= " Ext: " & dr("Ext").ToString
                lblDriver.Text &= "<br />"
                'If dr("FaxNumber").ToString <> String.Empty Then lblDriver.Text &= "Fax: " & dr("FaxNumber").ToString & "<br />"
                If dr("AddressLine1").ToString <> String.Empty Then lblDriver.Text &= dr("AddressLine1").ToString & "<br />"
                If dr("AddressLine2").ToString <> String.Empty Then lblDriver.Text &= dr("AddressLine2").ToString & "<br />"
                If dr("AddressLine3").ToString <> String.Empty Then lblDriver.Text &= dr("AddressLine3").ToString & "<br />"
                lblDriver.Text &= dr("City").ToString & ", "
                lblDriver.Text &= dr("State").ToString & " "
                lblDriver.Text &= dr("ZipCode").ToString
                'If dr("RepName").ToString <> String.Empty Then lblDriver.Text &= "<br /><br />RepName: " & dr("RepName").ToString & "<br />"

                Dim strLastTrailer As String = dr("LastTrailerUsed").ToString
                If String.IsNullOrEmpty(strLastTrailer) Then
                    txtTrailerNumber.Text = String.Empty
                    ddlTrailerType.ClearSelection()
                Else
                    'Dim arrLastTrailer() As String = Split(strLastTrailer, ",")
                    'If arrLastTrailer.Length > 0 Then
                    '    lblDriver.Text &= "<br/><font color='red' size='+1'>LastTrailer on Record: " & arrLastTrailer(0) & "</font>"
                    '    txtTrailerNumber.Text = arrLastTrailer(0)
                    '    Try
                    '        ddlTrailerType.ClearSelection()
                    '        If Not String.IsNullOrEmpty(arrLastTrailer(1)) Then
                    '            ddlTrailerType.SelectedValue = arrLastTrailer(1).Replace("Type:", "").Trim()
                    '        End If
                    '    Catch
                    '    End Try
                    'End If
                    Dim TrailerNo As String = GetTrailerDetails(strLastTrailer)
                    If TrailerNo <> String.Empty Then
                        lblDriver.Text &= "<br/><font color='red' size='+1'>LastTrailer on Record: " & TrailerNo & "</font>"
                    End If
                End If
            End If 'Not dr Is Nothing Then
        End Sub
        Private Function GetTrailerDetails(ByVal TrailerDetail As String) As String
            If String.IsNullOrEmpty(TrailerDetail) Then Return String.Empty
            Dim arrLastTrailer() As String = Split(TrailerDetail, ",")
            If arrLastTrailer.Length > 0 Then
                txtTrailerNumber.Text = arrLastTrailer(0).Trim()
                Try
                    ddlTrailerType.ClearSelection()
                    If Not String.IsNullOrEmpty(arrLastTrailer(1)) Then
                        ddlTrailerType.SelectedValue = arrLastTrailer(1).Replace("Type:", "").Trim()
                    End If
                Catch
                End Try
                Return arrLastTrailer(0).Trim()
            Else
                Return String.Empty
            End If

        End Function

        Private Sub txtBrokerName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBrokerName.TextChanged
            If Not String.IsNullOrEmpty(txtBrokerName.Text) Then
                'Dim CityStateZip As String() = Strings.Split(txtCustomerName.Text, "|")
                Dim CityStateZip() As String = Split(txtBrokerName.Text, " | ")
                If CityStateZip.Length > 0 Then
                    txtBrokerName.Text = CityStateZip(0)
                    If CityStateZip.Length > 1 Then
                        txtBrokerCode.Text = CityStateZip(1)
                        txtBrokerCode_TextChanged(Nothing, Nothing)
                    Else
                        btnBrokerSearch_Click(Nothing, Nothing)
                    End If

                    Dim sm As ScriptManager = AJAX.ScriptManagerControl(Me.Page)
                    sm.SetFocus(ddlBrokerCode)
                End If
            End If
        End Sub

        Private Sub ddlBrokerCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBrokerCode.SelectedIndexChanged
            Dim dr As IDataReader = (New Business.LoadSheetsController).GetBrokerByCode(ddlBrokerCode.SelectedValue)
            If Not dr Is Nothing Then
                dr.Read()

                lblBroker.Text = "<br />BrokerCode: " & dr("BrokerCode").ToString
                ViewState("BrokerStatus") = dr("BStatus").ToString.ToUpper
                'ViewState("BrokerNotes") = dr("BrokerNotes").ToString
                If (ViewState("BrokerStatus") = "HOLD") Then
                    lblBrokerNotes.Text = "<br/>" & Convert.ToString(Null.SetNull(dr("BrokerNotes"), Null.NullString))
                Else
                    lblBrokerNotes.Text = ""
                End If
                SetLoadStatus()

                'lblBroker.Text &= "<br />Status: "
                If dr("BStatus").ToString.ToUpper = "ACTIVE" Then
                    'lblBroker.Text &= "<font color='green'>ACTIVE</font><br />"
                    lblBrokerStatus.Text = "<font color='green'>ACTIVE</font>"
                Else
                    'lblBroker.Text &= "<font color='red'>INACTIVE</font><br />"
                    'lblBroker.Text &= "<font color='red'>" & dr("BStatus").ToString.ToUpper & "</font><br />"
                    lblBrokerStatus.Text = "<font color='red'>" & dr("BStatus").ToString.ToUpper & "</font>"
                    'If ddlLoadStatus.SelectedValue.ToUpper <> "VOIDED" Then
                    '    ddlLoadStatus.ClearSelection()
                    '    ddlLoadStatus.Items.FindByValue("SUSPENSE").Selected = True
                    'End If
                End If

                lblBroker.Text &= "<br />"
                If dr("ContactCode").ToString <> String.Empty Then lblBroker.Text &= dr("ContactCode").ToString & ", "
                lblBroker.Text &= "Phone: " & Phone.FormatPhoneNo(dr("PhoneNo").ToString)
                lblBroker.Text &= "<br />"

                If dr("AddressLine1").ToString <> String.Empty Then lblBroker.Text &= dr("AddressLine1").ToString & "<br />"
                If dr("AddressLine2").ToString <> String.Empty Then lblBroker.Text &= dr("AddressLine2").ToString & "<br />"

                lblBroker.Text &= dr("City").ToString & ", "
                lblBroker.Text &= dr("State").ToString & " "
                lblBroker.Text &= dr("ZipCode").ToString


                If ddlBrokerCode.SelectedValue <> ViewState("BrokerCode").ToString() Then
                    lblUpdateBroker.Text = "<p><font color='red'><b>Broker changed</b><br/>Be sure to re-calculate Accounting.</font></p>"
                Else
                    lblUpdateBroker.Text = ""
                End If

                'Update the Search TextBoxes
                txtBrokerCode.Text = "" 'ddlBrokerCode.SelectedValue
                txtBrokerName.Text = "" 'ddlBrokerCode.SelectedItem.Text

                If Page.IsPostBack Then BindBkrDrivers() '(ddlBkrDriverNo.SelectedValue)
            End If 'Not dr Is Nothing Then

        End Sub

        Private Sub txtBrokerCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBrokerCode.TextChanged
            With ddlBrokerCode
                Dim txt As String '= .Items(0).Text '.SelectedItem.Text
                Dim val As String '= .Items(0).Value '.SelectedValue
                If .Items.Count > 0 Then
                    txt = .Items(0).Text  '.SelectedItem.Text
                    val = .Items(0).Value  '.SelectedValue
                End If

                '.DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerCode.Text, "BrokerCode", (rblBrokerSearchType.SelectedIndex < 1))
                .DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerCode.Text, "BrokerCode")
                .DataValueField = "BrokerCode"
                .DataTextField = "BrokerName"
                .DataBind()

                ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
                'If val <> String.Empty Then .Items.Insert(0, (New ListItem(txt, val)))
                ''.Items.Insert(0, (New ListItem("", "0000000")))

                If .Items.Count > 0 Then
                    ddlBrokerCode_SelectedIndexChanged(Nothing, Nothing)
                Else
                    .Items.Add(New ListItem("No Broker", ""))
                    lblBroker.Text = ""
                    ViewState("BrokerStatus") = "INACTIVE"
                    SetLoadStatus()
                End If

            End With 'ddlDriverName
        End Sub

        Private Sub btnBrokerSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBrokerSearch.Click
            With ddlBrokerCode
                Dim txt As String '= .Items(0).Text '.SelectedItem.Text
                Dim val As String '= .Items(0).Value '.SelectedValue
                If .Items.Count > 0 Then
                    txt = .Items(0).Text  '.SelectedItem.Text
                    val = .Items(0).Value  '.SelectedValue
                End If

                '.DataSource = (New Business.LoadSheetsController).GetSearchedBrokers(txtBrokerName.Text)
                .DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerName.Text, "BrokerName", True)
                '.DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerName.Text, True)
                .DataValueField = "BrokerCode"
                .DataTextField = "BrokerName"
                .DataBind()

                'If BC <> String.Empty Then .Items.Insert(0, (New ListItem(BN, BC)))
                '                        If val <> String.Empty Then .Items.Insert(0, (New ListItem(txt, val)))
                '.Items.Insert(0, (New ListItem("N/A", "0000000")))
                .Items.Insert(0, (New ListItem("To be assigned", "0000000")))
                If .Items.Count > 1 Then
                    .SelectedIndex = 1
                    ddlBrokerCode_SelectedIndexChanged(Nothing, Nothing)
                Else
                    '.Items.Add(New ListItem("No Broker", ""))
                    lblBroker.Text = ""
                    ViewState("BrokerStatus") = "INACTIVE"
                    SetLoadStatus()
                End If
            End With 'BrokerCode
        End Sub

        Private Sub ddlIOCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlIOCode.SelectedIndexChanged
            SetCanRecover()
            SeteMailTo()
            SetLoadStatus()
        End Sub

        Private Sub imbUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdate.Click, imbAdd.Click
            cmdUpdate_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click, cmdAdd.Click
            Try
                ' Only Update if the Entered Data is Valid
                If Page.IsValid Then
                    'Dim objLoadSheet As New LoadSheetInfo
                    ''Initialise the ojbLoadSheet object
                    'objLoadSheet = CType(CBO.InitializeObject(objLoadSheet, GetType(Business.LoadSheetInfo)), LoadSheetInfo)

                    'bind text values to object
                    Dim objLoadSheet As LoadSheetInfo = PageToItem()


                    Dim objLoadSheetsController As New LoadSheetsController
                    If Null.IsNull(itemId) Then
                        itemId = objLoadSheetsController.AddLoadSheet(objLoadSheet)
                    Else
                        objLoadSheetsController.UpdateLoadSheet(objLoadSheet)
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
                        Case "ACCOUNTING"
                            'Redirect to the Accounting Page of this Item for Viewing the details of this Item
                            Response.Redirect(EditUrl("LoadID", objLoadSheet.LoadID, "EditAcct"), True)
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
                Case "ACCOUNTING"
                    If Not Null.IsNull(itemId) Then
                        ''Redirect to the Accounting Page of this Item for Viewing the details of this Item
                        Response.Redirect(hypLoadAccounting.NavigateUrl, True)
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
                    Dim objLoadSheetsController As New LoadSheetsController
                    objLoadSheetsController.DeleteLoadSheet(itemId)
                End If

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

#Region " Icon Bar "
        Private Sub UpdateBrokerDetails(ByVal objLoadSheet As LoadSheetInfo)
            'If (objLoadSheet.LoadStatus = "BK") AndAlso (objLoadSheet.BrokerCode <> ViewState("BrokerCode").ToString()) Then
            If lblUpdateBroker.Text <> "" Then
                Dim objLAC As New LoadAcctsController
                objLAC.UpdateBrokerDetails(txtLoadID.Text, 0, "N")
            End If
        End Sub

        Private Function UpdateDriverStatus(ByVal objLoadSheet As LoadSheetInfo) As Boolean
            Dim Result As Boolean = False
            'Dim objLC As New LoadSheetsController
            Select Case objLoadSheet.LoadType.ToUpper
                Case "OO"
                    'Dim DriverId As Integer = objLC.GetSalesPersonId(objLoadSheet.DriverCode)
                    Dim objSC As New bhattji.Modules.SalesPersons.Business.SalesPersonsController
                    objSC.ClearLastLoadData(objLoadSheet.LoadID)
                    objSC.RefreshForNullLoadId()
                    'objSC.RefreshForLastLoadId(objLoadSheet.LoadID)
                    objSC.RefreshLastLoadData(objLoadSheet.DriverCode)

                    Result = True
                Case "BK"
                    'Dim DriverId As Integer = objLC.GetBkrSalesPersonId(objLoadSheet.BkrDriverNo)
                    Dim objSC As New bhattji.Modules.BkrSalesPersons.Business.SalesPersonsController
                    objSC.ClearLastLoadData(objLoadSheet.LoadID)
                    objSC.RefreshForNullLoadId()
                    'objSC.RefreshForLastLoadId(objLoadSheet.LoadID)
                    objSC.RefreshLastLoadData(objLoadSheet.BkrDriverNo)

                    Result = True
            End Select

            Return Result
        End Function

        'Private Function UpdateDriverStatus1(ByVal objLoadSheet As LoadSheetInfo) As Boolean
        '    Dim Result As Boolean = False
        '    Dim objLC As New LoadSheetsController
        '    Select Case objLoadSheet.LoadType.ToUpper
        '        Case "OO"
        '            Dim DriverId As Integer = objLC.GetSalesPersonId(objLoadSheet.DriverCode)
        '            Dim objSC As New bhattji.Modules.SalesPersons.Business.SalesPersonsController
        '            'objSC.ClearLastLoadData(objLoadSheet.LoadID)
        '            objSC.RefreshForLastLoadId(objLoadSheet.LoadID)
        '            Dim objSalePerson As bhattji.Modules.SalesPersons.Business.SalesPersonInfo = objSC.GetSalesPerson(DriverId)
        '            If (Not objSalePerson Is Nothing) AndAlso (objSalePerson.LastLoad <= objLoadSheet.LoadDate) Then
        '                Try
        '                    If (objSalePerson.LastLoad < objLoadSheet.LoadDate) OrElse (objLC.GetItemId(objSalePerson.LastLoadID) < objLC.GetItemId(objLoadSheet.ItemId)) Then
        '                        objSalePerson.LastLoadID = objLoadSheet.LoadID
        '                        objSalePerson.LastLoad = objLoadSheet.LoadDate

        '                        'objSalePerson.LastPU = objLoadSheet.PUCityST
        '                        'objSalePerson.LastDP = objLoadSheet.DPCityST
        '                        'objSalePerson.LastLoadDeliv = objLoadSheet.LoadDate

        '                        objSalePerson.LastTrailerUsed = objLoadSheet.TrailerNumber

        '                        objSC.UpdateSalesPerson(objSalePerson)

        '                        Dim objLoadPUsController As New LoadPUsController
        '                        objLoadPUsController.SetPUCityST(objLoadSheet.LoadID)

        '                        Dim objLoadDropsController As New LoadDropsController
        '                        objLoadDropsController.SetDPCityST(objLoadSheet.LoadID)

        '                        Result = True
        '                    End If
        '                Catch
        '                End Try
        '            End If
        '        Case "BK"
        '            Dim DriverId As Integer = objLC.GetBkrSalesPersonId(objLoadSheet.BkrDriverNo)
        '            Dim objSC As New bhattji.Modules.BkrSalesPersons.Business.SalesPersonsController
        '            'objSC.ClearLastLoadData(objLoadSheet.LoadID)
        '            objSC.RefreshForLastLoadId(objLoadSheet.LoadID)
        '            Dim objSalePerson As bhattji.Modules.BkrSalesPersons.Business.SalesPersonInfo = objSC.GetSalesPerson(DriverId)
        '            If (Not objSalePerson Is Nothing) AndAlso (objSalePerson.LastLoad <= objLoadSheet.LoadDate) Then
        '                Try
        '                    If (objSalePerson.LastLoad < objLoadSheet.LoadDate) OrElse (objLC.GetItemId(objSalePerson.LastLoadID) < objLC.GetItemId(objLoadSheet.ItemId)) Then
        '                        objSalePerson.LastLoadID = objLoadSheet.LoadID
        '                        objSalePerson.LastLoad = objLoadSheet.LoadDate

        '                        'objSalePerson.LastPU = objLoadSheet.PUCityST
        '                        'objSalePerson.LastDP = objLoadSheet.DPCityST
        '                        'objSalePerson.LastLoadDeliv = objLoadSheet.LoadDate

        '                        objSalePerson.LastTrailerUsed = objLoadSheet.TrailerNumber

        '                        objSC.UpdateSalesPerson(objSalePerson)

        '                        objSC.UpdateSalesPerson(objSalePerson)

        '                        Dim objLoadPUsController As New LoadPUsController
        '                        objLoadPUsController.SetPUCityST(objLoadSheet.LoadID)

        '                        Dim objLoadDropsController As New LoadDropsController
        '                        objLoadDropsController.SetDPCityST(objLoadSheet.LoadID)

        '                        Result = True
        '                    End If
        '                Catch
        '                End Try
        '            End If
        '    End Select

        '    Return Result
        'End Function

        Private Function UpdateLoad() As LoadSheetInfo
            Dim objLoadSheet As New LoadSheetInfo
            ' Only Update if the Entered Data is Valid
            If Page.IsValid Then
                'Dim objLoadSheet As New LoadSheetInfo
                ''Initialise the ojbLoadSheet object
                objLoadSheet = CType(CBO.InitializeObject(objLoadSheet, GetType(Business.LoadSheetInfo)), LoadSheetInfo)

                'bind text values to object
                objLoadSheet = PageToItem()

                'Controls.Add(objOI.Popup("Success", "ItemId: " & objLoadSheet.ItemId & ", LoadId: " & objLoadSheet.LoadID))
                DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Success", "ItemId: " & objLoadSheet.ItemId & ", LoadId: " & objLoadSheet.LoadID, Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "ItemId: " & objLoadSheet.ItemId & ", LoadId: " & objLoadSheet.LoadID, Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)

                Dim objLoadSheetsController As New LoadSheetsController
                If Null.IsNull(itemId) Then
                    itemId = objLoadSheetsController.AddLoadSheet(objLoadSheet)
                    objLoadSheet.ItemId = itemId
                Else
                    objLoadSheetsController.UpdateLoadSheet(objLoadSheet)
                    If lblCustomerChanged.Text <> "" Then '(objLoadSheet.CustomerNumber <> ViewState("CustomerNumber").ToString()) Then 'If ddlCustomerNumber.SelectedValue <> ViewState("CustomerNumber").ToString() Then '
                        Try
                            Dim objLAC As New LoadAcctsController
                            'Dim objLoadAcct As LoadAcctInfo = objLAC.GetLoadAcctByLoadId(objLoadSheet.LoadID) 'objLAC.GetLoadAcct(objLAC.GetLoadAcctId(objLoadSheet.LoadID))

                            'objLoadAcct.RepNo = objLoadSheet.RepNo
                            'objLoadAcct.RepName = objLoadSheet.RepName
                            'objLoadAcct.RepPct = 0 'objLoadSheet.RepPctM
                            'objLoadAcct.RepDlr = 0 'objLoadSheet.RepDlrM

                            'objLAC.UpdateLoadAcct(objLoadAcct)
                            objLAC.UpdateRepDetails(objLAC.GetLoadAcctId(objLoadSheet.LoadID), objLoadSheet.RepPctM, objLoadSheet.RepDlrM)
                        Catch
                        End Try
                    End If
                    UpdateBrokerDetails(objLoadSheet)
                End If

                If UpdateDriverStatus(objLoadSheet) Then
                    'Controls.Add(objOI.Popup("Success", "Driver Status posted successfully"))
                    DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Success", "Driver Status posted successfully", Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)
                Else
                    'Controls.Add(objOI.Popup("Failure", "Driver Status could not be posted successfully"))
                    DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "Driver Status could not be posted successfully", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                End If

                ' url tracking
                'Dim objUrls As New UrlController
                ' url tracking for MediaSrc
                'With ctlMediaSrc
                '    objUrls.UpdateUrl(PortalId, .Url, .UrlType, .Log, .Track, ModuleId, .NewWindow)
                'End With 'ctlMediaSrc

            End If

            Return objLoadSheet
        End Function


        Private Sub imbHome_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbHome.Click
            lnbHome_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbHome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbHome.Click
            Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            'Redirect to the Accounting Page of this Item for Viewing the details of this Item
            Response.Redirect(ResolveUrl("~/Default.aspx") & "?tabname=Home", True)
        End Sub

        Private Sub imbPUDrops_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPUDrops.Click
            lnbPUDrops_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbPUDrops_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbPUDrops.Click
            Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            'Redirect to the Accounting Page of this Item for Viewing the details of this Item
            Response.Redirect(EditUrl("ItemID", itemId.ToString, "EditPUDrops", "dnnprintmode=true"), True)
        End Sub

        Private Sub imbUpdateAccounting_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateAccounting.Click
            lnbUpdateAccounting_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateAccounting_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUpdateAccounting.Click
            Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            'Redirect to the Accounting Page of this Item for Viewing the details of this Item
            Response.Redirect(EditUrl("LoadID", objLoadSheet.LoadID, "EditAcct"), True)
        End Sub

        Private Sub imbUpdateAddNew_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateAddNew.Click
            lnbUpdateAddNew_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUpdateAddNew.Click
            Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            'Redirect back to the Edit Page of the Item for Add
            Response.Redirect(EditUrl(), True)
        End Sub

        Private Sub imbUpdateToList_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateToList.Click
            lnbUpdateToList_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateToList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUpdateToList.Click
            Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            'Redirect back to the portal home page
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub imbUpdateContinueEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) 'Handles imbUpdateContinueEdit.Click
            lnbUpdateContinueEdit_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateContinueEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles lnbUpdateContinueEdit.Click
            Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            'Redirect back to this same Edit Page with same ItemId to Edit & Continue
            Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
        End Sub

        Private Sub imbUpdateToViewer_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) 'Handles imbUpdateToViewer.Click
            lnbUpdateToViewer_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateToViewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles lnbUpdateToViewer.Click
            Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            'Redirect to the Detail Page of this Item for Viewing the details of this Item
            Response.Redirect(EditUrl("ItemId", itemId.ToString, "ItemDetails"), True)
        End Sub

        Private Sub imbCancelReload_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancelReload.Click
            lnbCancelReload_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbCancelReload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbCancelReload.Click
            'Redirect back to the Edit Page of the Item for Add
            Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
        End Sub

        Private Sub imbPrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrint.Click
            lnbPrint_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbPrint.Click
            Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            ''Redirect back to this same Edit Page with same ItemId to Edit & Continue
            'Dim NavUrl As String = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
            'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"), True)
            'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper), True)
            ResponseHelper.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper))
        End Sub

        Private Sub imbPrintConfirm_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintConfirm.Click
            lnbPrintConfirm_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbPrintConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbPrintConfirm.Click
            Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            ''Redirect back to this same Edit Page with same ItemId to Edit & Continue
            'Dim NavUrl As String = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
            'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"), True)
            'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper), True)
            'ResponseHelper.Redirect(EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper))

            'New PDF Confirm Report
            ResponseHelper.Redirect(EditUrl("ReportType", "LoadConfirm", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper, "dnnprintmode=true"))
        End Sub

        'Private Sub imbEmail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbEmail.Click
        '    lnbEmail_Click(Nothing,Nothing)
        'End Sub
        'Private Sub lnbEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbEmail.Click
        '    'Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
        '    ''Redirect back to this same Edit Page with same ItemId to Edit & Continue
        '    'Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
        'End Sub

        Private Sub ddleMailTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddleMailTo.SelectedIndexChanged
            txteMailTo.Visible = (ddleMailTo.SelectedValue = "")
        End Sub
        Private Sub imbEmail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbEmail.Click, imbeMailTo.Click
            lnbEmail_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbEmail.Click
            If ddleMailTo.SelectedValue <> "" Then
                Dim Dispatcher As Users.UserInfo = Users.UserController.GetUserByName(PortalId, ddleMailTo.SelectedValue)
                txteMailTo.Text = Dispatcher.Email
            End If
            'ResponseHelper.Redirect("mailto:" & Dispatcher.Email & ";" & Dispatcher.Membership.Email & "&Subject=IO Load Sold&Body=The IO Load has been sold to the Office")
            If txteMailTo.Text <> "" Then
                SendNotification(txteMailTo.Text, ddleMailTo.SelectedValue) 'Dispatcher.DisplayName)
            End If
        End Sub
        Private Sub imbEmailCanRecover_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbEmailCanRecover.Click
            If ddlCanRecover.SelectedValue <> "" Then
                Dim Dispatcher As Users.UserInfo = Users.UserController.GetUserByName(PortalId, ddlCanRecover.SelectedValue)
                SendNotification(Dispatcher.Email, ddlCanRecover.SelectedValue) 'Dispatcher.DisplayName)
            End If
        End Sub

        Private Sub imbVoidLoad_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbVoidLoad.Click
            lnbVoidLoad_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbVoidLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbVoidLoad.Click
            Try
                ''If ddlLoadStatus.Items.FindByValue("VOIDED").Selected Then
                ''    lnbVoid.Text = "<br/><font size='+1' color='red'>LOAD VOIDED</font>"
                ''Else
                ''    ddlLoadStatus.ClearSelection()
                ''    ddlLoadStatus.Items.FindByValue("VOIDED").Selected = True
                ''    'ddlLoadStatus.SelectedValue = "VOIDED"
                ''End If
                ''ddlLoadStatus.Items.FindByValue("VOIDED").Selected = True
                'ddlLoadStatus.SelectedValue = "VOIDED"
                'SetLoadStatusText(ddlLoadStatus.SelectedItem.Text)
                ''SetLoadStatus()
                'HideWhenLoadIsVoid()
                ''lnbUpdateToList_Click(Nothing, Nothing)
                ''lnbUpdateContinueEdit_Click(Nothing, Nothing)
                Dim objLSC As New LoadSheetsController
                objLSC.VoidLoad(txtLoadID.Text)

                'Set the OffLoad to WIP if the Load Is IORecovered
                'Dim objLSC As New LoadSheetsController
                Dim objLAC As New LoadAcctsController
                Dim objLoadAcct As LoadAcctInfo = objLAC.GetLoadAcctByLoadId(txtLoadID.Text)
                If (Not objLoadAcct Is Nothing) AndAlso objLoadAcct.IsIORecoveredLoad AndAlso (objLoadAcct.IOOffL1 <> "") Then '
                    Dim objOriginalLoad As LoadSheetInfo = objLSC.GetLoadSheetByLoadId(objLoadAcct.IOOffL1)
                    If Not objOriginalLoad Is Nothing Then
                        objOriginalLoad.LoadStatus = "WIP"
                        objLSC.UpdateLoadSheet(objOriginalLoad)
                    End If
                End If

                'Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
                Response.Redirect(NavigateURL, True)
            Catch
            End Try
        End Sub

        Private Sub imbUnVoidLoad_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUnVoidload.Click
            lnbUnVoidLoad_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUnVoidLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles inbUnVoidLoad.Click
            Try
                'If ddlLoadStatus.Items.FindByValue("VOIDED").Selected Then
                '    ddlLoadStatus.ClearSelection()
                '    'ddlLoadStatus.Items.FindByValue("SUSPENSE").Selected = True
                '    ddlLoadStatus.SelectedValue = "SUSPENSE"
                'End If
                ddlLoadStatus.SelectedValue = "SUSPENSE"
                SetLoadStatus()
                HideWhenLoadIsVoid(True)

                lnbUpdateContinueEdit_Click(Nothing, Nothing)
            Catch
            End Try
        End Sub

        Private Sub imbCopyLoad_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCopyLoad.Click
            lnbCopyLoad_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbCopyLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbCopyLoad.Click
            Response.Redirect(EditUrl("FromLoadId", txtLoadID.Text, "Edit", "OType=CopyLoad"), True)
        End Sub


#End Region

    End Class 'EditItem

End Namespace 'bhattji.Modules.LoadSheets