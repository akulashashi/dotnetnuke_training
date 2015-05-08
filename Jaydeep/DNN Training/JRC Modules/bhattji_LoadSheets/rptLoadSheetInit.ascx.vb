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
Imports System.Web.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports bhattji.Modules.SalesPersons.Business
'Imports bhattji.Modules.SalesReps.Business
'Imports Microsoft.ScalableHosting.Security
'Imports AspNetSecurity = Microsoft.ScalableHosting.Security

Namespace bhattji.Modules.LoadSheets

    Public MustInherit Class rptLoadSheetInit
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "

        Private itemId As Integer
        Private loadId As String
        Private objOI As OptionsInfo

#End Region

#Region " Methods "

        Private Sub InitEveryTime()
            'Put user code to initialize the page here
            Dim RattleImageJS As String = "<SCRIPT type=""text/javascript"" src=""" & ModulePath & "js/JbRattleImage.js""></SCRIPT>"
            If (Not Page.ClientScript.IsClientScriptBlockRegistered("RattleImageJS")) Then
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "RattleImageJS", RattleImageJS)
            End If
            Dim JB_ActiveContentJS As String = "<SCRIPT type=""text/javascript"" src=""" & ModulePath & "js/JB_ActiveContent.js""></SCRIPT>"
            If (Not Page.ClientScript.IsClientScriptBlockRegistered("JB_ActiveContentJS")) Then
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "JB_ActiveContentJS", JB_ActiveContentJS)
            End If

        End Sub

        Private Sub InitFirstTime()
            'divButtons.Visible = (Request.QueryString("SkinSrc") Is Nothing) OrElse (Request.QueryString("SkinSrc") = "")
            divButtons.Visible = (Request.QueryString("dnnprintmode") Is Nothing) OrElse (Request.QueryString("dnnprintmode").ToLower <> "true")
            If divButtons.Visible Then
                SetIconBar()
            Else
                'Dim ltrPrintScript As New LiteralControl
                'With ltrPrintScript
                '    .Text = "<script type=""text/javascript"" language=""javascript"">"
                '    .Text &= "window.print();"
                '    .Text &= "</script>"
                'End With
                'Controls.Add(ltrPrintScript)
                Controls.Add(New LiteralControl("<script type=""text/javascript"" language=""javascript"">window.print();</script>"))
            End If
        End Sub


        Private Sub SetIconBar()
            'Give the ImageUrl
            'hypImgEdit.ImageUrl = ModulePath & "img/bhattji_Edit.jpg"

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
                    '.ImageUrl = ModulePath & "img/bhattji_Close.jpg"
                    .NavigateUrl = NavigateURL()
                    .ToolTip = Localization.GetString("Close")
                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                End If
            End With  'hypImgClose

            'Print Authority
            With hypPrint
                .Visible = True
                If .Visible Then
                    '.NavigateUrl = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & Request.QueryString("LoadType"), "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                    .NavigateUrl = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & Request.QueryString("ItemId"), "LoadType=" & Request.QueryString("LoadType").ToUpper) & "?dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
                    '.Target = "_blank"
                    .ToolTip = Localization.GetString("Print", LocalResourceFile)
                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                End If
            End With  'hypPrint
            With hypImgPrint
                .Visible = True
                If .Visible Then
                    '.ImageUrl = ModulePath & "img/bhattji_Print.jpg"
                    .NavigateUrl = hypPrint.NavigateUrl
                    '.Target = "_blank"
                    .ToolTip = Localization.GetString("Print", LocalResourceFile)
                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                End If
            End With  'hypImgPrint
        End Sub 'SetIconBar()

        Private Sub ItemToPage(ByVal ItemId As Integer)
            If Not Null.IsNull(ItemId) Then 'Check for the Not-Null ItemId
                Dim objLoadSheet As Business.LoadSheetInfo = (New Business.LoadSheetsController).GetLoadSheet(ItemId)
                'Check for the Not-Null objLoadSheet
                If Not objLoadSheet Is Nothing Then ItemToPage(objLoadSheet)
            End If
        End Sub

        Private Sub ItemToPage(ByVal objLoadSheetInfo As Business.LoadSheetInfo)
            'Load objLoadSheetInfo data to the Page
            With objLoadSheetInfo
                loadId = .LoadID
                lblLoadId.Text = .LoadID
                lblLoadDate.Text = .LoadDate.ToShortDateString
                lblJRCIOfficeCode.Text = .JRCIOfficeCode

                lblCustomerNumber.Text = .CustomerNumber
                lblCustomer.Text = .CustomerName
                Dim dr As IDataReader = (New Business.LoadSheetsController).GetCustomerByNumber(.CustomerNumber)
                If Not dr Is Nothing Then
                    dr.Read()
                    lblCustomer.Text = dr("CustomerName").ToString & "<br />"

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

                End If 'Not dr Is Nothing Then

                lblComCheckSeq.Text = .ComCheckSeq
                If (.ComCheckAmt > 0) Then lblComCheckAmt.Text = String.Format("{0:0.00}", .ComCheckAmt)

                lblXmissionFile.Text = .XMissionFile
                If Not Null.IsNull(.XMissionDate) Then lblXmissionDate.Text = .XMissionDate.ToShortDateString

                lblCustPO.Text = .CustPO
                lblProJob.Text = .ProJob ' .PUCityST

                Dim strLoadType As String = Request.QueryString("LoadType").ToUpper
                tblDriver.Visible = (strLoadType = "OO")
                tblDriverPayables.Visible = tblDriver.Visible

                tblIOffice.Visible = (strLoadType = "IO")
                tblIOPayables.Visible = tblIOffice.Visible

                tblBroker.Visible = (strLoadType = "BK")
                tblBrokerPayables.Visible = tblBroker.Visible
                


                Select Case strLoadType
                    Case "BK"
                        'Broker Table
                        'lblReportHeading.Text = "Broker Load Sheet"
                        lblBrokerCode.Text = .BrokerCode
                        lblBrokerName.Text = .BrokerName
                        lblBrokerDriver.Text = .BKDriver
                    Case "IO"
                        'IO Table
                        'lblReportHeading.Text = "Inter Office Load Sheet"
                        lblJRCIOCode.Text = .JRCIOCode
                        lblIOName.Text = .IOName
                    Case Else '"OO"
                        'Driver Table
                        'lblReportHeading.Text = "Owner Operator Office Load Sheet"
                        lblDriverCode.Text = .DriverCode
                        lblDriverName.Text = .DriverName
                        lblDriverAcct.Text = .AccountNo
                        'lblDriverAcctF.Text = .AccountNo
                        trAdminExempt.Visible = (.AdminExempt.ToUpper = "Y")
                        If .SafetyAuth.ToUpper = "HOLD" Then
                            lblOOMsg.Text = "<font size='+1' color='red'>Driver on Safety Hold</font>"
                        Else
                            lblOOMsg.Visible = False
                        End If

                End Select


                lblTrailerNumber.Text = .TrailerNumber
                'lblTrailerType.Text = .TrailerType
                Select Case .TrailerType.ToUpper
                    Case "FD"
                        lblTrailerType.Text = "Flatbed"
                    Case "SD"
                        lblTrailerType.Text = "Stepdeck"
                    Case "RG"
                        lblTrailerType.Text = "RGN"
                    Case "DD"
                        lblTrailerType.Text = "Double Drop"
                    Case "48"
                        lblTrailerType.Text = "Van 48'"
                    Case "53"
                        lblTrailerType.Text = "Van 53'"
                    Case "20"
                        lblTrailerType.Text = "20' container"
                    Case "40"
                        lblTrailerType.Text = "40' container"
                    Case "FT"
                        lblTrailerType.Text = "FT"
                    Case "F"
                        lblTrailerType.Text = "F"
                    Case Else
                        lblTrailerType.Text = ""
                End Select
                If Not Null.IsNull(.TrailerDue) Then lblTrailerDue.Text = .TrailerDue.ToShortDateString

                lblContainer1.Text = .Container1
                If Not Null.IsNull(.Container1Due) Then lblContainer1Due.Text = .Container1Due.ToShortDateString
                lblContainer2.Text = .Container2
                If Not Null.IsNull(.Container2Due) Then lblContainer2Due.Text = .Container2Due.ToShortDateString



                lblLoadNotes.Text = .LDNotesA
                If .LDNotesB <> "" Then lblLoadNotes.Text &= "<br/>" & .LDNotesB
                If .LDNotesC <> "" Then lblLoadNotes.Text &= "<br/>" & .LDNotesC
                If .LDNotesD <> "" Then lblLoadNotes.Text &= "<br/>" & .LDNotesD

                'lblSpCustInst.Text = .InvCommentA
                'If .InvCommentB <> "" Then lblSpCustInst.Text &= "<br/>" & .InvCommentB
                'If .InvCommentC <> "" Then lblSpCustInst.Text &= "<br/>" & .InvCommentC
                'If .InvCommentD <> "" Then lblSpCustInst.Text &= "<br/>" & .InvCommentD
                If .TarpLoad.ToUpper = "Y" Then
                    If .TarpMessage <> "" Then
                        lblTarpMessage.Text = "<b>" & .TarpMessage & "</b>"
                    Else
                        lblTarpMessage.Text = "<b>THIS LOAD MUST BE TARPED</b>"
                    End If
                Else
                    lblTarpMessage.Text = ""
                End If
                'lblTarpMessage.Text = .TarpMessage

                lblInvComment.Text = .InvCommentA
                If .InvCommentB <> "" Then lblInvComment.Text &= " " & .InvCommentB
                If .InvCommentC <> "" Then lblInvComment.Text &= " " & .InvCommentC
                If .InvCommentD <> "" Then lblInvComment.Text &= " " & .InvCommentD

                lblDispatchCode.Text = .DispatchCode
                lblDispName.Text = .DispName

                lblOffOrgin.Text = .OffOrgin
                lblOffFunds.Text = .OffFunds

                lblProNox.Text = .ProNox
                If (.PDAmt > 0) Then lblPDAmt.Text = .PDAmt
                If (.OverrideComm > 0) Then lblOverrideComm.Text = .OverrideComm



                Dim objLoadSheetsController As New Business.LoadSheetsController
                Dim drIO As IDataReader = objLoadSheetsController.GetIOByCode(.JRCIOfficeCode)
                If Not drIO Is Nothing Then
                    drIO.Read()
                    lblLoadAcct.Text = drIO("LoadAcct").ToString
                    lblDiscAcct.Text = drIO("DiscAcct").ToString
                    lblDetenAcct.Text = drIO("DetenAcct").ToString
                    lblTollsAcct.Text = drIO("TollsAcct").ToString
                    lblFuelAcct.Text = drIO("FuelAcct").ToString
                    lblDropAcct.Text = drIO("DropAcct").ToString
                    lblReconAcct.Text = drIO("ReconAcct").ToString
                    lblTarpAcct.Text = drIO("TarpAcct").ToString
                    lblLumperAcct.Text = drIO("LumperAcct").ToString
                    lblUnloadAcct.Text = drIO("UnloadAcct").ToString
                    lblAdminMiscAcct.Text = drIO("AdminMiscAcct").ToString
                End If


                Dim objLoadAcctsController As New Business.LoadAcctsController
                lblJRCIOfficeCode.Text = objLoadAcctsController.GetIOName(.JRCIOfficeCode)


                Dim objLoadAcctInfo As Business.LoadAcctInfo = objLoadAcctsController.GetLoadAcct((New Business.LoadAcctsController).GetLoadAcctId(.LoadID))
                If Not objLoadAcctInfo Is Nothing Then ItemToPage(objLoadAcctInfo)

            End With 'objLoadSheetInfo

            'Edit Authority
            tdEdit.Visible = IsEditable

            With hypEdit
                .Visible = tdEdit.Visible
                If .Visible Then
                    .NavigateUrl = EditUrl("ItemID", itemId.ToString)
                    .ToolTip = Localization.GetString("Edit")
                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                End If
            End With  'hypEdit
            With hypImgEdit
                .Visible = hypEdit.Visible
                If .Visible Then
                    .NavigateUrl = EditUrl("ItemID", itemId.ToString)
                    .ToolTip = Localization.GetString("Edit")
                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                End If
            End With  'hypImgEdit

            'Audit Control
            With ctlAudit
                .CreatedByUser = objLoadSheetInfo.UpdatedByUser
                .CreatedDate = objLoadSheetInfo.UpdatedDate.ToString
            End With 'ctlAudit


        End Sub

        Private Sub ItemToPage(ByVal objLoadAcctInfo As Business.LoadAcctInfo)
            With objLoadAcctInfo

                lblBINC3.Text = .BINC3.ToUpper
                lblBINC4.Text = .BINC4.ToUpper
                lblBINC5.Text = .BINC5.ToUpper
                lblBINC6.Text = .BINC6.ToUpper
                lblBINC7.Text = .BINC7.ToUpper
                lblBINC8.Text = .BINC8.ToUpper
                lblBINC9.Text = .BINC9.ToUpper
                lblBINC10.Text = .BINC10.ToUpper
                lblBINC11.Text = .BINC11.ToUpper

                If (.BBaseLoad > 0) Then lblBBaseLoad.Text = String.Format("{0:0.00}", .BBaseLoad)
                If (.DiscountDlr > 0) Then lblDiscountDlr.Text = String.Format("{0:0.00}", .DiscountDlr)
                If (.BDeten > 0) Then lblBDeten.Text = String.Format("{0:0.00}", .BDeten)
                If (.BTolls > 0) Then lblBTolls.Text = String.Format("{0:0.00}", .BTolls)
                If (.BFuel > 0) Then lblBFuel.Text = String.Format("{0:0.00}", .BFuel)
                If (.BDrop > 0) Then lblBDrop.Text = String.Format("{0:0.00}", .BDrop)
                If (.BRecon > 0) Then lblBRecon.Text = String.Format("{0:0.00}", .BRecon)
                If (.BTarp > 0) Then lblBTarp.Text = String.Format("{0:0.00}", .BTarp)
                If (.BLumper > 0) Then lblBLumper.Text = String.Format("{0:0.00}", .BLumper)
                If (.BUnload > 0) Then lblBUnload.Text = String.Format("{0:0.00}", .BUnload)
                If (.BAdminMisc > 0) Then lblBAdminMisc.Text = String.Format("{0:0.00}", .BAdminMisc)
                If (.BCustBill > 0) Then lblBCustBill.Text = String.Format("{0:0.00}", .BCustBill)

                If (.CalcMI > 0) Then lblLoadMI.Text = .CalcMI
                If (.CalcMI > 0) Then lblCalcMI.Text = .CalcMI
                If (.CalcRate > 0) Then lblCalcRate.Text = String.Format("{0:0.00}", .CalcRate)
                If (.CalcTot > 0) Then lblCalcTot.Text = String.Format("{0:0.00}", .CalcTot)

                'Driver Payables
                If (.DRTolls > 0) Then lblDRTolls.Text = .DRTolls
                If (.DRMisc > 0) Then lblDRMisc.Text = .DRMisc
                If (.CommRate > 0) Then lblCommRate.Text = .CommRate
                If (.DRCommBase > 0) Then lblDRCommBase.Text = .DRCommBase

                'IO Payables
                If (.IODlr > 0) Then lblIODlr.Text = String.Format("{0:0.00}", .IODlr)

                'Broker Payables
                If (.BkrDlr > 0) Then lblBkrDlr.Text = String.Format("{0:0.00}", .BkrDlr)

                'SalesRep Payables 'If dr("RepName").ToString <> String.Empty Then lblCustomer.Text &= "<br /><br />RepName: " & dr("RepName").ToString & "<br />"
                lblRepNo.Text = .RepNo
                lblRepName.Text = .RepName '(New SalesRepsController).GetSalesRepByRepNo(.RepNo).RepName  ' 

                'IO Commission
                If (.IOPct > 0) Then lblIODlr.Text = String.Format("{0:0.00}", .IODlr)
                If (.IODlr > 0) Then lblIODlr.Text = String.Format("{0:0.00}", .IODlr)


                If .LoadType.ToUpper = "IO" Then
                    'IO Commission
                    tdIoCommission.InnerText = "IO Payable"
                    tblXmission.Visible = False
                    trHeading2.Visible = False
                    trSubHeading2.Visible = False
                    trLine1.Visible = False
                    If (.JRCIOOffC1 = "") Then lblJRCIOOffC1.Text = .OfficeOverride Else lblJRCIOOffC1.Text = .JRCIOOffC1 'lblJRCIOOffC1.Text = .JRCIOOffC1 '.JRCIOfficeCode '.JRCIOCode
                    Try
                        lblIOOffN1.Text = (New InterOffices.Business.InterOfficesController).GetInterOffice(lblJRCIOOffC1.Text).IOName
                    Catch
                        lblIOOffN1.Text = lblJRCIOOffC1.Text
                    End Try

                    If (.JRCOffComm > 0) Then lblIOComm1.Text = String.Format("{0:0.00}", .JRCOffComm)
                    If (.JRCOnePct > 0) Then lblIOAdmin1.Text = String.Format("{0:0.00}", .JRCOnePct)
                    If Not Null.IsNull(.LoadID) Then lblIOOffL1.Text = .LoadID

                    If Not Null.IsNull(.IOOffC3) Then lblIOOffC4.Text = .IOOffC3
                    If Not Null.IsNull(.IOOffN3) Then lblIOOffN4.Text = .IOOffN3
                    If (.IOComm3 > 0) Then lblIOComm4.Text = String.Format("{0:0.00}", .IOComm3)
                    'If (.IOAdmin3 > 0) Then lblIOAdmin4.Text = String.Format("{0:0.00}", .IOAdmin3)
                    ''If Not Null.IsNull(.LoadID) Then lblIOOffL4.Text = .LoadID
                Else
                    'OO & BK Commission
                    tdIoCommission.InnerText = "IO Commission"
                    'If Not Null.IsNull(.JRCIOOffC1) Then lblJRCIOOffC1.Text = .JRCIOOffC1
                    If .IsIORecoveredLoad Then
                        lblJRCIOOffC1.Text = .IoRecoveryCode
                    Else
                        If Not Null.IsNull(.JRCIOOffC1) Then lblJRCIOOffC1.Text = .JRCIOOffC1
                    End If

                    If Not Null.IsNull(.IOOffN1) Then
                        Try
                            lblIOOffN1.Text = (New InterOffices.Business.InterOfficesController).GetInterOffice(.IOOffN1).IOName
                        Catch
                            lblIOOffN1.Text = .IOOffN1
                        End Try
                    End If
                    'If .IsIORecoveredLoad Then
                    '    lblJRCIOOffC1.Text = .JRCIOOffC1
                    '    lblIOOffN1.Text = .IOOffN1
                    'Else
                    '    If Not Null.IsNull(.JRCIOOffC1) Then lblJRCIOOffC1.Text = .JRCIOOffC1
                    '    If Not Null.IsNull(.IOOffN1) Then
                    '        Try
                    '            lblIOOffN1.Text = (New InterOffices.Business.InterOfficesController).GetInterOffice(.IOOffN1).IOName
                    '        Catch
                    '            lblIOOffN1.Text = .IOOffN1
                    '        End Try
                    '    End If
                    'End If

                    If (.IOComm1 > 0) Then
                        lblIOComm1.Text = String.Format("{0:0.00}", .IOComm1)
                        tdIOCommDollors.InnerHtml &= "<br/><nobr><small><strong>" & lblJRCIOOffC1.Text & ":" & lblIOComm1.Text & "</strong></small></nobr>"
                    End If
                    If (.IOAdmin1 > 0) Then
                        lblIOAdmin1.Text = String.Format("{0:0.00}", .IOAdmin1)
                        tdIOAdminDollors.InnerHtml &= "<br/><nobr><small><strong>" & lblJRCIOOffC1.Text & "</strong></small></nobr>"
                    End If
                    If Not Null.IsNull(.IOOffL1) Then lblIOOffL1.Text = .IOOffL1

                    If Not Null.IsNull(.JRCIOOffC2) Then lblJRCIOOffC2.Text = .JRCIOOffC2
                    If Not Null.IsNull(.IOOffN2) Then lblIOOffN2.Text = .IOOffN2
                    If (.IOComm2 > 0) Then
                        lblIOComm2.Text = String.Format("{0:0.00}", .IOComm2)
                        tdIOCommDollors.InnerHtml &= "<br/><nobr><small><strong>" & lblJRCIOOffC2.Text & ":" & lblIOComm2.Text & "</strong></small></nobr>"
                    End If
                    If (.IOAdmin2 > 0) Then lblIOAdmin2.Text = String.Format("{0:0.00}", .IOAdmin2)
                    If Not Null.IsNull(.IOOffL2) Then lblIOOffL2.Text = .IOOffL2

                    If Not Null.IsNull(.IOOffC4) Then lblIOOffC4.Text = .IOOffC4
                    If Not Null.IsNull(.IOOffN4) Then lblIOOffN4.Text = .IOOffN4
                    If (.IOComm4 > 0) Then
                        lblIOComm4.Text = String.Format("{0:0.00}", .IOComm4)
                        tdIOCommDollors.InnerHtml &= "<br/><nobr><small><strong>" & lblIOOffC4.Text & ":" & lblIOComm4.Text & "</strong></small></nobr>"
                    End If
                    If (.IOAdmin4 > 0) Then lblIOAdmin4.Text = String.Format("{0:0.00}", .IOAdmin4)
                    If Not Null.IsNull(.IOOffL4) Then lblIOOffL4.Text = .IOOffL4
                End If
                'If (.DRTotDue > 0) Then lblDRTotDue1.Text = .DRTotDue
                'If (.JRCTotal > 0) Then lblJRCTotal1.Text = .JRCTotal

                If (.ExPermits > 0) Then lblExPermits.Text = .ExPermits
                If (.ExTrailer > 0) Then lblExTrailer.Text = .ExTrailer
                If (.ExMisc > 0) Then lblExMisc.Text = .ExMisc




                If (.BCustBill > 0) Then lblCustBill.Text = String.Format("{0:0.00}", .BCustBill)
                If (.RepDlr > 0) Then
                    lblRep.Text = String.Format("{0:0.00}", .RepDlr)
                    tdSalesRepDollors.InnerHtml &= "<br/><nobr><small><strong>" & lblRepNo.Text & "</strong></small></nobr>"
                End If
                If (.IOCommTot > 0) Then lblIOCommTot.Text = String.Format("{0:0.00}", .IOCommTot)
                If (.IOAdminTot > 0) Then lblIOAdminTot.Text = String.Format("{0:0.00}", .IOAdminTot)
                If (.ExTot > 0) Then lblExTot.Text = String.Format("{0:0.00}", .ExTot)

                If (.OCommNeg > 0) Then lblOCommNeg.Text = String.Format("{0:0.00}", .OCommNeg)

                If (.LoadType.ToUpper = "OO") AndAlso (.OCommPlus > 0) Then
                    ltrOCommPlus.Text = "Fuel Tax"
                    lblOCommPlus.Text = String.Format("{0:0.00}", .OCommPlus)
                    ltrAPComm4.Text = .JRCIOfficeCode.Substring(0, 7)
                End If

                If (.APComm3 > 0) Then
                    lblAPComm3.Text = String.Format("{0:0.00}", .APComm3)
                    ltrAPComm3.Text = .IOOffC3
                End If

                If (.JRCOffComm > 0) Then
                    lblJRCOffComm.Text = String.Format("{0:0.00}", .JRCOffComm)
                    ltrJRCOffComm.Text = .OfficeOverride '.JRCIOfficeCode
                    'ltrJRCOffComm.Text = "<nbsp>" & .OfficeOverride & ":" & String.Format("{0:0.00}", .JRCOffCommO) & "</nbsp>"
                    'If (.JRCOffCommM > 0) Then
                    '    ltrJRCOffComm.Text &= "<br/><nbsp>" & .ManagerOverrideAccount & ":" & String.Format("{0:0.00}", .JRCOffCommM) & "</nbsp>"
                    'End If
                End If
                'trLineMgr.Visible = (.ManagerOverride <> "")
                'If trLineMgr.Visible Then
                '    lblManagerOverride.Text = .ManagerOverride
                '    lblManagerOverrideAccount.Text = .ManagerOverrideAccount
                '    lblJRCOffCommM.Text = String.Format("{0:0.00}", .JRCOffCommM)
                'End If

                If (.DRTotDue > 0) Then lblDRTotDue.Text = String.Format("{0:0.00}", .DRTotDue)
                If (.JRCOnePct > 0) Then lblJRCOnePct.Text = String.Format("{0:0.00}", .JRCOnePct)
                If (.JRCTotal > 0) Then lblJRCTotal.Text = String.Format("{0:0.00}", .JRCTotal)

                If .AdjustJrcTotal Then
                    lblAdjustJrcTotal.Text = "The Office Commision has been adjusted as per the 4.85% rule"
                Else
                    lblAdjustJrcTotal.Text = ""
                End If
                Dim OverriddenMsg As String = ""
                If .OverriddenBy <> "" Then
                    OverriddenMsg &= " By <u>" & .OverriddenBy & "</u>"
                End If
                If .OverrideCode > 0 Then
                    OverriddenMsg &= " Code: <u>" & .OverrideCode.ToString & "</u>"
                End If
                If OverriddenMsg <> "" Then
                    'lblRepOverriden.Text = "The SalesRep Commision was Overridden By <b>" & .OverriddenBy & "</b>. Code: " & .OverrideCode.ToString
                    lblRepOverriden.Text = "The SalesRep Commision was Overridden" & OverriddenMsg
                Else
                    lblRepOverriden.Text = ""
                End If
            End With 'objLoadAcctInfo
        End Sub

        'Private Sub ItemToPage(ByVal objSalesPersonInfo As SalesPersonInfo)

        '    lblDriverAcct.Text = objSalesPersonInfo.AccountNo

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

                Dim objLoadSheetInfo As Business.LoadSheetInfo = (New Business.LoadSheetsController).GetLoadSheet(itemId)
                'Dim ReportLink As String = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & Request.QueryString("ItemId"), "LoadType=" & Request.QueryString("LoadType").ToUpper)
                Dim ReportLink As String = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper)
                If ReportLink.StartsWith("/") Then ReportLink = ApplicationPath & ReportLink

                Dim Disclaimer As String = "The information contained in this electronic message is private and confidential information of J.R.C. Transportation, Inc. and is intended only for the use of the individual and/or entity named above.  If the reader of this message is not the intended recipient, or the employee or agent responsible to deliver it to the intended recipient, you are hereby notified that reading, distributing, copying or making any other use of this communication is STRICTLY PROHIBITED.  In no event shall receipt of this message by an unintended party be construed as a waiver by J.R.C. Transportation, Inc. of any privilege or other privacy rights. If you have received this communication in error, please notify us at the above email address."

                'Dim Subject As String = "Load Report for the Load " & objLoadSheetInfo.LoadID & ", dated " & objLoadSheetInfo.LoadDate.ToShortDateString & " from " & objLoadSheetInfo.JRCIOfficeCode
                Dim Subject As String = "Load " & objLoadSheetInfo.LoadID & ", " & objLoadSheetInfo.LoadDate.ToShortDateString & " from " & objLoadSheetInfo.JRCIOfficeName.Replace("JRC - ", "") 'objLoadSheetInfo.JRCIOfficeCode
                If objLoadSheetInfo.PUCityST <> "" Then Subject &= ", 1st PU: " & objLoadSheetInfo.PUCityST

                Dim strLastDrop As String = ""
                If objLoadSheetInfo.DPCityST <> "" Then strLastDrop = ", Last Drop: " & objLoadSheetInfo.DPCityST


                Dim Body As String = "Please see " & Subject & strLastDrop & "<br/><br/>" & ReportLink & "<br/><br/><hr/>" & Disclaimer

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


#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                objOI = New OptionsInfo(ModuleId)

                ' Determine ItemId of Announcement to Display
                If Not (Request.QueryString("ItemId") Is Nothing) Then
                    itemId = Int32.Parse(Request.QueryString("ItemId"))
                Else
                    itemId = Convert.ToInt32(DotNetNuke.Common.Utilities.Null.NullInteger)
                End If

                InitEveryTime()

                If Not Page.IsPostBack Then
                    'Initilise the Controls and set its properties as well as Visiblity
                    InitFirstTime()

                    If Not Null.IsNull(itemId) Then
                        Dim objLoadSheetsController As New Business.LoadSheetsController
                        Dim objLoadSheetInfo As Business.LoadSheetInfo = objLoadSheetsController.GetLoadSheet(itemId)

                        If Not objLoadSheetInfo Is Nothing Then
                            ItemToPage(objLoadSheetInfo)

                            tdIOeMail.Visible = objLoadSheetInfo.LoadType.ToUpper = "IO"
                            If tdIOeMail.Visible Then
                                Try
                                    Dim Dispatcher As Users.UserInfo = Users.UserController.GetUserByName(PortalId, objLoadSheetInfo.CanRecover)
                                    If Not Dispatcher Is Nothing Then txteMailTo.Text = Dispatcher.Email
                                Catch
                                End Try
                            End If
                            If Not (divButtons.Visible And ((objLoadSheetInfo.IsPrinted.ToUpper = "Y") OrElse (objLoadSheetInfo.IsPrinted.ToUpper = "PRINTED"))) Then
                                objLoadSheetInfo.IsPrinted = "Y"
                                objLoadSheetsController.UpdateLoadSheet(objLoadSheetInfo)
                            End If
                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If
                    End If
                End If

            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub odsLoadPUs_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsLoadPUs.Selecting
            e.InputParameters("LoadID") = loadId.ToString
        End Sub

        Private Sub odsLoadDrops_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsLoadDrops.Selecting
            e.InputParameters("LoadID") = loadId.ToString
        End Sub

        Private Sub gdvLoadPUs_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvLoadPUs.RowDataBound
            Try
                If e.Row.RowType = DataControlRowType.DataRow Then
                    Dim ltrAditional1 As Literal = CType(e.Row.FindControl("ltrAditional1"), Literal)

                    Dim _PUCity As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUCity"), Null.NullString))
                    If _PUCity <> "" Then
                        ltrAditional1.Text = "<span class='SubHead'>Pickup: </span><span class='Normal'>" & _PUCity & "</span>"

                        Dim _PUState As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUState"), Null.NullString))
                        If _PUState <> "" Then
                            ltrAditional1.Text &= "<span class='Normal'> / " & _PUState.ToUpper() & "</span>"
                        End If

                        Dim _ZipCode As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ZipCode"), Null.NullString))
                        If _ZipCode <> "" Then
                            ltrAditional1.Text &= "<span class='Normal'> - " & _ZipCode & "</span>"
                        End If
                    End If

                    Dim _PUName As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUName"), Null.NullString))
                    If _PUName <> "" Then
                        ltrAditional1.Text &= "<br/><span class='NormalBold'>Name: </span><span class='Normal'>" & _PUName & "</span>"
                    End If
                    Dim _PUContact As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUContact"), Null.NullString))
                    If _PUContact <> "" Then
                        ltrAditional1.Text &= "<br/><span class='NormalBold'>Contact: </span><span class='Normal'>" & _PUContact & "</span>"
                    End If
                    Dim _PUTel As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUTel"), Null.NullString))
                    If _PUTel <> "" Then
                        ltrAditional1.Text &= "<br/><span class='NormalBold'>Phone: </span><span class='Normal'>" & Phone.FormatPhoneNo(_PUTel) & "</span>"
                    End If
                    Dim _PUAdd1 As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUAdd1"), Null.NullString))
                    If _PUAdd1 <> "" Then
                        ltrAditional1.Text &= "<br/><span class='NormalBold'>Addr: </span><span class='Normal'>" & _PUAdd1 & "</span>"
                    End If

                    Dim ltrAditional2 As Literal = CType(e.Row.FindControl("ltrAditional2"), Literal)

                    Dim _PUDate As DateTime = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUDate"), Null.NullDate))
                    If Not Null.IsNull(_PUDate) Then
                        'Dim lblPUDate As Label = CType(e.Row.FindControl("lblPUDate"), Label)
                        'lblPUDate.Text = _PUDate.ToShortDateString
                        'Dim PUDate As Date = _PUDate
                        If _PUDate.ToShortDateString <> "11/11/2222" Then 'If PUDate > #1/1/1950# Then
                            'Dim lblPUDate As Label = CType(e.Row.FindControl("lblPUDate"), Label)
                            'lblPUDate.Text = _PUDate.ToShortDateString
                            ltrAditional2.Text = "<span class='SubHead'>Date: </span><span class='Normal'>" & _PUDate.ToShortDateString & "</span>"

                            'time
                            Dim _PUTime As DateTime = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUTime"), Null.NullDate))
                            If Not Null.IsNull(_PUTime) Then
                                'Dim lblPUTime As Label = CType(e.Row.FindControl("lblPUTime"), Label)
                                'lblPUTime.Text = _PUTime.ToShortDateString
                                'Dim PUTime As Date = _PUTime
                                If _PUTime.ToShortTimeString <> "12:00 AM" Then 'If PUTime > #1/1/1950# Then
                                    'Dim lblPUTime As Label = CType(e.Row.FindControl("lblPUTime"), Label)
                                    'lblPUTime.Text = _PUTime.ToShortTimeString
                                    ltrAditional2.Text &= "<br/><span class='NormalBold'>Time: </span><span class='Normal'>" & _PUTime.ToShortTimeString & "</span>"
                                End If
                            End If

                        End If
                    End If

                    Dim _PRONo As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PRONo"), Null.NullString))
                    If _PRONo <> "" Then
                        ltrAditional2.Text &= "<br/><span class='NormalBold'>PRONo: </span><span class='Normal'>" & _PRONo & "</span>"
                    End If
                    Dim _Pieces As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "Pieces"), Null.NullString))
                    If _Pieces <> "" Then
                        ltrAditional2.Text &= "<br/><span class='NormalBold'>Pieces: </span><span class='Normal'>" & _Pieces & "</span>"
                    End If
                    Dim _Weight As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "Weight"), Null.NullString))
                    If _Weight <> "" Then
                        ltrAditional2.Text &= "<br/><span class='NormalBold'>Weight: </span><span class='Normal'>" & _Weight & "</span>"
                    End If
                    Dim _Miles As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "Miles"), Null.NullString))
                    If (_Miles <> "") AndAlso (_Miles <> "0") Then
                        ltrAditional2.Text &= "<br/><span class='NormalBold'>Miles: </span><span class='Normal'>" & _Miles & "</span>"
                    End If

                End If
            Catch exc As Exception    'Module failed to RowDataBound
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub gdvLoadDrops_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvLoadDrops.RowDataBound
            Try
                If e.Row.RowType = DataControlRowType.DataRow Then
                    Dim ltrAditional1 As Literal = CType(e.Row.FindControl("ltrAditional1"), Literal)

                    Dim _DPCity As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPCity"), Null.NullString))
                    If _DPCity <> "" Then
                        ltrAditional1.Text = "<span class='SubHead'>Drop: </span><span class='Normal'>" & _DPCity & "</span>"

                        Dim _DPState As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPState"), Null.NullString))
                        If _DPState <> "" Then
                            ltrAditional1.Text &= "<span class='Normal'> / " & _DPState.ToUpper() & "</span>"
                        End If

                        Dim _ZipCode As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ZipCode"), Null.NullString))
                        If _ZipCode <> "" Then
                            ltrAditional1.Text &= "<span class='Normal'> - " & _ZipCode & "</span>"
                        End If
                    End If

                    Dim _DPName As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPName"), Null.NullString))
                    If _DPName <> "" Then
                        ltrAditional1.Text &= "<br/><span class='NormalBold'>Name: </span><span class='Normal'>" & _DPName & "</span>"
                    End If
                    Dim _DPContact As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPContact"), Null.NullString))
                    If _DPContact <> "" Then
                        ltrAditional1.Text &= "<br/><span class='NormalBold'>Contact: </span><span class='Normal'>" & _DPContact & "</span>"
                    End If
                    Dim _DPPhone As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPPhone"), Null.NullString))
                    If _DPPhone <> "" Then
                        ltrAditional1.Text &= "<br/><span class='NormalBold'>Phone: </span><span class='Normal'>" & Phone.FormatPhoneNo(_DPPhone) & "</span>"
                    End If
                    Dim _DPAddr As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPAddr"), Null.NullString))
                    If _DPAddr <> "" Then
                        ltrAditional1.Text &= "<br/><span class='NormalBold'>Addr: </span><span class='Normal'>" & _DPAddr & "</span>"
                    End If

                    Dim ltrAditional2 As Literal = CType(e.Row.FindControl("ltrAditional2"), Literal)
                    Dim _DPDate As DateTime = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPDate"), Null.NullDate))
                    If Not Null.IsNull(_DPDate) Then
                        'Dim lblDPDate As Label = CType(e.Row.FindControl("lblDPDate"), Label)
                        'lblDPDate.Text = _DPDate.ToShortDateString
                        'Dim DPDate As Date = _DPDate
                        If _DPDate.ToShortDateString <> "11/11/2222" Then 'If DPDate > #1/1/1950# Then
                            'Dim lblDPDate As Label = CType(e.Row.FindControl("lblDPDate"), Label)
                            'lblDPDate.Text = _DPDate.ToShortDateString
                            ltrAditional2.Text = "<span class='SubHead'>Date: </span><span class='Normal'>" & _DPDate.ToShortDateString & "</span>"

                            'Stime
                            Dim _Stime As DateTime = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "Stime"), Null.NullDate))

                            If Not Null.IsNull(_Stime) Then
                                'Dim lblStime As Label = CType(e.Row.FindControl("lblStime"), Label)
                                'lblStime.Text = _Stime.ToShortDateString
                                'Dim Stime As Date = _Stime
                                If _Stime.ToShortTimeString <> "12:00 AM" Then 'If Stime > #1/1/1950# Then
                                    'Dim lblStime As Label = CType(e.Row.FindControl("lblStime"), Label)
                                    'lblStime.Text = _Stime.ToShortTimeString
                                    ltrAditional2.Text &= "<br/><span class='NormalBold'>Stime: </span><span class='Normal'>" & _Stime.ToShortTimeString & "</span>"
                                End If
                            End If

                            'Etime
                            Dim _Etime As DateTime = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "Etime"), Null.NullDate))

                            If Not Null.IsNull(_Etime) Then
                                'Dim lblEtime As Label = CType(e.Row.FindControl("lblEtime"), Label)
                                'lblEtime.Text = _Etime.ToShortDateString
                                'Dim Etime As Date = _Etime
                                If _Etime.ToShortTimeString <> "12:00 AM" Then 'If Etime > #1/1/1950# Then
                                    'Dim lblEtime As Label = CType(e.Row.FindControl("lblEtime"), Label)
                                    'lblEtime.Text = _Etime.ToShortTimeString
                                    ltrAditional2.Text &= "<br/><span class='NormalBold'>Etime: </span><span class='Normal'>" & _Etime.ToShortTimeString & "</span>"
                                End If
                            End If

                        End If
                    End If

                    Dim _Jobno As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "Jobno"), Null.NullString))
                    If _Jobno <> "" Then
                        ltrAditional2.Text &= "<br/><span class='NormalBold'>Job No: </span><span class='Normal'>" & _Jobno & "</span>"
                    End If
                    Dim _BillOLay As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "BillOLay"), Null.NullString))
                    If _BillOLay <> "" Then
                        ltrAditional2.Text &= "<br/><span class='NormalBold'>Message: </span><span class='Normal'>" & _BillOLay & "</span>"
                    End If
                    Dim _BOLSeq As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "BOLSeq"), Null.NullString))
                    If _BOLSeq <> "" Then
                        ltrAditional2.Text &= "<br/><span class='NormalBold'>Notes: </span><span class='Normal'>" & _BOLSeq & "</span>"
                    End If

                End If
            Catch exc As Exception    'Module failed to RowDataBound
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub imbeMailTo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbeMailTo.Click
            If txteMailTo.Text <> "" Then
                SendNotification(txteMailTo.Text) 'Dispatcher.DisplayName)
            End If
        End Sub

#End Region

    End Class 'rptLoadSheetInit

End Namespace 'bhattji.Modules.LoadSheets